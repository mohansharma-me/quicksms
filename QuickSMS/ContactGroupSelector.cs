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
    public partial class ContactGroupSelector : Form
    {
        public ContactGroup contactGroup = null;

        public ContactGroupSelector()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            contactGroup = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ContactGroupSelector_Load(object sender, EventArgs e)
        {
            Func.loadGroups(cmbGroups);
            if (cmbGroups.Items.Count > 0)
                cmbGroups.SelectedIndex = 0;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            contactGroup = cmbGroups.SelectedItem as ContactGroup;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
