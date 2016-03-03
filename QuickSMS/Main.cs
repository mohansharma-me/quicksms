using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;

namespace QuickSMS
{
    public partial class Main : Form
    {
        private bool SearchFlag = true;
        private SerialPort Port = new SerialPort();
        private ListViewColumnSorter cSorter_lvContacts,cSorter_lvGroups,cSorter_lvMessages;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Func.loadDatabase();
            cSorter_lvContacts = new ListViewColumnSorter();
            lvContacts.ListViewItemSorter = cSorter_lvContacts;
            cSorter_lvContacts.ColumnType = ColumnDataType.String;
            cSorter_lvContacts.SortColumn = 0;
            cSorter_lvContacts.Order = SortOrder.Ascending;
            lvContacts.SetSortIcon(0, SortOrder.Descending);
            lvContacts.ColumnClick += __SortOnClick_ListView_onColumnClick;
            lvContacts.Sort();

            lvFNos.ListViewItemSorter = cSorter_lvContacts;
            lvFNos.SetSortIcon(0, SortOrder.Descending);
            lvFNos.ColumnClick += __SortOnClick_ListView_onColumnClick;
            lvFNos.Sort();

            cSorter_lvGroups = new ListViewColumnSorter();
            lvGroups.ListViewItemSorter = cSorter_lvGroups;
            cSorter_lvGroups.ColumnType = ColumnDataType.String;
            cSorter_lvGroups.SortColumn = 0;
            cSorter_lvGroups.Order = SortOrder.Ascending;
            lvGroups.SetSortIcon(0, SortOrder.Descending);
            lvGroups.ColumnClick += __SortOnClick_ListView_onColumnClick;
            lvGroups.Sort();

            cSorter_lvMessages = new ListViewColumnSorter();
            lvMessages.ListViewItemSorter = cSorter_lvMessages;
            cSorter_lvMessages.ColumnType = ColumnDataType.Number;
            cSorter_lvMessages.Order = SortOrder.Ascending;
            cSorter_lvMessages.SortColumn = 0;
            lvMessages.SetSortIcon(0, SortOrder.Descending);
            lvMessages.ColumnClick += __SortOnClick_lvMessages_onColumnClick;
            lvMessages.Sort();

            Port.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
        }

        private void __SortOnClick_ListView_onColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                ListView lv = sender as ListView;

                switch (e.Column)
                {
                    case 0:
                    case 2:
                        (lv.ListViewItemSorter as ListViewColumnSorter).ColumnType = ColumnDataType.Number;
                        break;
                    default:
                        (lv.ListViewItemSorter as ListViewColumnSorter).ColumnType = ColumnDataType.String;
                        break;
                }

                if (e.Column == (lv.ListViewItemSorter as ListViewColumnSorter).SortColumn)
                {
                    // Reverse the current sort direction for this column.
                    if ((lv.ListViewItemSorter as ListViewColumnSorter).Order == System.Windows.Forms.SortOrder.Ascending)
                    {
                        lv.SetSortIcon(e.Column, SortOrder.Ascending);
                        (lv.ListViewItemSorter as ListViewColumnSorter).Order = System.Windows.Forms.SortOrder.Descending;
                    }
                    else
                    {
                        lv.SetSortIcon(e.Column, SortOrder.Descending);
                        (lv.ListViewItemSorter as ListViewColumnSorter).Order = System.Windows.Forms.SortOrder.Ascending;
                    }
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    (lv.ListViewItemSorter as ListViewColumnSorter).SortColumn = e.Column;
                    (lv.ListViewItemSorter as ListViewColumnSorter).Order = System.Windows.Forms.SortOrder.Ascending;
                    lv.SetSortIcon(e.Column, SortOrder.Descending);
                }

                // Perform the sort with these new sort options.
                lv.Sort();

            }
            catch (Exception excep)
            {

            }
        }

        private void __SortOnClick_lvMessages_onColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                ListView lv = sender as ListView;

                switch (e.Column)
                {
                    case 0:
                    case 2:
                        (lv.ListViewItemSorter as ListViewColumnSorter).ColumnType = ColumnDataType.Number;
                        break;
                    case 1:
                        (lv.ListViewItemSorter as ListViewColumnSorter).ColumnType = ColumnDataType.DateTime;
                        break;
                    default:
                        (lv.ListViewItemSorter as ListViewColumnSorter).ColumnType = ColumnDataType.String;
                        break;
                }

                if (e.Column == (lv.ListViewItemSorter as ListViewColumnSorter).SortColumn)
                {
                    // Reverse the current sort direction for this column.
                    if ((lv.ListViewItemSorter as ListViewColumnSorter).Order == System.Windows.Forms.SortOrder.Ascending)
                    {
                        lv.SetSortIcon(e.Column, SortOrder.Ascending);
                        (lv.ListViewItemSorter as ListViewColumnSorter).Order = System.Windows.Forms.SortOrder.Descending;
                    }
                    else
                    {
                        lv.SetSortIcon(e.Column, SortOrder.Descending);
                        (lv.ListViewItemSorter as ListViewColumnSorter).Order = System.Windows.Forms.SortOrder.Ascending;
                    }
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    (lv.ListViewItemSorter as ListViewColumnSorter).SortColumn = e.Column;
                    (lv.ListViewItemSorter as ListViewColumnSorter).Order = System.Windows.Forms.SortOrder.Ascending;
                    lv.SetSortIcon(e.Column, SortOrder.Descending);
                }

                // Perform the sort with these new sort options.
                lv.Sort();

            }
            catch (Exception excep)
            {

            }
        }

        void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (Port != null && Port.IsOpen && Port.CDHolding)
            {
                if (!Func.isPortData) return;
                String data = Port.ReadExisting();
                Console.WriteLine(data);
                if (data.Contains("+CMTI: "))
                {
                    String dte="";
                    Func.isPortData = false;
                    if (Func.PortCommand(Port, "AT+CMGL=\"REC UNREAD\"", ref dte,3000))
                    {
                        int msgs = Func.PortMessages(dte);
                        Action act = () => { MessageBox.Show(this, msgs + " new messages received."); };
                        try
                        {
                            try
                            {
                                Invoke(act);
                            }
                            catch (Exception) { }
                        }
                        catch (Exception) { }
                        Func.PortCommand(Port, "AT+CMGD=1,3", ref dte);
                    }
                    Func.isPortData = true;
                }
                if (data.Contains("+CDS: "))
                {
                    Func.PortCDS(data);
                }
                Func.PortData = data;
            }
            //cmti -- new message
            //cds no,+index -- delivery
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            NewContact newContact = new NewContact();
            if (cmbGroups.SelectedIndex > -1)
                newContact.setContactGroup(cmbGroups.SelectedItem as ContactGroup);
            newContact.ShowDialog(this);
            int backupIndex = cmbGroups.SelectedIndex;
            cmbGroups.SelectedIndex = -1;
            cmbGroups.SelectedIndex = backupIndex;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Func.saveDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void tabContacts_Enter(object sender, EventArgs e)
        {
            int backupIndex = cmbGroups.SelectedIndex;
            Func.loadGroups(cmbGroups);
            if (backupIndex < cmbGroups.Items.Count)
                cmbGroups.SelectedIndex = backupIndex;
        }

        private void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGroups.SelectedIndex > -1)
            {
                Func.loadContacts(lvContacts, cmbGroups.SelectedItem as ContactGroup);
            }
        }

        private void lvContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvContacts.SelectedItems.Count == 0)
            {
                btnEdit.Enabled = btnDelete.Enabled = false;
            }
            else if (lvContacts.SelectedItems.Count > 1)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = true;
            }
            else if(lvContacts.SelectedItems.Count==1)
            {
                btnEdit.Enabled = btnDelete.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvContacts.SelectedItems.Count == 1 && cmbGroups.SelectedIndex!=-1)
            { 
                NewContact editContact = new NewContact();
                editContact.setEditContact(lvContacts.SelectedItems[0].Tag as Contact, cmbGroups.SelectedItem as ContactGroup);
                if (editContact.ShowDialog(this) == DialogResult.OK)
                {
                    int backupIndex = cmbGroups.SelectedIndex;
                    cmbGroups.SelectedIndex = -1;
                    cmbGroups.SelectedIndex = backupIndex;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvContacts.SelectedItems.Count > 0 && cmbGroups.SelectedIndex!=-1)
            {
                if (MessageBox.Show(this, "Are you sure to delete all selected contacts from current contact group ?", "Delete Contacts", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<Contact> contacts = new List<Contact>();
                    foreach (ListViewItem li in lvContacts.SelectedItems)
                        contacts.Add(li.Tag as Contact);
                    if (Func.DeleteContacts(contacts, cmbGroups.SelectedItem as ContactGroup))
                    {
                        int backupIndex = cmbGroups.SelectedIndex;
                        cmbGroups.SelectedIndex = -1;
                        cmbGroups.SelectedIndex = backupIndex;

                        Func.saveDatabase();
                    }
                    else
                    {
                        MessageBox.Show(this,"Contact group not found.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void lvContacts_Leave(object sender, EventArgs e)
        {
            if (!(btnEdit.Focused || btnDelete.Focused))
            {
                btnEdit.Enabled = btnDelete.Enabled = false;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            SearchFlag = false;
            TextBox tb = sender as TextBox;
            if (tb.Text.Trim().Equals("Search..."))
                tb.Text = "";
            SearchFlag = true;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            SearchFlag = false;
            TextBox tb = sender as TextBox;
            if (tb.Text.Equals("Bypass!!"))
            {
                Func.BypassFNos = !Func.BypassFNos;
                tb.Text = "";
            }
            if (tb.Text.Trim().Length==0)
                tb.Text = "Search...";
            SearchFlag = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!SearchFlag) return;
            if (cmbGroups.SelectedIndex != -1 && !txtSearch.Text.Trim().Equals("Search..."))
            {
                Func.loadContacts(lvContacts, cmbGroups.SelectedItem as ContactGroup, txtSearch.Text.Trim());
            }
        }

        private void tabGroups_Enter(object sender, EventArgs e)
        {
            Func.loadGroups(lvGroups);
        }

        private void lvContacts_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void lvContacts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnDelete_Click(sender, e);
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            if (txtGroupName1.Text.Trim().Length == 0)
            {
                label2.ForeColor = Color.Red;
                txtGroupName1.Focus();
                return;
            }
            String name = txtGroupName1.Text.Trim();
            if (Func.ContactGroupExists(name))
            {
                label2.ForeColor = Color.Red;
                label2.Text = "Group : (Already exists!)";
                txtGroupName1.Focus();
                return;
            }

            if (Func.AddContactGroup(name))
            {
                txtGroupName1.Text = "";
                txtGroupName1.Focus();
                Func.loadGroups(lvGroups);
            }
            else
            {
                MessageBox.Show(this,"Contact group not added!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtGroupName1_TextChanged(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
            label2.Text = "Group :";
        }

        private void lvGroups_DoubleClick(object sender, EventArgs e)
        {
            if (lvGroups.SelectedItems.Count == 1)
            {
                ContactGroup cg = lvGroups.SelectedItems[0].Tag as ContactGroup;
                txtGroupName2.Text = cg.Name;
                txtGroupName2.Tag = cg;
                txtGroupName2.Focus();
            }
        }

        private void btnSaveGroup_Click(object sender, EventArgs e)
        {
            if (txtGroupName2.Tag == null) return;
            if (txtGroupName2.Text.Trim().Length == 0)
            {
                label3.ForeColor = Color.Red;
                txtGroupName2.Focus();
                return;
            }

            if (!(txtGroupName2.Tag as ContactGroup).Name.ToLower().Trim().Equals(txtGroupName2.Text.Trim().ToLower()) && Func.ContactGroupExists(txtGroupName2.Text.Trim()))
            {
                label3.Text = "Group: (Already exists!)";
                label3.ForeColor = Color.Red;
                return;
            }

            Func.UpdateContactGroup((txtGroupName2.Tag as ContactGroup).Name, txtGroupName2.Text.Trim());

            txtGroupName2.Text = "";
            txtGroupName2.Tag = null;
            Func.saveDatabase();

            Func.loadGroups(lvGroups);
        }

        private void txtGroupName2_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "Group :";
            label3.ForeColor = Color.Black;
        }

        private void lvGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGroups.SelectedItems.Count > 0)
            {
                btnDeleteGroups.Enabled = btnImportOpen.Enabled = btnExportEXL.Enabled = true;
            }
            else
            {
                btnDeleteGroups.Enabled = btnImportOpen.Enabled = btnExportEXL.Enabled = false;
            }
        }

        private void lvGroups_Leave(object sender, EventArgs e)
        {
            if (!(btnDeleteGroups.Focused || btnImportOpen.Focused))
            {
                btnDeleteGroups.Enabled = btnImportOpen.Enabled = false;
            }
        }

        private void btnDeleteGroups_Click(object sender, EventArgs e)
        {
            if (lvGroups.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Are you sure to delete all selected contact groups with its all contact members ?", "Delete Contact Groups", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<ContactGroup> contactGroups = new List<ContactGroup>();
                    foreach (ListViewItem li in lvGroups.SelectedItems)
                        contactGroups.Add(li.Tag as ContactGroup);
                    if (Func.DeleteContactGroups(contactGroups))
                    {
                        Func.loadGroups(lvGroups);
                    }
                    else
                    {
                        MessageBox.Show(this,"Contact groups not deleted!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtGroupSearch_TextChanged(object sender, EventArgs e)
        {
            if (!SearchFlag) return;
            if (!txtGroupSearch.Text.Trim().Equals("Search..."))
            {
                Func.loadGroups(lvGroups, txtGroupSearch.Text.Trim());
            }
        }

        private void btnImportOpen_Click(object sender, EventArgs e)
        {
            if (lvGroups.SelectedItems.Count != 1) return;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV File|*.csv|Text files|*.txt|All files|*.*";
            ofd.Title = "Open CSV file...";
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    String[] lines = File.ReadAllLines(ofd.FileName);
                    this.Enabled = false;
                    ContactGroup contactGroup = lvGroups.SelectedItems[0].Tag as ContactGroup;
                    foreach (String line in lines)
                    {
                        if (line.Split(new String[] { "," }, StringSplitOptions.None).Length >= 2)
                        {
                            int noIndex = line.LastIndexOf(",");
                            String name = line.Substring(0, noIndex);
                            String number = line.Substring(noIndex + 1);
                            long no = 0;
                            if (long.TryParse(number, out no))
                            {
                                Contact contact = new Contact();
                                contact.Name = name;
                                contact.Number = no;

                                if (!Func.ContactExists(contact, contactGroup, false))
                                {
                                    Func.AddContactToGroup(contact, contactGroup);
                                }
                            }
                        }
                    }
                    int backupIndex = lvGroups.SelectedIndices[0];
                    Func.loadGroups(lvGroups);
                    if (backupIndex < lvGroups.SelectedItems.Count)
                        lvGroups.Items[backupIndex].Selected = true;
                    this.Enabled = true;
                }
                catch (Exception) { }
            }
        }

        private void txtRWTimeout_KeyDown(object sender, KeyEventArgs e)
        {
            Control ctrl = sender as Control;
            if ((!e.Shift && e.KeyValue >= (int)'0' && e.KeyValue <= (int)'9') || e.KeyCode==Keys.Left || e.KeyCode==Keys.Right || (e.Control && (e.KeyCode==Keys.C || e.KeyCode==Keys.V)))
            {
                e.SuppressKeyPress = false;
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }

        private void btnRefreshmodem_Click(object sender, EventArgs e)
        {
            cmbModems.Items.Clear();
            btnRefreshmodem.Enabled = false;
            ThreadStart tsRefershModem = new ThreadStart(() => {
                try
                {
                    Func.isPortData = false;
                    String[] ports = SerialPort.GetPortNames();
                    foreach (String portname in ports)
                    {
                        try
                        {
                            SerialPort port = new SerialPort();
                            port.PortName = portname;
                            port.BaudRate = 9600;
                            port.DataBits = 8;
                            port.Parity = Parity.None;
                            port.StopBits = StopBits.One;
                            port.RtsEnable = true;
                            port.DtrEnable = true;
                            port.Handshake = Handshake.RequestToSend;
                            port.ReceivedBytesThreshold = 1;
                            port.NewLine = Environment.NewLine;
                            port.ReadTimeout = port.WriteTimeout = 4000;
                            port.Open();
                            String dte = "";
                            if (port.IsOpen && port.CDHolding)
                            {
                                if (Func.PortCommand(port, "AT",ref dte))
                                {
                                    if (Func.PortCommand(port, "ATI", ref dte))
                                    {
                                        String mfg = "", model = "", imei = "";
                                        String[] lines = dte.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                                        foreach (String line in lines)
                                        {
                                            if (line.Contains("Manufacturer:"))
                                            {
                                                mfg = line.Replace("Manufacturer:", "").Replace(" ", "").Trim();
                                            }
                                            if (line.Contains("Model:"))
                                            {
                                                model = line.Replace("Model:", "").Replace(" ", "").Trim();
                                            }
                                            if (line.Contains("IMEI:"))
                                            {
                                                imei = line.Replace("IMEI:", "").Replace(" ", "").Trim();
                                            }
                                        }

                                        if (mfg.Length > 0 && model.Length > 0 && imei.Length > 0 || (lines.Length==3))
                                        {
                                            if (lines.Length == 3)
                                            {
                                                mfg = lines[1];
                                                imei = portname;
                                            }
                                            String name = mfg + " " + model + " ("+imei+")";
                                            threadRefresh_AddPortTo_cmbModems(name, portname);
                                        }

                                    }
                                }
                            }

                            port.Close();
                        }
                        catch (Exception) { }
                    }
                }
                catch (ThreadAbortException) { }
                Func.isPortData = true;
                try
                {
                    threadRefresh_EnableRefreshButton();
                }
                catch (Exception) { }
            });
            Thread threadRefersh = new Thread(tsRefershModem);
            threadRefersh.Name = "RefreshModem";
            threadRefersh.Start();
        }

        private void threadRefresh_EnableRefreshButton()
        {
            Action a = () => {
                btnRefreshmodem.Enabled = true;
            };
            try
            {
                Invoke(a);
            }
            catch (Exception) { }
        }

        private void threadRefresh_AddPortTo_cmbModems(String name,String port)
        {
            Action a = () => {
                Item item = new Item();
                item.Name = name;
                item.Value = port;
                bool flag = true;
                foreach (Item it in cmbModems.Items)
                {
                    if (it.Name.Trim().ToLower().Equals(name.ToLower().Trim()))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    cmbModems.Items.Add(item);
            };
            try
            {
                Invoke(a);
            }
            catch (Exception) { }
        }

        private void tabUSBModem_Enter(object sender, EventArgs e)
        {
            cmbBaudRate.SelectedIndex = 3;
        }

        private void btnConnectUSB_Click(object sender, EventArgs e)
        {
            if (btnConnectUSB.Text.Equals("&Disconnect"))
            {
                timerModemVerifier.Stop();
                if (Port.IsOpen)
                {
                    Port.Close();
                }
                btnConnectUSB.Enabled = btnRefreshmodem.Enabled = cmbModems.Enabled = true;
                btnConnectUSB.Text = "&Connect";
                tbModem.Text = "Disconnected";
                tbSignals.Text = "";
                tbSents.Text = "";
                return;
            }

            if (cmbModems.SelectedIndex == -1) return;

            ParameterizedThreadStart threadStart = new ParameterizedThreadStart((obj) =>
            {
                object[] objArr = (object[])obj;
                String portname = objArr[0].ToString();

                Port.PortName = portname;
                Port.BaudRate = int.Parse(objArr[1].ToString());
                Port.DataBits = int.Parse(objArr[2].ToString());
                Port.Parity = Parity.None;
                Port.StopBits = StopBits.One;
                Port.RtsEnable = true;
                Port.DtrEnable = true;
                Port.Handshake = Handshake.RequestToSend;
                Port.ReceivedBytesThreshold = 1;
                Port.NewLine = Environment.NewLine;
                Port.ReadTimeout = Port.WriteTimeout = int.Parse(objArr[1].ToString()) * 1000;

                try
                {
                    Port.Open();
                }
                catch (Exception) {
                    threadErrorMessage("Can not open port.");
                }

                if (Port.IsOpen)
                {
                    String dte = "";
                    if (Func.PortCommand(Port, "AT", ref dte))
                    {
                        Func.PortCommand(Port, "AT+CREG=0", ref dte);
                        if (Func.PortCommand(Port, "AT+CREG?", ref dte))
                        {
                            Func.NetworkStatus nstatus = Func.PortCREG(dte);
                            if (nstatus == Func.NetworkStatus.NOT_REGISTERED || nstatus == Func.NetworkStatus.ERROR || nstatus == Func.NetworkStatus.DENIED || nstatus == Func.NetworkStatus.UNKNOWN)
                            {
                                threadErrorMessage("Network initilization failed. :: " + nstatus.ToString());
                            }
                            Func.PortCommand(Port, "AT+CFUN=1", ref dte);
                            if (Func.PortCommand(Port, "AT+CMGF=1", ref dte) && Func.PortCommand(Port, "AT+CSCS=\"GSM\"", ref dte))
                            {
                                bool deliveryEnable = false;
                                //Func.PortCommand(Port, "AT+CNMI=1", ref dte);
                                if (Func.PortCommand(Port, "AT+CSMP=49,167,0,0", ref dte) && Func.PortCommand(Port, "AT+CNMI=1", ref dte)) // AT+CNMI=0,1,0,1,0
                                {
                                    deliveryEnable = true;
                                }
                                else
                                {
                                    deliveryEnable = false;
                                }

                                if (!deliveryEnable)
                                {
                                    threadErrorMessage("Cant enable delivery reports.",false);
                                    //Port.Close();
                                }

                                Action act = () =>
                                {
                                    timerModemVerifier.Start();
                                };
                                try
                                {
                                    Invoke(act);
                                }
                                catch (Exception) { }
                            }
                            else
                            {
                                threadErrorMessage("Cant set modem to GSM mode.");
                            }
                        }
                        else
                        {
                            threadErrorMessage("No sim card.");
                        }
                    }
                    else
                    {
                        threadErrorMessage("USB modem is not responding.");
                    }
                }
                else
                {
                    threadErrorMessage("Cant access modem port.");
                }

                Action actSuc = () => {
                    btnConnectUSB.Text = "&Disconnect";
                    btnConnectUSB.Enabled = true;
                    btnRefreshmodem.Enabled = cmbModems.Enabled = false;
                };

                Action actEnable = () => {
                    btnConnectUSB.Enabled = cmbModems.Enabled = true;
                };
                if (!Port.IsOpen || !Port.CDHolding)
                    try
                    {
                        Invoke(actEnable);
                    }
                    catch (Exception) { }
                else
                    try
                    {
                        Invoke(actSuc);
                    }
                    catch (Exception) { }
            });
            tbSents.Text = "";
            btnConnectUSB.Enabled = cmbModems.Enabled = false;
            Thread threadConnect=new Thread(threadStart);
            object[] oarr = new object[4];
            oarr[0] = (cmbModems.SelectedItem as Item).Value.ToString();
            oarr[1] = cmbBaudRate.Text;
            oarr[2] = txtDatabits.Text.Trim();
            oarr[3] = txtRWTimeout.Text.Trim();
            threadConnect.Start(oarr);
        }

        private void threadErrorMessage(String message,bool closeDefaults=true)
        {
            Action ac = () =>
            {
                if (closeDefaults && Port.IsOpen)
                    Port.Close();
                MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            try
            {
                Invoke(ac);
            }
            catch (Exception) { }
        }

        private void timerModemVerifier_Tick(object sender, EventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(() => {

                if (Port!=null && Port.IsOpen && (Port.CDHolding || Port.CtsHolding))
                {
                    String dte="";
                    if (Func.PortCommand(Port, "at+creg?", ref dte))
                    {
                        Func.NetworkStatus nst=Func.PortCREG(dte);
                        if (nst == Func.NetworkStatus.REGISTERED)
                        {

                            if (Func.PortCommand(Port, "at+csq", ref dte))
                            {
                                String simOperator="";
                                int per = Func.PortCSQ(dte);
                                if (Func.PortCommand(Port, "AT+COPS=0,1", ref dte) && Func.PortCommand(Port,"AT+COPS?",ref dte))
                                {
                                    simOperator = Func.PortOperator(dte);
                                }
                                Action act = () => {
                                    String conn = "";
                                    if (simOperator.Trim().Length != 0)
                                    {
                                        conn = " (" + simOperator + ") ";
                                    }
                                    tbSignals.Text = "Signal" + conn + ": " + per + "%";
                                    tbModem.Text = "Connected!!";
                                };
                                try
                                {
                                    Invoke(act);
                                }
                                catch (Exception) { }
                            }
                        }
                        else if (nst == Func.NetworkStatus.NOT_REGISTERED_SEARCHING)
                        {
                            Action act = () => { tbSignals.Text = "Searching network..."; };
                            try
                            {
                                Invoke(act);
                            }
                            catch (Exception) { }
                        }
                        else
                        {
                            Action act = () => {
                                btnConnectUSB.Text = "&Disconnect";
                                btnConnectUSB_Click(btnConnectUSB, new EventArgs());
                                MessageBox.Show(this,"USB Modem disconnected.");
                                tbSignals.Text = "No signals!!";
                                tbModem.Text = "Modem disconnected!!";
                            };
                            try
                            {
                                Invoke(act);
                            }
                            catch (Exception) { }
                        }
                    }
                }
                else
                {
                    Action act = () =>
                    {
                        /*if (!Port.IsOpen || !Port.CDHolding)
                        {
                            //Port.Close();
                            Port.Open();*/
                            if (!Port.IsOpen)
                            {
                                btnConnectUSB.Text = "&Disconnect";
                                btnConnectUSB_Click(btnConnectUSB, new EventArgs());
                                MessageBox.Show(this, "USB Modem disconnected.");
                                tbSignals.Text = "No signals!!";
                                tbModem.Text = "Modem disconnected!!";
                            }
                        //}
                    };
                    try
                    {
                        Invoke(act);
                    }
                    catch (Exception) { }
                }
            });

            Thread threadScanmodem = new Thread(threadStart);
            if(!sendingMessages)
            threadScanmodem.Start();
            
            if (timerModemVerifier.Interval == 100)
                timerModemVerifier.Interval = 5000;
        }

        private void radInbox_CheckedChanged(object sender, EventArgs e)
        {
            Func.loadMessages(lvMessages, Func.MessageType.INBOX);
        }

        private void radSent_CheckedChanged(object sender, EventArgs e)
        {
            Func.loadMessages(lvMessages, Func.MessageType.SENT);
        }

        private void radOutbox_CheckedChanged(object sender, EventArgs e)
        {
            Func.loadMessages(lvMessages, Func.MessageType.OUTBOX);
        }

        private void ListView_MouseClick(object sender, MouseEventArgs e)
        {
            if ((sender as ListView).SelectedItems.Count > 0 && e.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                MenuItem mi = new MenuItem("&Add to Compose", ListView_RightClickAction);
                mi.Tag = sender;
                cm.MenuItems.Add(mi);

                MenuItem mi1 = new MenuItem("&Copy to", ListView_RightClickAction);
                mi1.Tag = sender;
                cm.MenuItems.Add(mi1);

                cm.Show(sender as Control, e.Location);
            }
        }

        private void ListView_RightClickAction(object sender,EventArgs e)
        {
            MenuItem mi=sender as MenuItem;
            if (mi.Text.StartsWith("&Add to Compose") && mi.Tag is ListView)
            {
                ListView lv = mi.Tag as ListView;
                if (lv.SelectedItems.Count > 0)
                {
                    if (lv.SelectedItems[0].Tag is Contact)
                    {
                        foreach (ListViewItem li in lv.SelectedItems)
                        {
                            Func.AddContactToFNOS(lvFNos, li.Tag as Contact);
                        }
                    }
                    if (lv.SelectedItems[0].Tag is ContactGroup)
                    {
                        foreach (ListViewItem li in lv.SelectedItems)
                        {
                            ContactGroup cgt = li.Tag as ContactGroup;
                            foreach (Contact ct in cgt.Contacts)
                            {
                                Func.AddContactToFNOS(lvFNos, ct);
                            }
                        }
                    }
                }
            }
            else if (mi.Text.StartsWith("&Copy to"))
            {
                ListView lv = mi.Tag as ListView;
                if (lv.SelectedItems.Count > 0)
                {
                    ContactGroupSelector cgs = new ContactGroupSelector();
                    if (cgs.ShowDialog(this) == DialogResult.OK && cgs.contactGroup!=null)
                    {
                        ContactGroup dest = cgs.contactGroup;
                        if (lv.SelectedItems[0].Tag is Contact)
                        {
                            //List<Contact> deleteContacts = new List<Contact>();
                            foreach (ListViewItem li in lv.SelectedItems)
                            {
                                Func.AddContactToGroup(li.Tag as Contact, dest);
                                //deleteContacts.Add(li.Tag as Contact);
                            }
                            //Func.DeleteContacts(deleteContacts, cmbGroups.SelectedItem as ContactGroup);
                            Func.saveDatabase();
                            Func.loadContacts(lvContacts, cmbGroups.SelectedItem as ContactGroup);
                            MessageBox.Show(this, "Copy successfull.", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (lv.SelectedItems[0].Tag is ContactGroup)
                        {
                            foreach (ListViewItem li in lv.SelectedItems)
                            {
                                ContactGroup cgt = li.Tag as ContactGroup;
                                foreach (Contact ct in cgt.Contacts)
                                {
                                    Func.AddContactToGroup(ct, dest);
                                    //Func.DeleteContacts(new Contact[] { ct }.ToList<Contact>(), cgt);
                                }
                            }
                            Func.saveDatabase();
                            Func.loadGroups(lvGroups);
                            MessageBox.Show(this, "Copy successfull.", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void lvFNos_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvFNos.SelectedItems.Count > 0 && e.KeyCode==Keys.Enter)
            {
                List<int> indexs = new List<int>();
                foreach (ListViewItem li in lvFNos.SelectedItems)
                {
                    indexs.Add(li.Index);
                }
                indexs.Sort(new Comparison<int>(CMP_INT));
                foreach (int ind in indexs)
                    lvFNos.Items[ind].Remove();
            }
        }

        private int CMP_INT(int i1, int i2)
        {
            return -i1.CompareTo(i2);
        }

        private bool sendingMessages = false;
        private void btnSendMessages_Click(object sender, EventArgs e)
        {
            if (!Port.IsOpen || !Port.CDHolding)
            {
                MessageBox.Show(this, "Please connect usb modem first.", "No modem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lvFNos.Items.Count == 0)
            {
                MessageBox.Show(this, "Please add contacts or contact groups to compose box.", "No numbers", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtMsgs.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "Please enter message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<long> numbers = new List<long>();
            foreach (ListViewItem li in lvFNos.Items)
            {
                numbers.Add(long.Parse(li.SubItems[2].Text.Trim()));
            }
            pb.Maximum = numbers.Count;
            pb.Value = 0;
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart((obj) => {
                object[] od = (object[])obj;
                List<long> nos = (List<long>)od[0];
                String msg = od[1].ToString();
                List<long> faillist = new List<long>();
                Action actInc = () => { pb.Value++; tbSents.Text = pb.Value + " sent out of " + pb.Maximum + " (" + faillist.Count + " fails)"; };
                long key = Func.AccessControl();
                Func.isPortData = false;
                foreach (long no in nos)
                {
                    if (Func.PortSendMsg(Port,no, msg,key))
                    {
                        try
                        {
                            Invoke(actInc);
                        }
                        catch (Exception) { }
                    }
                    else
                    {
                        faillist.Add(no);
                    }
                }
                Func.isPortData = true;
                Func.FreeControl(key);
                
                Action actEnb = () => {
                    lvFNos.Items.Clear();
                    foreach (long no in faillist)
                    {
                        Contact ct = Func.getContactFromNumber(no);
                        ListViewItem li = new ListViewItem(new String[] { ct.Name, ct.Number + "" });
                        li.Tag = ct;
                        lvFNos.Items.Add(li);
                    }
                    btnSendMessages.Enabled = true;
                    sendingMessages = false;
                };
                try
                {
                    Invoke(actEnb);
                }
                catch (Exception) { }
            });
            Thread threadSender = new Thread(threadStart);
            object[] data=new object[2];
            data[0] = numbers;
            data[1] = txtMsgs.Text.Trim();
            btnSendMessages.Enabled = false;
            sendingMessages = true;
            threadSender.Start(data);
        }

        private void toolStripStatusLabel1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabAbout_Enter(object sender, EventArgs e)
        {
            tabAbout.Controls.Clear();
            SplashScreen ss = new SplashScreen();
            ss.NoExit = true;
            ss.TopLevel = false;
            tabAbout.Controls.Add(ss);
            ss.Show();
        }

        private void btnClearMessages_Click(object sender, EventArgs e)
        {
            if (radInbox.Checked)
            {
                Func.clearMessages(Func.MessageType.INBOX);
                Func.loadMessages(lvMessages, Func.MessageType.INBOX);
            }
            if (radSent.Checked)
            {
                Func.clearMessages(Func.MessageType.SENT);
                Func.loadMessages(lvMessages, Func.MessageType.SENT);
            } 
            if (radOutbox.Checked)
            {
                Func.clearMessages(Func.MessageType.OUTBOX);
                Func.loadMessages(lvMessages, Func.MessageType.OUTBOX);
            }
            
        }

        private void lvMessages_DoubleClick(object sender, EventArgs e)
        {
            if (lvMessages.SelectedItems.Count > 0)
            {
                String msg = "";
                msg += lvMessages.SelectedItems[0].SubItems[0].Text + Environment.NewLine;
                msg += lvMessages.SelectedItems[0].SubItems[1].Text + Environment.NewLine;
                msg += lvMessages.SelectedItems[0].SubItems[2].Text + Environment.NewLine;
                msg += lvMessages.SelectedItems[0].SubItems[3].Text + Environment.NewLine;
                MessageBox.Show(this, "Message:" + Environment.NewLine + msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabCompose_Click(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save backup to ...";
            sfd.Filter = "QuickSMS Backup file|*.qsb";
            sfd.FileName = "";
            sfd.CheckFileExists = false;
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    Func.saveDatabase();
                    File.WriteAllBytes(sfd.FileName, File.ReadAllBytes(Program.DatabasePath));
                    MessageBox.Show(this, "Your current configuration is backuped to the location:" + Environment.NewLine + sfd.FileName, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Can't create backup file, please check selected location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Title = "Restore backup from ...";
            sfd.Filter = "QuickSMS Backup file|*.qsb";
            sfd.FileName = "";
            sfd.CheckFileExists = true;
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    File.WriteAllBytes(Program.DatabasePath, File.ReadAllBytes(sfd.FileName));
                    Func.loadDatabase();
                    MessageBox.Show(this, "Your backedup configuration is restored from the location:" + Environment.NewLine + sfd.FileName, "Restored", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Can't restore backup file, please check selected location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnExportEXL_Click(object sender, EventArgs e)
        {
            if (lvGroups.SelectedItems.Count == 1)
            {
                ContactGroup cg = lvGroups.SelectedItems[0].Tag as ContactGroup;
                if (cg != null)
                {
                    try
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Title = "Save CSV file ...";
                        sfd.Filter = "CSV File | *.csv";
                        sfd.FileName = "";
                        sfd.CheckFileExists = false;
                        if (sfd.ShowDialog(this) == DialogResult.OK)
                        {
                            String dataFile = "";
                            foreach (Contact contact in cg.Contacts)
                            {
                                dataFile += contact.Name + "," + contact.Number +Environment.NewLine;
                            }
                            File.WriteAllText(sfd.FileName, dataFile);
                            MessageBox.Show(this, "Your selected group's CSV file is saved to location:" + Environment.NewLine + sfd.FileName, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(this, "Can't save CSV file to your given location, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            btnExportEXL.Enabled = false;
        }

    }

    public class Item
    {
        public String Name;
        public object Value;

        public override string ToString()
        {
            return Name;
        }
    }
}