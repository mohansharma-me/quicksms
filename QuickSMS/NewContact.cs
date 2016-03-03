using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickSMS
{
    public partial class NewContact : Form
    {
        private bool EditMode = false;
        public NewContact()
        {
            InitializeComponent();
            Func.loadGroups(cmbGroup);
        }

        private void NewContact_Load(object sender, EventArgs e)
        {
            
        }

        public void setContactGroup(ContactGroup cg)
        {
            cmbGroup.SelectedItem = cg;
        }

        public void setEditContact(Contact contact,ContactGroup cg)
        {
            cmbGroup.SelectedItem = cg;
            cmbGroup.Enabled = false;
            txtName.Text = contact.Name;
            txtName.Tag = contact.Name;
            txtNumber.Text = contact.Number+"";
            txtNumber.Tag = contact.Number;
            EditMode = true;
            Text = "Edit Contact";
            btnAdd.Text = "&Save";
            btnClose.Text = "&Cancel";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbGroup.SelectedIndex == -1)
            {
                label1.ForeColor = Color.Red;
                cmbGroup.Focus();
                return;
            }
            ContactGroup cg = cmbGroup.SelectedItem as ContactGroup;
            
            if (txtName.Text.Trim().Length == 0)
            {
                label2.ForeColor = Color.Red;
                txtName.Focus();
                return;
            }
            String name=txtName.Text.Trim();

            long number=0;
            if (txtNumber.Text.Trim().Length == 0 || !long.TryParse(txtNumber.Text.Trim(), out number))
            {
                label3.ForeColor = Color.Red;
                txtNumber.Focus();
                return;
            }

            Contact contact = new Contact();
            contact.Name = name;
            contact.Number = number;

            contact.Number = 0;
            if (Func.ContactExists(contact, cg, false))
            {
                bool flag = true;
                if (EditMode)
                {
                    if (txtName.Text.Equals(txtName.Tag.ToString()))
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    label2.ForeColor = Color.Red;
                    label2.Text = "Name : (Already exists!!)";
                    //label3.Text = "Mobile Number : (Already exists!!)";
                    txtName.Focus();
                    return;
                }
            }
            contact.Name = "";
            contact.Number = number;
            if (Func.ContactExists(contact, cg, false))
            {
                if (Func.ContactExists(contact, cg, false))
                {
                    bool flag = true;
                    if (EditMode)
                    {
                        if (txtNumber.Text.Equals(txtNumber.Tag.ToString()))
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        label3.ForeColor = Color.Red;
                        //label2.Text = "Name : (Already exists!!)";
                        label3.Text = "Mobile Number : (Already exists!!)";
                        txtNumber.Focus();
                        return;
                    }
                }
            }

            contact.Name = name;
            contact.Number = number;
            if (EditMode)
            {
                Contact oldContact = new Contact();
                oldContact.Name = txtName.Tag.ToString();
                oldContact.Number = (long)txtNumber.Tag;
                if (Func.UpdateContactToGroup(oldContact, contact, cg))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(this, "Known contact or contact group isn't exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (Func.AddContactToGroup(contact, cg))
                {
                    txtName.Text = txtNumber.Text = "";
                    txtName.Focus();
                }
                else
                {
                    MessageBox.Show(this, "Group not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Func.loadGroups(cmbGroup);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            label1.Text = "Group :";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
            label2.Text = "Name :";
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
            label3.Text = "Mobile Number :";
        }

        private void NewContact_FormClosing(object sender, FormClosingEventArgs e)
        {
            Func.saveDatabase();
        }

    }
}
