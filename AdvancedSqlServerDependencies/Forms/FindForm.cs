using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.MySqlObjects;
using AdvancedSqlServerDependencies.SqlServer.Metadata;

namespace AdvancedSqlServerDependencies.Forms
{
    public partial class FindForm : Form
    {
        // private IEnumerable<MyDatabaseObject> _objectListReference;

        public FindForm(IEnumerable<MySqlObject> dependencyObjects)
        {
            InitializeComponent();

            checkedListBox1.Items.AddRange(dependencyObjects.Select(t => t.ObjectType).Distinct().ToArray());
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);
        }

        private void buttonUncheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            //int q = MyDatabaseObjects.Objects.Count;
        }
    }
}
