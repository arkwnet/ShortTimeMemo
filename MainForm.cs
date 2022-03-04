using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

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

        private void Timer_Tick(object sender, System.EventArgs e)
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
    }
}
