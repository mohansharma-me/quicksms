using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace QuickSMS
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "http://www.wcodez.com";
            linkLabel1.Links.Add(link);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        public bool NoExit = false;

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            if (!NoExit)
            {
                closeTimer.Enabled = true;
            }
            else
            {
                loadingCircle1.Visible = false;
            }
        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
