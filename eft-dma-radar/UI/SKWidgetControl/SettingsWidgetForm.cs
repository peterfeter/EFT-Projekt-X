using DarkModeForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using eft_dma_radar.UI.Radar;
using eft_dma_shared.Common.Misc;
using eft_dma_radar.UI.Misc;
using eft_dma_radar.Tarkov.Features.MemoryWrites;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace LonesEFTRadar.UI.SKWidgetControl
{
    public partial class SettingsWidgetForm : Form
    {
        #region Fields
        private readonly DarkModeCS _darkmode;
        private bool isMinimized = false;
        private Point lastMousePosition;
        private MainForm _mainForm;
        #endregion

        #region Constructor
        public SettingsWidgetForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _mainForm.RefreshQuestHelper();
            SetDarkMode(ref _darkmode);
            UpdateCheckboxStates();
            InitializeHeaderText();
            PopulateQuestHelperList();
            PopulateComboBoxAimbotTarget();
            trackBar_AimFOV_SettingsWidget.ValueChanged += TrackBar_AimFOV_SettingsWidget_ValueChanged;
            comboBox_AimbotTarget_SettingsWidget.SelectedIndexChanged += ComboBox_AimbotTarget_SettingsWidget_SelectedIndexChanged;
            checkBox_AimRandomBone_SettingsWidget.CheckedChanged += checkBox_AimRandomBone_SettingsWidget_CheckedChanged;
            UpdateComboBoxAimbotTarget(_mainForm.comboBox_AimbotTarget.SelectedIndex);
        }
        #endregion

        #region Initialization
        private void InitializeHeaderText()
        {
            Label headerLabel = new Label();
            headerLabel.Text = "EFT DMA RADAR Settings";
            headerLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            headerLabel.ForeColor = Color.Purple;
            headerLabel.AutoSize = true;
            headerLabel.Location = new Point(10, 3);
            headerPanel.Controls.Add(headerLabel);
        }

        private void PopulateQuestHelperList()
        {
            checkedListBox_QuestHelper_SettingsWidget.Items.Clear();
            foreach (var item in _mainForm.checkedListBox_QuestHelper.Items)
            {
                checkedListBox_QuestHelper_SettingsWidget.Items.Add(item, _mainForm.checkedListBox_QuestHelper.GetItemChecked(_mainForm.checkedListBox_QuestHelper.Items.IndexOf(item)));
            }
        }

        #endregion

        #region Event Handlers
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            if (isMinimized)
            {
                this.Size = new System.Drawing.Size(600, 273);
                // this.contentPanel.Visible = true;
                this.minimizeButton.Text = "-";
            }
            else
            {
                this.Size = new System.Drawing.Size(600, 20);
                //this.contentPanel.Visible = false;
                this.minimizeButton.Text = "+";
            }
            isMinimized = !isMinimized;
        }

        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lastMousePosition = e.Location;
            }
        }

        private void headerPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(
                    this.Location.X + e.X - lastMousePosition.X,
                    this.Location.Y + e.Y - lastMousePosition.Y);
            }
        }
        #region Clicks and CheckChanged
        private void button_Restart_SettingsWidget_Click(object sender, EventArgs e)
        {
            MainForm.button_Restart_Click(sender, e);
        }

        private void button_GymHack_SettingsWidget_Click(object sender, EventArgs e)
        {
            _mainForm.button_GymHack_Click(sender, e);
        }

        private void button_AntiAfk_SettingsWidget_Click(object sender, EventArgs e)
        {
            _mainForm.button_AntiAfk_Click(sender, e);
        }

        private void checkBox_MoveSpeed_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_MoveSpeed.Checked = checkBox_MoveSpeed_SettingsWidget.Checked;
        }

        private void checkBox_MoveSpeed2_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_MoveSpeed2.Checked = checkBox_MoveSpeed2_SettingsWidget.Checked;
        }

        private void checkBox_FullBright_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_FullBright.Checked = checkBox_FullBright_SettingsWidget.Checked;
        }

        private void checkBox_InfStamina_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_InfStamina.Checked = checkBox_InfStamina_SettingsWidget.Checked;
        }

        private void checkBox_LTW_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_LTW.Checked = checkBox_LTW_SettingsWidget.Checked;
        }

        private void checkBox_FastLoadUnload_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_FastLoadUnload.Checked = checkBox_FastLoadUnload_SettingsWidget.Checked;
        }

        private void checkBox_Chams_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_Chams.Checked = checkBox_Chams_SettingsWidget.Checked;
        }
        private void checkBox_AimBotEnabled_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_AimBotEnabled.Checked = checkBox_AimBotEnabled_SettingsWidget.Checked;
        }
        private void checkBox_SA_SafeLock_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_SA_SafeLock.Checked = checkBox_SA_SafeLock_SettingsWidget.Checked;
        }
        private void checkBox_SA_AutoBone_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_SA_AutoBone.Checked = checkBox_SA_AutoBone_SettingsWidget.Checked;
        }
        private void radioButton_AimTarget_FOV_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.radioButton_AimTarget_FOV.Checked = radioButton_AimTarget_FOV_SettingsWidget.Checked;
        }
        private void radioButton_AimTarget_CQB_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.radioButton_AimTarget_CQB.Checked = radioButton_AimTarget_CQB_SettingsWidget.Checked;
        }
        private void checkBox_AimbotDisableReLock_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_AimbotDisableReLock.Checked = checkBox_AimbotDisableReLock_SettingsWidget.Checked;
        }
        private void TrackBar_AimFOV_SettingsWidget_ValueChanged(object sender, EventArgs e)
        {
            int value = trackBar_AimFOV_SettingsWidget.Value;
            label_AimFOV_SettingsWidget.Text = $"FOV {value}";
            _mainForm.UpdateTrackBarAimFOV(value);
            _mainForm.UpdateLabelAimFOV(value);
        }
        private void checkBox_AimHeadAI_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_AimHeadAI.Checked = checkBox_AimHeadAI_SettingsWidget.Checked;
        }
        private void checkBox_AimRandomBone_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_AimRandomBone.Checked = checkBox_AimRandomBone_SettingsWidget.Checked;
            comboBox_AimbotTarget_SettingsWidget.Enabled = !checkBox_AimRandomBone_SettingsWidget.Checked;
        }
        private void ComboBox_AimbotTarget_SettingsWidget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AimbotTarget_SettingsWidget.SelectedItem is BonesListItem entry)
            {
                Aimbot.Config.Bone = entry.Bone;
            }

            if (_mainForm != null)
            {
                _mainForm.UpdateComboBoxAimbotTarget(comboBox_AimbotTarget_SettingsWidget.SelectedIndex);
            }

        }
        private void checkedListBox_QuestHelper_SettingsWidget_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Update the corresponding item in the main form's checkedListBox_QuestHelper
            _mainForm.QuestHelperListBox.ItemCheck -= _mainForm.CheckedListBox_QuestHelper_ItemCheck;
            _mainForm.QuestHelperListBox.SetItemChecked(e.Index, e.NewValue == CheckState.Checked);
            _mainForm.QuestHelperListBox.ItemCheck += _mainForm.CheckedListBox_QuestHelper_ItemCheck;
        }
        #endregion
        #endregion

        #region Methods
        public void UpdateCheckboxStates()
        {
            checkBox_MoveSpeed_SettingsWidget.Checked = _mainForm.checkBox_MoveSpeed.Checked;
            checkBox_MoveSpeed2_SettingsWidget.Checked = _mainForm.checkBox_MoveSpeed2.Checked;
            checkBox_FullBright_SettingsWidget.Checked = _mainForm.checkBox_FullBright.Checked;
            checkBox_InfStamina_SettingsWidget.Checked = _mainForm.checkBox_InfStamina.Checked;
            checkBox_FastLoadUnload_SettingsWidget.Checked = _mainForm.checkBox_FastLoadUnload.Checked;
            checkBox_LTW_SettingsWidget.Checked = _mainForm.checkBox_LTW.Checked;
            checkBox_AimBotEnabled_SettingsWidget.Checked = _mainForm.checkBox_AimBotEnabled.Checked;
            checkBox_SA_SafeLock_SettingsWidget.Checked = _mainForm.checkBox_SA_SafeLock.Checked;
            checkBox_SA_AutoBone_SettingsWidget.Checked = _mainForm.checkBox_SA_AutoBone.Checked;
            radioButton_AimTarget_FOV_SettingsWidget.Checked = _mainForm.radioButton_AimTarget_FOV.Checked;
            radioButton_AimTarget_CQB_SettingsWidget.Checked = _mainForm.radioButton_AimTarget_CQB.Checked;
            checkBox_AimbotDisableReLock_SettingsWidget.Checked = _mainForm.checkBox_AimbotDisableReLock.Checked;
            checkBox_AimHeadAI_SettingsWidget.Checked = _mainForm.checkBox_AimHeadAI.Checked;
            checkBox_AimRandomBone_SettingsWidget.Checked = _mainForm.checkBox_AimRandomBone.Checked;
        }

        public void UpdateMoveSpeedCheckbox(bool isChecked)
        {
            checkBox_MoveSpeed_SettingsWidget.Checked = isChecked;
        }

        public void UpdateMoveSpeed2Checkbox(bool isChecked)
        {
            checkBox_MoveSpeed2_SettingsWidget.Checked = isChecked;
        }

        public void UpdateFullBrightCheckbox(bool isChecked)
        {
            checkBox_FullBright_SettingsWidget.Checked = isChecked;
        }

        public void UpdateInfStaminaCheckbox(bool isChecked)
        {
            checkBox_InfStamina_SettingsWidget.Checked = isChecked;
        }

        public void UpdateLTWCheckbox(bool isChecked)
        {
            checkBox_LTW_SettingsWidget.Checked = isChecked;
        }

        public void UpdateFastLoadUnloadCheckbox(bool isChecked)
        {
            checkBox_FastLoadUnload_SettingsWidget.Checked = isChecked;
        }

        public void UpdateChamsCheckbox(bool isChecked)
        {
            checkBox_Chams_SettingsWidget.Checked = isChecked;
        }

        public void UpdateAimBotEnabledCheckbox(bool isChecked)
        {
            checkBox_AimBotEnabled_SettingsWidget.Checked = isChecked;
        }
        public void UpdateSA_SafeLockCheckbox(bool isChecked)
        {
            checkBox_SA_SafeLock_SettingsWidget.Checked = isChecked;
        }
        public void UpdateSA_AutoBoneCheckbox(bool isChecked)
        {
            checkBox_SA_AutoBone_SettingsWidget.Checked = isChecked;
        }
        public void UpdateAimTarget_FOVCheckbox(bool isChecked)
        {
            radioButton_AimTarget_FOV_SettingsWidget.Checked = isChecked;
        }
        public void UpdateAimTarget_CQBCheckbox(bool isChecked)
        {
            radioButton_AimTarget_CQB_SettingsWidget.Checked = isChecked;
        }
        public void UpdateAimbotDisableReLockCheckbox(bool isChecked)
        {
            checkBox_AimbotDisableReLock_SettingsWidget.Checked = isChecked;
        }
        public void UpdateAimHeadAICheckbox(bool isChecked)
        {
            checkBox_AimHeadAI_SettingsWidget.Checked = isChecked;
        }
        public void UpdateAimRandomBoneCheckbox(bool isChecked)
        {
            checkBox_AimRandomBone_SettingsWidget.Checked = isChecked;
        }
        public void UpdateQuestHelperList(int index, bool isChecked)
        {
            checkedListBox_QuestHelper_SettingsWidget.ItemCheck -= checkedListBox_QuestHelper_SettingsWidget_ItemCheck;
            checkedListBox_QuestHelper_SettingsWidget.SetItemChecked(index, isChecked);
            checkedListBox_QuestHelper_SettingsWidget.ItemCheck += checkedListBox_QuestHelper_SettingsWidget_ItemCheck;
        }
        public void UpdateTrackBarAimFOV(int value)
        {
            if (trackBar_AimFOV_SettingsWidget.Value != value)
            {
                trackBar_AimFOV_SettingsWidget.Value = value;
            }
        }
        public void UpdateLabelAimFOV(int value)
        {
            label_AimFOV_SettingsWidget.Text = $"FOV {value}";
        }
        public void UpdateComboBoxAimbotTarget(int selectedIndex)
        {
            if (comboBox_AimbotTarget_SettingsWidget.SelectedIndex != selectedIndex)
            {
                comboBox_AimbotTarget_SettingsWidget.SelectedIndex = selectedIndex;
            }
        }
        private void PopulateComboBoxAimbotTarget()
        {
            comboBox_AimbotTarget_SettingsWidget.Items.Clear();
            foreach (var item in _mainForm.comboBox_AimbotTarget.Items)
            {
                comboBox_AimbotTarget_SettingsWidget.Items.Add(item);
            }
        }
        #endregion

        /// <summary>
        /// Set Dark Mode on startup.
        /// </summary>
        /// <param name="darkmode"></param>
        private void SetDarkMode(ref DarkModeCS darkmode)
        {
            darkmode = new DarkModeCS(this);
            if (darkmode.IsDarkMode)
            {
                SharedPaints.PaintBitmap.ColorFilter = SharedPaints.GetDarkModeColorFilter(0.7f);
                SharedPaints.PaintBitmapAlpha.ColorFilter = SharedPaints.GetDarkModeColorFilter(0.7f);
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label_EspLineScale_Click(object sender, EventArgs e)
        {

        }
    }
}
