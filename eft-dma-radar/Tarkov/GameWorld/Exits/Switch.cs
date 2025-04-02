using eft_dma_radar.Tarkov.EFTPlayer;
using eft_dma_radar.UI.ESP;
using eft_dma_radar.UI.Misc;
using eft_dma_radar.UI.Radar;
using eft_dma_shared.Common.ESP;
using eft_dma_shared.Common.Maps;
using eft_dma_shared.Common.Misc;
using eft_dma_shared.Common.Misc.Data;
using eft_dma_shared.Common.Players;
using eft_dma_shared.Common.Unity;
using SkiaSharp;

namespace eft_dma_radar.Tarkov.GameWorld.Exits
{
    public sealed class Switch
    {
        public Vector3 Position { get; }
        public string Name { get; }

        public Switch(Vector3 position, string name)
        {
            Position = position;
            Name = name;
        }

        public void Draw(SKCanvas canvas, LoneMapParams mapParams, ILocalPlayer localPlayer)
        {
            var heightDiff = localPlayer.Position.Y - Position.Y;
            var paint = GetPaint();
            var point = Position.ToMapPos(mapParams.Map).ToZoomedPos(mapParams);
            var mouseoverPosition = new Vector2(point.X, point.Y);
            SKPaints.ShapeOutline.StrokeWidth = 2f;

            if (heightDiff > 1.75f) // switch is above player
            {
                using var path = point.GetUpArrow(6.5f);
                canvas.DrawPath(path, SKPaints.ShapeOutline);
                canvas.DrawPath(path, paint);
            }
            else if (heightDiff < -1.75f) // switch is below player
            {
                using var path = point.GetDownArrow(6.5f);
                canvas.DrawPath(path, SKPaints.ShapeOutline);
                canvas.DrawPath(path, paint);
            }
            else // switch is level with player
            {
                float size = 4.75f * MainForm.UIScale;
                canvas.DrawCircle(point, size, SKPaints.ShapeOutline);
                canvas.DrawCircle(point, size, paint);
            }
        }

        public void DrawMouseover(SKCanvas canvas, LoneMapParams mapParams, LocalPlayer localPlayer)
        {
            // Save the current canvas state
            canvas.Save();

            // Get the switch's position on the map
            var switchMapPosition = Position.ToMapPos(mapParams.Map).ToZoomedPos(mapParams);

            // Apply a rotation transformation to the canvas
            canvas.RotateDegrees(180, switchMapPosition.X, switchMapPosition.Y);

            // Draw the mouseover text
            List<string> lines = new();
            var name = Name ?? "unknown";
            lines.Add($"{name}");
            switchMapPosition.DrawMouseoverText(canvas, lines);

            // Restore the canvas state
            canvas.Restore();
        }

        private SKPaint GetPaint()
        {
            // Implement the logic to get the appropriate paint for the switch
            return SKPaints.PaintExfilOpen; // Example paint, replace with actual logic
        }
    }
}
