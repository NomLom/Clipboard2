using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClipboardCycle
{
    public partial class Form1 : Form
    {
        private string[] clipboardContents = new string[4];
        private int currentIndex = 0;
        private System.Windows.Forms.Timer clipboardMonitorTimer;
        private string lastClipboardText;

        public Form1()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            clipboardMonitorTimer = new System.Windows.Forms.Timer();
            clipboardMonitorTimer.Interval = 100;
            clipboardMonitorTimer.Tick += ClipboardMonitorTimer_Tick;
            clipboardMonitorTimer.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            clipboardMonitorTimer.Stop();
            clipboardMonitorTimer.Dispose();
        }

        private void ClipboardMonitorTimer_Tick(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string currentClipboardText = Clipboard.GetText();

                if (currentClipboardText != lastClipboardText)
                {
                    lastClipboardText = currentClipboardText;
                    clipboardContents[currentIndex] = currentClipboardText;
                    currentIndex = (currentIndex + 1) % clipboardContents.Length;
                    UpdateTextBoxContent();
                }
            }
        }

        private void UpdateTextBoxContent()
        {
            textBox1.Text = clipboardContents[0] ?? string.Empty;
            textBox2.Text = clipboardContents[1] ?? string.Empty;
            textBox3.Text = clipboardContents[2] ?? string.Empty;
            textBox4.Text = clipboardContents[3] ?? string.Empty;
        }

    }
}
