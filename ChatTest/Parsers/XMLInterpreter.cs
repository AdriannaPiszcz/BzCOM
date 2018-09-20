using System;
using System.Collections.Generic;
using System.Threading;

namespace ChatTest
{
    public class XMLInterpreter
    {
        public List<User> UserInfo = new List<User>();

        private Connection connection;

        private XCTIP packet;

        public string Error { get; set; }

        private Logger logger = new Logger();

        public XMLInterpreter(Connection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Funkcja zwraca stosowną odpowiedź na polecenie zalogowania
        /// </summary>
        /// <returns></returns>
        public string LogIn()
        {
            string answer = String.Empty;
            foreach (var item in connection.GetFramesList())
            {
                packet = ServiceXML.GenericDeserialize<XCTIP>(item);
                if (packet.LogItems != null && packet.LogItems[0].Answer != null)
                {
                    var error = packet.LogItems[0].Answer[0].Error;
                    if (error == null || error == "")
                    {
                        connection.State = State.LoggedIn;
                        answer = "Logowanie zakończono pomyślnie!  ";
                    }
                    else
                    {
                        answer = error;
                        logger.Debug($"Error:\n{error}\n");
                    }
                }
                answer = answer + CurrentUserInfo();
            }
            return answer;
        }

        /// <summary>
        /// Funkcja zwraca informacje o zalogowanym użytkowniku
        /// </summary>
        /// <returns></returns>
        public string CurrentUserInfo()
        {
            string answer = null;
            if (packet.LogItems != null && packet.LogItems[0].LogInfo_ANS != null)
            {
                answer = "Witaj! Twój numer telefonu to: " + packet.LogItems[0].LogInfo_ANS[0].Number;
            }
            return answer;
        }

        public List<User> GetBook()
        {
            List<User> bookList = new List<User>();
            if (connection.State == State.LoggedIn)
            {
                foreach (var item in connection.GetFramesList())
                {

                    packet = ServiceXML.GenericDeserialize<XCTIP>(item);
                    if (packet.SyncItems != null && packet.SyncItems[0].Answer != null && packet.SyncItems[0].Answer[0].Error != null)
                    {
                        var error = packet.SyncItems[0].Answer[0].Error;
                        Error = error;
                        logger.Debug($"Error:\n{error}\n");
                    }
                    else
                    {
                        if (packet.SyncItems != null && packet.SyncItems[0].Records_ANS != null)
                        {
                            foreach (var row in packet.SyncItems[0].Records_ANS[0].Row)
                            {
                                User user = new User();
                                if (row.Contact != null && row.Contact[0].Name != null)
                                {
                                    user.UserId = row.Contact[0].IdExtNo;
                                    user.UserName = row.Contact[0].Name;
                                    user.ContactId = row.Contact[0].ContactId;
                                    /// tutaj foreach po phone i pola phone number i phone desc jako tablica słowników, tuple czy cokolwiek
                                    if (row.Contact[0].Phone != null)
                                    {
                                        user.PhoneNumber = row.Contact[0].Phone[0].Number;
                                        user.PhoneDesc = row.Contact[0].Phone[0].Comment;
                                    }

                                    user.UserNumber = row.Contact[0].ExtNo;
                                    bookList.Add(user);
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                Error = "Najpierw musisz ustanowić połączenie z serwerem i zalogować się";
                logger.Debug($"Error:\n{Error}\n");
            }
            UserInfo = bookList;
            return bookList;
        }

        public List<User> GetStatus()
        {
            List<User> users = new List<User>();

            foreach (var item in connection.GetFramesList())
            {
                User user = new User();
                packet = ServiceXML.GenericDeserialize<XCTIP>(item);
                if (packet.StatusItems != null && packet.StatusItems[0].Refresh_EV != null)
                {
                    user.UserId = packet.StatusItems[0].Refresh_EV[0].Id;
                    foreach (var el in UserInfo)
                    {
                        if (el.UserId == user.UserId)
                            user.UserName = el.UserName;
                    }
                    if (packet.StatusItems[0].Refresh_EV[0].AppState != null)
                        user.UserState = (Status)Enum.Parse(typeof(Status), packet.StatusItems[0].Refresh_EV[0].AppState);
                    else
                        user.UserState = Status.UNAVAILABLE;
                    if (packet.StatusItems[0].Refresh_EV[0].AppInfo != null)
                        user.UserDesc = packet.StatusItems[0].Refresh_EV[0].AppInfo;
                }
                users.Add(user);
            }

            return users;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<User> GetChangedStatus()
        {
            List<User> users = new List<User>();
            User user = new User();
            if (packet.StatusItems != null && packet.StatusItems[0].Change_EV != null)
            {
                user.UserId = packet.StatusItems[0].Change_EV[0].Id;
                foreach (var el in UserInfo)
                {
                    if (el.UserId == user.UserId)
                        user.UserName = el.UserName;
                }
                if (packet.StatusItems[0].Change_EV[0].AppState != null)
                {
                    user.UserState = (Status)Enum.Parse(typeof(Status), packet.StatusItems[0].Change_EV[0].AppState);
                    packet.StatusItems[0].Change_EV[0].AppState = null;
                }

                if (packet.StatusItems[0].Change_EV[0].AppInfo != null)
                {
                    user.UserDesc = packet.StatusItems[0].Change_EV[0].AppInfo;
                    packet.StatusItems[0].Change_EV[0].AppInfo = null;
                }
            users.Add(user);
            }
            return users;
        }

        public List<Message> GetMessageRecords_EV()
        {
            Message message = new Message();
            List<Message> messages = new List<Message>();
            if (packet.SyncItems != null && packet.SyncItems[0].Records_EV != null && packet.SyncItems[0].Records_EV[0].Row != null)
                foreach (var item in packet.SyncItems[0].Records_EV[0].Row)
                {
                    message.DateTime = Convert.ToDateTime(item.HistoryMsg[0].Date);
                    message.Number = Convert.ToInt32(item.HistoryMsg[0].Number);
                    message.Text = item.HistoryMsg[0].Text;
                    messages.Add(message);
                }
            return messages;
        }

        public List<Message> GetMessageRecords_ANS()
        {

            List<Message> messages = new List<Message>();
            if (packet.SyncItems != null && packet.SyncItems[0].Records_ANS != null && packet.SyncItems[0].Records_ANS[0].Row != null)
                foreach (var item in packet.SyncItems[0].Records_ANS[0].Row)
                {
                    Message message = new Message();
                    if (item.HistoryMsg == null)
                        continue;

                    message.DateTime = Convert.ToDateTime(item.HistoryMsg[0].Date);
                    message.Number = Convert.ToInt32(item.HistoryMsg[0].Number);
                    message.Text = item.HistoryMsg[0].Text;
                    messages.Add(message);
                }
            return messages;
        }

        public Message GetSMSReceive_EV()
        {
            Message message = new Message();
            if (packet.SMSItems == null || packet.SMSItems[0].Receive_EV == null)
                return message;

            message.DateTime = Convert.ToDateTime(packet.SMSItems[0].Receive_EV[0].RecvTime);
            message.Number = Convert.ToInt32(packet.SMSItems[0].Receive_EV[0].Number);
            message.Text = packet.SMSItems[0].Receive_EV[0].Text;
            packet.SMSItems[0].Receive_EV = null;

            return message;
        }

        public bool IsSyncChange_EV()
        {
            if (packet.SyncItems == null || packet.SyncItems[0].Change_EV == null)
                return false;

            return true;
        }

        public bool SMSError()
        {
            bool error;
            if (packet.SMSItems != null && packet.SMSItems[0].Answer != null)
            {
                if (packet.SMSItems[0].Answer[0].Error == null)
                    error = false;
                else
                    error = true;
            }
            else
                error = true;
            return error;
        }

        public void ParsePacket()
        {
            foreach (var item in connection.GetFramesList())
            {
                packet = ServiceXML.GenericDeserialize<XCTIP>(item);
            }
        }
    }
}
