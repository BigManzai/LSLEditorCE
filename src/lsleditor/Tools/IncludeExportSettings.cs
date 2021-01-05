using System.Windows.Forms;

namespace LSLEditor.Tools
{
	public partial class IncludeExportSettings : UserControl, ICommit
    {
        public IncludeExportSettings()
        {
            InitializeComponent();
            checkBox1.Checked = Properties.Settings.Default.ShowIncludeMetaData;
        }

        public void Commit()
        {
            Properties.Settings.Default.ShowIncludeMetaData = checkBox1.Checked;
        }
    }
}