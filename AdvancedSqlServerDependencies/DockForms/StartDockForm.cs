using WeifenLuo.WinFormsUI.Docking;
using System.Collections.Generic;
using System;
using AdvancedSqlServerDependencies.Forms;
using AdvancedSqlServerDependencies.SqlServer.Metadata;

namespace AdvancedSqlServerDependencies.DockForms
{
    public partial class StartDockForm : DockContent
    {
        private MainFormMdi _mainForm;



        public StartDockForm(ref MainFormMdi mainForm)
        {
            InitializeComponent();

            this._mainForm = mainForm;

            this.Enabled = true;
        }

        public void SetObject(object obj, IEnumerable<MySqlObject> childrenObjects, string titlePropertyName, bool allowEdit = false)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._mainForm.connect(sender, e);
        }

        private void buttonNewDependencyCheck_Click(object sender, EventArgs e)
        {
            this._mainForm.newDependencyCheck(sender, e);
        }        
    }
}
