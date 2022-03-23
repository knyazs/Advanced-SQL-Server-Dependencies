using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.Properties;

namespace AdvancedSqlServerDependencies.Forms.Options
{
    public partial class OptionsAppearancePanel : UserControl
    {
        public OptionsAppearancePanel()
        {
            InitializeComponent();
        }

        private void OptionsAppearancePanel_Load(object sender, EventArgs e)
        {
            cbxUseAlternatingBackColors.Checked = UserSettings.Default.UseAlternatingBackColors;

            //
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("FirstName", typeof(String));
            dt.Columns.Add("LastName", typeof(String));
            dt.Columns.Add("Sport", typeof(String));
            dt.Rows.Add(1, "Michael", "Jordan", "Basketball");
            dt.Rows.Add(2, "Novak", "Djokovic", "Tennis");
            dt.Rows.Add(3, "Michael", "Schumacher", "Formula 1");
            dt.Rows.Add(4, "Zinedine", "Zidane", "Football");
            dt.Rows.Add(5, "Muhammad", "Ali", "Boxing");
            dt.Rows.Add(6, "Usain", "Bolt", "Running");
            dt.Rows.Add(7, "Michael", "Phelps", "Swimming");
            dt.Rows.Add(8, "Tiger", "Woods", "Golf");

            objectListView1.AlternateRowBackColor = UserSettings.Default.AlternateRowBackColor;
            objectListView1.UseAlternatingBackColors = UserSettings.Default.UseAlternatingBackColors;
            objectListView1.Objects = dt.Rows;
        }

        private void cbxUseAlternatingBackColors_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Default.UseAlternatingBackColors = cbxUseAlternatingBackColors.Checked;
            
            objectListView1.UseAlternatingBackColors = cbxUseAlternatingBackColors.Checked;
            refreshObjectListView();
        }

        private void buttonAlternateBackColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = UserSettings.Default.AlternateRowBackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                UserSettings.Default.AlternateRowBackColor = colorDialog1.Color;

                objectListView1.AlternateRowBackColor = colorDialog1.Color;
                refreshObjectListView();
            }
        }

        private void refreshObjectListView()
        {
            if (objectListView1.Objects != null)
                objectListView1.UpdateObjects(objectListView1.Objects.Cast<object>().ToList());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserSettings.Default.AlternateRowBackColor = SystemColors.Info;
            objectListView1.AlternateRowBackColor = SystemColors.Info; 
            refreshObjectListView();
        }
    }
}
