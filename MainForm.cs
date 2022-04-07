using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace ShortTimeMemo
{
    public partial class MainForm : Form
    {
        public int height = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            if (File.Exists("savedata"))
            {
                StreamReader streamReader = new StreamReader("savedata");
                textBox.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += new EventHandler(Timer_Tick);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            toolStripStatusLabel.Text = dateTime.ToString("yyyy/MM/dd HH:mm:ss");
            if (height != Size.Height)
            {
                height = Size.Height;
                int textWidth = textBox.Size.Width;
                textBox.Size = new Size(textWidth, height - 64);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter("savedata", false, Encoding.GetEncoding("UTF-8"));
            streamWriter.Write(textBox.Text);
            streamWriter.Close();
        }

        private void cutMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void pasteMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void versionMenuItem_Click(object sender, EventArgs e)
        {
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            string version = fileVersionInfo.FileVersion;
            string copyright = fileVersionInfo.LegalCopyright;
            MessageBox.Show(Text + "\nVersion " + version + "\n\n" + copyright + "\nLicensed under the MIT License");
        }
    }
}
