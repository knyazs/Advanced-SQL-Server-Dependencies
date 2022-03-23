using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.Properties;

namespace AdvancedSqlServerDependencies.Forms.Options
{
    public partial class OptionsForm : Form
    {
        private readonly Dictionary<string, object> _propertyMap;
        public OptionsForm()
        {
            InitializeComponent();

            _propertyMap = new Dictionary<string, object>();
        }

        

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            // Save settings
            // backup properties
            foreach (var propertyInfo in UserSettings.Default.GetType().GetProperties())
            {
                if (propertyInfo.CanRead && propertyInfo.CanWrite && propertyInfo.GetCustomAttributes(typeof(UserScopedSettingAttribute), false).Any())
                {
                    var name = propertyInfo.Name;
                    var value = propertyInfo.GetValue(UserSettings.Default, null);
                    _propertyMap.Add(name, value);
                }
            }


            var n = treeView1.Nodes.Find(AppSettings.Default.LastOption, true).FirstOrDefault();
            if (n != null)
            {
                treeView1.SelectedNode = n;
            }

            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            panel1.Controls.Clear();
            Control optionPanel = null;

            if (treeView1.SelectedNode.Text.Equals("Appearance", StringComparison.InvariantCultureIgnoreCase))
            {
                optionPanel = new OptionsAppearancePanel();
            }
            else if (treeView1.SelectedNode.Text.Equals("Database", StringComparison.InvariantCultureIgnoreCase))
            {
                optionPanel = new OptionsDatabasePanel();
            }
            else if (treeView1.SelectedNode.Text.Equals("Database Connection", StringComparison.InvariantCultureIgnoreCase))
            {
                optionPanel = new OptionsDatabasePanel();
            }
            if (optionPanel != null)
            {
                optionPanel.Dock = DockStyle.Fill;
                panel1.Controls.Add(optionPanel);
            }
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppSettings.Default.LastOption = treeView1.SelectedNode.Name;
            AppSettings.Default.Save();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            UserSettings.Default.Save();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // restore properties
            foreach (var propertyInfo in UserSettings.Default.GetType().GetProperties())
            {
                if (propertyInfo.CanRead && propertyInfo.CanWrite && propertyInfo.GetCustomAttributes(typeof(UserScopedSettingAttribute), false).Any())
                {
                    var value = _propertyMap[propertyInfo.Name];
                    propertyInfo.SetValue(UserSettings.Default, value, null);
                }
            }
            UserSettings.Default.Save();
        }
    }
}
