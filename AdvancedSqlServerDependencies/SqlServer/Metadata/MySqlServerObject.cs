using AdvancedSqlServerDependencies.Util;
using System;
using System.ComponentModel;

namespace AdvancedSqlServerDependencies.SqlServer.Metadata
{
    public class MySqlServerObject
    {
        /// <summary>
        /// Children
        /// </summary>
        
        public int ServerObjectId;

        [Category("Name"), DisplayName("Data Source"), Description("Data Source name")]
        public string ServerObjectName { get; set; }

        [TypeConverter(typeof(YesNoTypeConverter)), Category("Misc"), DisplayName("Linked Server"), Description("Indicates if server is linked or not")]
        public bool IsLinked { get; set; }

        public string Product { get; set; }
        public string Provider { get; set; }

        [Category("SQL Server Properties"), DisplayName("Product Version Code"), Description("Microsoft SQL Server Version")]
        public string ProductVersionCode { get; set; }

        [Category("SQL Server Properties"), DisplayName("Product Level"), Description("Level")]
        public string ProductLevel { get; set; }

        [Category("SQL Server Properties"), Description("Microsoft SQL Server Edition")]
        public string Edition { get; set; }
        
        private Version _version
        {
            get
            {
                int major = 0, minor = 0, build = 0, revision = 0;

                string[] ver = ProductVersionCode.Split('.');
                if (ver.Length > 0)
                    major = Convert.ToInt32(ver[0]);
                if (ver.Length > 1)
                    minor = Convert.ToInt32(ver[1]);
                if (ver.Length > 2)
                    build = Convert.ToInt32(ver[2]);
                if (ver.Length > 3)
                    revision = Convert.ToInt32(ver[3]);
                return new Version(major, minor, build, revision);
            }
        }

        [Category("Misc"), TypeConverter(typeof(YesNoTypeConverter)), DisplayName("Supported Version"), Description("Application supprts SQL Server versions from SQL Server 2008")]
        public bool IsValid
        {
            get
            {
                return _version.Major > 9;
            }
            set { value = false; }
        }

        [Category("SQL Server Properties"), DisplayName("Product Version Name"), Description("Version of the server. More info: http://sqlserverbuilds.blogspot.com.au/")]
        public string ProductVersionName
        {
            get
            {
                if (_version.Major == 7)
                    return "SQL Server 7";
                if (_version.Major == 8)
                    return "SQL Server 2000";
                if (_version.Major == 9)
                    return "SQL Server 2005";
                if (_version.Major == 10 && _version.Minor == 0)
                    return "SQL Server 2008";
                if (_version.Major == 10 && _version.Minor == 50)
                    return "SQL Server 2008 R2";
                if (_version.Major == 11)
                    return "SQL Server 2012";
                if (_version.Major == 12)
                    return "SQL Server 2014";
                return "Unknown";
            }

            set { value = "UNKNOWN"; }
        }

        [Category("SQL Server Properties"), DisplayName("Process ID")]
        public int ProcessId { get; set; }

        [Browsable(false)]
        public int EditionID { get; set; }

        [Category("SQL Server Properties"), DisplayName("Edition ID")]
        public string EditionIDName
        {
            get
            {
                switch (EditionID)
                {
                    case 1804890536: return "Enterprise";

                    case 1872460670: return "Enterprise Edition: Core-based Licensing";
                    case 610778273: return "Enterprise Evaluation";
                    case 284895786: return "Business Intelligence";
                    case -2117995310: return "Developer";
                    case -1592396055: return "Express";
                    case -133711905: return "Express with Advanced Services";
                    case -1534726760: return "Standard";
                    case 1293598313: return "Web";
                    case 1674378470: return "SQL Database";
                    default: return "Unknown";
                }
            }
        }

        [Category("SQL Server Properties"), DisplayName("LicenseType")]
        public string LicenseType { get; set; }


        public override string ToString()
        {
            return ServerObjectName;
        }

        //public ServerObject(int server_id)
        //{

        //}
    }
}
