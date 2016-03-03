using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace QuickSMS
{
    public partial class Activation : Form
    {
        public bool Suc = false;
        private bool devFlag = false;
        public Activation(bool developerFlag)
        {
            InitializeComponent();
            devFlag = developerFlag;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim().Length == 0)
            {
                label2.ForeColor = Color.Red;
                txtUser.Focus();
                return;
            }
            String user = txtUser.Text.Trim();
            WebClient wc=new WebClient();
            String website = "http://activation.wcodez.com/smsapp.php";
            if (isControl)
            {
                website = "http://localhost/act.php";
            }
            Uri uri = new Uri(website+"?uid=" + user);
            Cursor = Cursors.WaitCursor;
            btnCancel.Enabled = btnGo.Enabled = txtUser.Enabled = false;
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            wc.DownloadStringAsync(uri);
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(this, "Internet connection error :: " + e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            if (!e.Cancelled && e.Result != null)
            {
                if (e.Result.Contains(txtUser.Text + " "))
                {
                    StreamWriter sw = new StreamWriter(File.Open(Application.ExecutablePath + ".act", FileMode.Create));
                    double datetime = File.GetCreationTime(Application.ExecutablePath).ToOADate();
                    sw.WriteLine(StringSecurity.Encrypt(datetime.ToString() + "," + txtUser.Text.Trim() + "," + txtUser.Text.Trim(), "9722505033"));
                    sw.Close();
                    Application.Restart();
                }
            }
            btnCancel.Enabled = btnGo.Enabled = txtUser.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Activation_Load(object sender, EventArgs e)
        {
            Visible = false;
        }

        public bool setSerialNumber()
        {
            bool flag = false;
            try
            {
                Process proc = new Process();
                proc.StartInfo = new ProcessStartInfo("cmd", "/c " + "wmic diskdrive get serialnumber");
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.OutputDataReceived += new DataReceivedEventHandler(proc_OutputDataReceived);
                proc.Start();
                flag = true;
                proc.BeginOutputReadLine();
                proc.WaitForExit();
                txtUser.Text = ToNumbers(StringSecurity.Encrypt(serialNumber, "9722505033"));
                if (devFlag)
                    MessageBox.Show(serialNumber);
            }
            catch (Exception) { flag = false; }
            return flag;
        }

        private String ToNumbers(String data)
        {
            String ret = "";
            foreach (char ch in data)
            {
                ret += (int)ch;
            }
            return ret;
        }

        private String serialNumber = "";
        private bool getSerial = false;
        void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) return;
            if (e.Data.Trim().ToLower().Contains("serial"))
            {
                getSerial = true;
            }
            if (getSerial && e.Data.Trim().Length > 0)
            {
                serialNumber = e.Data.Trim().ToLower();
            }
        }

        private void Activation_Shown(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (File.Exists(Application.ExecutablePath + ".act"))
            {
                String oa = File.GetCreationTime(Application.ExecutablePath).ToOADate().ToString();
                String coa = File.ReadAllText(Application.ExecutablePath + ".act");
                if (coa.Trim().Length != 0)
                {
                    coa = StringSecurity.Decrypt(coa, "9722505033");
                    String[] arr = coa.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (arr.Length == 3)
                    {
                        String foa = arr[0];
                        String user = arr[1];
                        String sn = arr[2];
                        String tmpStr = ToNumbers(StringSecurity.Encrypt(serialNumber, "9722505033"));
                        if (oa.Equals(foa) && tmpStr.Equals(sn))
                        {
                            Suc = true;
                            Close();
                            return;
                        }
                    }
                }
            }
            this.Enabled = true;
            Visible = true;
            txtUser.Focus();
        }

        private bool isControl = false;
        private void btnGo_KeyDown(object sender, KeyEventArgs e)
        {
            isControl = e.Control;
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (serialNumber.Trim().Length == 0)
                txtUser.ReadOnly = false;
        }

    }
}