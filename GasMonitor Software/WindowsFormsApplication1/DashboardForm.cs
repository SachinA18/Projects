using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class DashboardForm : Form
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

        public DashboardForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            while (true)
            {
                WebClient client = new WebClient();
                string downloadString1 = client.DownloadString("http://192.168.4.1/data.txt");
                string downloadString2 = client.DownloadString("http://192.168.4.1/data1.txt");

                lbls1.Text = downloadString1;
                lbls2.Text = downloadString2;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .2;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    
    }
}
