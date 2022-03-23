using AdvancedSqlServerDependencies.Properties;
using AdvancedSqlServerDependencies.Util;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;

namespace AdvancedSqlServerDependencies.SqlServer.Metadata
{
    public class MySqlDatabase
    {
        public int ServerObjectId;
        public string ServerObjectName;
        public bool IsChecked;
        

        [Category("Identity"), DisplayName("Database ID"), Description("Database unique identifier")]
        public int DatabaseId { get; set; }

        [Category("Name"), DisplayName("Database Name"), Description("Database Name")]
        public string DatabaseName { get; set; }

        [Category("Properties"), DisplayName("Database State"), Description("Database connection state")]
        public string State { get; set; }

        //[Category("Properties"), TypeConverter(typeof(YesNoTypeConverter)), DisplayName("Database Access"), Description("Database access")]
        [Browsable(false)]
        public bool UserHasDbAccess { get; set; }

        [Category("Properties"), DisplayName("Note"), Description("Note")]
        public string Note { get
            {
                return (!UserHasDbAccess) ? "No access" : "OK";
            }
        }

        [Category("Properties"), DisplayName("Compatibilty Level"), Description("Compatibilty Level")]
        public int CompatibilityLevel { get; set; }

        [Category("Properties"), DisplayName("Collation Name"), Description("Collation Name")]
        public string CollationName { get; set; }

        [Category("Properties"), DisplayName("Recovery Model"), Description("Recovery Model")]
        public string RecoveryModel { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}]", DatabaseName);
        }

        [Browsable(false)]
        public string Rtf
        {
            get
            {
                var s = string.Format(@"\rtf1\ansi \b {0}\b0  {1}", DatabaseName, this.ToString());
                return "{" + s + "}";
            }
        }

        [Browsable(false)]
        public Image Image
        {
            get
            {
                Image img;
                switch (State)
                {
                    case "ONLINE":
                        img = Resources.database; break;
                    default: img = Resources.database_read_only; break;
                }

                //return img;

                Bitmap Logo = new Bitmap(img);
                Logo.MakeTransparent(Logo.GetPixel(1, 1));
                return (Image)Logo;
            }
        }
    }
}
