using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ShortTimeMemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            if (File.Exists("savedata"))
            {
                StreamReader streamReader = new StreamReader("savedata");
                textBox1.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter("savedata", false, Encoding.GetEncoding("UTF-8"));
            streamWriter.Write(textBox1.Text);
            streamWriter.Close();
        }
    }
}
