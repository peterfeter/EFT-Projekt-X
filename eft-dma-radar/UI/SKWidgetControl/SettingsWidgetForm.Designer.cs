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
            contentPanel = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            checkedListBox_QuestHelper_SettingsWidget = new CheckedListBox();
            headerPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = SystemColors.Control;
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
            minimizeButton.UseVisualStyleBackColor = true;
            minimizeButton.Click += minimizeButton_Click;
            // 
            // button_Restart_SettingsWidget
            // 
            button_Restart_SettingsWidget.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Restart_SettingsWidget.Location = new Point(12, 6);
            button_Restart_SettingsWidget.Name = "button_Restart_SettingsWidget";
            button_Restart_SettingsWidget.Size = new Size(88, 23);
            button_Restart_SettingsWidget.TabIndex = 19;
            button_Restart_SettingsWidget.Text = "Restart Radar";
            button_Restart_SettingsWidget.UseVisualStyleBackColor = false;
            button_Restart_SettingsWidget.Click += button_Restart_SettingsWidget_Click;
            // 
            // checkBox_MoveSpeed2_SettingsWidget
            // 
            checkBox_MoveSpeed2_SettingsWidget.AutoSize = true;
            checkBox_MoveSpeed2_SettingsWidget.Location = new Point(12, 60);
            checkBox_MoveSpeed2_SettingsWidget.Name = "checkBox_MoveSpeed2_SettingsWidget";
            checkBox_MoveSpeed2_SettingsWidget.Size = new Size(152, 19);
            checkBox_MoveSpeed2_SettingsWidget.TabIndex = 81;
            checkBox_MoveSpeed2_SettingsWidget.Text = "1.4x Move Speed (Risky)";
            checkBox_MoveSpeed2_SettingsWidget.UseVisualStyleBackColor = false;
            checkBox_MoveSpeed2_SettingsWidget.CheckedChanged += checkBox_MoveSpeed2_SettingsWidget_CheckedChanged;
            // 
            // checkBox_MoveSpeed_SettingsWidget
            // 
            checkBox_MoveSpeed_SettingsWidget.AutoSize = true;
            checkBox_MoveSpeed_SettingsWidget.Location = new Point(12, 35);
            checkBox_MoveSpeed_SettingsWidget.Name = "checkBox_MoveSpeed_SettingsWidget";
            checkBox_MoveSpeed_SettingsWidget.Size = new Size(152, 19);
            checkBox_MoveSpeed_SettingsWidget.TabIndex = 80;
            checkBox_MoveSpeed_SettingsWidget.Text = "1.2x Move Speed (Risky)";
            checkBox_MoveSpeed_SettingsWidget.UseVisualStyleBackColor = false;
            checkBox_MoveSpeed_SettingsWidget.CheckedChanged += checkBox_MoveSpeed_SettingsWidget_CheckedChanged;
            // 
            // button_GymHack_SettingsWidget
            // 
            button_GymHack_SettingsWidget.Location = new Point(106, 6);
            button_GymHack_SettingsWidget.Name = "button_GymHack_SettingsWidget";
            button_GymHack_SettingsWidget.Size = new Size(96, 23);
            button_GymHack_SettingsWidget.TabIndex = 82;
            button_GymHack_SettingsWidget.Text = "Gym Hack";
            button_GymHack_SettingsWidget.UseVisualStyleBackColor = false;
            button_GymHack_SettingsWidget.Click += button_GymHack_SettingsWidget_Click;
            // 
            // checkBox_FullBright_SettingsWidget
            // 
            checkBox_FullBright_SettingsWidget.AutoSize = true;
            checkBox_FullBright_SettingsWidget.Location = new Point(170, 35);
            checkBox_FullBright_SettingsWidget.Name = "checkBox_FullBright_SettingsWidget";
            checkBox_FullBright_SettingsWidget.Size = new Size(80, 19);
            checkBox_FullBright_SettingsWidget.TabIndex = 83;
            checkBox_FullBright_SettingsWidget.Text = "Full Bright";
            checkBox_FullBright_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_FullBright_SettingsWidget.CheckedChanged += checkBox_FullBright_SettingsWidget_CheckedChanged;
            // 
            // button_AntiAfk_SettingsWidget
            // 
            button_AntiAfk_SettingsWidget.FlatStyle = FlatStyle.Popup;
            button_AntiAfk_SettingsWidget.Location = new Point(208, 6);
            button_AntiAfk_SettingsWidget.Name = "button_AntiAfk_SettingsWidget";
            button_AntiAfk_SettingsWidget.Size = new Size(96, 23);
            button_AntiAfk_SettingsWidget.TabIndex = 84;
            button_AntiAfk_SettingsWidget.Text = "Anti-AFK";
            button_AntiAfk_SettingsWidget.UseVisualStyleBackColor = false;
            button_AntiAfk_SettingsWidget.Click += button_AntiAfk_SettingsWidget_Click;
            // 
            // checkBox_InfStamina_SettingsWidget
            // 
            checkBox_InfStamina_SettingsWidget.AutoSize = true;
            checkBox_InfStamina_SettingsWidget.Location = new Point(170, 60);
            checkBox_InfStamina_SettingsWidget.Name = "checkBox_InfStamina_SettingsWidget";
            checkBox_InfStamina_SettingsWidget.Size = new Size(147, 19);
            checkBox_InfStamina_SettingsWidget.TabIndex = 85;
            checkBox_InfStamina_SettingsWidget.Text = "Infinite Stamina (Risky)";
            checkBox_InfStamina_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_InfStamina_SettingsWidget.CheckedChanged += checkBox_InfStamina_SettingsWidget_CheckedChanged;
            // 
            // checkBox_LTW_SettingsWidget
            // 
            checkBox_LTW_SettingsWidget.AutoSize = true;
            checkBox_LTW_SettingsWidget.Location = new Point(170, 85);
            checkBox_LTW_SettingsWidget.Name = "checkBox_LTW_SettingsWidget";
            checkBox_LTW_SettingsWidget.Size = new Size(168, 19);
            checkBox_LTW_SettingsWidget.TabIndex = 86;
            checkBox_LTW_SettingsWidget.Text = "Loot Through Walls (Risky)";
            checkBox_LTW_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_LTW_SettingsWidget.CheckedChanged += checkBox_LTW_SettingsWidget_CheckedChanged;
            // 
            // checkBox_FastLoadUnload_SettingsWidget
            // 
            checkBox_FastLoadUnload_SettingsWidget.AutoSize = true;
            checkBox_FastLoadUnload_SettingsWidget.Location = new Point(12, 85);
            checkBox_FastLoadUnload_SettingsWidget.Name = "checkBox_FastLoadUnload_SettingsWidget";
            checkBox_FastLoadUnload_SettingsWidget.Size = new Size(119, 19);
            checkBox_FastLoadUnload_SettingsWidget.TabIndex = 87;
            checkBox_FastLoadUnload_SettingsWidget.Text = "Fast Load/Unload";
            checkBox_FastLoadUnload_SettingsWidget.UseVisualStyleBackColor = false;
            checkBox_FastLoadUnload_SettingsWidget.CheckedChanged += checkBox_FastLoadUnload_SettingsWidget_CheckedChanged;
            // 
            // checkBox_Chams_SettingsWidget
            // 
            checkBox_Chams_SettingsWidget.AutoSize = true;
            checkBox_Chams_SettingsWidget.Location = new Point(12, 110);
            checkBox_Chams_SettingsWidget.Name = "checkBox_Chams_SettingsWidget";
            checkBox_Chams_SettingsWidget.Size = new Size(63, 19);
            checkBox_Chams_SettingsWidget.TabIndex = 88;
            checkBox_Chams_SettingsWidget.Text = "Chams";
            checkBox_Chams_SettingsWidget.UseVisualStyleBackColor = false;
            checkBox_Chams_SettingsWidget.CheckedChanged += checkBox_Chams_SettingsWidget_CheckedChanged;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = SystemColors.Control;
            contentPanel.Controls.Add(tabControl1);
            contentPanel.Controls.Add(checkedListBox_QuestHelper_SettingsWidget);
            contentPanel.Controls.Add(checkBox_Chams_SettingsWidget);
            contentPanel.Controls.Add(checkBox_FastLoadUnload_SettingsWidget);
            contentPanel.Controls.Add(checkBox_LTW_SettingsWidget);
            contentPanel.Controls.Add(checkBox_InfStamina_SettingsWidget);
            contentPanel.Controls.Add(button_AntiAfk_SettingsWidget);
            contentPanel.Controls.Add(checkBox_FullBright_SettingsWidget);
            contentPanel.Controls.Add(button_GymHack_SettingsWidget);
            contentPanel.Controls.Add(checkBox_MoveSpeed_SettingsWidget);
            contentPanel.Controls.Add(checkBox_MoveSpeed2_SettingsWidget);
            contentPanel.Controls.Add(button_Restart_SettingsWidget);
            contentPanel.Location = new Point(0, 20);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(600, 440);
            contentPanel.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(3, 289);
            tabControl1.Margin = new Padding(0);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(0, 0);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(597, 143);
            tabControl1.TabIndex = 89;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Transparent;
            tabPage1.BackgroundImageLayout = ImageLayout.None;
            tabPage1.BorderStyle = BorderStyle.FixedSingle;
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(0);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(589, 115);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Quick Settings";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Transparent;
            tabPage2.BorderStyle = BorderStyle.FixedSingle;
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(589, 115);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            // 
            // checkedListBox_QuestHelper_SettingsWidget
            // 
            checkedListBox_QuestHelper_SettingsWidget.Anchor = AnchorStyles.None;
            checkedListBox_QuestHelper_SettingsWidget.BorderStyle = BorderStyle.FixedSingle;
            checkedListBox_QuestHelper_SettingsWidget.FormattingEnabled = true;
            checkedListBox_QuestHelper_SettingsWidget.Location = new Point(12, 135);
            checkedListBox_QuestHelper_SettingsWidget.Name = "checkedListBox_QuestHelper_SettingsWidget";
            checkedListBox_QuestHelper_SettingsWidget.Size = new Size(343, 128);
            checkedListBox_QuestHelper_SettingsWidget.TabIndex = 48;
            checkedListBox_QuestHelper_SettingsWidget.ItemCheck += checkedListBox_QuestHelper_SettingsWidget_ItemCheck;
            // 
            // SettingsWidgetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(601, 486);
            Controls.Add(contentPanel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SettingsWidgetForm";
            Text = "SettingsWidgetForm";
            TopMost = true;
            Load += SettingsWidgetForm_Load;
            headerPanel.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);

        }

        private void SettingsWidgetForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            bool isDarkMode = IsDarkModeEnabled();

            Color contentBackgroundColor = isDarkMode ? Color.FromArgb(45, 45, 48) : SystemColors.ControlLightLight;
            Color tabControlBackgroundColor = isDarkMode ? Color.FromArgb(45, 45, 48) : SystemColors.ControlLightLight;
            Color tabpage1BackgroundColor = isDarkMode ? Color.FromArgb(45, 45, 48) : SystemColors.ControlLightLight;
            Color tabpage2BackgroundColor = isDarkMode ? Color.FromArgb(45, 45, 48) : SystemColors.ControlLightLight;
            Color headerBackgroundColor = isDarkMode ? Color.FromArgb(35, 35, 38) : SystemColors.Control;
            Color foregroundColor = isDarkMode ? Color.White : SystemColors.ControlText;

            BackColor = contentBackgroundColor;
            ForeColor = foregroundColor;

            headerPanel.BackColor = headerBackgroundColor;
            headerPanel.ForeColor = foregroundColor;
            contentPanel.BackColor = contentBackgroundColor;
            contentPanel.ForeColor = foregroundColor;
            tabControl1.BackColor = tabControlBackgroundColor;
            tabControl1.ForeColor = foregroundColor;
            tabPage1.BackColor = tabControlBackgroundColor;
            tabPage1.ForeColor = foregroundColor;
            tabPage2.BackColor = tabControlBackgroundColor;
            tabPage2.ForeColor = foregroundColor;
            minimizeButton.BackColor = headerBackgroundColor;
            minimizeButton.ForeColor = foregroundColor;

            checkedListBox_QuestHelper_SettingsWidget.BackColor = contentBackgroundColor;
            checkedListBox_QuestHelper_SettingsWidget.ForeColor = foregroundColor;
        }
        private bool IsDarkModeEnabled()
        {
            const string registryKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            const string registryValue = "AppsUseLightTheme";

            object registryValueObject = Registry.GetValue(registryKey, registryValue, null);
            if (registryValueObject == null)
            {
                return false;
            }

            int registryValueInt = (int)registryValueObject;
            return registryValueInt == 0;
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
        private Panel contentPanel;
        private FlowLayoutPanel flowLayoutPanel1;
        private CheckedListBox checkedListBox_QuestHelper_SettingsWidget;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}