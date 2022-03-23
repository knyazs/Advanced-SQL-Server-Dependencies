using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.MySqlObjects;
using AdvancedSqlServerDependencies.SqlServer.Metadata;

namespace AdvancedSqlServerDependencies.Forms
{
    public partial class RecommendedDatabasesForm : Form
    {
        public List<MySqlDatabase> CheckedRecommendedDatabases
        {
            get
            {
                return (from RecommendedDatabase checkedObject in objectListView1.CheckedObjects select new MySqlDatabase {ServerObjectName = checkedObject.ServerName, DatabaseName = checkedObject.DatabaseName}).ToList();
            }
        }

        public RecommendedDatabasesForm(MySqlDatabase[] recommendedDatabases)
        {
            InitializeComponent();

            var query = from rdb in recommendedDatabases.AsEnumerable()
                        group rdb by new {rdb.ServerObjectName, rdb.DatabaseName}
                        into grp
                        select new RecommendedDatabase
                        {
                            DatabaseName = grp.Key.DatabaseName,
                            ServerName = grp.Key.ServerObjectName,
                            UsageCount = grp.Count()
                        };


            this.objectListView1.SetObjects(query);
            //this.objectListView1.AutoResizeColumns();
        }
    }

    class RecommendedDatabase
    {
        public string DatabaseName;
        public string ServerName;
        public int UsageCount;
    }
}
