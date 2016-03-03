using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace QuickSMS
{
    [Serializable]
    public class Database : ISerializable
    {
        public List<ContactGroup> ContactGroups=new List<ContactGroup>();
        public List<Message> Messages = new List<Message>();

        public Database()
        {
           
        }

        public Database(SerializationInfo info, StreamingContext ctxt)
        {
            ContactGroups = (List<ContactGroup>)info.GetValue("ContactGroups", typeof(List<ContactGroup>));
            Messages = (List<Message>)info.GetValue("Messages", typeof(List<Message>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("ContactGroups", ContactGroups);
            info.AddValue("Messages", Messages);
        }

        public static Database Open()
        {
            Database db=null;
            try
            {
                if (File.Exists(Program.DatabasePath))
                {
                    Stream stream=File.Open(Program.DatabasePath,FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    db=(Database)bf.Deserialize(stream);
                    stream.Close();
                }
            }
            catch (Exception) { }

            /*db.ContactGroups.Clear();
            ContactGroup cg = new ContactGroup();
            cg.Name = "MyGroup1";
            cg.Contacts = new List<Contact>();
            Contact contact = new Contact();
            contact.Name = "Mohan Sharma";
            contact.Number = 9722505033;
            cg.Contacts.Add(contact);
            db.ContactGroups.Add(cg);*/

            return db;
        }

        public static bool Save(Database db)
        {
            try
            {
                Stream stream = File.Open(Program.DatabasePath, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, db);
                stream.Close();
                return true;
            }
            catch (Exception) { return false; }
        }

    }

    [Serializable]
    public class ContactGroup
    {
        public String Name;
        public List<Contact> Contacts=new List<Contact>();

        public override string ToString()
        {
            return Name;
        }
    }

    [Serializable]
    public class Contact
    {
        public String Name;
        public long Number;

        public override string ToString()
        {
            return Name;
        }
    }

    [Serializable]
    public enum MessageType
    {
        ALL,
        REC_UNREAD,
        REC_READED,
        STO_SENT,
        STO_UNSENT
    }

    [Serializable]
    public class Message
    {
        public String Index = "", Status = "", Alphabet = "", Sender = "", Time = "", MessageText = "";
        public String ID = "";
        public bool Delivered = false, isSent = false;

        /*
         * 
         * public enum MessageType
            {
                ALL,
                REC_UNREAD,
                REC_READED,
                STO_SENT,
                STO_UNSENT
            }
         * 
         * 
         * String mttt = TypeOfMessage.ToString().Replace("_", " ");
                        key = AccessControl();
                            port.WriteLine("at+cmgl=\"" + mttt + "\"");//write("at+cmgl=\"" + mttt + "\"");
                            Thread.Sleep(1000);
                            input = port.ReadExisting();//input = read();
                        FreeControl(key);
                        List<Message> msgs = new List<Message>();
                        try
                        {
                            Regex r = new Regex(@"\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)");//\r\n
                            Match m = r.Match(input);
                            while (m.Success)
                            {
                                Message msg = new Message();
                                msg.Index = m.Groups[1].Value;
                                msg.Status = m.Groups[2].Value;
                                msg.Sender = m.Groups[3].Value;
                                msg.Alphabet = m.Groups[4].Value;
                                msg.Time = m.Groups[5].Value;
                                msg.MessageText = m.Groups[6].Value;
                                msgs.Add(msg);

                                m = m.NextMatch();
                            }
                        }
                        catch (Exception ex)
                        { FreeControl(key); }
         */
    }
}
