using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class LoadingForm : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,    
            int nTopRect,     
            int nRightRect,   
            int nBottomRect,  
            int nWidthEllipse,
            int nHeightEllipse
        );

        public LoadingForm()
        {
            InitializeComponent();
            //DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            
        }


        public bool isConnectionSuccess = false;


        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .2;
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            backgroundWorker1.RunWorkerAsync();  
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
                 try
                 {
                     
                     WebClient client = new WebClient();
                     //string downloadString1 = client.DownloadString("https://jsonplaceholder.typicode.com/users");
                     //string downloadString2 = client.DownloadString("http://192.168.4.1/data1.txt");

                     //textbox1.Text = downloadString1;
                     //textBox2.Text = downloadString2;

                     Thread.Sleep(4000);
                     isConnectionSuccess = true;
                     this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
                 }
                 catch (WebException)
                 {
                     this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
                 }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            if (isConnectionSuccess)
            {
                DashboardForm dash = new DashboardForm();
                timer2.Start();
                
                dash.FormClosed += (s, args) => this.Close();
                dash.Show();
                dash.Focus();
            }
            else
            {
                RetryExitMessageBox.Show("GasMonitor Wifi isn't Connected.\nPlease Reconnect and Try again", "Connection Error!");

                DialogResult res = RetryExitMessageBox.MsgBox.DialogResult;

                if (res == DialogResult.Retry)
                {
                    timer3.Start();
                }
                else if (res == DialogResult.Abort)
                {
                    timer4.Start();
                }
            }  
            
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

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (Opacity == 0)
            {
                timer3.Stop();
                Application.Restart();
            }
            Opacity -= .2;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (Opacity == 0)
            {
                Application.Exit();
            }
            Opacity -= .2;
        }
    }
}
