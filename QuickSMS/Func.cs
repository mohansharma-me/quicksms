using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace QuickSMS
{
    public class Func
    {
        public static bool BypassFNos = false;
        public static Database DB;
        public static String PortData = "";
        public static bool isPortData = true, isUsed = false;
        public static long staticlock=0;

        public static void loadDatabase()
        {
            DB = Database.Open();
            if (DB == null)
                DB = new Database();
        }

        public static bool saveDatabase()
        {
            if (DB != null)
            {
                return Database.Save(DB);
            }
            else
            {
                throw new Exception("No database initilized!!");
            } 
        }

        public static void loadGroups(ComboBox cmb)
        {
            cmb.Items.Clear();
            foreach (ContactGroup cg in DB.ContactGroups)
                cmb.Items.Add(cg);
        }
        public static void loadGroups(ListView listView)
        {
            loadGroups(listView, "");
        }
        public static void loadGroups(ListView listView,String searchString)
        {
            listView.Items.Clear();
            foreach (ContactGroup cg in DB.ContactGroups)
            {
                bool flag = true;
                if (searchString.Trim().Length > 0)
                {
                    if (cg.Name.ToLower().Trim().Contains(searchString.Trim().ToLower()))
                        flag = true;
                    else
                        flag = false;
                }
                ListViewItem li = new ListViewItem(new String[] { cg.Name + " (" + cg.Contacts.Count + " contacts)" });
                li.Tag = cg;
                if (flag)
                {
                    listView.Items.Add(li);
                }
            }
        }
        

        public static bool ContactExists(Contact contact,ContactGroup cg,bool strict)
        {
            bool flag = false;
            Contact ct = cg.Contacts.Find(x => {
                if (strict)
                {
                    return x.Name.ToLower().Trim().Equals(contact.Name.ToLower().Trim()) && x.Number == contact.Number;
                }
                else
                {
                    return x.Name.ToLower().Trim().Equals(contact.Name.ToLower().Trim()) || x.Number == contact.Number;
                }
            });
            if (ct == null)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public static bool ContactGroupExists(String name)
        {
            bool flag = false;
            ContactGroup cg = DB.ContactGroups.Find(x => (x.Name.ToLower().Trim().Equals(name.ToLower().Trim())));
            if (cg == null) 
                flag = false;
            else
                flag = true;
            return flag;
        }

        public static bool AddContactToGroup(Contact contact,ContactGroup cg)
        {
            ContactGroup ctg = DB.ContactGroups.Find(x => (x.Name.ToLower().Trim().Equals(cg.Name.ToLower().Trim())));
            if (ctg == null)
            {
                return false;
            }
            else
            {
                ctg.Contacts.Add(contact);
                return true;
            }
        }

        public static bool UpdateContactToGroup(Contact ocontact,Contact ncontact,ContactGroup cg)
        {
            bool flag = false;
            ContactGroup ctg = DB.ContactGroups.Find(x => (x.Name.ToLower().Trim().Equals(cg.Name.ToLower().Trim())));
            if (ctg == null)
            {
                flag = false;
            }
            else
            {
                Contact contact = ctg.Contacts.Find(x => (x.Name.ToLower().Trim().Equals(ocontact.Name.ToLower().Trim()) && x.Number == ocontact.Number));
                if (contact == null)
                {
                    flag = false;
                }
                else
                {
                    contact.Name = ncontact.Name;
                    contact.Number = ncontact.Number;
                    flag = true;
                }                
            }
            return flag;
        }

        public static bool DeleteContacts(List<Contact> contacts, ContactGroup cg)
        {
            bool flag = false;
            ContactGroup ctg = DB.ContactGroups.Find(x => (x.Name.ToLower().Trim().Equals(cg.Name.ToLower().Trim())));
            if (ctg == null)
            {
                flag = false;
            }
            else
            {
                foreach (Contact contact in contacts)
                    ctg.Contacts.Remove(contact);
                flag = true;
            }
            return flag;
        }

        public static bool AddContactGroup(String name)
        {
            bool flag = false;
            try
            {
                ContactGroup cgroup = new ContactGroup();
                cgroup.Name = name;
                cgroup.Contacts = new List<Contact>();

                DB.ContactGroups.Add(cgroup);
                flag = true;
            }
            catch (Exception) { flag = false; }
            return flag;
        }

        public static bool UpdateContactGroup(String oldname,String newname)
        {
            bool flag = false;
            ContactGroup cg = DB.ContactGroups.Find(x => (x.Name.ToLower().Trim().Equals(oldname.ToLower().Trim())));
            if (cg == null)
            {
                flag = false;
            }
            else
            {
                
                cg.Name = newname;
                flag = true;
            }
            return flag;
        }

        public static bool DeleteContactGroups(List<ContactGroup> contactGroups)
        {
            bool flag = false;
            try
            {
                foreach (ContactGroup contactGroup in contactGroups)
                    DB.ContactGroups.Remove(contactGroup);
                flag = true;
            }
            catch (Exception) { flag = false; }
            return flag;
        }

        public static void loadContacts(ListView listView,ContactGroup cg)
        {
            loadContacts(listView, cg, "");
        }

        public static void loadContacts(ListView listView, ContactGroup cg,String searchString)
        {
            listView.Items.Clear();
            Decimal idCounter = 1;
            foreach (Contact contact in cg.Contacts)
            {
                bool flag = true;
                if (searchString.Trim().Length > 0)
                {
                    if (contact.Name.ToLower().Trim().Contains(searchString) || contact.Number.ToString().Contains(searchString))
                        flag = true;
                    else
                        flag = false;
                }
                ListViewItem li = new ListViewItem(new String[] { idCounter.ToString(),contact.Name, contact.Number + "" });
                li.Tag = contact;
                if (flag)
                {
                    listView.Items.Add(li);
                    idCounter++;
                }
            }
        }

        public static Contact getContactFromNumber(long number)
        {
            foreach (ContactGroup cg in DB.ContactGroups)
            {
                foreach (Contact ct in cg.Contacts)
                {
                    if (ct.Number == number)
                        return ct;
                }
            }
            return null;
        }

        public static bool PortCommand(System.IO.Ports.SerialPort port,String command,ref String dte,int sleepMS=300,String match="OK",long key=-1,bool waitUntilMatch=false)
        {
            bool flag = false;
            try
            {
                if (!port.IsOpen || !port.CDHolding) return false;
                long oldkey = key;
                key = key == -1 ? AccessControl() : key;
                PortData = "";
                if (port.IsOpen) 
                    port.WriteLine(command);
                System.Threading.Thread.Sleep(sleepMS);
                if (!port.IsOpen || !port.CDHolding)
                {
                    if (!port.CDHolding && port.IsOpen)
                        port.Close();
                    port.Open();
                }
                String temp = "";
                int wlCount = 0;
            waitLoop: if (isPortData)
                    temp = PortData;
                else
                {
                    temp = port.ReadExisting();
                }
                if (temp.Contains("+CDS:"))
                    PortCDS(temp);
                if (waitUntilMatch)
                {
                    if (!temp.Contains(match))
                    {
                        Thread.Sleep(sleepMS);
                        if (wlCount <= 10)
                        {
                            wlCount++;
                            goto waitLoop;
                        }
                    }
                }
                if (temp.Contains(match))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                dte = temp;
                PortData = "";
                if (oldkey == -1)
                    FreeControl(key);
            }
            catch (Exception ex) { }
            return flag;
        }

        public enum NetworkStatus
        {
            NOT_REGISTERED_SEARCHING,
            NOT_REGISTERED,
            REGISTERED,
            DENIED,
            UNKNOWN,
            ERROR
        }

        public static NetworkStatus PortCREG(String dte)
        {
            NetworkStatus status=NetworkStatus.ERROR;
            if (dte.Contains("+CREG: "))
            {
                String data = dte.Substring(dte.IndexOf("+CREG: ")+7, 3);
                if (data.Contains(",0"))
                    status = NetworkStatus.NOT_REGISTERED;
                if (data.Contains(",1") || data.Contains(",5"))
                    status = NetworkStatus.REGISTERED;
                if (data.Contains(",2"))
                    status = NetworkStatus.NOT_REGISTERED_SEARCHING;
                if (data.Contains(",3"))
                    status = NetworkStatus.DENIED;
                if (data.Contains(",4"))
                    status = NetworkStatus.UNKNOWN;
            }
            return status;
        }

        public static int PortCSQ(String dte)
        {
            int ret = 0;
            if (dte.Contains("+CSQ: "))
            {
                String str = dte.Substring(dte.IndexOf("+CSQ: ") + 6, 5).Trim();
                str = str.Substring(0, str.IndexOf(",")).Replace(",", "").Trim();
                int.TryParse(str, out ret);
                ret = (ret * 100) / 31;
            }
            return ret;
        }

        public static int PortMessages(String dte)
        {
            int counter = 0;
            try
            {
                Regex r = new Regex(@"\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)");//\r\n
                Match m = r.Match(dte);
                while (m.Success)
                {
                    Message msg = new Message();
                    msg.Index = m.Groups[1].Value;
                    msg.Status = m.Groups[2].Value;
                    msg.Sender = m.Groups[3].Value;
                    msg.Alphabet = m.Groups[4].Value;
                    msg.Time = m.Groups[5].Value;
                    msg.MessageText = m.Groups[6].Value;
                    msg.Delivered = false;
                    msg.isSent = false;
                    DB.Messages.Add(msg);
                    counter++;
                    m = m.NextMatch();
                }
            }
            catch (Exception ex) { }
            saveDatabase();
            return counter;
        }

        public static void PortCDS(String dte)
        {
            ThreadStart threadStart = new ThreadStart(() => {
                String[] lines = dte.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //foreach (String line in lines)
                for (int i = 0; i < lines.Length; i++)
                {
                    String line = lines[i];
                    if (line.Contains("+CDS: "))
                    {
                        String[] arr = line.Split(new String[] { "," }, StringSplitOptions.None);
                        if (arr.Length == 1)
                        {
                            SMSPDULib.SMSStatusReport ssr = new SMSPDULib.SMSStatusReport();
                            String refStr = lines[i+1].Trim();
                            SMSPDULib.SMSStatusReport.Fetch(ssr, ref refStr);
                            String ID = ssr.MessageReference.ToString();
                            Message msg = DB.Messages.Find(x => (x.isSent && x.ID.Trim().Equals(ID)));
                            if (msg != null)
                            {
                                Console.WriteLine("DELREPID:" + ID);
                                msg.Delivered = true;
                            }
                        }
                        else
                            if (arr.Length >= 2)
                            {
                                String ID = arr[1].Trim();
                                Message msg = DB.Messages.Find(x => (x.isSent && x.ID.Trim().Equals(ID)));
                                if (msg != null)
                                {
                                    Console.WriteLine("DELREPID:" + ID);
                                    msg.Delivered = true;
                                }
                            }
                    }
                }
                saveDatabase();
            });
            Thread threadCDS = new Thread(threadStart);
            threadCDS.Name = "CDS Thread";
            threadCDS.Start();
        }

        public static String PortOperator(String dte)
        {
            String ret = "";
            String[] lines = dte.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (String line in lines)
            {
                if (line.Contains("+COPS: "))
                {
                    String[] arr = line.Trim().Split(new String[] { "," }, StringSplitOptions.None);
                    if (arr.Length > 3)
                    {
                        ret = arr[2].Trim().Replace("\"", "");
                    }
                }
            }
            return ret;
        }

        public static long AccessControl()
        {
            //Console.WriteLine("NewKey Call: " + staticlock);
            while (isUsed)
                Thread.Sleep(500);
            isUsed = true;
            long k = ++staticlock;
            //Console.WriteLine("NewKey Picked:" + k);
            return k;
        }
        public static void FreeControl(long key)
        {
            //Console.WriteLine("OldKey Call:" + key);
            if (staticlock == key)
            {
                isUsed = false;
                //Console.WriteLine("Released:" + key);
            }
        }

        public static void loadMessages(ListView listView,MessageType mtype)
        {
            listView.Items.Clear();
            Decimal idCounter = 1;
            foreach (Message msg in DB.Messages)
            {
                bool add = false;
                if (mtype == MessageType.INBOX && !msg.isSent)
                {
                    add = true;
                } else
                if (mtype == MessageType.SENT && msg.isSent && msg.Delivered)
                {
                    add = true;
                } else
                if (mtype == MessageType.OUTBOX && msg.isSent && !msg.Delivered)
                {
                    add = true;
                }
                if (add)
                {
                    //msg.ID.Length == 0 ? msg.Index : msg.ID
                    ListViewItem li = new ListViewItem(new String[] { idCounter.ToString(), msg.Time, msg.Sender, msg.MessageText });
                    li.Tag = msg;
                    listView.Items.Add(li);
                    idCounter++;
                }
            }
        }

        public static void clearMessages(MessageType mtype) 
        {
            if (mtype == MessageType.INBOX)
            {
                DB.Messages.RemoveAll(x => (!x.isSent));
            }
            else if (mtype == MessageType.SENT)
            {
                DB.Messages.RemoveAll(x => (x.isSent && x.Delivered));
            }
            else if (mtype == MessageType.OUTBOX)
            {
                DB.Messages.RemoveAll(x => (x.isSent && !x.Delivered));
            }
        }

        public static void AddContactToFNOS(ListView listView,Contact contact)
        {
            bool add = true;
            foreach (ListViewItem li in listView.Items)
            {
                Contact ct = li.Tag as Contact;
                if (ct.Number == contact.Number)
                {
                    add = false;
                    break;
                }
            }
            if (add || BypassFNos)
            {
                ListViewItem li = new ListViewItem(new String[] { (listView.Items.Count + 1).ToString(), contact.Name, contact.Number + "" });
                li.Tag = contact;
                listView.Items.Add(li);
            }
        }

        public enum MessageType
        {
            INBOX,SENT,OUTBOX
        }

        public static bool PortSendMsg(System.IO.Ports.SerialPort port, long number,String msgs,long key)
        {
            bool flag = false;
            String dte = "";
            port.DiscardInBuffer();
            port.DiscardOutBuffer();
            if (PortCommand(port, "AT+CMGS=\"" + number + "\"", ref dte,300,">",key,true))
            {
                //PortCommand(port, msgs, ref dte, 1000,"OK",key);
                char[] chars = msgs.ToCharArray();
                for(int c=0;c<chars.Length;c++)
                {
                    port.Write(chars, c, 1);
                }

                if (PortCommand(port, Convert.ToString((char)(26)), ref dte, 2000, "OK", key,true))
                {
                    if (dte.Contains("+CMGS: "))
                    {
                        Message msg = new Message();
                        msg.Delivered = false;
                        msg.isSent = true;
                        msg.MessageText = msgs;
                        msg.Sender = number + "";
                        msg.Time = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                        String[] _lines = dte.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                        List<String> lines = _lines.ToList<String>();
                        String line = lines.Find(x => (x.Contains("+CMGS: ")));
                        if (line != null)
                        {
                            msg.ID = line.Replace("+CMGS:", "").Replace(" ", "").Trim();
                            Console.WriteLine("SENTID:" + msg.ID);
                            DB.Messages.Add(msg);
                            flag = true;
                        }
                    }
                }
            }
            port.BaseStream.Flush();
            return flag;
        }
    }
}
