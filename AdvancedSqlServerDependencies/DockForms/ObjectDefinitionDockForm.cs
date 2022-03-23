using System;
using System.Diagnostics;
using System.IO;
using AdvancedSqlServerDependencies.MySqlObjects;
using AdvancedSqlServerDependencies.Properties;
using AdvancedSqlServerDependencies.Util;
using WeifenLuo.WinFormsUI.Docking;
using System.Windows;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using AdvancedSqlServerDependencies.SqlServer.Metadata;
using AdvancedSqlServerDependencies.SqlServer;

namespace AdvancedSqlServerDependencies.DockForms
{
    public partial class ObjectDefinitionDockForm : DockContent
    {
        private MySqlObject _mySqlObject;
        private MySqlServer _mySqlServer;
        //private const string _unknownObjectName = "Object not selected.";

        private string _previousHighlightText;
        private Color _defaultSelectionColor;
        private Font _defaultSelectionFont;

        private List<int> _highlightTextIndexesList = new List<int>();

        private bool _isBusy = false;

        public ObjectDefinitionDockForm(ref MySqlServer mySqlServer)
        {
            InitializeComponent();

            _mySqlServer = mySqlServer;

            this.richTextBoxObjectName.Text = AppSettings.Default.NoObjectSelectedDefaultText;
            this.Enabled = false;

            _defaultSelectionColor = richTextBoxObjectDef.SelectionColor;
            _defaultSelectionFont = richTextBoxObjectDef.Font;
        }

        public void SetObject(MySqlObject mySqlObject)
        {
            this.Enabled = mySqlObject != null;

            if (mySqlObject != null)
            {
                this._mySqlObject = mySqlObject;
                richTextBoxObjectName.Rtf = mySqlObject.Rtf;

                //string od = mySqlObject.GetObjectDefinition(ref _mySqlServer);
                string od = mySqlObject.ObjectDefinition;
                richTextBoxObjectDef.Enabled = !string.IsNullOrEmpty(od);
                richTextBoxObjectDef.Text = (!string.IsNullOrEmpty(od)) ? od : "Object definition unknown";
            }
            else
            {
                this.richTextBoxObjectName.Text = AppSettings.Default.NoObjectSelectedDefaultText;
                richTextBoxObjectDef.Enabled = false;
                richTextBoxObjectDef.Text = string.Empty;
            }
        }



        //private void highlight()
        //{
        //    _isBusy = true;

        //    this.richTextBoxObjectDef.TextChanged -= new System.EventHandler(this.objectDefinitionOrSearchPhrase_TextChanged);

        //    tstbHighlightText.BackColor = string.IsNullOrEmpty(tstbHighlightText.Text) ? System.Drawing.SystemColors.Window : Color.Yellow;
        //    tslMatchesCount.Visible = !string.IsNullOrEmpty(tstbHighlightText.Text);

        //    int len = richTextBoxObjectDef.TextLength;
        //    int index = 0;
        //    int lastIndex;
        //    int counter = 0;

        //    // Clear current highlights if exists
        //    Console.WriteLine("Cleaning...");
        //    counter = 0;
        //    if (!string.IsNullOrEmpty(_previousHighlightText))
        //    {
        //        lastIndex = richTextBoxObjectDef.Text.LastIndexOf(_previousHighlightText, StringComparison.InvariantCultureIgnoreCase);
        //        if (lastIndex > _previousLastVisibleCharIndex)
        //            lastIndex = _previousLastVisibleCharIndex;

        //        index = (_previousFirstVisibleCharIndex > 0) ? _previousFirstVisibleCharIndex : 0;

        //        while (index <= lastIndex)
        //        {
        //            richTextBoxObjectDef.Find(_previousHighlightText, index, len, RichTextBoxFinds.None);
        //            richTextBoxObjectDef.SelectionBackColor = DefaultBackColor;
        //            //richTextBoxObjectDef.SelectionColor = _defaultSelectionColor;
        //            //richTextBoxObjectDef.SelectionFont = _defaultSelectionFont;
        //            index = richTextBoxObjectDef.Text.IndexOf(_previousHighlightText, index, StringComparison.InvariantCultureIgnoreCase) + 1;

        //            counter++;
        //        }

        //        Console.WriteLine("Cleaned highlights for {0} items.", counter);
        //    }



        //    int firstVisibleCharIndex = richTextBoxObjectDef.GetCharIndexFromPosition(new System.Drawing.Point(0, 0));
        //    int lastVisibleCharIndex = richTextBoxObjectDef.GetCharIndexFromPosition(new System.Drawing.Point(richTextBoxObjectDef.ClientSize.Width, richTextBoxObjectDef.ClientSize.Height));



        //    Console.WriteLine("Highlighting...");
        //    counter = 0;
        //    if (!string.IsNullOrEmpty(tstbHighlightText.Text))
        //    {

        //        lastIndex = richTextBoxObjectDef.Text.LastIndexOf(tstbHighlightText.Text, StringComparison.InvariantCultureIgnoreCase);
        //        if (lastIndex > lastVisibleCharIndex)
        //            lastIndex = lastVisibleCharIndex;

        //        index = (firstVisibleCharIndex > 0) ? firstVisibleCharIndex : 0;

        //        while (index <= lastIndex)
        //        {
        //            richTextBoxObjectDef.Find(tstbHighlightText.Text, index, len, RichTextBoxFinds.None);
        //            richTextBoxObjectDef.SelectionBackColor = Color.Yellow;
        //            //richTextBoxObjectDef.SelectionColor = Color.Red;
        //            //richTextBoxObjectDef.SelectionFont = new System.Drawing.Font(_defaultSelectionFont, System.Drawing.FontStyle.Bold);
        //            index = richTextBoxObjectDef.Text.IndexOf(tstbHighlightText.Text, index, StringComparison.InvariantCultureIgnoreCase) + 1;
        //            counter++;
        //        }

        //        Console.WriteLine("Drawn highlights for {0} items.", counter);
        //    }

        //    _previousHighlightText = tstbHighlightText.Text;



        //    this.richTextBoxObjectDef.TextChanged += new System.EventHandler(this.objectDefinitionOrSearchPhrase_TextChanged);

        //    _previousFirstVisibleCharIndex = firstVisibleCharIndex;
        //    _previousLastVisibleCharIndex = lastVisibleCharIndex;

        //    _isBusy = false;
        //}


        private void objectDefinitionOrSearchPhrase_TextChanged(object sender, EventArgs e)
        {
            int index = 0;

            _previousHighlightText = string.Empty;
            tslMatchesCount.Visible = !string.IsNullOrEmpty(tstbHighlightText.Text);

            _highlightTextIndexesList.Clear();

            var s = richTextBoxObjectDef.Text;
            if (!string.IsNullOrEmpty(tstbHighlightText.Text))
            {
                int lastIndex = s.LastIndexOf(tstbHighlightText.Text, StringComparison.InvariantCultureIgnoreCase);

                while (index <= lastIndex)
                {
                    index = s.IndexOf(tstbHighlightText.Text, index, StringComparison.InvariantCultureIgnoreCase);
                    _highlightTextIndexesList.Add(index);
                    index++;
                }

                tslMatchesCount.Text = string.Format("{0} matches found.", _highlightTextIndexesList.Count);
            }

            toolStripStatusLabel1.Text = string.Format("{0:n0} lines", richTextBoxObjectDef.Lines.Count().ToString());
            toolStripStatusLabel2.Text = string.Format("{0:n0} characters", richTextBoxObjectDef.TextLength.ToString());
        }

        private void toolStripButtonWrapText_Click(object sender, EventArgs e)
        {
            if (!richTextBoxObjectDef.WordWrap)
            {
                toolStripButtonWrapText.CheckState = CheckState.Checked;
                richTextBoxObjectDef.WordWrap = true;
            }
            else
            {
                toolStripButtonWrapText.CheckState = CheckState.Unchecked;
                richTextBoxObjectDef.WordWrap = false;
            }
        }

        private void tsbFindNext_Click(object sender, EventArgs e)
        {
            _isBusy = true;

            int nextIndex = -1;

            if (!richTextBoxObjectDef.Focused)
                richTextBoxObjectDef.Focus();


            int ss = richTextBoxObjectDef.SelectionStart;
            int firstVisibleCharIndex = richTextBoxObjectDef.GetCharIndexFromPosition(new System.Drawing.Point(0, 0));
            int ii = (ss < 0) ? firstVisibleCharIndex : ss;

            foreach (int i in _highlightTextIndexesList)
            {
                if (i > ii)
                {
                    nextIndex = i;
                    break;
                }
            }

            if (nextIndex == -1 && _highlightTextIndexesList.Count > 0)
                nextIndex = _highlightTextIndexesList[0];

            if (nextIndex >= 0)
            {
                richTextBoxObjectDef.SelectionStart = nextIndex;
                richTextBoxObjectDef.ScrollToCaret();
                richTextBoxObjectDef.SelectionLength = tstbHighlightText.Text.Length;
            }

            _isBusy = false;
        }
    }
}
