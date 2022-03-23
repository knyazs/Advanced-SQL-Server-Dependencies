using System.Windows.Forms;
using AdvancedSqlServerDependencies.Properties;
using WeifenLuo.WinFormsUI.Docking;
using AdvancedSqlServerDependencies.MySqlObjects;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;
using AdvancedSqlServerDependencies.Forms;
using AdvancedSqlServerDependencies.SqlServer.Metadata;
using AdvancedSqlServerDependencies.SqlServer;

namespace AdvancedSqlServerDependencies.DockForms
{
    public partial class TopObjectsDockForm : DockContent
    {
        private MySqlServer _mySqlServer;
        
        public TopObjectsDockForm(ref MySqlServer mySqlServer)
        {
            InitializeComponent();

            this._mySqlServer = mySqlServer;
        }

        internal void RefreshInfo()
        {
            var t1 = from tt in _mySqlServer.SqlObjects.Where(x => x.ObjectType == "USER_TABLE")
                     orderby tt.RowCount descending
                     select tt;
            objectListView1.SetObjects(t1);

            var t2 = from tt in _mySqlServer.SqlObjects.Where(x => x.ObjectType == "USER_TABLE")
                     orderby tt.TotalSpaceUsedKB descending
                     select tt;
            objectListView2.SetObjects(t2);
        }

        private void TopObjectsDockForm_Paint(object sender, PaintEventArgs e)
        {
            var olvs = new[] { objectListView1, objectListView2 };

            foreach (var olv in olvs)
            {
                bool settingsChanged = false;
                if (olv.AlternateRowBackColor != UserSettings.Default.AlternateRowBackColor)
                {
                    olv.AlternateRowBackColor = UserSettings.Default.AlternateRowBackColor;
                    settingsChanged = true;
                }

                if (olv.UseAlternatingBackColors != UserSettings.Default.UseAlternatingBackColors)
                {
                    olv.UseAlternatingBackColors = UserSettings.Default.UseAlternatingBackColors;
                    settingsChanged = true;
                }

                if (olv.Objects != null && settingsChanged)
                    olv.UpdateObjects(olv.Objects.Cast<MySqlObject>().ToList());
            }
        }
    }
}
