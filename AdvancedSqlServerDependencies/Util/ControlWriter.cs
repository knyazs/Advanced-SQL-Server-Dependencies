using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AdvancedSqlServerDependencies.DockForms;

namespace AdvancedSqlServerDependencies.Util
{
    public class ControlWriter : TextWriter
    {
        delegate void SetTextCallback(string text);

        private bool _displayTimestamp;

        private readonly TextBox _textbox;
        public ControlWriter(TextBox textbox)
        {
            this._textbox = textbox;
            _displayTimestamp = true;
        }

        public override void WriteLine(string value)
        {
            Write(value);
            Write(Environment.NewLine);
            _displayTimestamp = true;
        }

        public override void Write(string value)
        {
            string s = "";

            if (_displayTimestamp)
                s += string.Format("[{0}]: ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            s += value;

            if (this._textbox.InvokeRequired)
            {
                SetTextCallback d = Write;
                ((OutputDockForm)this._textbox.Parent).Invoke(d, value);
            }
            else
            {
                this._textbox.AppendText(s);
            }
            _displayTimestamp = false;
        }

        //public override void Write(char value)
        //{

        //}

        //public override void Write(string value)
        //{
        //    var s = string.Format("[{0}]: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), value);
        //    textbox.AppendText(s);
        //}

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
}
