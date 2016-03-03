namespace QuickSMS
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ilToolbars = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabContacts = new System.Windows.Forms.TabPage();
            this.cmbGroups = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNewContact = new System.Windows.Forms.Button();
            this.lvContacts = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabGroups = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnExportEXL = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnImportOpen = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDeleteGroups = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveGroup = new System.Windows.Forms.Button();
            this.txtGroupName2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.txtGroupName1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGroupSearch = new System.Windows.Forms.TextBox();
            this.lvGroups = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabMessages = new System.Windows.Forms.TabPage();
            this.btnClearMessages = new System.Windows.Forms.Button();
            this.radOutbox = new System.Windows.Forms.RadioButton();
            this.radSent = new System.Windows.Forms.RadioButton();
            this.radInbox = new System.Windows.Forms.RadioButton();
            this.lvMessages = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabUSBModem = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnConnectUSB = new System.Windows.Forms.Button();
            this.txtRWTimeout = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDatabits = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRefreshmodem = new System.Windows.Forms.Button();
            this.cmbModems = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabCompose = new System.Windows.Forms.TabPage();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.btnSendMessages = new System.Windows.Forms.Button();
            this.txtMsgs = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lvFNos = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tbSignals = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbSents = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbModem = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerModemVerifier = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabContacts.SuspendLayout();
            this.tabGroups.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabMessages.SuspendLayout();
            this.tabUSBModem.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabCompose.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilToolbars
            // 
            this.ilToolbars.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilToolbars.ImageStream")));
            this.ilToolbars.TransparentColor = System.Drawing.Color.Transparent;
            this.ilToolbars.Images.SetKeyName(0, "Administrator.png");
            this.ilToolbars.Images.SetKeyName(1, "User Group.png");
            this.ilToolbars.Images.SetKeyName(2, "mail.png");
            this.ilToolbars.Images.SetKeyName(3, "wifi.png");
            this.ilToolbars.Images.SetKeyName(4, "email_add.png");
            this.ilToolbars.Images.SetKeyName(5, "get_info.png");
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabContacts);
            this.tabControl1.Controls.Add(this.tabGroups);
            this.tabControl1.Controls.Add(this.tabMessages);
            this.tabControl1.Controls.Add(this.tabUSBModem);
            this.tabControl1.Controls.Add(this.tabCompose);
            this.tabControl1.Controls.Add(this.tabAbout);
            this.tabControl1.ImageList = this.ilToolbars;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(7, 7);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(765, 555);
            this.tabControl1.TabIndex = 0;
            // 
            // tabContacts
            // 
            this.tabContacts.Controls.Add(this.cmbGroups);
            this.tabContacts.Controls.Add(this.txtSearch);
            this.tabContacts.Controls.Add(this.label1);
            this.tabContacts.Controls.Add(this.btnDelete);
            this.tabContacts.Controls.Add(this.btnEdit);
            this.tabContacts.Controls.Add(this.btnNewContact);
            this.tabContacts.Controls.Add(this.lvContacts);
            this.tabContacts.ImageIndex = 0;
            this.tabContacts.Location = new System.Drawing.Point(4, 47);
            this.tabContacts.Name = "tabContacts";
            this.tabContacts.Padding = new System.Windows.Forms.Padding(3);
            this.tabContacts.Size = new System.Drawing.Size(757, 504);
            this.tabContacts.TabIndex = 0;
            this.tabContacts.Text = "Contacts";
            this.tabContacts.ToolTipText = "Manage your contacts";
            this.tabContacts.UseVisualStyleBackColor = true;
            this.tabContacts.Enter += new System.EventHandler(this.tabContacts_Enter);
            // 
            // cmbGroups
            // 
            this.cmbGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroups.FormattingEnabled = true;
            this.cmbGroups.Location = new System.Drawing.Point(142, 7);
            this.cmbGroups.Name = "cmbGroups";
            this.cmbGroups.Size = new System.Drawing.Size(189, 24);
            this.cmbGroups.TabIndex = 8;
            this.cmbGroups.SelectedIndexChanged += new System.EventHandler(this.cmbGroups_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(337, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(145, 23);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.Text = "Search...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Group :";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(488, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(73, 27);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(567, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(66, 27);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNewContact
            // 
            this.btnNewContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewContact.Location = new System.Drawing.Point(639, 6);
            this.btnNewContact.Name = "btnNewContact";
            this.btnNewContact.Size = new System.Drawing.Size(112, 27);
            this.btnNewContact.TabIndex = 3;
            this.btnNewContact.Text = "&New Contact";
            this.btnNewContact.UseVisualStyleBackColor = true;
            this.btnNewContact.Click += new System.EventHandler(this.btnNewContact_Click);
            // 
            // lvContacts
            // 
            this.lvContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvContacts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader1,
            this.columnHeader2});
            this.lvContacts.FullRowSelect = true;
            this.lvContacts.GridLines = true;
            this.lvContacts.Location = new System.Drawing.Point(6, 39);
            this.lvContacts.Name = "lvContacts";
            this.lvContacts.Size = new System.Drawing.Size(745, 459);
            this.lvContacts.TabIndex = 2;
            this.lvContacts.UseCompatibleStateImageBehavior = false;
            this.lvContacts.View = System.Windows.Forms.View.Details;
            this.lvContacts.SelectedIndexChanged += new System.EventHandler(this.lvContacts_SelectedIndexChanged);
            this.lvContacts.DoubleClick += new System.EventHandler(this.lvContacts_DoubleClick);
            this.lvContacts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvContacts_KeyDown);
            this.lvContacts.Leave += new System.EventHandler(this.lvContacts_Leave);
            this.lvContacts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseClick);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "ID";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Full Name";
            this.columnHeader1.Width = 277;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mobile Number";
            this.columnHeader2.Width = 145;
            // 
            // tabGroups
            // 
            this.tabGroups.Controls.Add(this.groupBox5);
            this.tabGroups.Controls.Add(this.groupBox3);
            this.tabGroups.Controls.Add(this.btnDeleteGroups);
            this.tabGroups.Controls.Add(this.groupBox2);
            this.tabGroups.Controls.Add(this.groupBox1);
            this.tabGroups.Controls.Add(this.txtGroupSearch);
            this.tabGroups.Controls.Add(this.lvGroups);
            this.tabGroups.ImageIndex = 1;
            this.tabGroups.Location = new System.Drawing.Point(4, 47);
            this.tabGroups.Name = "tabGroups";
            this.tabGroups.Size = new System.Drawing.Size(757, 504);
            this.tabGroups.TabIndex = 1;
            this.tabGroups.Text = "Contact Groups";
            this.tabGroups.UseVisualStyleBackColor = true;
            this.tabGroups.Enter += new System.EventHandler(this.tabGroups_Enter);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnExportEXL);
            this.groupBox5.Controls.Add(this.btnRestore);
            this.groupBox5.Controls.Add(this.btnBackup);
            this.groupBox5.Location = new System.Drawing.Point(297, 394);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(335, 78);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Backup contacts";
            // 
            // btnExportEXL
            // 
            this.btnExportEXL.Enabled = false;
            this.btnExportEXL.Location = new System.Drawing.Point(204, 33);
            this.btnExportEXL.Name = "btnExportEXL";
            this.btnExportEXL.Size = new System.Drawing.Size(125, 25);
            this.btnExportEXL.TabIndex = 4;
            this.btnExportEXL.Text = "&Export (EXL)";
            this.btnExportEXL.UseVisualStyleBackColor = true;
            this.btnExportEXL.Click += new System.EventHandler(this.btnExportEXL_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(105, 33);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(93, 25);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "&Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(6, 33);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(93, 25);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "&Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnImportOpen);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(297, 248);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 140);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Import contacts";
            // 
            // btnImportOpen
            // 
            this.btnImportOpen.Enabled = false;
            this.btnImportOpen.Location = new System.Drawing.Point(130, 97);
            this.btnImportOpen.Name = "btnImportOpen";
            this.btnImportOpen.Size = new System.Drawing.Size(75, 25);
            this.btnImportOpen.TabIndex = 2;
            this.btnImportOpen.Text = "&Open";
            this.btnImportOpen.UseVisualStyleBackColor = true;
            this.btnImportOpen.Click += new System.EventHandler(this.btnImportOpen_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(319, 65);
            this.label4.TabIndex = 0;
            this.label4.Text = "Open CSV file which contains one name and mobile number per line.\r\n\r\nIf duplicate" +
    " mobile number or contact name found then it will be ignored.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDeleteGroups
            // 
            this.btnDeleteGroups.Enabled = false;
            this.btnDeleteGroups.Location = new System.Drawing.Point(297, 215);
            this.btnDeleteGroups.Name = "btnDeleteGroups";
            this.btnDeleteGroups.Size = new System.Drawing.Size(335, 27);
            this.btnDeleteGroups.TabIndex = 11;
            this.btnDeleteGroups.Text = "&Delete all selected groups";
            this.btnDeleteGroups.UseVisualStyleBackColor = true;
            this.btnDeleteGroups.Click += new System.EventHandler(this.btnDeleteGroups_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveGroup);
            this.groupBox2.Controls.Add(this.txtGroupName2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(297, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 100);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edit Group";
            // 
            // btnSaveGroup
            // 
            this.btnSaveGroup.Location = new System.Drawing.Point(230, 47);
            this.btnSaveGroup.Name = "btnSaveGroup";
            this.btnSaveGroup.Size = new System.Drawing.Size(75, 25);
            this.btnSaveGroup.TabIndex = 2;
            this.btnSaveGroup.Text = "&SAVE";
            this.btnSaveGroup.UseVisualStyleBackColor = true;
            this.btnSaveGroup.Click += new System.EventHandler(this.btnSaveGroup_Click);
            // 
            // txtGroupName2
            // 
            this.txtGroupName2.Location = new System.Drawing.Point(28, 49);
            this.txtGroupName2.Name = "txtGroupName2";
            this.txtGroupName2.Size = new System.Drawing.Size(196, 23);
            this.txtGroupName2.TabIndex = 1;
            this.txtGroupName2.TextChanged += new System.EventHandler(this.txtGroupName2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Group name : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddGroup);
            this.groupBox1.Controls.Add(this.txtGroupName1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(297, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Group";
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(230, 47);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(75, 25);
            this.btnAddGroup.TabIndex = 2;
            this.btnAddGroup.Text = "&ADD";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // txtGroupName1
            // 
            this.txtGroupName1.Location = new System.Drawing.Point(28, 49);
            this.txtGroupName1.Name = "txtGroupName1";
            this.txtGroupName1.Size = new System.Drawing.Size(196, 23);
            this.txtGroupName1.TabIndex = 1;
            this.txtGroupName1.TextChanged += new System.EventHandler(this.txtGroupName1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Group name : ";
            // 
            // txtGroupSearch
            // 
            this.txtGroupSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupSearch.Location = new System.Drawing.Point(3, 3);
            this.txtGroupSearch.Name = "txtGroupSearch";
            this.txtGroupSearch.Size = new System.Drawing.Size(288, 23);
            this.txtGroupSearch.TabIndex = 8;
            this.txtGroupSearch.Text = "Search...";
            this.txtGroupSearch.TextChanged += new System.EventHandler(this.txtGroupSearch_TextChanged);
            this.txtGroupSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtGroupSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // lvGroups
            // 
            this.lvGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.lvGroups.FullRowSelect = true;
            this.lvGroups.GridLines = true;
            this.lvGroups.Location = new System.Drawing.Point(3, 32);
            this.lvGroups.Name = "lvGroups";
            this.lvGroups.Size = new System.Drawing.Size(288, 469);
            this.lvGroups.TabIndex = 3;
            this.lvGroups.UseCompatibleStateImageBehavior = false;
            this.lvGroups.View = System.Windows.Forms.View.Details;
            this.lvGroups.SelectedIndexChanged += new System.EventHandler(this.lvGroups_SelectedIndexChanged);
            this.lvGroups.DoubleClick += new System.EventHandler(this.lvGroups_DoubleClick);
            this.lvGroups.Leave += new System.EventHandler(this.lvGroups_Leave);
            this.lvGroups.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Group name";
            this.columnHeader3.Width = 277;
            // 
            // tabMessages
            // 
            this.tabMessages.Controls.Add(this.btnClearMessages);
            this.tabMessages.Controls.Add(this.radOutbox);
            this.tabMessages.Controls.Add(this.radSent);
            this.tabMessages.Controls.Add(this.radInbox);
            this.tabMessages.Controls.Add(this.lvMessages);
            this.tabMessages.ImageIndex = 2;
            this.tabMessages.Location = new System.Drawing.Point(4, 47);
            this.tabMessages.Name = "tabMessages";
            this.tabMessages.Size = new System.Drawing.Size(757, 504);
            this.tabMessages.TabIndex = 2;
            this.tabMessages.Text = "Messages";
            this.tabMessages.UseVisualStyleBackColor = true;
            // 
            // btnClearMessages
            // 
            this.btnClearMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearMessages.Location = new System.Drawing.Point(653, 450);
            this.btnClearMessages.Name = "btnClearMessages";
            this.btnClearMessages.Size = new System.Drawing.Size(75, 26);
            this.btnClearMessages.TabIndex = 8;
            this.btnClearMessages.Text = "&Clear";
            this.btnClearMessages.UseVisualStyleBackColor = true;
            this.btnClearMessages.Click += new System.EventHandler(this.btnClearMessages_Click);
            // 
            // radOutbox
            // 
            this.radOutbox.AutoSize = true;
            this.radOutbox.Location = new System.Drawing.Point(193, 16);
            this.radOutbox.Name = "radOutbox";
            this.radOutbox.Size = new System.Drawing.Size(71, 21);
            this.radOutbox.TabIndex = 7;
            this.radOutbox.TabStop = true;
            this.radOutbox.Text = "&Outbox";
            this.radOutbox.UseVisualStyleBackColor = true;
            this.radOutbox.CheckedChanged += new System.EventHandler(this.radOutbox_CheckedChanged);
            // 
            // radSent
            // 
            this.radSent.AutoSize = true;
            this.radSent.Location = new System.Drawing.Point(93, 16);
            this.radSent.Name = "radSent";
            this.radSent.Size = new System.Drawing.Size(81, 21);
            this.radSent.TabIndex = 6;
            this.radSent.TabStop = true;
            this.radSent.Text = "&Sent box";
            this.radSent.UseVisualStyleBackColor = true;
            this.radSent.CheckedChanged += new System.EventHandler(this.radSent_CheckedChanged);
            // 
            // radInbox
            // 
            this.radInbox.AutoSize = true;
            this.radInbox.Location = new System.Drawing.Point(17, 16);
            this.radInbox.Name = "radInbox";
            this.radInbox.Size = new System.Drawing.Size(59, 21);
            this.radInbox.TabIndex = 5;
            this.radInbox.TabStop = true;
            this.radInbox.Text = "&Inbox";
            this.radInbox.UseVisualStyleBackColor = true;
            this.radInbox.CheckedChanged += new System.EventHandler(this.radInbox_CheckedChanged);
            // 
            // lvMessages
            // 
            this.lvMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvMessages.FullRowSelect = true;
            this.lvMessages.GridLines = true;
            this.lvMessages.Location = new System.Drawing.Point(17, 43);
            this.lvMessages.Name = "lvMessages";
            this.lvMessages.Size = new System.Drawing.Size(727, 447);
            this.lvMessages.TabIndex = 4;
            this.lvMessages.UseCompatibleStateImageBehavior = false;
            this.lvMessages.View = System.Windows.Forms.View.Details;
            this.lvMessages.DoubleClick += new System.EventHandler(this.lvMessages_DoubleClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            this.columnHeader5.Width = 45;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Date & Time";
            this.columnHeader6.Width = 123;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Mobile number";
            this.columnHeader7.Width = 112;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Message";
            this.columnHeader8.Width = 286;
            // 
            // tabUSBModem
            // 
            this.tabUSBModem.Controls.Add(this.groupBox4);
            this.tabUSBModem.ImageIndex = 3;
            this.tabUSBModem.Location = new System.Drawing.Point(4, 47);
            this.tabUSBModem.Name = "tabUSBModem";
            this.tabUSBModem.Size = new System.Drawing.Size(757, 504);
            this.tabUSBModem.TabIndex = 3;
            this.tabUSBModem.Text = "USB Modem";
            this.tabUSBModem.UseVisualStyleBackColor = true;
            this.tabUSBModem.Enter += new System.EventHandler(this.tabUSBModem_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnConnectUSB);
            this.groupBox4.Controls.Add(this.txtRWTimeout);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtDatabits);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.cmbBaudRate);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.btnRefreshmodem);
            this.groupBox4.Controls.Add(this.cmbModems);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(15, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(358, 318);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // btnConnectUSB
            // 
            this.btnConnectUSB.Location = new System.Drawing.Point(37, 263);
            this.btnConnectUSB.Name = "btnConnectUSB";
            this.btnConnectUSB.Size = new System.Drawing.Size(94, 27);
            this.btnConnectUSB.TabIndex = 9;
            this.btnConnectUSB.Text = "&Connect";
            this.btnConnectUSB.UseVisualStyleBackColor = true;
            this.btnConnectUSB.Click += new System.EventHandler(this.btnConnectUSB_Click);
            // 
            // txtRWTimeout
            // 
            this.txtRWTimeout.Location = new System.Drawing.Point(37, 223);
            this.txtRWTimeout.Name = "txtRWTimeout";
            this.txtRWTimeout.Size = new System.Drawing.Size(281, 23);
            this.txtRWTimeout.TabIndex = 8;
            this.txtRWTimeout.Text = "4";
            this.txtRWTimeout.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRWTimeout_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(209, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Read/Write Timeout (seconds) :";
            // 
            // txtDatabits
            // 
            this.txtDatabits.Location = new System.Drawing.Point(37, 168);
            this.txtDatabits.Name = "txtDatabits";
            this.txtDatabits.Size = new System.Drawing.Size(281, 23);
            this.txtDatabits.TabIndex = 6;
            this.txtDatabits.Text = "8";
            this.txtDatabits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRWTimeout_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Data bits :";
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "152000",
            "230400",
            "460800",
            "921600"});
            this.cmbBaudRate.Location = new System.Drawing.Point(37, 111);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(281, 24);
            this.cmbBaudRate.TabIndex = 4;
            this.cmbBaudRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRWTimeout_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Buad Rate :";
            // 
            // btnRefreshmodem
            // 
            this.btnRefreshmodem.Location = new System.Drawing.Point(241, 59);
            this.btnRefreshmodem.Name = "btnRefreshmodem";
            this.btnRefreshmodem.Size = new System.Drawing.Size(77, 25);
            this.btnRefreshmodem.TabIndex = 2;
            this.btnRefreshmodem.Text = "&Refresh";
            this.btnRefreshmodem.UseVisualStyleBackColor = true;
            this.btnRefreshmodem.Click += new System.EventHandler(this.btnRefreshmodem_Click);
            // 
            // cmbModems
            // 
            this.cmbModems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModems.DropDownWidth = 300;
            this.cmbModems.FormattingEnabled = true;
            this.cmbModems.Location = new System.Drawing.Point(37, 60);
            this.cmbModems.Name = "cmbModems";
            this.cmbModems.Size = new System.Drawing.Size(198, 24);
            this.cmbModems.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Modem :";
            // 
            // tabCompose
            // 
            this.tabCompose.Controls.Add(this.pb);
            this.tabCompose.Controls.Add(this.btnSendMessages);
            this.tabCompose.Controls.Add(this.txtMsgs);
            this.tabCompose.Controls.Add(this.label9);
            this.tabCompose.Controls.Add(this.lvFNos);
            this.tabCompose.ImageIndex = 4;
            this.tabCompose.Location = new System.Drawing.Point(4, 47);
            this.tabCompose.Name = "tabCompose";
            this.tabCompose.Size = new System.Drawing.Size(757, 504);
            this.tabCompose.TabIndex = 4;
            this.tabCompose.Text = "Compose";
            this.tabCompose.UseVisualStyleBackColor = true;
            this.tabCompose.Click += new System.EventHandler(this.tabCompose_Click);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(338, 254);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(287, 23);
            this.pb.TabIndex = 9;
            // 
            // btnSendMessages
            // 
            this.btnSendMessages.Location = new System.Drawing.Point(631, 251);
            this.btnSendMessages.Name = "btnSendMessages";
            this.btnSendMessages.Size = new System.Drawing.Size(78, 28);
            this.btnSendMessages.TabIndex = 8;
            this.btnSendMessages.Text = "&Send";
            this.btnSendMessages.UseVisualStyleBackColor = true;
            this.btnSendMessages.Click += new System.EventHandler(this.btnSendMessages_Click);
            // 
            // txtMsgs
            // 
            this.txtMsgs.Location = new System.Drawing.Point(338, 33);
            this.txtMsgs.Multiline = true;
            this.txtMsgs.Name = "txtMsgs";
            this.txtMsgs.Size = new System.Drawing.Size(371, 212);
            this.txtMsgs.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(335, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Message :";
            // 
            // lvFNos
            // 
            this.lvFNos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvFNos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader4,
            this.columnHeader9});
            this.lvFNos.FullRowSelect = true;
            this.lvFNos.GridLines = true;
            this.lvFNos.Location = new System.Drawing.Point(13, 13);
            this.lvFNos.Name = "lvFNos";
            this.lvFNos.Size = new System.Drawing.Size(307, 483);
            this.lvFNos.TabIndex = 5;
            this.lvFNos.UseCompatibleStateImageBehavior = false;
            this.lvFNos.View = System.Windows.Forms.View.Details;
            this.lvFNos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvFNos_KeyDown);
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "ID";
            this.columnHeader11.Width = 44;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 149;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Mobile Number";
            this.columnHeader9.Width = 140;
            // 
            // tabAbout
            // 
            this.tabAbout.ImageIndex = 5;
            this.tabAbout.Location = new System.Drawing.Point(4, 47);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Size = new System.Drawing.Size(757, 504);
            this.tabAbout.TabIndex = 5;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            this.tabAbout.Enter += new System.EventHandler(this.tabAbout_Enter);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSignals,
            this.tbSents,
            this.toolStripStatusLabel1,
            this.tbModem});
            this.statusStrip1.Location = new System.Drawing.Point(0, 570);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(789, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tbSignals
            // 
            this.tbSignals.Name = "tbSignals";
            this.tbSignals.Size = new System.Drawing.Size(63, 17);
            this.tbSignals.Text = "No signal!!";
            // 
            // tbSents
            // 
            this.tbSents.Name = "tbSents";
            this.tbSents.Size = new System.Drawing.Size(17, 17);
            this.tbSents.Text = "--";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(559, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "WebcodeZ Infoway - www.wcodez.com";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            this.toolStripStatusLabel1.DoubleClick += new System.EventHandler(this.toolStripStatusLabel1_DoubleClick);
            // 
            // tbModem
            // 
            this.tbModem.Name = "tbModem";
            this.tbModem.Size = new System.Drawing.Size(135, 17);
            this.tbModem.Text = "Modem not connected!!";
            // 
            // timerModemVerifier
            // 
            this.timerModemVerifier.Tick += new System.EventHandler(this.timerModemVerifier_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(789, 592);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(772, 524);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuickSMS - WebcodeZ Infoway";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabContacts.ResumeLayout(false);
            this.tabContacts.PerformLayout();
            this.tabGroups.ResumeLayout(false);
            this.tabGroups.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabMessages.ResumeLayout(false);
            this.tabMessages.PerformLayout();
            this.tabUSBModem.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabCompose.ResumeLayout(false);
            this.tabCompose.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList ilToolbars;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabContacts;
        private System.Windows.Forms.TabPage tabGroups;
        private System.Windows.Forms.TabPage tabMessages;
        private System.Windows.Forms.TabPage tabUSBModem;
        private System.Windows.Forms.TabPage tabCompose;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView lvContacts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnNewContact;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbGroups;
        private System.Windows.Forms.ListView lvGroups;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox txtGroupSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.TextBox txtGroupName1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveGroup;
        private System.Windows.Forms.TextBox txtGroupName2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeleteGroups;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnImportOpen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbModems;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRefreshmodem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDatabits;
        private System.Windows.Forms.TextBox txtRWTimeout;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnConnectUSB;
        private System.Windows.Forms.Timer timerModemVerifier;
        private System.Windows.Forms.ToolStripStatusLabel tbSignals;
        private System.Windows.Forms.ToolStripStatusLabel tbModem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ListView lvMessages;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.RadioButton radInbox;
        private System.Windows.Forms.RadioButton radSent;
        private System.Windows.Forms.RadioButton radOutbox;
        private System.Windows.Forms.ListView lvFNos;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMsgs;
        private System.Windows.Forms.Button btnSendMessages;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.ToolStripStatusLabel tbSents;
        private System.Windows.Forms.Button btnClearMessages;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnExportEXL;

    }
}

