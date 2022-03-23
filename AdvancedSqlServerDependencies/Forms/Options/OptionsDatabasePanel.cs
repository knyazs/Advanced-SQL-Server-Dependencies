using System;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.Properties;

namespace AdvancedSqlServerDependencies.Forms.Options
{
    public partial class OptionsDatabasePanel : UserControl
    {
        public OptionsDatabasePanel()
        {
            InitializeComponent();
        }

        private void OptionsDatabasePanel_Load(object sender, EventArgs e)
        {
            if(UserSettings.Default.CommandTimeout > numericUpDown1.Maximum)
                numericUpDown1.Value = numericUpDown1.Maximum;
            else if(UserSettings.Default.CommandTimeout < numericUpDown1.Minimum)
                numericUpDown1.Value = numericUpDown1.Minimum;
            else
                numericUpDown1.Value = UserSettings.Default.CommandTimeout;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UserSettings.Default.CommandTimeout = Convert.ToInt32(numericUpDown1.Value);
        }
    }
}
