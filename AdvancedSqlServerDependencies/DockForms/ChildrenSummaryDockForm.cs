using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.MySqlObjects;
using AdvancedSqlServerDependencies.Properties;
using WeifenLuo.WinFormsUI.Docking;
using BrightIdeasSoftware;
using System.Drawing;
using AdvancedSqlServerDependencies.SqlServer.Metadata;

namespace AdvancedSqlServerDependencies.DockForms
{
    public partial class ChildrenSummaryDockForm : DockContent
    {
        private string totalString = "TOTAL";

        public ChildrenSummaryDockForm()
        {
            InitializeComponent();
        }

        private void ChildrenSummaryDockForm_Load(object sender, EventArgs e)
        {
            this.richTextBox1.Text = AppSettings.Default.NoObjectSelectedDefaultText;
            this.Enabled = false;
        }

        public void SetObject(MySqlObject mo, IEnumerable<MySqlObject> childrenObjects)
        {
            this.Enabled = mo != null;

            if (mo != null)
            {
                richTextBox1.Rtf = mo.Rtf;

                MySqlObjectEqualityComparer moec = new MySqlObjectEqualityComparer();

                var resultAll = from o in childrenObjects
                                group o.SystemId by o.ObjectType into g
                                orderby g.Key ascending
                                select new { ObjectType = g.Key, ObjectCount = g.Count() };

                var resultUnique = from o in childrenObjects.Distinct(moec)
                                   group o.SystemId by o.ObjectType into g
                                   orderby g.Key ascending
                                   select new { ObjectType = g.Key, UniqueObjectCount = g.Count() };

                var result = from r1 in resultAll
                             join r2 in resultUnique on r1.ObjectType equals r2.ObjectType
                             select new { r1.ObjectType, r1.ObjectCount, r2.UniqueObjectCount };

                var totals = from r in result
                             select new { ObjectType = totalString, ObjectCount = result.Sum(r1 => r1.ObjectCount), UniqueObjectCount = result.Sum(r2 => r2.UniqueObjectCount) };

                objectListView1.SetObjects(result.Union(totals));


                tsslObjectCount.Text = string.Format("{0} objects, {1} unique", result.Sum(r1 => r1.ObjectCount), result.Sum(r2 => r2.UniqueObjectCount));
            }
            else
            {
                this.richTextBox1.Text = AppSettings.Default.NoObjectSelectedDefaultText;
                objectListView1.ClearObjects();
            }
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{

        //}

        private void ChildrenSummaryDockForm_Paint(object sender, PaintEventArgs e)
        {
            bool settingsChanged = false;
            if (objectListView1.AlternateRowBackColor != UserSettings.Default.AlternateRowBackColor)
            {
                objectListView1.AlternateRowBackColor = UserSettings.Default.AlternateRowBackColor;
                settingsChanged = true;
            }

            if (objectListView1.UseAlternatingBackColors != UserSettings.Default.UseAlternatingBackColors)
            {
                objectListView1.UseAlternatingBackColors = UserSettings.Default.UseAlternatingBackColors;
                settingsChanged = true;
            }

            if (objectListView1.Objects != null && settingsChanged)
                objectListView1.UpdateObjects(objectListView1.Objects.Cast<object>().ToList());
        }

        private void objectListView1_FormatRow(object sender, FormatRowEventArgs e)
        {
            if (e.Item.Text.Equals(totalString))
            {
                Font f = e.Item.Font;
                e.Item.Font = new Font(f, FontStyle.Bold);
            }                
        }
    }
}
