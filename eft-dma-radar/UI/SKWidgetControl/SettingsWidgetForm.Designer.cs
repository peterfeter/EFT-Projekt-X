using SkiaSharp;
using System.Runtime;
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LonesEFTRadar.UI.SKWidgetControl
{
    partial class SettingsWidgetForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            headerPanel = new Panel();
            minimizeButton = new Button();
            button_Restart_SettingsWidget = new Button();
            checkBox_MoveSpeed2_SettingsWidget = new CheckBox();
            checkBox_MoveSpeed_SettingsWidget = new CheckBox();
            button_GymHack_SettingsWidget = new Button();
            checkBox_FullBright_SettingsWidget = new CheckBox();
            button_AntiAfk_SettingsWidget = new Button();
            checkBox_InfStamina_SettingsWidget = new CheckBox();
            checkBox_LTW_SettingsWidget = new CheckBox();
            checkBox_FastLoadUnload_SettingsWidget = new CheckBox();
            checkBox_Chams_SettingsWidget = new CheckBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            checkedListBox_QuestHelper_SettingsWidget = new CheckedListBox();
            tabPage2 = new TabPage();
            checkBox_AimRandomBone_SettingsWidget = new CheckBox();
            checkBox_AimHeadAI_SettingsWidget = new CheckBox();
            label_AimFOV_SettingsWidget = new Label();
            trackBar_AimFOV_SettingsWidget = new TrackBar();
            checkBox_AimbotDisableReLock_SettingsWidget = new CheckBox();
            radioButton_AimTarget_FOV_SettingsWidget = new RadioButton();
            radioButton_AimTarget_CQB_SettingsWidget = new RadioButton();
            checkBox_SA_AutoBone_SettingsWidget = new CheckBox();
            checkBox_SA_SafeLock_SettingsWidget = new CheckBox();
            checkBox_AimBotEnabled_SettingsWidget = new CheckBox();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            label10 = new Label();
            comboBox_AimbotTarget_SettingsWidget = new ComboBox();
            headerPanel.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((ISupportInitialize)trackBar_AimFOV_SettingsWidget).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(minimizeButton);
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(600, 20);
            headerPanel.TabIndex = 0;
            headerPanel.MouseDown += headerPanel_MouseDown;
            headerPanel.MouseMove += headerPanel_MouseMove;
            // 
            // minimizeButton
            // 
            minimizeButton.Dock = DockStyle.Right;
            minimizeButton.Location = new Point(578, 0);
            minimizeButton.Name = "minimizeButton";
            minimizeButton.Size = new Size(22, 20);
            minimizeButton.TabIndex = 0;
            minimizeButton.Text = "-";
            minimizeButton.Click += minimizeButton_Click;
            // 
            // button_Restart_SettingsWidget
            // 
            button_Restart_SettingsWidget.FlatStyle = FlatStyle.Popup;
            button_Restart_SettingsWidget.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Restart_SettingsWidget.Location = new Point(4, 3);
            button_Restart_SettingsWidget.Name = "button_Restart_SettingsWidget";
            button_Restart_SettingsWidget.Size = new Size(88, 23);
            button_Restart_SettingsWidget.TabIndex = 19;
            button_Restart_SettingsWidget.Text = "Restart Radar";
            button_Restart_SettingsWidget.Click += button_Restart_SettingsWidget_Click;
            // 
            // checkBox_MoveSpeed2_SettingsWidget
            // 
            checkBox_MoveSpeed2_SettingsWidget.AutoSize = true;
            checkBox_MoveSpeed2_SettingsWidget.Location = new Point(4, 57);
            checkBox_MoveSpeed2_SettingsWidget.Name = "checkBox_MoveSpeed2_SettingsWidget";
            checkBox_MoveSpeed2_SettingsWidget.Size = new Size(152, 19);
            checkBox_MoveSpeed2_SettingsWidget.TabIndex = 81;
            checkBox_MoveSpeed2_SettingsWidget.Text = "1.4x Move Speed (Risky)";
            checkBox_MoveSpeed2_SettingsWidget.CheckedChanged += checkBox_MoveSpeed2_SettingsWidget_CheckedChanged;
            // 
            // checkBox_MoveSpeed_SettingsWidget
            // 
            checkBox_MoveSpeed_SettingsWidget.AutoSize = true;
            checkBox_MoveSpeed_SettingsWidget.Location = new Point(4, 32);
            checkBox_MoveSpeed_SettingsWidget.Name = "checkBox_MoveSpeed_SettingsWidget";
            checkBox_MoveSpeed_SettingsWidget.Size = new Size(152, 19);
            checkBox_MoveSpeed_SettingsWidget.TabIndex = 80;
            checkBox_MoveSpeed_SettingsWidget.Text = "1.2x Move Speed (Risky)";
            checkBox_MoveSpeed_SettingsWidget.CheckedChanged += checkBox_MoveSpeed_SettingsWidget_CheckedChanged;
            // 
            // button_GymHack_SettingsWidget
            // 
            button_GymHack_SettingsWidget.FlatStyle = FlatStyle.Popup;
            button_GymHack_SettingsWidget.Location = new Point(98, 3);
            button_GymHack_SettingsWidget.Name = "button_GymHack_SettingsWidget";
            button_GymHack_SettingsWidget.Size = new Size(96, 23);
            button_GymHack_SettingsWidget.TabIndex = 82;
            button_GymHack_SettingsWidget.Text = "Gym Hack";
            button_GymHack_SettingsWidget.Click += button_GymHack_SettingsWidget_Click;
            // 
            // checkBox_FullBright_SettingsWidget
            // 
            checkBox_FullBright_SettingsWidget.AutoSize = true;
            checkBox_FullBright_SettingsWidget.Location = new Point(158, 32);
            checkBox_FullBright_SettingsWidget.Name = "checkBox_FullBright_SettingsWidget";
            checkBox_FullBright_SettingsWidget.Size = new Size(80, 19);
            checkBox_FullBright_SettingsWidget.TabIndex = 83;
            checkBox_FullBright_SettingsWidget.Text = "Full Bright";
            checkBox_FullBright_SettingsWidget.CheckedChanged += checkBox_FullBright_SettingsWidget_CheckedChanged;
            // 
            // button_AntiAfk_SettingsWidget
            // 
            button_AntiAfk_SettingsWidget.FlatStyle = FlatStyle.Popup;
            button_AntiAfk_SettingsWidget.Location = new Point(200, 3);
            button_AntiAfk_SettingsWidget.Name = "button_AntiAfk_SettingsWidget";
            button_AntiAfk_SettingsWidget.Size = new Size(96, 23);
            button_AntiAfk_SettingsWidget.TabIndex = 84;
            button_AntiAfk_SettingsWidget.Text = "Anti-AFK";
            button_AntiAfk_SettingsWidget.Click += button_AntiAfk_SettingsWidget_Click;
            // 
            // checkBox_InfStamina_SettingsWidget
            // 
            checkBox_InfStamina_SettingsWidget.AutoSize = true;
            checkBox_InfStamina_SettingsWidget.Location = new Point(244, 32);
            checkBox_InfStamina_SettingsWidget.Name = "checkBox_InfStamina_SettingsWidget";
            checkBox_InfStamina_SettingsWidget.Size = new Size(147, 19);
            checkBox_InfStamina_SettingsWidget.TabIndex = 85;
            checkBox_InfStamina_SettingsWidget.Text = "Infinite Stamina (Risky)";
            checkBox_InfStamina_SettingsWidget.CheckedChanged += checkBox_InfStamina_SettingsWidget_CheckedChanged;
            // 
            // checkBox_LTW_SettingsWidget
            // 
            checkBox_LTW_SettingsWidget.AutoSize = true;
            checkBox_LTW_SettingsWidget.Location = new Point(283, 57);
            checkBox_LTW_SettingsWidget.Name = "checkBox_LTW_SettingsWidget";
            checkBox_LTW_SettingsWidget.Size = new Size(168, 19);
            checkBox_LTW_SettingsWidget.TabIndex = 86;
            checkBox_LTW_SettingsWidget.Text = "Loot Through Walls (Risky)";
            checkBox_LTW_SettingsWidget.CheckedChanged += checkBox_LTW_SettingsWidget_CheckedChanged;
            // 
            // checkBox_FastLoadUnload_SettingsWidget
            // 
            checkBox_FastLoadUnload_SettingsWidget.AutoSize = true;
            checkBox_FastLoadUnload_SettingsWidget.Location = new Point(158, 57);
            checkBox_FastLoadUnload_SettingsWidget.Name = "checkBox_FastLoadUnload_SettingsWidget";
            checkBox_FastLoadUnload_SettingsWidget.Size = new Size(119, 19);
            checkBox_FastLoadUnload_SettingsWidget.TabIndex = 87;
            checkBox_FastLoadUnload_SettingsWidget.Text = "Fast Load/Unload";
            checkBox_FastLoadUnload_SettingsWidget.CheckedChanged += checkBox_FastLoadUnload_SettingsWidget_CheckedChanged;
            // 
            // checkBox_Chams_SettingsWidget
            // 
            checkBox_Chams_SettingsWidget.AutoSize = true;
            checkBox_Chams_SettingsWidget.Location = new Point(397, 32);
            checkBox_Chams_SettingsWidget.Name = "checkBox_Chams_SettingsWidget";
            checkBox_Chams_SettingsWidget.Size = new Size(63, 19);
            checkBox_Chams_SettingsWidget.TabIndex = 88;
            checkBox_Chams_SettingsWidget.Text = "Chams";
            checkBox_Chams_SettingsWidget.CheckedChanged += checkBox_Chams_SettingsWidget_CheckedChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.ImeMode = ImeMode.NoControl;
            tabControl1.Location = new Point(0, 23);
            tabControl1.Margin = new Padding(0);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(0, 0);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(600, 247);
            tabControl1.TabIndex = 89;
            // 
            // tabPage1
            // 
            tabPage1.BackgroundImageLayout = ImageLayout.None;
            tabPage1.Controls.Add(button_Restart_SettingsWidget);
            tabPage1.Controls.Add(checkedListBox_QuestHelper_SettingsWidget);
            tabPage1.Controls.Add(button_GymHack_SettingsWidget);
            tabPage1.Controls.Add(checkBox_Chams_SettingsWidget);
            tabPage1.Controls.Add(button_AntiAfk_SettingsWidget);
            tabPage1.Controls.Add(checkBox_LTW_SettingsWidget);
            tabPage1.Controls.Add(checkBox_FastLoadUnload_SettingsWidget);
            tabPage1.Controls.Add(checkBox_MoveSpeed_SettingsWidget);
            tabPage1.Controls.Add(checkBox_FullBright_SettingsWidget);
            tabPage1.Controls.Add(checkBox_InfStamina_SettingsWidget);
            tabPage1.Controls.Add(checkBox_MoveSpeed2_SettingsWidget);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(0);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(592, 219);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Quick Settings";
            // 
            // checkedListBox_QuestHelper_SettingsWidget
            // 
            checkedListBox_QuestHelper_SettingsWidget.BorderStyle = BorderStyle.FixedSingle;
            checkedListBox_QuestHelper_SettingsWidget.FormattingEnabled = true;
            checkedListBox_QuestHelper_SettingsWidget.Location = new Point(4, 82);
            checkedListBox_QuestHelper_SettingsWidget.Name = "checkedListBox_QuestHelper_SettingsWidget";
            checkedListBox_QuestHelper_SettingsWidget.Size = new Size(343, 128);
            checkedListBox_QuestHelper_SettingsWidget.TabIndex = 48;
            checkedListBox_QuestHelper_SettingsWidget.ItemCheck += checkedListBox_QuestHelper_SettingsWidget_ItemCheck;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Transparent;
            tabPage2.BorderStyle = BorderStyle.FixedSingle;
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(comboBox_AimbotTarget_SettingsWidget);
            tabPage2.Controls.Add(checkBox_AimRandomBone_SettingsWidget);
            tabPage2.Controls.Add(checkBox_AimHeadAI_SettingsWidget);
            tabPage2.Controls.Add(label_AimFOV_SettingsWidget);
            tabPage2.Controls.Add(trackBar_AimFOV_SettingsWidget);
            tabPage2.Controls.Add(checkBox_AimbotDisableReLock_SettingsWidget);
            tabPage2.Controls.Add(radioButton_AimTarget_FOV_SettingsWidget);
            tabPage2.Controls.Add(radioButton_AimTarget_CQB_SettingsWidget);
            tabPage2.Controls.Add(checkBox_SA_AutoBone_SettingsWidget);
            tabPage2.Controls.Add(checkBox_SA_SafeLock_SettingsWidget);
            tabPage2.Controls.Add(checkBox_AimBotEnabled_SettingsWidget);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(592, 219);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Aim Bot";
            // 
            // checkBox_AimRandomBone_SettingsWidget
            // 
            checkBox_AimRandomBone_SettingsWidget.Anchor = AnchorStyles.Right;
            checkBox_AimRandomBone_SettingsWidget.AutoSize = true;
            checkBox_AimRandomBone_SettingsWidget.Location = new Point(170, 56);
            checkBox_AimRandomBone_SettingsWidget.Name = "checkBox_AimRandomBone_SettingsWidget";
            checkBox_AimRandomBone_SettingsWidget.Size = new Size(101, 19);
            checkBox_AimRandomBone_SettingsWidget.TabIndex = 70;
            checkBox_AimRandomBone_SettingsWidget.Text = "Random Bone";
            checkBox_AimRandomBone_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_AimRandomBone_SettingsWidget.CheckedChanged += checkBox_AimRandomBone_SettingsWidget_CheckedChanged;
            // 
            // checkBox_AimHeadAI_SettingsWidget
            // 
            checkBox_AimHeadAI_SettingsWidget.Anchor = AnchorStyles.Right;
            checkBox_AimHeadAI_SettingsWidget.AutoSize = true;
            checkBox_AimHeadAI_SettingsWidget.Checked = true;
            checkBox_AimHeadAI_SettingsWidget.CheckState = CheckState.Checked;
            checkBox_AimHeadAI_SettingsWidget.Location = new Point(170, 6);
            checkBox_AimHeadAI_SettingsWidget.Name = "checkBox_AimHeadAI_SettingsWidget";
            checkBox_AimHeadAI_SettingsWidget.Size = new Size(91, 19);
            checkBox_AimHeadAI_SettingsWidget.TabIndex = 69;
            checkBox_AimHeadAI_SettingsWidget.Text = "Headshot AI";
            checkBox_AimHeadAI_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_AimHeadAI_SettingsWidget.CheckedChanged += checkBox_AimHeadAI_SettingsWidget_CheckedChanged;
            // 
            // label_AimFOV_SettingsWidget
            // 
            label_AimFOV_SettingsWidget.Anchor = AnchorStyles.Right;
            label_AimFOV_SettingsWidget.AutoSize = true;
            label_AimFOV_SettingsWidget.Location = new Point(7, 128);
            label_AimFOV_SettingsWidget.Name = "label_AimFOV_SettingsWidget";
            label_AimFOV_SettingsWidget.Size = new Size(50, 15);
            label_AimFOV_SettingsWidget.TabIndex = 68;
            label_AimFOV_SettingsWidget.Text = "FOV 150";
            // 
            // trackBar_AimFOV_SettingsWidget
            // 
            trackBar_AimFOV_SettingsWidget.Anchor = AnchorStyles.Right;
            trackBar_AimFOV_SettingsWidget.BackColor = SystemColors.Window;
            trackBar_AimFOV_SettingsWidget.Location = new Point(63, 128);
            trackBar_AimFOV_SettingsWidget.Maximum = 500;
            trackBar_AimFOV_SettingsWidget.Minimum = 5;
            trackBar_AimFOV_SettingsWidget.Name = "trackBar_AimFOV_SettingsWidget";
            trackBar_AimFOV_SettingsWidget.Size = new Size(78, 45);
            trackBar_AimFOV_SettingsWidget.TabIndex = 67;
            trackBar_AimFOV_SettingsWidget.TickStyle = TickStyle.None;
            trackBar_AimFOV_SettingsWidget.Value = 150;
            trackBar_AimFOV_SettingsWidget.ValueChanged += TrackBar_AimFOV_SettingsWidget_ValueChanged;
            // 
            // checkBox_AimbotDisableReLock_SettingsWidget
            // 
            checkBox_AimbotDisableReLock_SettingsWidget.Anchor = AnchorStyles.Right;
            checkBox_AimbotDisableReLock_SettingsWidget.AutoSize = true;
            checkBox_AimbotDisableReLock_SettingsWidget.Location = new Point(6, 106);
            checkBox_AimbotDisableReLock_SettingsWidget.Name = "checkBox_AimbotDisableReLock_SettingsWidget";
            checkBox_AimbotDisableReLock_SettingsWidget.Size = new Size(110, 19);
            checkBox_AimbotDisableReLock_SettingsWidget.TabIndex = 66;
            checkBox_AimbotDisableReLock_SettingsWidget.Text = "Disable Re-Lock";
            checkBox_AimbotDisableReLock_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_AimbotDisableReLock_SettingsWidget.CheckedChanged += checkBox_AimbotDisableReLock_SettingsWidget_CheckedChanged;
            // 
            // radioButton_AimTarget_FOV_SettingsWidget
            // 
            radioButton_AimTarget_FOV_SettingsWidget.Anchor = AnchorStyles.Right;
            radioButton_AimTarget_FOV_SettingsWidget.AutoSize = true;
            radioButton_AimTarget_FOV_SettingsWidget.Checked = true;
            radioButton_AimTarget_FOV_SettingsWidget.Location = new Point(6, 81);
            radioButton_AimTarget_FOV_SettingsWidget.Name = "radioButton_AimTarget_FOV_SettingsWidget";
            radioButton_AimTarget_FOV_SettingsWidget.Size = new Size(47, 19);
            radioButton_AimTarget_FOV_SettingsWidget.TabIndex = 64;
            radioButton_AimTarget_FOV_SettingsWidget.TabStop = true;
            radioButton_AimTarget_FOV_SettingsWidget.Text = "FOV";
            radioButton_AimTarget_FOV_SettingsWidget.UseVisualStyleBackColor = true;
            radioButton_AimTarget_FOV_SettingsWidget.CheckedChanged += radioButton_AimTarget_FOV_SettingsWidget_CheckedChanged;
            // 
            // radioButton_AimTarget_CQB_SettingsWidget
            // 
            radioButton_AimTarget_CQB_SettingsWidget.Anchor = AnchorStyles.Right;
            radioButton_AimTarget_CQB_SettingsWidget.AutoSize = true;
            radioButton_AimTarget_CQB_SettingsWidget.Location = new Point(59, 81);
            radioButton_AimTarget_CQB_SettingsWidget.Name = "radioButton_AimTarget_CQB_SettingsWidget";
            radioButton_AimTarget_CQB_SettingsWidget.Size = new Size(49, 19);
            radioButton_AimTarget_CQB_SettingsWidget.TabIndex = 65;
            radioButton_AimTarget_CQB_SettingsWidget.Text = "CQB";
            radioButton_AimTarget_CQB_SettingsWidget.UseVisualStyleBackColor = true;
            radioButton_AimTarget_CQB_SettingsWidget.CheckedChanged += radioButton_AimTarget_CQB_SettingsWidget_CheckedChanged;
            // 
            // checkBox_SA_AutoBone_SettingsWidget
            // 
            checkBox_SA_AutoBone_SettingsWidget.Anchor = AnchorStyles.Right;
            checkBox_SA_AutoBone_SettingsWidget.AutoSize = true;
            checkBox_SA_AutoBone_SettingsWidget.Location = new Point(6, 56);
            checkBox_SA_AutoBone_SettingsWidget.Name = "checkBox_SA_AutoBone_SettingsWidget";
            checkBox_SA_AutoBone_SettingsWidget.Size = new Size(82, 19);
            checkBox_SA_AutoBone_SettingsWidget.TabIndex = 63;
            checkBox_SA_AutoBone_SettingsWidget.Text = "Auto Bone";
            checkBox_SA_AutoBone_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_SA_AutoBone_SettingsWidget.CheckedChanged += checkBox_SA_AutoBone_SettingsWidget_CheckedChanged;
            // 
            // checkBox_SA_SafeLock_SettingsWidget
            // 
            checkBox_SA_SafeLock_SettingsWidget.Anchor = AnchorStyles.Right;
            checkBox_SA_SafeLock_SettingsWidget.AutoSize = true;
            checkBox_SA_SafeLock_SettingsWidget.Location = new Point(6, 31);
            checkBox_SA_SafeLock_SettingsWidget.Name = "checkBox_SA_SafeLock_SettingsWidget";
            checkBox_SA_SafeLock_SettingsWidget.Size = new Size(76, 19);
            checkBox_SA_SafeLock_SettingsWidget.TabIndex = 62;
            checkBox_SA_SafeLock_SettingsWidget.Text = "Safe Lock";
            checkBox_SA_SafeLock_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_SA_SafeLock_SettingsWidget.CheckedChanged += checkBox_SA_SafeLock_SettingsWidget_CheckedChanged;
            // 
            // checkBox_AimBotEnabled_SettingsWidget
            // 
            checkBox_AimBotEnabled_SettingsWidget.Anchor = AnchorStyles.Right;
            checkBox_AimBotEnabled_SettingsWidget.AutoSize = true;
            checkBox_AimBotEnabled_SettingsWidget.Location = new Point(6, 6);
            checkBox_AimBotEnabled_SettingsWidget.Name = "checkBox_AimBotEnabled_SettingsWidget";
            checkBox_AimBotEnabled_SettingsWidget.Size = new Size(104, 19);
            checkBox_AimBotEnabled_SettingsWidget.TabIndex = 61;
            checkBox_AimBotEnabled_SettingsWidget.Text = "Aimbot (Risky)";
            checkBox_AimBotEnabled_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_AimBotEnabled_SettingsWidget.CheckedChanged += checkBox_AimBotEnabled_SettingsWidget_CheckedChanged;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(592, 219);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "ESP";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(592, 219);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Chams";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(592, 219);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Web Radar";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(170, 32);
            label10.Name = "label10";
            label10.Size = new Size(40, 15);
            label10.TabIndex = 72;
            label10.Text = "Target";
            // 
            // comboBox_AimbotTarget_SettingsWidget
            // 
            comboBox_AimbotTarget_SettingsWidget.Anchor = AnchorStyles.Right;
            comboBox_AimbotTarget_SettingsWidget.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_AimbotTarget_SettingsWidget.FormattingEnabled = true;
            comboBox_AimbotTarget_SettingsWidget.Location = new Point(216, 29);
            comboBox_AimbotTarget_SettingsWidget.Name = "comboBox_AimbotTarget_SettingsWidget";
            comboBox_AimbotTarget_SettingsWidget.Size = new Size(121, 23);
            comboBox_AimbotTarget_SettingsWidget.TabIndex = 71;
            comboBox_AimbotTarget_SettingsWidget.SelectedIndexChanged += new EventHandler(this.ComboBox_AimbotTarget_SettingsWidget_SelectedIndexChanged);
            // 
            // SettingsWidgetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(600, 273);
            Controls.Add(tabControl1);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SettingsWidgetForm";
            Text = "SettingsWidgetForm";
            TopMost = true;
            headerPanel.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((ISupportInitialize)trackBar_AimFOV_SettingsWidget).EndInit();
            ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Button minimizeButton;
        private Button button_Restart_SettingsWidget;
        private CheckBox checkBox_MoveSpeed2_SettingsWidget;
        private CheckBox checkBox_MoveSpeed_SettingsWidget;
        private Button button_GymHack_SettingsWidget;
        private CheckBox checkBox_FullBright_SettingsWidget;
        private Button button_AntiAfk_SettingsWidget;
        private CheckBox checkBox_InfStamina_SettingsWidget;
        private CheckBox checkBox_LTW_SettingsWidget;
        private CheckBox checkBox_FastLoadUnload_SettingsWidget;
        private CheckBox checkBox_Chams_SettingsWidget;
        private FlowLayoutPanel flowLayoutPanel1;
        private CheckedListBox checkedListBox_QuestHelper_SettingsWidget;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private CheckBox checkBox_AimBotEnabled_SettingsWidget;
        private CheckBox checkBox_SA_SafeLock_SettingsWidget;
        private CheckBox checkBox_SA_AutoBone_SettingsWidget;
        private RadioButton radioButton_AimTarget_FOV_SettingsWidget;
        private RadioButton radioButton_AimTarget_CQB_SettingsWidget;
        private CheckBox checkBox_AimbotDisableReLock_SettingsWidget;
        private Label label_AimFOV_SettingsWidget;
        private TrackBar trackBar_AimFOV_SettingsWidget;
        private CheckBox checkBox_AimHeadAI_SettingsWidget;
        private CheckBox checkBox_AimRandomBone_SettingsWidget;
        private TabPage tabPage5;
        private Label label10;
        private ComboBox comboBox_AimbotTarget_SettingsWidget;
    }
}