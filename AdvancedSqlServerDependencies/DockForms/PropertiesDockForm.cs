using System.Windows.Forms;
using AdvancedSqlServerDependencies.Properties;
using WeifenLuo.WinFormsUI.Docking;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;
using AdvancedSqlServerDependencies.SqlServer.Metadata;

namespace AdvancedSqlServerDependencies.DockForms
{
    public partial class PropertiesDockForm : DockContent
    {
        private object _object;
        private bool _allowEdit;

        public PropertiesDockForm()
        {
            InitializeComponent();

            this.richTextBox1.Text = AppSettings.Default.NoObjectSelectedDefaultText;
            this.Enabled = false;
        }

        public void SetObject(object obj, IEnumerable<MySqlObject> childrenObjects, string titlePropertyName, bool allowEdit = false)
        {
            this._object = obj;
            this._allowEdit = allowEdit;

            this.Enabled = obj != null;

            //string title = obj.GetType().GetProperty(titlePropertyName).GetValue(obj, null).ToString();
            if (obj != null)
            {
                string title;

                if (obj.GetType().GetProperty("Rtf") != null)
                {
                    title = obj.GetType().GetProperty("Rtf").GetValue(obj, null).ToString();
                    richTextBox1.Rtf = string.Format("{0}", title);
                }
                else
                {
                    try
                    {

                        var t = obj.GetType();
                        var p = t.GetProperty(titlePropertyName);
                        var v = p.GetValue(obj, null);
                        var s = v.ToString();
                        title = s;
                        richTextBox1.Text = string.Format("{0}", title);
                    }
                    catch
                    {
                        richTextBox1.Text = titlePropertyName;
                    }
                }
            }
            else
            {
                this.richTextBox1.Text = AppSettings.Default.NoObjectSelectedDefaultText;
            }

            // Set TotalTableRowCount
            if (obj != null)
            {
                PropertyInfo propertyInfo = obj.GetType().GetProperty("UnderlyingTableCount");
                if (propertyInfo != null && childrenObjects != null)
                {
                    try
                    {
                        MySqlObjectEqualityComparer moec = new MySqlObjectEqualityComparer();
                        Int64 val = childrenObjects.Where(co => co.ObjectType.Equals("USER_TABLE")).Distinct(moec).Count();
                        propertyInfo.SetValue(obj, val, null);
                    }
                    catch (Exception ex)
                    {
                        propertyInfo.SetValue(obj, Convert.ChangeType(ex.Message, propertyInfo.PropertyType), null);
                    }
                }

                propertyInfo = obj.GetType().GetProperty("UnderlyingTableRowCount");
                if (propertyInfo != null && childrenObjects != null)
                {
                    try
                    {
                        MySqlObjectEqualityComparer moec = new MySqlObjectEqualityComparer();
                        var uniqueUserTables = childrenObjects.Where(co => co.ObjectType.Equals("USER_TABLE")).Distinct(moec);
                        var totalTableRowCount = uniqueUserTables.Select(co => co.RowCount).Sum();

                        //var val = string.Format("{0:n0} ({1:n0} tables)", totalTableRowCount, uniqueUserTables.Count());

                        propertyInfo.SetValue(obj, totalTableRowCount, null);
                    }
                    catch (Exception ex)
                    {
                        propertyInfo.SetValue(obj, Convert.ChangeType(ex.Message, propertyInfo.PropertyType), null);
                    }
                }
            }


            propertyGrid1.SelectedObject = obj;
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (!this._allowEdit)
            {
                MessageBox.Show("Object properties are read-only and cannot be changed!", "Invalid Operation",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                var n = e.ChangedItem.PropertyDescriptor.Name;
                var t = this._object.GetType();
                var p = t.GetProperty(n);
                p.SetValue(this._object, e.OldValue, null);
            }
        }
    }
}
