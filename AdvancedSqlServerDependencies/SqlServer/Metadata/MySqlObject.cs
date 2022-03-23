using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using AdvancedSqlServerDependencies.Properties;
using AdvancedSqlServerDependencies.Util;
using System.Data.SqlClient;
using System.Data;

namespace AdvancedSqlServerDependencies.SqlServer.Metadata
{
    public class MySqlObject
    {
        #region 'System' properties
        [Browsable(false)]
        public int SystemId;

        [Browsable(false)]
        public string SystemIdString { get { return this.SystemId.ToString(); } }

        [Browsable(false)]
        public int SystemParentId;

        [Browsable(false)]
        public string SystemParentIdString { get { return this.SystemParentId.ToString(); } }
        #endregion

        [Category("Identity"), DisplayName("Server ID"), Description("Server unique identifier")]
        public int ServerObjectId { get; set; }

        [Category("Name"), DisplayName("Server Name"), Description("Server name")]
        public string ServerObjectName { get; set; }

        [Category("Identity"), DisplayName("Schema ID"), Description("Schema unique identifier")]
        public int SchemaId { get; set; }

        [Category("Name"), DisplayName("Schema Name"), Description("Schema name")]
        public string SchemaName { get; set; }

        [Category("Identity"), DisplayName("Database ID"), Description("Database unique identifier")]
        public int DatabaseId { get; set; }

        [Category("Name"), DisplayName("Database Name"), Description("Database name")]
        public string DatabaseName { get; set; }

        [Category("Identity"), DisplayName("Object ID"), Description("Object unique identifier")]
        public int ObjectId { get; set; }

        [Category("Name"), DisplayName("Object Name"), Description("Object name")]
        public string ObjectName { get; set; }


        private string _objectTypeId;
        [Browsable(true), Category("Category"), DisplayName("Object Type Id"), Description("Object type Id")]
        public string ObjectTypeId { get { return _objectTypeId.Trim(); } set { _objectTypeId = value; } }

        [Browsable(false), Category("Category"), DisplayName("Object Type"), Description("Object type")]
        public string ObjectType { get; set; }

        [Category("Category"), DisplayName("Object Type"), Description("Object type")]
        public string ObjectTypeBeautified
        {
            get
            {
                string retValue = "";
                foreach (char c in ObjectType)
                {
                    if (Char.IsLetter(c))
                        retValue += c;
                    else
                        retValue += " ";
                }

                return new CultureInfo("en-US", false).TextInfo.ToTitleCase(retValue.ToLower());
            }
            set { value = "NO TYPE"; }
        }

        [Category("Extended"), DisplayName("Full Object Name"), Description("Full object name")]
        public string ObjectNameFull { get; set; }

        [Category("Navigation"), DisplayName("Hierarchy Level"), Description("Object level from top to down; 0 = root.")]
        public int HierarchyLevel { get; set; }

        [Category("Extended"), DisplayName("Self Referencing"), Description("Desribes if object references to itself")]
        public string IsSelfReferencing { get; set; }

        [Browsable(false)]
        public string Rtf
        {
            get
            {
                var s = string.Format(@"\rtf1\ansi \b {0}\b0  {1}", ObjectName, ObjectNameFull);
                return "{" + s + "}";
            }
        }

        public override string ToString()
        {
            return ObjectNameFull;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        [Browsable(false)]
        public Image Image
        {
            get
            {
                // Object types taken from here: https://msdn.microsoft.com/en-us/library/ms190324.aspx
                Image img;
                switch (ObjectType)
                {
                    case "AGGREGATE_FUNCTION":
                        img = Resources.SSMS_ScalarFunction_16x16; break;
                    case "CHECK_CONSTRAINT":
                        img = Resources.SSMS_CheckConstraint_16x16; break;
                    case "CLR_SCALAR_FUNCTION":
                        img = Resources.SSMS_ScalarFunction_16x16; break;
                    case "CLR_STORED_PROCEDURE":
                        img = Resources.SSMS_StoredProcedureCLR_16x16; break;
                    case "CLR_TABLE_VALUED_FUNCTION":
                        img = Resources.SSMS_TableValueFunction_16x16; break;
                    case "CLR_TRIGGER":
                        img = Resources.SSMS_Trigger_16x16; break;
                    case "DEFAULT_CONSTRAINT":
                        img = Resources.SSMS_DefaultConstraint_16x16; break;
                    case "EXTENDED_STORED_PROCEDURE":
                        img = Resources.SSMS_ExtendedStoredProcedure_16x16; break;
                    case "FOREIGN_KEY_CONSTRAINT":
                        img = Resources.SSMS_ForeignKeyConstraint_16x16; break;
                    case "INTERNAL_TABLE":
                        img = Resources.TableView_nameonly_263_32; break;
                    case "PLAN_GUIDE":
                        img = Resources.SSMS_PlanGuide_16x16; break;
                    case "PRIMARY_KEY_CONSTRAINT":
                        img = Resources.SSMS_PrimaryKeyConstraint_16x16; break;
                    case "REPLICATION_FILTER_PROCEDURE":
                        img = Resources.Filter16; break;
                    case "RULE":
                        img = Resources.SSMS_Rule_16x16; break;
                    case "SEQUENCE_OBJECT":
                        img = Resources.SSMS_SequenceObject_16x16; break;
                    case "SERVICE_QUEUE":
                        img = Resources.SSMS_ServiceQueue_16x16; break;
                    case "SQL_INLINE_TABLE_VALUED_FUNCTION":
                        img = Resources.SSMS_TableValueFunction_16x16; break;
                    case "SQL_SCALAR_FUNCTION":
                        img = Resources.SSMS_ScalarFunction_16x16; break;
                    case "SQL_STORED_PROCEDURE":
                        img = Resources.SSMS_StoredProcedure_16x16; break;
                    case "SQL_TABLE_VALUED_FUNCTION":
                        img = Resources.SSMS_TableValueFunction_16x16; break;
                    case "SQL_TRIGGER":
                        img = Resources.SSMS_Trigger_16x16; break;
                    case "SYNONYM":
                        img = Resources.SSMS_Synonym_16x16; break;
                    case "SYSTEM_TABLE":
                        img = Resources.SSMS_Table_16x16; break;
                    case "TABLE_TYPE":
                        img = Resources.SSMS_Table_16x16; break;
                    case "UNIQUE_CONSTRAINT":
                        img = Resources.SSMS_UniqueConstraint_16x16; break;
                    case "USER_TABLE":
                        img = Resources.SSMS_Table_16x16; break;
                    case "VIEW":
                        img = Resources.SSMS_View_16x16; break;

                    default: img = Resources._1508_QuestionMarkRed; break;
                }
                return img;
            }
        }

        [Category("Navigation"), DisplayName("Maximum Underlying Levels"), Description("Maximum number of levels below selected object")]
        public int MaximumUnderlyingLevels { get; set; }

        public string ObjectDefinition { get; set; }

        //[Browsable(false), Category("Extended"), DisplayName("Object Definition"), Description("Definition of the object")]
        //public string GetObjectDefinition(ref MySqlServer mySqlServer)
        //{
        //    string result = string.Empty;

        //    mySqlServer.ConnectionPool.GetConnection(this.ServerObjectId).ChangeDatabase(DatabaseName);
        //    SqlCommand cmd = (SqlCommand)mySqlServer.ConnectionPool.GetConnection(this.ServerObjectId).CreateCommand();
        //    cmd.CommandText = string.Format("SELECT OBJECT_DEFINITION ({0}) AS [ObjectDefinition]", ObjectId);
        //    cmd.CommandTimeout = UserSettings.Default.CommandTimeout;
        //    cmd.CommandType = CommandType.Text;
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    while (rdr.Read())
        //    {
        //        result = rdr[0].ToString();
        //    }
        //    rdr.Close();

        //    return (!string.IsNullOrEmpty(result)) ? result : "Cannot get object definition from the server";
        //}

        private Int64 _rowCount = 0;
        [Category("Extended"), DisplayName("Row Count"), Description("Row Count"), TypeConverter(typeof(CustomNumberTypeConverter))]
        public Int64 RowCount { get { return _rowCount; } set { _rowCount = value; } }

        public long TotalSpaceUsedKB { get; set; }

        [Category("Extended"), DisplayName("Total Space Used"), Description("Total Space Used")]
        public string TotalSpaceUsed { get { return ValueConverter.ConvertToDynamicSize(TotalSpaceUsedKB * 1024); } }

        [Category("Extended"), DisplayName("Underlying Table Row Count"), Description("Total number of rows from all underlying tables in selected object"), TypeConverter(typeof(CustomNumberTypeConverter))]
        public Int64 UnderlyingTableRowCount { get; set; }

        [Category("Extended"), DisplayName("Underlying Table Count"), Description("Total number of underlying tables for selected object"), TypeConverter(typeof(CustomNumberTypeConverter))]
        public Int64 UnderlyingTableCount { get; set; }


        [Category("Synonym"), DisplayName("Base Object Name"), Description("Base object of a synonym")]
        public string BaseObjectNameFull { get; set; }

    }

    class MySqlObjectEqualityComparer : IEqualityComparer<MySqlObject>
    {
        public bool Equals(MySqlObject b1, MySqlObject b2)
        {
            return b1.ObjectNameFull.Equals(b2.ObjectNameFull, StringComparison.InvariantCultureIgnoreCase);
        }


        public int GetHashCode(MySqlObject bx)
        {
            return bx.ObjectNameFull.GetHashCode();
        }

    }
}
