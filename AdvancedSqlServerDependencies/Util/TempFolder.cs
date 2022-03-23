using System;
using System.IO;

namespace AdvancedSqlServerDependencies.Util
{
    public static class TempFolder
    {
        private static readonly string _transientRootPath = Path.Combine(Path.GetTempPath(), "AdvancedSQLServerDependencies", "Transient");
        private static readonly string _permanentRootPath = Path.Combine(Path.GetTempPath(), "AdvancedSQLServerDependencies", "Permanent");

        /// <summary>
        /// Returns full path of requested file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileExtension"></param>
        /// <param name="isTransient"></param>
        /// <returns>Full path</returns>
        public static string GetPath(string fileName, string fileExtension, bool isTransient)
        {
            var rootPath = (isTransient)? _transientRootPath : _permanentRootPath;

            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            fileName = (string.IsNullOrEmpty(fileName) ? DateTime.Now.ToString("yyyy_MM_dd__HH_mm_ss") /* Guid.NewGuid().ToString()*/ : fileName);

            return Path.Combine(rootPath, fileName + "." + fileExtension);
        }

        //public static string GetRandomFilePathFromExtension(string extension)
        //{
        //    if (!Directory.Exists(_transientRootPath))
        //        Directory.CreateDirectory(_transientRootPath);

        //    string fileName = string.Concat(Guid.NewGuid().ToString(), "." + extension);

        //    return Path.Combine(_transientRootPath, fileName);
        //}

        public static void CleanTransientFolder()
        {
            if (!Directory.Exists(_transientRootPath))
                return;

            DirectoryInfo di = new DirectoryInfo(_transientRootPath);

            foreach (FileInfo file in di.GetFiles())
            {
                try { file.Delete(); }
                catch
                {
                    // ignored
                }
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                try { dir.Delete(true); }
                catch
                {
                    // ignored
                }
            }
        }
    }
}
