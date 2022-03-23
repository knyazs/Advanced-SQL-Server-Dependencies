using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.MySqlObjects;
using AdvancedSqlServerDependencies.SqlServer.Metadata;

namespace AdvancedSqlServerDependencies.Forms
{
    public partial class InvalidDatabaseReferencesForm : Form
    {

        public InvalidDatabaseReferencesForm(KeyValuePair<MySqlObject, MySqlDatabase>[] invalidDatabaseReferences)
        {
            InitializeComponent();

            var query = from idr in invalidDatabaseReferences.AsEnumerable()
                        select new IvalidRefObject
                        {
                            ObjectName = idr.Key.ObjectNameFull,
                            DatabaseName = "[" + idr.Value.ServerObjectName + "].[" +  idr.Value.DatabaseName + "]"
                        };


            this.objectListView1.SetObjects(query);
            //this.objectListView1.AutoResizeColumns();
        }
    }

    class IvalidRefObject
    { 
        public string ObjectName;
        public string DatabaseName;
    }
}
