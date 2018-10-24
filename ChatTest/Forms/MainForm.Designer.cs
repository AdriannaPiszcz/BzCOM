﻿namespace ChatTest
{
    partial class MainForm
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
            this.ListBoxLogger = new System.Windows.Forms.ListBox();
            this.ComboBoxIPAddress = new System.Windows.Forms.ComboBox();
            this.NumericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.ButtonLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.TextBoxMessage = new System.Windows.Forms.TextBox();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.ButtonBold = new System.Windows.Forms.Button();
            this.ButtonItalic = new System.Windows.Forms.Button();
            this.TextBoxLogin = new System.Windows.Forms.TextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.szczegółyKontaktuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edytujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxDescription = new System.Windows.Forms.TextBox();
            this.ComboBoxStatus = new System.Windows.Forms.ComboBox();
            this.ListViewAddressBook = new System.Windows.Forms.ListView();
            this.order = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nazwa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelAvailable = new System.Windows.Forms.Label();
            this.labelUnavailable = new System.Windows.Forms.Label();
            this.labelBrb = new System.Windows.Forms.Label();
            this.labelBusy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPort)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBoxLogger
            // 
            this.ListBoxLogger.FormattingEnabled = true;
            this.ListBoxLogger.ItemHeight = 16;
            this.ListBoxLogger.Location = new System.Drawing.Point(24, 27);
            this.ListBoxLogger.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListBoxLogger.Name = "ListBoxLogger";
            this.ListBoxLogger.Size = new System.Drawing.Size(539, 68);
            this.ListBoxLogger.TabIndex = 0;
            // 
            // ComboBoxIPAddress
            // 
            this.ComboBoxIPAddress.FormattingEnabled = true;
            this.ComboBoxIPAddress.Location = new System.Drawing.Point(73, 110);
            this.ComboBoxIPAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ComboBoxIPAddress.Name = "ComboBoxIPAddress";
            this.ComboBoxIPAddress.Size = new System.Drawing.Size(159, 24);
            this.ComboBoxIPAddress.TabIndex = 1;
            this.ComboBoxIPAddress.Text = "212.122.223.102";
            this.ComboBoxIPAddress.SelectedIndexChanged += new System.EventHandler(this.ComboBoxIPAddress_SelectedIndexChanged);
            // 
            // NumericUpDownPort
            // 
            this.NumericUpDownPort.Location = new System.Drawing.Point(300, 110);
            this.NumericUpDownPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NumericUpDownPort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericUpDownPort.Name = "NumericUpDownPort";
            this.NumericUpDownPort.Size = new System.Drawing.Size(124, 22);
            this.NumericUpDownPort.TabIndex = 2;
            this.NumericUpDownPort.Value = new decimal(new int[] {
            5529,
            0,
            0,
            0});
            this.NumericUpDownPort.ValueChanged += new System.EventHandler(this.NumericUpDownPort_ValueChanged);
            // 
            // ButtonLogout
            // 
            this.ButtonLogout.Location = new System.Drawing.Point(432, 106);
            this.ButtonLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonLogout.Name = "ButtonLogout";
            this.ButtonLogout.Size = new System.Drawing.Size(133, 31);
            this.ButtonLogout.TabIndex = 3;
            this.ButtonLogout.Text = "Wyloguj";
            this.ButtonLogout.UseVisualStyleBackColor = true;
            this.ButtonLogout.Click += new System.EventHandler(this.ButtonLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Adres:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.ContextMenuStrip = this.contextMenuStrip1;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(17, 160);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(27, 25);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(557, 308);
            this.webBrowser1.TabIndex = 6;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripMenuItem,
            this.ClearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 52);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.SaveToolStripMenuItem.Text = "Zapisz";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.ClearToolStripMenuItem.Text = "Wyczyść";
            this.ClearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "html";
            this.saveFileDialog1.Filter = "Pliki HTML (*.html)|*.html|Pliki tekstowe(*.txt)|*.txt|Wszystkie pliki (*.*)|*.*." +
    "";
            this.saveFileDialog1.Title = "Zapisz rozmowę";
            // 
            // TextBoxMessage
            // 
            this.TextBoxMessage.Location = new System.Drawing.Point(16, 506);
            this.TextBoxMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxMessage.Multiline = true;
            this.TextBoxMessage.Name = "TextBoxMessage";
            this.TextBoxMessage.Size = new System.Drawing.Size(557, 73);
            this.TextBoxMessage.TabIndex = 8;
            this.TextBoxMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxMessage_KeyPress);
            this.TextBoxMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxMessage_KeyUp_1);
            this.TextBoxMessage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBoxMessage_MouseUp_1);
            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(245, 585);
            this.ButtonSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(100, 28);
            this.ButtonSend.TabIndex = 9;
            this.ButtonSend.Text = "Wyślij";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // ButtonBold
            // 
            this.ButtonBold.Location = new System.Drawing.Point(17, 475);
            this.ButtonBold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonBold.Name = "ButtonBold";
            this.ButtonBold.Size = new System.Drawing.Size(27, 25);
            this.ButtonBold.TabIndex = 10;
            this.ButtonBold.Text = "B";
            this.ButtonBold.UseVisualStyleBackColor = true;
            this.ButtonBold.Click += new System.EventHandler(this.ButtonBold_Click);
            // 
            // ButtonItalic
            // 
            this.ButtonItalic.Location = new System.Drawing.Point(49, 475);
            this.ButtonItalic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonItalic.Name = "ButtonItalic";
            this.ButtonItalic.Size = new System.Drawing.Size(27, 25);
            this.ButtonItalic.TabIndex = 11;
            this.ButtonItalic.Text = "I";
            this.ButtonItalic.UseVisualStyleBackColor = true;
            this.ButtonItalic.Click += new System.EventHandler(this.ButtonItalic_Click);
            // 
            // TextBoxLogin
            // 
            this.TextBoxLogin.Location = new System.Drawing.Point(645, 39);
            this.TextBoxLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxLogin.Name = "TextBoxLogin";
            this.TextBoxLogin.Size = new System.Drawing.Size(179, 22);
            this.TextBoxLogin.TabIndex = 13;
            this.TextBoxLogin.Text = "101";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.szczegółyKontaktuToolStripMenuItem,
            this.edytujToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(206, 52);
            // 
            // szczegółyKontaktuToolStripMenuItem
            // 
            this.szczegółyKontaktuToolStripMenuItem.Name = "szczegółyKontaktuToolStripMenuItem";
            this.szczegółyKontaktuToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.szczegółyKontaktuToolStripMenuItem.Text = "Szczegóły kontaktu";
            // 
            // edytujToolStripMenuItem
            // 
            this.edytujToolStripMenuItem.Name = "edytujToolStripMenuItem";
            this.edytujToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.edytujToolStripMenuItem.Text = "Edytuj";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(593, 43);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Login";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(593, 73);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Hasło";
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Location = new System.Drawing.Point(645, 69);
            this.TextBoxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.PasswordChar = '*';
            this.TextBoxPassword.Size = new System.Drawing.Size(179, 22);
            this.TextBoxPassword.TabIndex = 16;
            this.TextBoxPassword.Text = "apiszcz";
            this.TextBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPassword_KeyPress);
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.Location = new System.Drawing.Point(659, 107);
            this.ButtonLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(100, 28);
            this.ButtonLogin.TabIndex = 18;
            this.ButtonLogin.Text = "Zaloguj";
            this.ButtonLogin.UseVisualStyleBackColor = true;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(16, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(559, 149);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Połączenie z serwerem";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(583, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(251, 149);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logowanie";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.TextBoxDescription);
            this.groupBox3.Controls.Add(this.ComboBoxStatus);
            this.groupBox3.Location = new System.Drawing.Point(583, 153);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(251, 80);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Opis";
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TextBoxDescription.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TextBoxDescription.Location = new System.Drawing.Point(67, 48);
            this.TextBoxDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.Size = new System.Drawing.Size(175, 21);
            this.TextBoxDescription.TabIndex = 1;
            this.TextBoxDescription.Text = "Wpisz i naciśnij enter";
            this.TextBoxDescription.Enter += new System.EventHandler(this.TextBoxDescription_Enter);
            this.TextBoxDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDescription_KeyPress);
            this.TextBoxDescription.Leave += new System.EventHandler(this.TextBoxDescription_Leave);
            // 
            // ComboBoxStatus
            // 
            this.ComboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxStatus.FormattingEnabled = true;
            this.ComboBoxStatus.Location = new System.Drawing.Point(9, 21);
            this.ComboBoxStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ComboBoxStatus.Name = "ComboBoxStatus";
            this.ComboBoxStatus.Size = new System.Drawing.Size(232, 24);
            this.ComboBoxStatus.TabIndex = 0;
            this.ComboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.ComboBoxStatus_SelectedIndexChanged);
            // 
            // ListViewAddressBook
            // 
            this.ListViewAddressBook.AllowColumnReorder = true;
            this.ListViewAddressBook.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.order,
            this.nazwa,
            this.info});
            this.ListViewAddressBook.ContextMenuStrip = this.contextMenuStrip2;
            this.ListViewAddressBook.FullRowSelect = true;
            this.ListViewAddressBook.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewAddressBook.Location = new System.Drawing.Point(583, 234);
            this.ListViewAddressBook.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListViewAddressBook.MultiSelect = false;
            this.ListViewAddressBook.Name = "ListViewAddressBook";
            this.ListViewAddressBook.Size = new System.Drawing.Size(249, 302);
            this.ListViewAddressBook.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ListViewAddressBook.TabIndex = 24;
            this.ListViewAddressBook.UseCompatibleStateImageBehavior = false;
            this.ListViewAddressBook.View = System.Windows.Forms.View.Details;
            this.ListViewAddressBook.DoubleClick += new System.EventHandler(this.ListViewAddressBook_DoubleClick);
            // 
            // order
            // 
            this.order.Text = "Lp";
            // 
            // nazwa
            // 
            this.nazwa.Text = "nazwa";
            this.nazwa.Width = 43;
            // 
            // info
            // 
            this.info.Text = "info";
            // 
            // labelAvailable
            // 
            this.labelAvailable.AutoSize = true;
            this.labelAvailable.BackColor = System.Drawing.Color.LightGreen;
            this.labelAvailable.Location = new System.Drawing.Point(592, 545);
            this.labelAvailable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAvailable.Name = "labelAvailable";
            this.labelAvailable.Size = new System.Drawing.Size(81, 17);
            this.labelAvailable.TabIndex = 25;
            this.labelAvailable.Text = "AVAILABLE";
            // 
            // labelUnavailable
            // 
            this.labelUnavailable.AutoSize = true;
            this.labelUnavailable.BackColor = System.Drawing.Color.LightGray;
            this.labelUnavailable.Location = new System.Drawing.Point(592, 566);
            this.labelUnavailable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUnavailable.Name = "labelUnavailable";
            this.labelUnavailable.Size = new System.Drawing.Size(101, 17);
            this.labelUnavailable.TabIndex = 26;
            this.labelUnavailable.Text = "UNAVAILABLE";
            // 
            // labelBrb
            // 
            this.labelBrb.AutoSize = true;
            this.labelBrb.BackColor = System.Drawing.Color.LightSkyBlue;
            this.labelBrb.Location = new System.Drawing.Point(736, 545);
            this.labelBrb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBrb.Name = "labelBrb";
            this.labelBrb.Size = new System.Drawing.Size(36, 17);
            this.labelBrb.TabIndex = 27;
            this.labelBrb.Text = "BRB";
            // 
            // labelBusy
            // 
            this.labelBusy.AutoSize = true;
            this.labelBusy.BackColor = System.Drawing.Color.IndianRed;
            this.labelBusy.Location = new System.Drawing.Point(736, 566);
            this.labelBusy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBusy.Name = "labelBusy";
            this.labelBusy.Size = new System.Drawing.Size(45, 17);
            this.labelBusy.TabIndex = 28;
            this.labelBusy.Text = "BUSY";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 626);
            this.Controls.Add(this.labelBusy);
            this.Controls.Add(this.labelBrb);
            this.Controls.Add(this.labelUnavailable);
            this.Controls.Add(this.labelAvailable);
            this.Controls.Add(this.ListViewAddressBook);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ButtonLogin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxLogin);
            this.Controls.Add(this.ButtonItalic);
            this.Controls.Add(this.ButtonBold);
            this.Controls.Add(this.ButtonSend);
            this.Controls.Add(this.TextBoxMessage);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonLogout);
            this.Controls.Add(this.NumericUpDownPort);
            this.Controls.Add(this.ComboBoxIPAddress);
            this.Controls.Add(this.ListBoxLogger);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "BzCOM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPort)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxLogger;
        private System.Windows.Forms.ComboBox ComboBoxIPAddress;
        private System.Windows.Forms.NumericUpDown NumericUpDownPort;
        private System.Windows.Forms.Button ButtonLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox TextBoxMessage;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.Button ButtonBold;
        private System.Windows.Forms.Button ButtonItalic;
        private System.Windows.Forms.TextBox TextBoxLogin;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TextBoxDescription;
        private System.Windows.Forms.ComboBox ComboBoxStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView ListViewAddressBook;
        private System.Windows.Forms.ColumnHeader nazwa;
        private System.Windows.Forms.ColumnHeader info;
        private System.Windows.Forms.Label labelAvailable;
        private System.Windows.Forms.Label labelUnavailable;
        private System.Windows.Forms.Label labelBrb;
        private System.Windows.Forms.Label labelBusy;
        private System.Windows.Forms.ColumnHeader order;
        private System.Windows.Forms.ToolStripMenuItem edytujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem szczegółyKontaktuToolStripMenuItem;
    }
}

