using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LonesEFTRadar.UI.SKWidgetControl
{
    public partial class SettingsWidgetForm : Form
    {
        private bool isMinimized = false;
        private Point lastMousePosition;

        public SettingsWidgetForm()
        {
            InitializeComponent();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            if (isMinimized)
            {
                this.Size = new System.Drawing.Size(400, 300);
                this.contentPanel.Visible = true;
                this.minimizeButton.Text = "_";
            }
            else
            {
                this.Size = new System.Drawing.Size(400, 30);
                this.contentPanel.Visible = false;
                this.minimizeButton.Text = "▢";
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
    }
}