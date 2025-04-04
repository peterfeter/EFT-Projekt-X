using eft_dma_radar.Tarkov.EFTPlayer;
using eft_dma_radar.Tarkov.EFTPlayer.Plugins;
using eft_dma_radar.Tarkov.GameWorld;
using eft_dma_radar.UI.Misc;
using eft_dma_radar.UI.Radar;
using eft_dma_shared.Common.DMA;
using eft_dma_shared.Common.ESP;
using eft_dma_shared.Common.Features;
using eft_dma_shared.Common.Misc;
using eft_dma_shared.Common.Players;
using eft_dma_shared.Common.Ballistics;
using eft_dma_shared.Common.Unity;
using eft_dma_shared.Common.Unity.Collections;
using eft_dma_shared.Common.Misc.Pools;
using static eft_dma_shared.Common.Unity.UnityTransform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace eft_dma_radar.Tarkov.Features.MemoryWrites
{
    public sealed class Aimbot : MemWriteFeature<Aimbot>
    {
        #region Fields / Properties / Startup
        private const float BaseFOV = 30f;
        private const float MaxFOV = 55f;
        private const float SpeedThreshold = 1.5f; // Lowered threshold for better responsiveness
        private const float MaxSpeed = 3.7f; // Increased max speed for wider FOV range
        private const float FOVSmoothing = 1.0f; // Smoothing factor for FOV transitions

        private float _currentDynamicFOV = BaseFOV; // Current smoothed FOV value

        /// <summary>
        /// Aimbot Configuration.
        /// </summary>
        public static AimbotConfig Config { get; } = Program.Config.MemWrites.Aimbot;

        /// <summary>
        /// Aimbot Supported Bones.
        /// </summary>
        public static readonly IReadOnlySet<Bones> BoneNames = new HashSet<Bones>
        {
            Bones.HumanHead,
            Bones.HumanNeck,
            Bones.HumanSpine3,
            Bones.HumanPelvis,
            Bones.Legs
        };

        private bool _firstLock;
        private sbyte _lastShotIndex = -1;
        private Bones _lastRandomBone = Config.Bone;

        /// <summary>
        /// Aimbot Info.
        /// </summary>
        public AimbotCache Cache { get; private set; }

        public Aimbot()
        {
            new Thread(AimbotWorker)
            {
                IsBackground = true,
                Priority = ThreadPriority.Highest
            }.Start();
        }

        public override bool Enabled
        {
            get => Config.Enabled;
            set => Config.Enabled = value;
        }

        /// <summary>
        /// Managed Thread that does realtime Aimbot updates.
        /// </summary>
        private void AimbotWorker()
        {
            LoneLogging.WriteLine("Aimbot thread starting...");
            while (true)
            {
                try
                {
                    if (MemDMABase.WaitForRaid() && Enabled && MemWrites.Enabled && Memory.Game is LocalGameWorld game && game.RaidHasStarted)
                    {
                        while (Enabled && MemWrites.Enabled && game.InRaid)
                        {
                            SetAimbot(game);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoneLogging.WriteLine($"CRITICAL ERROR on Aimbot Thread: {ex}");
                }
                finally
                {
                    try { ResetAimbot(); } catch { }
                    Thread.Sleep(200);
                }
            }
        }
        #endregion

        #region Aimbot Execution
        /// <summary>
        /// Executes Aimbot features on the AimbotDMAWorker Thread.
        /// </summary>
        private void SetAimbot(LocalGameWorld game)
        {
            try
            {
                if (Memory.LocalPlayer is LocalPlayer localPlayer && ILocalPlayer.HandsController is ulong handsController && handsController.IsValidVirtualAddress())
                {
                    /// Check if the cache is still valid
                    /// This checks if the HandsController (FirearmController) address has changed for LocalPlayer
                    /// If it has changed we should re-init the Aimbot Cache
                    if (Cache != handsController) // Reset Aimbot Cache -> First Cycle
                    {
                        LoneLogging.WriteLine("[Aimbot] Reset!");
                        Cache?.ResetLock();
                        Cache = new AimbotCache(handsController);
                        /// First run checks
                        const float targetAccuracy = 0.0003f;
                        float currentAccuracy = Memory.ReadValue<float>(handsController + Offsets.FirearmController.TotalCenterOfImpact);
                        if (currentAccuracy != targetAccuracy &&
                            currentAccuracy > 0f && currentAccuracy < 1f)
                        {
                            Memory.WriteValue(game, handsController + Offsets.FirearmController.TotalCenterOfImpact, targetAccuracy);
                            LoneLogging.WriteLine($"[Aimbot] Set Weapon Accuracy {currentAccuracy} -> {targetAccuracy}");
                        }
                    }

                    /// If for some reason the cache is still null, do not continue
                    if (Cache is null)
                    {
                        Thread.Sleep(1);
                        return;
                    }
                    Cache.FireportTransform ??= GetFireport(handsController);

                    /// If already locked on, check if the target has died or left FOV
                    if (Cache.AimbotLockedPlayer is not null)
                    {
                        // Check if target died
                        ulong corpseAddr = Cache.AimbotLockedPlayer.CorpseAddr;
                        if (corpseAddr.IsValidVirtualAddress())
                        {
                            ulong corpse = Memory.ReadValue<ulong>(corpseAddr, false);
                            if (corpse.IsValidVirtualAddress()) // Dead
                            {
                                Cache.AimbotLockedPlayer.SetDead(corpse);
                                Cache.ResetLock();
                            }
                        }

                        // Check if target left FOV
                        if (Config.SilentAim.SafeLock && IsSafeLockTripped(Cache.AimbotLockedPlayer))
                        {
                            _firstLock = false; // Allow re-lock
                            Cache.ResetLock();
                        }
                    }

                    /// If we do not have a target, acquire one
                    if (Cache.AimbotLockedPlayer is null)
                    {
                        if (_firstLock && Config.DisableReLock) // Disable re-locking if configured
                        {
                            ResetAimbot();
                            return;
                        }

                        Cache.AimbotLockedPlayer = GetBestAimbotTarget(game, localPlayer);
                    }

                    /// If we still do not have a target, Sleep and return
                    if (Cache.AimbotLockedPlayer is null)
                    {
                        Thread.Sleep(1);
                        return;
                    }

                    /// We have a valid target and Aimbot can continue
                    _firstLock = true;
                    BeginSilentAim(localPlayer);
                    Cache.AimbotLockedPlayer.IsAimbotLocked = true; // Locked On
                }
                else
                {
                    _firstLock = false;
                    ResetAimbot();
                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                LoneLogging.WriteLine($"Aimbot [FAIL] {ex}");
            }
        }

        private bool IsSafeLockTripped(Player target)
        {
            foreach (var tr in target.Skeleton.Bones)
            {
                if (tr.Key is Bones.HumanBase)
                    continue;
                if (CameraManagerBase.WorldToScreen(ref tr.Value.Position, out var scrPos, true) &&
                    CameraManagerBase.GetFovMagnitude(scrPos) is float fov && fov < _currentDynamicFOV) // Use current dynamic FOV
                    return false; // At least one bone in FOV - exit early
            }
            return true;
        }

        /// <summary>
        /// Begin Silent Aim Aimbot.
        /// </summary>
        private void BeginSilentAim(LocalPlayer localPlayer)
        {
            try
            {
                var target = Cache.AimbotLockedPlayer;
                var bone = Config.Bone;

                if (MemWriteFeature<RageMode>.Instance.Enabled || Config.HeadshotAI && target.IsAI)
                    bone = Bones.HumanHead;
                else if (Config.RandomBone.Enabled) // Random Bone
                {
                    var shotIndex = Memory.ReadValue<sbyte>(Cache + Offsets.ClientFirearmController.ShotIndex, false);
                    if (shotIndex != _lastShotIndex)
                    {
                        _lastRandomBone = Config.RandomBone.GetRandomBone();
                        _lastShotIndex = shotIndex;
                        LoneLogging.WriteLine($"New Random Bone {_lastRandomBone.GetDescription()} ({shotIndex})");
                    }
                    bone = _lastRandomBone;
                }
                else if (Config.SilentAim.AutoBone)
                {
                    var boneTargets = new List<PossibleAimbotTarget>();
                    foreach (var tr in target.Skeleton.Bones)
                    {
                        if (tr.Key is Bones.HumanBase)
                            continue;
                        if (CameraManagerBase.WorldToScreen(ref tr.Value.Position, out var scrPos, true))
                        {
                            boneTargets.Add(
                            new PossibleAimbotTarget()
                            {
                                Player = target,
                                FOV = CameraManagerBase.GetFovMagnitude(scrPos),
                                Bone = tr.Key
                            });
                        }
                    }
                    if (boneTargets.Count > 0)
                        bone = boneTargets.MinBy(x => x.FOV).Bone;
                }
                if (bone == Bones.Legs) // Pick a leg
                {
                    bool isLeft = Random.Shared.Next(0, 2) == 1;
                    if (isLeft)
                        bone = Bones.HumanLThigh2;
                    else
                        bone = Bones.HumanRThigh2;
                }

                /// Target Bone Position
                Vector3 bonePosition = target.Skeleton.Bones[bone].UpdatePosition();

                /// Get Fireport Position & Run Prediction
                Vector3 fireportPosition;
                Quaternion fireportRotation;
                try
                {
                    SharedArray<TrsX> fireportVertices = Cache.FireportTransform.ReadVertices();
                    fireportPosition = Cache.FireportTransform.UpdatePosition(fireportVertices);
                    fireportRotation = Cache.FireportTransform.GetRotation(fireportVertices);
                }
                catch
                {
                    Cache.FireportTransform = null;
                    throw;
                }
                Vector3 newWeaponDirection = CalculateSilentAimTrajectory(target, ref fireportPosition, ref bonePosition);
                newWeaponDirection.ThrowIfAbnormal();

                Memory.WriteValue(localPlayer.PWA + Offsets.ProceduralWeaponAnimation.ShotNeedsFovAdjustments, false);
                Memory.WriteValue(localPlayer.PWA + Offsets.ProceduralWeaponAnimation._shotDirection, fireportRotation.InverseTransformDirection(newWeaponDirection));

                Cache.LastFireportPos = fireportPosition;
                Cache.LastPlayerPos = bonePosition;
            }
            catch (Exception ex)
            {
                LoneLogging.WriteLine($"Silent Aim [FAIL] {ex}");
                ResetSilentAim();
            }
        }

        private Player GetBestAimbotTarget(LocalGameWorld game, Player localPlayer)
        {
            var players = game.Players?
                .Where(x => x.IsHostileActive && x is not BtrOperator);

            if (players is null || !players.Any())
                return null;

            var targets = new List<PossibleAimbotTarget>();
            foreach (var player in players)
            {
                // Get target velocity
                Vector3 targetVelocity;
                if (player is ObservedPlayer)
                    targetVelocity = Memory.ReadValue<Vector3>(player.MovementContext + Offsets.ObservedMovementController.Velocity, false);
                else
                    targetVelocity = default;

                // Calculate speed magnitude
                float speed = targetVelocity.Length(); // Oder targetVelocity.Magnitude, wenn Length nicht verfügbar ist

                // Calculate dynamic FOV based on speed with smoothing
                float targetFOV = BaseFOV;
                if (speed > SpeedThreshold)
                {
                    float speedFactor = Math.Min((speed - SpeedThreshold) / (MaxSpeed - SpeedThreshold), 1f);
                    targetFOV = BaseFOV + (MaxFOV - BaseFOV) * speedFactor;
                }
                _currentDynamicFOV = Lerp(_currentDynamicFOV, targetFOV, FOVSmoothing);

                var distance = Vector3.Distance(localPlayer.Position, player.Position);
                if (distance > MainForm.Config.MaxDistance)
                    continue;

                foreach (var bonePair in player.Skeleton.Bones)
                {
                    if (bonePair.Key is Bones.HumanBase)
                        continue;

                    if (CameraManagerBase.WorldToScreen(ref bonePair.Value.Position, out var scrPos, true) &&
                        CameraManagerBase.GetFovMagnitude(scrPos) is float fov && fov < _currentDynamicFOV)
                    {
                        targets.Add(new PossibleAimbotTarget
                        {
                            Player = player,
                            FOV = fov,
                            Bone = bonePair.Key,
                            Distance = distance,
                            DynamicFOV = _currentDynamicFOV
                        });
                        LoneLogging.WriteLine($"[Dynamic FOV] Target: {player.Name}, Speed: {speed:F2}, FOV: {_currentDynamicFOV:F2}, Bone: {bonePair.Key}");
                    }
                }
            }

            if (targets.Count == 0)
                return null;

            return Config.TargetingMode switch
            {
                AimbotTargetingMode.FOV => targets.OrderBy(x => x.FOV).FirstOrDefault().Player,
                AimbotTargetingMode.CQB => targets.OrderBy(x => x.Distance).FirstOrDefault().Player,
                _ => throw new NotImplementedException(nameof(Config.TargetingMode))
            };
        }

        private static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * Math.Clamp(t, 0, 1);
        }

        /// <summary>
        /// Get LocalPlayer Fireport Transform.
        /// </summary>
        private static UnityTransform GetFireport(ulong handsController)
        {
            handsController.ThrowIfInvalidVirtualAddress();
            var ti = Memory.ReadPtrChain(handsController, Offsets.FirearmController.To_FirePortTransformInternal, false);
            return new UnityTransform(ti);
        }

        /// <summary>
        /// Recurses a given weapon for the total velocity on attachments.
        /// Used by Aimbot.
        /// </summary>
        private static void RecurseWeaponAttachVelocity(ulong lootItemBase, ref float velocityModifier)
        {
            try
            {
                var parentSlots = Memory.ReadPtr(lootItemBase + Offsets.LootItemMod.Slots);
                using var slots = MemArray<ulong>.Get(parentSlots);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(slots.Count, 100, nameof(slots));

                foreach (var slot in slots)
                {
                    try
                    {
                        var containedItem = Memory.ReadPtr(slot + Offsets.Slot.ContainedItem);
                        var itemTemplate = Memory.ReadPtr(containedItem + Offsets.LootItem.Template);
                        // Add this attachment's Velocity %
                        velocityModifier += Memory.ReadValue<float>(itemTemplate + Offsets.ModTemplate.Velocity);
                        RecurseWeaponAttachVelocity(containedItem, ref velocityModifier);
                    }
                    catch
                    {
                    } // Skip over empty slots
                }
            }
            catch (Exception ex)
            {
                LoneLogging.WriteLine($"AIMBOT ERROR RecurseWeaponAttachVelocity() -> {ex}");
            }
        }

        /// <summary>
        /// Runs Aimbot Prediction between a source -> target.
        /// </summary>
        private Vector3 CalculateSilentAimTrajectory(Player target, ref Vector3 sourcePosition, ref Vector3 targetPosition)
        {
            /// Get Current Ammo Details
            try
            {
                int weaponVersion = Memory.ReadValue<int>(Cache.ItemBase + Offsets.LootItem.Version);
                if (Cache.LastWeaponVersion != weaponVersion) // New round in chamber
                {
                    var ammoTemplate = FirearmManager.MagazineManager.GetAmmoTemplateFromWeapon(Cache.ItemBase);
                    if (Cache.LoadedAmmo != ammoTemplate)
                    {
                        LoneLogging.WriteLine("[Aimbot] Ammo changed!");
                        Cache.Ballistics.BulletMassGrams = Memory.ReadValue<float>(ammoTemplate + Offsets.AmmoTemplate.BulletMassGram);
                        Cache.Ballistics.BulletDiameterMillimeters =
                            Memory.ReadValue<float>(ammoTemplate + Offsets.AmmoTemplate.BulletDiameterMilimeters);
                        Cache.Ballistics.BallisticCoefficient =
                            Memory.ReadValue<float>(ammoTemplate + Offsets.AmmoTemplate.BallisticCoeficient);

                        /// Calculate Muzzle Velocity
                        float bulletSpeed = Memory.ReadValue<float>(ammoTemplate + Offsets.AmmoTemplate.InitialSpeed);
                        float velMod = 0f;
                        velMod += Memory.ReadValue<float>(Cache.ItemTemplate + Offsets.WeaponTemplate.Velocity);
                        RecurseWeaponAttachVelocity(Cache.ItemBase, ref velMod);
                        velMod = 1f + (velMod / 100f);
                        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(velMod, 0d, nameof(velMod));
                        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(velMod, 2d, nameof(velMod));
                        bulletSpeed *= velMod;
                        Cache.Ballistics.BulletSpeed = bulletSpeed;
                        Cache.LoadedAmmo = ammoTemplate;
                    }
                    Cache.LastWeaponVersion = weaponVersion;
                }
            }
            catch (Exception ex)
            {
                LoneLogging.WriteLine($"Aimbot [WARNING] - Unable to set/update Ballistics: {ex}");
            }

            /// Target Velocity
            Vector3 targetVelocity;
            if (target is ObservedPlayer)
                targetVelocity = Memory.ReadValue<Vector3>(target.MovementContext + Offsets.ObservedMovementController.Velocity, false);
            else
                targetVelocity = default;

            /// Run Prediction Simulation
            if (Cache.IsAmmoValid)
            {
                var sim = BallisticsSimulation.Run(ref sourcePosition, ref targetPosition, Cache.Ballistics);
                if (Math.Abs(targetVelocity.X) > 25f || Math.Abs(targetVelocity.Y) > 25f || Math.Abs(targetVelocity.Z) > 25f)
                {
                    LoneLogging.WriteLine("[AIMBOT] -> RunPrediction(): Invalid Target Velocity - Running without prediction.");
                }
                else
                {
                    targetVelocity *= sim.TravelTime;

                    targetPosition.X += targetVelocity.X;
                    targetPosition.Y += targetVelocity.Y + sim.DropCompensation;
                    targetPosition.Z += targetVelocity.Z;
                }
            }
            else
            {
                Cache.LoadedAmmo = default;
                Cache.LastWeaponVersion = default;
                LoneLogging.WriteLine("Aimbot [WARNING] - Invalid Ammo Ballistics! Running without prediction.");
            }

            return Vector3.Normalize(targetPosition - sourcePosition);
        }

        /// <summary>
        /// Reset the Aimbot Lock and reset the aimbot back to default state.
        /// </summary>
        private void ResetAimbot()
        {
            Cache?.ResetLock();
            Cache = null;
            _lastShotIndex = -1;
            _currentDynamicFOV = BaseFOV; // Reset to base FOV
            ResetSilentAim();
        }

        #endregion

        #region Silent Aim Internal

        /// <summary>
        /// Reset the Shot Direction (Silent Aim) back to default state.
        /// </summary>
        private static void ResetSilentAim()
        {
            if (Memory.LocalPlayer is LocalPlayer localPlayer && ILocalPlayer.HandsController is ulong handsController && handsController.IsValidVirtualAddress())
            {
                Memory.WriteValue(localPlayer.PWA + Offsets.ProceduralWeaponAnimation._shotDirection, new Vector3() { X = 0f, Y = -1f, Z = 0f });
                LoneLogging.WriteLine("Silent Aim [SHOT DIRECTION RESET]");
            }
        }

        #endregion

        #region Types
        public enum AimbotTargetingMode : int
        {
            /// <summary>
            /// FOV based targeting.
            /// </summary>
            [Description(nameof(FOV))]
            FOV = 1,
            /// <summary>
            /// CQB (Distance) based targeting.
            /// </summary>
            [Description(nameof(CQB))]
            CQB = 2
        }

        /// <summary>
        /// Encapsulates Aimbot Targeting Results.
        /// </summary>
        public struct PossibleAimbotTarget
        {
            public Player Player { get; set; }
            public float FOV { get; set; }
            public Bones Bone { get; set; }
            public float Distance { get; set; }
            public float DynamicFOV { get; set; }
        }

        public sealed class AimbotCache
        {
            public static implicit operator ulong(AimbotCache x) => x?.HandsBase ?? 0x0;

            public bool IsAmmoValid => Ballistics.IsAmmoValid;

            private ulong HandsBase { get; }
            public ulong ItemBase { get; }
            public ulong ItemTemplate { get; }
            public Player AimbotLockedPlayer { get; set; }
            public ulong LoadedAmmo { get; set; }
            public BallisticsInfo Ballistics { get; } = new();
            public UnityTransform FireportTransform { get; set; }
            public Vector3? LastFireportPos { get; set; }
            public Vector3? LastPlayerPos { get; set; }
            public int LastWeaponVersion { get; set; } = -1;

            public AimbotCache(ulong handsBase)
            {
                HandsBase = handsBase;
                ItemBase = Memory.ReadPtr(HandsBase + Offsets.ItemHandsController.Item, false);
                ItemTemplate = Memory.ReadPtr(ItemBase + Offsets.LootItem.Template, false);
            }

            public void ResetLock()
            {
                LastFireportPos = null;
                LastPlayerPos = null;
                if (AimbotLockedPlayer is not null)
                {
                    AimbotLockedPlayer.IsAimbotLocked = false;
                    AimbotLockedPlayer = null;
                }
            }
        }
        #endregion
    }
}
