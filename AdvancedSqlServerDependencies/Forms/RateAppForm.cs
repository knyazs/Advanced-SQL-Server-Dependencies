using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvancedSqlServerDependencies.Forms
{
    public partial class RateAppForm : Form
    {
        public RateAppForm()
        {
            InitializeComponent();

            textBox2.Visible = Properties.AppSettings.Default.ApplicationRated == 1;
        }

        private void buttonRateLater_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRateNow_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://advancedsqlserverdependencies.codeplex.com/");
            Properties.AppSettings.Default.ApplicationRated = 1;
            Properties.AppSettings.Default.Save();
            Process.Start(sInfo);
            this.Close();
        }

        private void buttonDontRate_Click(object sender, EventArgs e)
        {
            Properties.AppSettings.Default.ApplicationRated = -1;
            Properties.AppSettings.Default.Save();
            this.Close();
        }
    }
}
