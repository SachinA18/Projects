using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApplication1
{
    public partial class RetryExitMessageBox : Form
    {
        public RetryExitMessageBox()
        {
            InitializeComponent();
        }

        #region Variables
        public static RetryExitMessageBox MsgBox;
        public static DialogResult result;
        #endregion
        public static DialogResult Show(string text, string title)
        {
            MsgBox = new RetryExitMessageBox();
            SystemSounds.Beep.Play();
            MsgBox.lblMessage.Text = text;
            MsgBox.lblTitle.Text = title;
            MsgBox.pictureBox1.Image = SystemIcons.Error.ToBitmap();
            
            MsgBox.ShowDialog();
            return result;
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            timer2.Start();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .2;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity == 0)
            {
                timer2.Stop();
                this.Hide();
            }
            Opacity -= .2;
        }
        
    }
}
