using AdvancedSqlServerDependencies.CustomOutput;
using WeifenLuo.WinFormsUI.Docking;

namespace AdvancedSqlServerDependencies.DockForms
{
    public partial class OutputDockForm : DockContent
    {
        public OutputDockForm()
        {
            InitializeComponent();

            //olvColumnMessageType.ImageGetter = delegate(object x)
            //{
            //    return ((MyOutputMessage)x).Image;
            //};

            olvColumnMessageType.AspectGetter = delegate(object x)
            {
                return ((MyOutputMessage)x).OutputMessageType;
            };
            olvColumnMessageType.AspectToStringConverter = delegate(object x)
            {
                return string.Empty;
            };
            olvColumnMessageType.ImageGetter = delegate(object x)
            {
                return ((MyOutputMessage)x).Image;
            };
        }

        private void OutputDockForm_Resize(object sender, System.EventArgs e)
        {
            olvColumnMessageDescription.Width = objectListView1.Width - olvColumnMessageType.Width - olvColumnMessageTimestamp.Width - olvColumnDuration.Width - 5;
        }
    }
}
