using System.IO;
using System.Reflection;
using System.Text;

namespace AdvancedSqlServerDependencies.SqlServer
{
    public static class QueryReader
    {
        public static string Read(string fileName)
        {
            StringBuilder tsql = new StringBuilder();
            string line;
            //string sourceFile = string.Format("AdvancedSqlServerDependencies.SqlQuery.{0}", fileName);
            string sourceFile = string.Format("AdvancedSqlServerDependencies.SqlServer.Queries.{0}", fileName);

            Assembly assembly = Assembly.GetExecutingAssembly();
            var sourceFileStream = assembly.GetManifestResourceStream(sourceFile);
            if (sourceFileStream != null)
            {
                StreamReader textStreamReader = new StreamReader(sourceFileStream);
                while ((line = textStreamReader.ReadLine()) != null)
                {
                    tsql.AppendLine(line);
                }
            }

            return tsql.ToString();
        }
    }
}
