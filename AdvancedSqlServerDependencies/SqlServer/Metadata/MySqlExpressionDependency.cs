using System;
namespace AdvancedSqlServerDependencies.SqlServer.View
{
    public class MySqlExpressionDependency
    {
        public int ServerObjectId;
        public int DatabaseId;
        public int ParentServerObjectId;
        public int ParentDatabaseId;
        public int ParentObjectId;
        public int ChildServerObjectId;
        public int ChildDatabaseId;
        public int ChildObjectId;

        public string ChildServerObjectName;
        public string ChildDatabaseName;
        public string ChildSchemaName;
        public string ChildObjectName;

        public bool ChildObjectExists;

        public override string ToString()
        {
            if(ChildObjectExists)
                return string.Format("P:{0} => C:{1}", ParentObjectId, ChildObjectId);
            return string.Format("P:{0} => C:[{1}].[{2}].[{3}].[{4}]", ParentObjectId, ChildServerObjectName, ChildDatabaseName, ChildSchemaName, ChildObjectName);
        }
    }
}
