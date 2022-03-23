using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.Forms;
using AdvancedSqlServerDependencies.Progress;
using AdvancedSqlServerDependencies.Properties;
using AdvancedSqlServerDependencies.Util;
using BrightIdeasSoftware;
using WeifenLuo.WinFormsUI.Docking;
using AdvancedSqlServerDependencies.CustomOutput;
using AdvancedSqlServerDependencies.SqlServer.Metadata;
using AdvancedSqlServerDependencies.SqlServer;

namespace AdvancedSqlServerDependencies.DockForms
{
    public partial class DependencyBrowserDockForm : DockContent
    {
        private readonly List<MySqlObject> _dependencyObjectList;

        //private readonly List<MySqlDatabase> _recommendedDatabases;
        //public List<MySqlDatabase> RecommendedDatabases
        //{
        //    get { return _recommendedDatabases; }
        //}

        private readonly List<KeyValuePair<MySqlObject, MySqlDatabase>> _recommendedDatabases;
        public List<KeyValuePair<MySqlObject, MySqlDatabase>> RecommendedDatabases
        {
            get { return _recommendedDatabases; }
        }

        private MySqlServer _mySqlServer;
        public bool AreDependenciesInitialized;

        private MySqlObject selectedSqlObject
        {
            get { return (MySqlObject)this.treeListView1.SelectedObject; }
        }

        //public void SetInMemoryDatabase(ref InMemoryDatabase inMemoryDatabase)
        //{
        //    this._inMemoryDatabase = inMemoryDatabase;

        //    textBox2.Text = string.Join(", ", inMemoryDatabase.LoadedDatabases.Select(d => "[" + d.DatabaseName + "]"));
        //}

        //public DependencyBrowserDockForm(string title, bool isTopDown)
        public DependencyBrowserDockForm(ref MySqlServer mySqlServer, string title, string[] objectTypes, bool isTopDown, int windowId)
        {
            InitializeComponent();

            this._mySqlServer = mySqlServer;

            //_objectDepParentDictionary = new Dictionary<MySqlObjectParentKey, MySqlObject>();
            //_objectDepChildDictionary = new Dictionary<MySqlObjectChildKey, MySqlObject>();
            _dependencyObjectList = new List<MySqlObject>();
            _recommendedDatabases = new List<KeyValuePair<MySqlObject, MySqlDatabase>>();

            this.Text = string.Format("New Dependency {0}", windowId);

            this.treeListView1.CanExpandGetter = delegate (object x)
            {
                return _dependencyObjectList.Any(m => m.SystemParentId == ((MySqlObject)x).SystemId);
            };

            this.treeListView1.ChildrenGetter = delegate (object x)
            {
                return _dependencyObjectList.Where(m => m.SystemParentId == ((MySqlObject)x).SystemId).OrderBy(m => m.ObjectName);
            };

            olvColumnObjectName.ImageGetter = delegate (object x)
            {
                return ((MySqlObject)x).Image;
            };

            treeListView1.UseAlternatingBackColors = UserSettings.Default.UseAlternatingBackColors;

            //
            //pictureBox1.too
            pictureBox1.Image = (isTopDown) ? Resources._112_DownArrowLong_Blue_32x32_72 : Resources._112_UpArrowLong_Orange_32x42_72;
            textBox1.Text = (isTopDown) ? string.Format("Objects on which '{0}' depends on", title) : string.Format("Objects that depend on '{0}'", title);
            textBox2.Text = string.Join(", ", _mySqlServer.SqlLoadedDatabases.Select(d => "[" + d.DatabaseName + "]"));
        }

        private void expandSelectedObject(object sender, EventArgs e)
        {
            if (treeListView1.CanExpand(treeListView1.SelectedObject))
                treeListView1.Expand(treeListView1.SelectedObject);

            foreach (MySqlObject mo in GetChildren(this.selectedSqlObject).Where(mo => treeListView1.CanExpand(mo)).OrderBy(m => m.HierarchyLevel))
            {
                treeListView1.Expand(mo);
            }
        }

        private void collapseSelectedObject(object sender, EventArgs e)
        {
            foreach (MySqlObject mo in GetChildren(this.selectedSqlObject).OrderByDescending(m => m.HierarchyLevel))
            {
                treeListView1.Collapse(mo);
            }
            treeListView1.Collapse(this.selectedSqlObject);
        }

        private void expandAllObjects(object sender, EventArgs e)
        {
            treeListView1.ExpandAll();
        }

        private void collapseAllObjects(object sender, EventArgs e)
        {
            treeListView1.CollapseAll();
        }

        public void AutoResizeColumns()
        {
            treeListView1.AutoResizeColumns();
        }

        public IEnumerable<MySqlObject> GetChildren(MySqlObject parent)
        {
            List<MySqlObject> children = new List<MySqlObject>();
            foreach (MySqlObject o in _dependencyObjectList.Where(m => m.SystemParentId == parent.SystemId).OrderBy(m => m.ObjectName))
            {
                children.Add(o);
                children.AddRange(GetChildren(o));
            }

            return children;
        }

        private void export(object sender, EventArgs e)
        {
            if (!_dependencyObjectList.Any())
                return;

            try
            {
                string workbookName = TempFolder.GetPath(null, "xlsx", true);

                var spreadsheet = Excel.CreateWorkbook(workbookName);

                Excel.AddBasicStyles(spreadsheet);
                Excel.AddWorksheet(spreadsheet, "Sheet1");
                var worksheet = spreadsheet.WorkbookPart.WorksheetParts.First().Worksheet;

                // Excel file ready for the data

                // 
                uint maxDepth = (uint)_dependencyObjectList.Max(o => o.HierarchyLevel) + 1;

                // Columns
                for (uint i = 1; i <= maxDepth; i++)
                {
                    string text = string.Format("Level {0}", /*this.treeListView1.Columns[0].Text,*/ i);
                    Excel.SetCellValue(spreadsheet, worksheet, i, 1, text, false, false);
                }

                for (uint i = maxDepth + 1; i <= (uint)this.treeListView1.Columns.Count + maxDepth - 1; i++)
                {
                    string text = this.treeListView1.Columns[(int)i - (int)maxDepth].Text;
                    Excel.SetCellValue(spreadsheet, worksheet, i, 1, text, false, false);
                }

                // data
                uint row = 2;
                foreach (object obj in this.treeListView1.Objects)
                {
                    MySqlObject sqlObj = (MySqlObject)obj;
                    Excel.SetCellValue(spreadsheet, worksheet, (uint)sqlObj.HierarchyLevel + 1, row, sqlObj.ObjectName, false, false);
                    Excel.SetCellValue(spreadsheet, worksheet, (uint)maxDepth + 1, row, sqlObj.ObjectId, null, false);
                    Excel.SetCellValue(spreadsheet, worksheet, (uint)maxDepth + 2, row, sqlObj.ServerObjectName, false, false);
                    Excel.SetCellValue(spreadsheet, worksheet, (uint)maxDepth + 3, row, sqlObj.DatabaseName, false, false);
                    Excel.SetCellValue(spreadsheet, worksheet, (uint)maxDepth + 4, row, sqlObj.SchemaName, false, false);
                    Excel.SetCellValue(spreadsheet, worksheet, (uint)maxDepth + 5, row, sqlObj.ObjectType, false, false);
                    Excel.SetCellValue(spreadsheet, worksheet, (uint)maxDepth + 6, row, sqlObj.MaximumUnderlyingLevels, null, false);
                    Excel.SetCellValue(spreadsheet, worksheet, (uint)maxDepth + 7, row, sqlObj.IsSelfReferencing, false, false);

                    row++;

                    IEnumerable<MySqlObject> children = GetChildren(sqlObj);
                    foreach (MySqlObject child in children)
                    {
                        Excel.SetCellValue(spreadsheet, worksheet, (uint)child.HierarchyLevel + 1, row, child.ObjectName, false, false);
                        Excel.SetCellValue(spreadsheet, worksheet, (uint)maxDepth + 1, row, child.ObjectId, null, false);
                        Excel.SetCellValue(spreadsheet, worksheet, (uint)maxDepth + 2, row, child.ServerObjectName, false, false);
                        Excel.SetCellValue(spreadsheet, worksheet, (uint)maxDepth + 3, row, child.DatabaseName, false, false);
                        Excel.SetCellValue(spreadsheet, worksheet, (uint)maxDepth + 4, row, child.SchemaName, false, false);
                        Excel.SetCellValue(spreadsheet, worksheet, (uint)maxDepth + 5, row, child.ObjectType, false, false);
                        Excel.SetCellValue(spreadsheet, worksheet, (uint)maxDepth + 6, row, child.MaximumUnderlyingLevels, null, false);
                        Excel.SetCellValue(spreadsheet, worksheet, (uint)maxDepth + 7, row, child.IsSelfReferencing, false, false);

                        row++;
                    }
                }

                worksheet.Save();
                spreadsheet.Close();

                Process.Start(workbookName);
            }
            catch (Exception ex)
            {
            }
        }

        private void autoResizeColumns(object sender, EventArgs e)
        {
            this.treeListView1.AutoResizeColumns();
        }

        private void treeListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // this.treeListView1.SelectedObject

            MySqlObject mso = (MySqlObject)this.treeListView1.SelectedObject;

            expandSelectedObjectToolStripMenuItem1.Enabled = this.treeListView1.SelectedObject != null;
            collapseSelectedObjectToolStripMenuItem1.Enabled = this.treeListView1.SelectedObject != null;
            //objectScriptToolStripMenuItem1.Enabled = this.treeListView1.SelectedObject != null;
            //objectSummaryToolStripMenuItem1.Enabled = this.treeListView1.SelectedObject != null;
            //objectPropertiesToolStripMenuItem1.Enabled = this.treeListView1.SelectedObject != null;
            //dataPreviewToolStripMenuItem1.Enabled = this.treeListView1.SelectedObject != null; e.Index != -1 && mso != null && (mso.ObjectType == "USER_TABLE" || mso.ObjectType == "VIEW" || mso.ObjectType == "SYNONYM");

            expandSelectedObjectToolStripMenuItem.Enabled = this.treeListView1.SelectedObject != null;
            collapseSelectedObjectToolStripMenuItem.Enabled = this.treeListView1.SelectedObject != null;
            //objectScriptToolStripMenuItem.Enabled = e.Index != -1;
            //objectSummaryToolStripMenuItem.Enabled = e.Index != -1;
            //objectPropertiesToolStripMenuItem.Enabled = e.Index != -1;
            //dataPreviewToolStripMenuItem1.Enabled = e.Index != -1 && mso != null && (mso.ObjectType == "USER_TABLE" || mso.ObjectType == "VIEW" || mso.ObjectType == "SYNONYM");


            ((MainFormMdi)this.ParentForm).PropertiesDockForm.SetObject(mso, (mso != null) ? GetChildren(mso) : null, "ObjectName");
            ((MainFormMdi)this.ParentForm).ObjectDefinitionDockForm.SetObject(mso);
            ((MainFormMdi)this.ParentForm).ChildrenSummaryDockForm.SetObject(mso, (mso != null) ? GetChildren(mso) : null);
            ((MainFormMdi)this.ParentForm).DataPreviewDockForm.SetObject(mso);
            ((MainFormMdi)this.ParentForm).ObjectDefinitionDockForm.SetObject(mso);
        }


        public void LoadDependencies(string pattern, string[] objectTypes, bool isTopDown, EMatchMethod matchMethod, bool forceReload, MySqlDatabase[] searchDatabases)
        {
            //_inMemoryDatabase.Load(checkedDatabases, forceReload);\\

            _recommendedDatabases.Clear();

            //----------------
            int objectId = 0;
            IEnumerable<MySqlObject> rootObjects;
            // Parent objects



            rootObjects = from o in _mySqlServer.SqlObjects.AsEnumerable()
                          where
                            (
                                string.IsNullOrEmpty(pattern) ||
                                (
                                    matchMethod == EMatchMethod.StartsWith && o.ObjectName.StartsWith(pattern, StringComparison.InvariantCultureIgnoreCase) ||
                                    matchMethod == EMatchMethod.EndsWith && o.ObjectName.EndsWith(pattern, StringComparison.InvariantCultureIgnoreCase) ||
                                    matchMethod == EMatchMethod.Equals && o.ObjectName.Equals(pattern, StringComparison.InvariantCultureIgnoreCase) ||
                                    matchMethod == EMatchMethod.Contains && o.ObjectName.ToUpper().Contains(pattern.ToUpper())
                                )
                            )
                            &&
                            (
                                objectTypes == null || (objectTypes != null && objectTypes.Contains(o.ObjectTypeId))
                            )
                            &&
                            (
                                searchDatabases == null || (searchDatabases != null && searchDatabases.Select(sdb => "[" + sdb.ServerObjectName + "].[" + sdb.DatabaseName + "]").Contains("[" + o.ServerObjectName + "].[" + o.DatabaseName + "]"))
                            )
                          select o;

            // -- nonExisting

            var nonExistingRootObjects = from d in _mySqlServer.SqlExpressionDependencies.Where(dl => dl.ChildObjectExists == false)
                                         where
                            (
                                string.IsNullOrEmpty(pattern) ||
                                (
                                    matchMethod == EMatchMethod.StartsWith && d.ChildObjectName.StartsWith(pattern, StringComparison.InvariantCultureIgnoreCase) ||
                                    matchMethod == EMatchMethod.EndsWith && d.ChildObjectName.EndsWith(pattern, StringComparison.InvariantCultureIgnoreCase) ||
                                    matchMethod == EMatchMethod.Equals && d.ChildObjectName.Equals(pattern, StringComparison.InvariantCultureIgnoreCase) ||
                                    matchMethod == EMatchMethod.Contains && d.ChildObjectName.ToUpper().Contains(pattern.ToUpper())
                                )
                            )
                            &&
                            (
                                searchDatabases == null || (searchDatabases != null && searchDatabases.Select(sdb => "[" + sdb.ServerObjectName + "].[" + sdb.DatabaseName + "]").Contains("[" + d.ChildServerObjectName + "].[" + d.ChildDatabaseName + "]"))
                            )
                                         select new MySqlObject
                                         {
                                             ServerObjectName = d.ChildServerObjectName,
                                             DatabaseName = d.ChildDatabaseName,
                                             SchemaName = d.ChildSchemaName,
                                             ObjectName = d.ChildObjectName,

                                             ServerObjectId = -1,
                                             DatabaseId = -1,
                                             SchemaId = -1,
                                             ObjectId = -1,
                                             ObjectNameFull = string.Format("[{0}].[{1}].[{2}].[{3}]", d.ChildServerObjectName, d.ChildDatabaseName, d.ChildSchemaName, d.ChildObjectName),
                                             ObjectTypeId = "UNRESOLVED_ENTITY",
                                             ObjectType = "UNRESOLVED_ENTITY"

                                         };

            MySqlObjectEqualityComparer moec = new MySqlObjectEqualityComparer();
            rootObjects = rootObjects.Union(nonExistingRootObjects.Distinct(moec));



            /*

             * 
             * 
            if(string.IsNullOrEmpty(pattern))
                rootObjects = from o in _inMemoryDatabase.SqlObjectList.AsEnumerable()
                              select o;
            else if (matchMethod == EMatchMethod.StartsWith)
                rootObjects = from o in _inMemoryDatabase.SqlObjectList.AsEnumerable()
                              where o.ObjectName.StartsWith(pattern, StringComparison.InvariantCultureIgnoreCase)
                              select o;
            else if (matchMethod == EMatchMethod.EndsWith)
                rootObjects = from o in _inMemoryDatabase.SqlObjectList.AsEnumerable()
                              where o.ObjectName.EndsWith(pattern, StringComparison.InvariantCultureIgnoreCase)
                              select o;
            else if (matchMethod == EMatchMethod.Equals)
                rootObjects = from o in _inMemoryDatabase.SqlObjectList.AsEnumerable()
                              where o.ObjectName.Equals(pattern, StringComparison.InvariantCultureIgnoreCase)
                              select o;
            else
                rootObjects = from o in _inMemoryDatabase.SqlObjectList.AsEnumerable()
                              where o.ObjectName.ToUpper().Contains(pattern.ToUpper())
                              select o;

            // Filter by object types
            if (objectTypes != null)
                rootObjects = rootObjects.Where(ro => objectTypes.Contains(ro.ObjectTypeId));
            */
            // var allowedStatus = new[]{ "A", "B", "C" };
            // var filteredOrders = orders.Order.Where(o => allowedStatus.Contains(o.StatusCode));


            MyOutput.NewMessage(EOutputMessageType.INFORMATION, string.Format("{0:n0} matching search objects found. ", rootObjects.Count()));

            if (rootObjects.Count() <= 50 || rootObjects.Count() > 50 && MessageBox.Show(string.Format("Large number of matching objects was found - {0}!{1}Searching dependencies may take a while.{1}Are you sure you want to continue?", rootObjects.Count(), Environment.NewLine), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DateTime dt = DateTime.Now;
                MyOutput.NewMessage(EOutputMessageType.PROGRESS, string.Format("Finding dependent objects..."));
                _dependencyObjectList.Clear();
                loadDependentObjects(null, rootObjects.ToArray(), isTopDown, ref objectId, 0);

                AreDependenciesInitialized = true;
                MyOutput.AppendToLastMessage(EOutputMessageType.INFORMATION, string.Format("Done. {0:n0} dependent objects found.", _dependencyObjectList.Count(d => d.HierarchyLevel > 0)), (DateTime.Now - dt).TotalSeconds);
            }
            else
            {
                AreDependenciesInitialized = false;
                MyOutput.AppendToLastMessage(EOutputMessageType.WARNING, string.Format("Finding dependent objects cancelled."));
            }
        }

        private int loadDependentObjects(MySqlObject masterParentObject, MySqlObject[] objs, bool isTopDown, ref int refObjectId, int level)
        {
            int totalMaxLevel = -1;
            bool hasNextObjects = false;
            int counter = 0;

            IEnumerable<MySqlObject> nextObjects;
            IEnumerable<MySqlObject> nextSynonymObjects;


            foreach (MySqlObject obj in objs)
            {
                if (LongRunningOperationManager.CancellationPending)
                {
                    //e.Cancel = true;
                    break;
                }

                var singleObjectMaxLevel = -1;

                // Get next objects which are NOT synonyms
                if (isTopDown)
                {
                    nextObjects = from o in _mySqlServer.SqlObjects
                                  join d in _mySqlServer.SqlExpressionDependencies.Where(d => d.ChildObjectExists).Where(d => d.ChildObjectId != d.ParentObjectId)
                                    on      new { ServerId = o.ServerObjectId, DatabaseId = o.DatabaseId, ObjectId = o.ObjectId }
                                    equals  new { ServerId = d.ChildServerObjectId, DatabaseId = d.ChildDatabaseId, ObjectId = d.ChildObjectId }
                                  where obj.ServerObjectId == d.ParentServerObjectId
                                       && obj.DatabaseId == d.ParentDatabaseId
                                       && obj.ObjectId == d.ParentObjectId
                                       && obj.ObjectType != "SYNONYM"
                                  select o;

                    var nonExistingNextObjects = from d in _mySqlServer.SqlExpressionDependencies.Where(d => !d.ChildObjectExists).Where(d => d.ChildObjectId != d.ParentObjectId)
                                                 where obj.ServerObjectId == d.ParentServerObjectId
                                                      && obj.DatabaseId == d.ParentDatabaseId
                                                      && obj.ObjectId == d.ParentObjectId
                                                      && obj.ObjectType != "SYNONYM"
                                                 select new MySqlObject
                                                 {
                                                     ServerObjectName = d.ChildServerObjectName,
                                                     DatabaseName = d.ChildDatabaseName,
                                                     SchemaName = d.ChildSchemaName,
                                                     ObjectName = d.ChildObjectName,

                                                     ServerObjectId = -1,
                                                     DatabaseId = -1,
                                                     SchemaId = -1,
                                                     ObjectId = -1,
                                                     ObjectNameFull = string.Format("[{0}].[{1}].[{2}].[{3}]", d.ChildServerObjectName, d.ChildDatabaseName, d.ChildSchemaName, d.ChildObjectName),
                                                     ObjectTypeId = "UNRESOLVED_ENTITY",
                                                     ObjectType = "UNRESOLVED_ENTITY"
                                                 };

                    nextObjects = nextObjects.Union(nonExistingNextObjects);

                    if (!string.IsNullOrEmpty(obj.BaseObjectNameFull))
                    {
                        string[] bo = obj.BaseObjectNameFull.Replace("[", string.Empty).Replace("]", string.Empty).Split('.');
                        string serverName = bo[0];
                        string databaseName = bo[1];

                        if (
                            !_mySqlServer.SqlLoadedDatabases.Any(
                                db => db.ServerObjectName.Equals(serverName, StringComparison.InvariantCultureIgnoreCase) &&
                                      db.DatabaseName.Equals(databaseName, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            _recommendedDatabases.Add(new KeyValuePair<MySqlObject, MySqlDatabase>(obj, new MySqlDatabase { ServerObjectId = -1, ServerObjectName = serverName, DatabaseId = -1, DatabaseName = databaseName }));
                        }
                    }

                    nextSynonymObjects = from o in _mySqlServer.SqlObjects
                                         where o.ObjectNameFull.Equals(obj.BaseObjectNameFull, StringComparison.InvariantCultureIgnoreCase)
                                            && obj.ObjectType == "SYNONYM"
                                         select o;
                }
                else
                {
                    nextObjects = from o in _mySqlServer.SqlObjects
                                  join d in _mySqlServer.SqlExpressionDependencies.Where(d => d.ChildObjectId != d.ParentObjectId) on new { ServerId = o.ServerObjectId, o.DatabaseId, o.ObjectId } equals new { ServerId = d.ParentServerObjectId, DatabaseId = d.ParentDatabaseId, ObjectId = d.ParentObjectId }
                                  where obj.ServerObjectId == d.ChildServerObjectId
                                       && obj.DatabaseId == d.ChildDatabaseId
                                       && obj.ObjectId == d.ChildObjectId
                                        && o.ObjectType != "SYNONYM"
                                  select o;

                    // non-existing objects

                    //var a1 = from d in _inMemoryDatabase.SqlDependencyList.Where(d => !d.ChildObjectExists).Where(d => d.ChildObjectId != d.ParentObjectId)
                    //         where obj.ServerName.Equals(d.ChildServerName, StringComparison.InvariantCultureIgnoreCase) &&
                    //         obj.DatabaseName.Equals(d.ChildDatabaseName, StringComparison.InvariantCultureIgnoreCase) &&
                    //         obj.SchemaName.Equals(d.ChildSchemaName, StringComparison.InvariantCultureIgnoreCase) &&
                    //         obj.ObjectName.Equals(d.ChildObjectName, StringComparison.InvariantCultureIgnoreCase)
                    //         select d;



                    var nonExistingNextObjects = from o in _mySqlServer.SqlObjects
                                                 join d in _mySqlServer.SqlExpressionDependencies.Where(d => !d.ChildObjectExists).Where(d => d.ChildObjectId != d.ParentObjectId) on new { ServerId = o.ServerObjectId, o.DatabaseId, o.ObjectId } equals new { ServerId = d.ParentServerObjectId, DatabaseId = d.ParentDatabaseId, ObjectId = d.ParentObjectId }
                                                 where obj.ServerObjectName.Equals(d.ChildServerObjectName, StringComparison.InvariantCultureIgnoreCase) &&
                             obj.DatabaseName.Equals(d.ChildDatabaseName, StringComparison.InvariantCultureIgnoreCase) &&
                             obj.SchemaName.Equals(d.ChildSchemaName, StringComparison.InvariantCultureIgnoreCase) &&
                             obj.ObjectName.Equals(d.ChildObjectName, StringComparison.InvariantCultureIgnoreCase)
                                                       && o.ObjectType != "SYNONYM"
                                                 select o;

                    nextObjects = nextObjects.Union(nonExistingNextObjects);

                    nextSynonymObjects = from o in _mySqlServer.SqlObjects
                                         where obj.ObjectNameFull.Equals(o.BaseObjectNameFull, StringComparison.InvariantCultureIgnoreCase)
                                            && o.ObjectType == "SYNONYM"
                                         select o;
                }


                var allNextObjects = nextObjects.Union(nextSynonymObjects);

                if (allNextObjects.Any())
                    hasNextObjects = true;

                if (masterParentObject == null && allNextObjects.Any() || masterParentObject != null)
                {
                    obj.SystemId = ++refObjectId;
                    obj.SystemParentId = (masterParentObject == null) ? -1 : masterParentObject.SystemId;
                    obj.HierarchyLevel = (masterParentObject == null) ? 0 : masterParentObject.HierarchyLevel + 1;
                    obj.IsSelfReferencing = _mySqlServer.SqlExpressionDependencies.Any(d => d.ParentObjectId == obj.ObjectId && d.ParentObjectId == d.ChildObjectId) ? "Yes" : "No";

                    int nextObjectsMaxLevel = loadDependentObjects(obj, allNextObjects.ToArray(), isTopDown, ref refObjectId, level + 1);

                    if (nextObjectsMaxLevel > totalMaxLevel)
                        totalMaxLevel = nextObjectsMaxLevel;
                    if (nextObjectsMaxLevel > singleObjectMaxLevel)
                        singleObjectMaxLevel = nextObjectsMaxLevel;

                    obj.MaximumUnderlyingLevels = singleObjectMaxLevel - obj.HierarchyLevel;
                    _dependencyObjectList.Add((MySqlObject)obj.Clone());
                }

                if (level == 0)
                    LongRunningOperationManager.ReportProgress(100 * ++counter / objs.Length);
            }
            return Math.Max(totalMaxLevel, (hasNextObjects) ? level : level - 1);

            //MyOutput.NewMessage(EOutputMessageType.INFORMATION, string.Format("Done. Loaded {0:n0} dependencies in {1:0.00} seconds.", _sqlDependencyList.Count - initialNumberOfRows, (DateTime.Now - dt).TotalSeconds));
        }

       

        public void DrawObjects()
        {
            if (_dependencyObjectList.Count > 0)
            {
                LongRunningOperationManager.ReportProgress(-1);

                DateTime dt = DateTime.Now;
                MyOutput.NewMessage(EOutputMessageType.PROGRESS, string.Format("Drawing objects..."));

                this.treeListView1.Roots = _dependencyObjectList.Where(m => m.SystemParentId == -1).OrderBy(m => m.ObjectName);
                tsslObjectCount.Text = string.Format("{0:n0} total, {1:n0} root, {2:n0} dependency, {3:n0} unique", _dependencyObjectList.Count(), _dependencyObjectList.Count(d => d.HierarchyLevel == 0), _dependencyObjectList.Count(d => d.HierarchyLevel > 0), _dependencyObjectList.Distinct(new MySqlObjectEqualityComparer()).Count());

                MyOutput.AppendToLastMessage(EOutputMessageType.INFORMATION, string.Format("Done. {0:n0} objects drawn.", _dependencyObjectList.Count()), (DateTime.Now - dt).TotalSeconds);
            }
        }

        private void DependencyBrowserDockForm_Paint(object sender, PaintEventArgs e)
        {
            bool settingsChanged = false;
            if (treeListView1.AlternateRowBackColor != UserSettings.Default.AlternateRowBackColor)
            {
                treeListView1.AlternateRowBackColor = UserSettings.Default.AlternateRowBackColor;
                settingsChanged = true;
            }

            if (treeListView1.UseAlternatingBackColors != UserSettings.Default.UseAlternatingBackColors)
            {
                treeListView1.UseAlternatingBackColors = UserSettings.Default.UseAlternatingBackColors;
                settingsChanged = true;
            }

            if (treeListView1.Objects != null && settingsChanged)
                treeListView1.UpdateObjects(treeListView1.Objects.Cast<object>().ToList());
        }

        public void SetInfo(string text, Image image)
        {
            labelInfo.Text = text;
            pictureBoxInfo.Image = image;
            panelInfo.Visible = true;
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(toolStripTextBox1.Text))
            {
                TextMatchFilter filter = new TextMatchFilter(this.treeListView1, toolStripTextBox1.Text);
                this.treeListView1.DefaultRenderer = new HighlightTextRenderer(filter);
                this.treeListView1.TreeColumnRenderer.Filter = filter;
                toolStripTextBox1.BackColor = Color.Yellow;
            }
            else
            {
                this.treeListView1.DefaultRenderer = null;
                this.treeListView1.TreeColumnRenderer.Filter = null;
                toolStripTextBox1.BackColor = SystemColors.Window;
            }

            if (treeListView1.Objects != null)
                treeListView1.UpdateObjects(treeListView1.Objects.Cast<object>().ToList());
        }





    }


}
