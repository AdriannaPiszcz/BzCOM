using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ChatTest
{
    public partial class MainForm : Form
    {
        private string currentNumber;

        private int CursorPosition;

        delegate void SetUsersCallBack(List<User> users);

        delegate void SetTextCallBack(string text);

        delegate void SetScrollCallBack();

        private TrafficController trafficController = new TrafficController();

        private Logger logger = new Logger();

        private bool loggerActive = false;

        public MainForm()
        {
            InitializeComponent();

            trafficController.OnMessageReceived += TrafficController_OnMessageReceived;
            trafficController.OnUpdateStatus += TrafficController_OnUpdateStatus;
            logger.OnLoggerMessage += Logger_OnLoggerMessage;

            foreach (var item in Enum.GetValues(typeof(Status)))
            {
                if (item.ToString() != Status.UNKNOWN.ToString())
                    ComboBoxStatus.Items.Add(item);
            }

            webBrowser1.Navigate("about:blank");
            webBrowser1.Document.Write("<html><head><style>body,table { font-size: 10pt; font-family: Verdana; margin: 3px 3px 3px 3px; font-color: black; } </style></head><body width=\"" + (webBrowser1.ClientSize.Width - 20).ToString() + "\">");
        }

        private void Logger_OnLoggerMessage(Logger sender, string msg)
        {
            if (loggerActive)
                SetText(msg);
        }

        private void TrafficController_OnUpdateStatus(TrafficController sender, List<User> users)
        {
            EditBook(users);
            foreach (var item in users)
            {
                if (item.UserState != Status.UNKNOWN)
                    SetColor(trafficController.SetColor(users));
            }
        }

        private void TrafficController_OnMessageReceived(TrafficController sender, Message msgNow)
        {
            TypeText(trafficController.FindName(msgNow.Number.ToString()), msgNow.Text, msgNow.DateTime);
        }

        public static void DoOnUIThread(Control control, Action action)
        {
            if (control.IsDisposed)
                return;

            if (control.InvokeRequired)
                control.Invoke(action);
            else
            {
                if (control.IsDisposed)
                    return;
                action();
            }

            //DoOnUIThread(this, () =>
            //{

            //});
        }

        private void InsertTag(string tag)
        {
            string code = TextBoxMessage.Text;
            TextBoxMessage.Text = code.Insert(CursorPosition, tag);
            TextBoxMessage.Focus();
            if (tag == "<br>" || tag == "<hr>")
            {
                TextBoxMessage.Select(CursorPosition + tag.Length, 0);
                CursorPosition += tag.Length;
            }
            else
            {
                TextBoxMessage.Select(CursorPosition + tag.Length / 2, 0);
                CursorPosition += tag.Length / 2;
            }
        }

        private void ButtonBold_Click(object sender, EventArgs e)
        {
            InsertTag("<b></b>");
        }

        private void ButtonItalic_Click(object sender, EventArgs e)
        {
            InsertTag("<i></i>");
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("about:blank");
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    try
                    {
                        sw.Write(webBrowser1.DocumentText);
                    }
                    catch
                    {
                        MessageBox.Show("Nie można zapisać pliku: " + saveFileDialog1.FileName);
                    }
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //currentName = ListViewAddressBook.Items[ListViewAddressBook.FocusedItem.Index].SubItems[1].Text;
            //AddInfoForm form2 = new AddInfoForm(currentName, StaticFields.contactId);
            //form2.Text = "Edycja";
            //form2.ShowDialog();
        }

        private void ContactDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string currentPhone = "brak";
            //string currentDescription = "brak";
            ////writing.Write(Sync_REQ());
            //currentName = ListViewAddressBook.Items[ListViewAddressBook.FocusedItem.Index].SubItems[1].Text;
            //if (StaticFields.phone.ContainsKey(currentName))
            //    currentPhone = StaticFields.phone[currentName];
            //if (StaticFields.description.ContainsKey(currentName))
            //    currentDescription = StaticFields.description[currentName];
            //ShowInfoForm form3 = new ShowInfoForm(currentName, currentPhone, currentDescription);
            //form3.Text = "Szczegóły kontaktu";
            //form3.ShowDialog();
        }


        private void TextBoxMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                this.ButtonSend_Click(sender, e);
        }

        private void TextBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                this.ButtonLogin_Click(sender, e);
        }

        private void TextBoxMessage_MouseUp_1(object sender, MouseEventArgs e)
        {
            CursorPosition = TextBoxMessage.SelectionStart;
        }

        private void TextBoxMessage_KeyUp_1(object sender, KeyEventArgs e)
        {
            CursorPosition = TextBoxMessage.SelectionStart;
        }

        private void TextBoxDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((trafficController.GetState() == State.LoggedIn || trafficController.GetState() == State.OpenedGate) && e.KeyChar == (char)13)
                trafficController.SetDescription(ComboBoxStatus.Text, TextBoxDescription.Text);

        }

        private void TextBoxDescription_Enter(object sender, EventArgs e)
        {
            if (TextBoxDescription.Text == "Wpisz i naciśnij enter")
            {
                TextBoxDescription.Text = "";
                TextBoxDescription.ForeColor = Color.Black;
            }
        }

        private void TextBoxDescription_Leave(object sender, EventArgs e)
        {
            if (TextBoxDescription.Text == "")
            {
                TextBoxDescription.Text = "Wpisz i naciśnij enter";
                TextBoxDescription.ForeColor = Color.Silver;
            }
        }

        private void NumericUpDownPort_ValueChanged(object sender, EventArgs e)
        {
            trafficController.SetPort(Convert.ToInt32(NumericUpDownPort.Value));
        }

        private void ListViewAddressBook_DoubleClick(object sender, EventArgs e)
        {
            //if (trafficController.GetState() == State.LoggedIn)
            //{
            ListViewItem selectedItem = ListViewAddressBook.SelectedItems[0];
            currentNumber = trafficController.FindNumber(selectedItem.SubItems[1].Text);
            var temp = ListViewAddressBook.FocusedItem.ListView;
            trafficController.SetState(State.OpenedGate);
            SetText($"Rozmowa z {selectedItem.SubItems[1].Text}");
            //}
            //else
            //SetText("Najpierw musisz ustanowić połączenie!");
        }

        private void ComboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (trafficController.GetState() == State.LoggedIn || trafficController.GetState() == State.OpenedGate)
                trafficController.SetStatus((Status)Enum.Parse(typeof(Status), ComboBoxStatus.Text));
        }

        public void SetText(string text)
        {
            if (ListBoxLogger.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetText);
                this.Invoke(f, new object[] { text });
            }
            else
            {
                ListBoxLogger.Items.Add(text);
                ListBoxLogger.TopIndex = ListBoxLogger.Items.Count - 1;
            }
        }

        private void SetBook(List<User> bookList)
        {
            if (ListViewAddressBook.InvokeRequired)
            {
                SetUsersCallBack f = new SetUsersCallBack(SetBook);
                Invoke(f, new object[] { bookList });
            }
            else
            {
                ListViewAddressBook.View = View.Details;

                foreach (var item in bookList)
                {
                    ListViewItem listViewItem = new ListViewItem(new string[] { item.UserState.ToString(), item.UserName, item.UserDesc });
                    ListViewAddressBook.Items.Add(listViewItem);
                }

                ListViewAddressBook.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                ListViewAddressBook.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                ListViewAddressBook.Columns[0].Width = 0;
            }
        }

        private void EditBook(List<User> bookList)
        {
            if (ListViewAddressBook.InvokeRequired)
            {
                SetUsersCallBack f = new SetUsersCallBack(EditBook);
                this.Invoke(f, new object[] { bookList });
            }
            else
            {
                foreach (ListViewItem lvi in ListViewAddressBook.Items)
                {
                    foreach (var item in bookList)
                    {
                        if (lvi.SubItems[1].Text == item.UserName)
                        {
                            if (item.UserState != Status.UNKNOWN)
                            {
                                int stateIndex = (int)item.UserState;
                                lvi.SubItems[0].Text = stateIndex.ToString();
                                SetText("Użytkownik " + item.UserName + " zaktualizował swój status!");
                                ListViewAddressBook.Sort();
                            }
                            if (item.UserDesc != null && item.UserDesc != "")
                            {
                                lvi.SubItems[2].Text = item.UserDesc;
                                SetText("Użytkownik " + item.UserName + " zaktualizował swój opis!");
                            }
                        }
                    }
                }
            }
        }

        private void SetTextHTML(string text)
        {
            if (webBrowser1.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetTextHTML);
                Invoke(f, new object[] { text });
            }
            else
            {
                webBrowser1.Document.Write(text);
            }
        }

        private void SetScroll()
        {
            if (webBrowser1.InvokeRequired)
            {
                SetScrollCallBack s = new SetScrollCallBack(SetScroll);
                Invoke(s);
            }
            else
            {
                webBrowser1.Document.Window.ScrollTo(0, int.MaxValue);
                //webBrowser1.Document.Body.ScrollIntoView(false);
            }
        }

        private void TypeText(string who, string message, DateTime datatime)
        {
            SetTextHTML("<table><tr><td width=\"10%\"><b><font size=1>" + who + "</font></b></td><td width=\"90%\"><font size=1>(" + datatime + "):</font></td></tr>");
            SetTextHTML("<tr><td colspan=2><font size=1>" + message + "</font></td></tr></table>");
            SetTextHTML("<hr>");
            SetScroll();
        }

        private void ChangeComboBox(string text)
        {
            ComboBoxStatus.Text = text;
        }

        private void ComboBoxIPAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            trafficController.SetIPAddress(IPAddress.Parse(ComboBoxIPAddress.Text));
        }

        private void SetColor(List<User> colorList)
        {
            if (ListViewAddressBook.InvokeRequired)
            {
                SetUsersCallBack f = new SetUsersCallBack(SetColor);
                this.Invoke(f, new object[] { colorList });
            }
            else
            {
                foreach (ListViewItem lvi in ListViewAddressBook.Items)
                {
                    foreach (var item in colorList)
                    {
                        if (lvi.SubItems[1].Text == item.UserName)
                        {
                            lvi.BackColor = item.StateColor;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Button send
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSend_Click(object sender, EventArgs e)
        {
            if (trafficController.GetState() == State.OpenedGate)
            {
                /// TODO
                //Random r = new Random();
                /// Wysyłanie konkretnej wiadomości do kontaktu, z którym mamy otwartego gate'a
                if (!trafficController.SMSSend(currentNumber, null, TextBoxMessage.Text, "", null))
                {
                    TypeText("ja", TextBoxMessage.Text, DateTime.Now);
                }
                else
                    SetText("Nie udało się wysłać wiadomości");
                TextBoxMessage.Clear();
            }
            else MessageBox.Show("Nie wybrałeś kontaktu, do którego chcesz wysłać wiadomość!");
        }

        /// <summary>
        /// Button login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (trafficController.GetState() == State.Connected)
            {
                /// Checking, if login went successfully, if not, then showing the error
                /// SetText powinno być wykorzystywane tylko i wyłącznie do wyświetlania informacji z klasy logującej
                SetText(trafficController.LogIn(TextBoxLogin.Text, TextBoxPassword.Text));

                /// Manages the initial import of the adress book and statuses
                List<User> temp = trafficController.GetUsers();
                if (temp == null)
                    SetText("Coś poszło nie tak");
                SetBook(temp);

                /// Manages the initial import of statuses and description
                SetColor(trafficController.SetColor(temp));
                
                /// Register sms module
                trafficController.RegisterToModules();

                /// Ustawiamy status oznaczający, że wszystkie dane zostały już ustawione i możemy działać w naszej aplikacji
                trafficController.SetState(State.DataSet);
            }
            /// Changes the status displayed in combobox, when you logged in
            if (trafficController.GetState() == State.LoggedIn)
            {
                ChangeComboBox(Status.AVAILABLE.ToString());
            }

            TextBoxLogin.Text = "";
            TextBoxPassword.Text = "";
        }

        /// <summary>
        /// Ta funkcja póki co nie ma większego sensu, trzeba to ogarnąć
        /// </summary>
        /// <param name="packet"></param>
        //private void PhoneMonitor(XCTIP packet)
        //{
        //    if (packet.SyncItems != null && packet.SyncItems[0].Change_EV != null)
        //    {
        //        // tutaj zczytywać na nowo książkę adresową i wprowadzać zmiany do słowników
        //        connection.SendingPacket(xmlCreator.Sync_REQ());
        //        foreach (var contact in connection.GetFramesList())
        //        {
        //            packet = ServiceXML.GenericDeserialize<XCTIP>(contact);
        //            if (packet.SyncItems != null && packet.SyncItems[0].Records_ANS != null)
        //                foreach (var row in packet.SyncItems[0].Records_ANS[0].Row)
        //                {
        //                    if (row.Contact != null && row.Contact[0].Phone != null)
        //                    {
        //                        if (!StaticFields.phone.ContainsKey(row.Contact[0].Name))
        //                        {
        //                            StaticFields.phone.Remove(row.Contact[0].Name);
        //                            StaticFields.phone.Add(row.Contact[0].Name, row.Contact[0].Phone[row.Contact[0].Phone.Length].Number);
        //                        }
        //                        if (!StaticFields.description.ContainsKey(row.Contact[0].Name))
        //                        {
        //                            StaticFields.description.Remove(row.Contact[0].Name);
        //                            StaticFields.description.Add(row.Contact[0].Name, row.Contact[0].Phone[row.Contact[0].Phone.Length].Comment);
        //                        }
        //                    }
        //                }
        //        }
        //    }
        //}


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.L)
                loggerActive = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
