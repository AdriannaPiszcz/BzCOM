using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Threading;

namespace ChatTest
{
    public class TrafficController
    {
        private Connection connection = new Connection();

        private XMLCreator xmlCreator = new XMLCreator();

        private XMLInterpreter xmlInterpreter;

        public delegate void OnMessageReceivedDelegate(TrafficController sender, Message msg);
        public event OnMessageReceivedDelegate OnMessageReceived;

        public delegate void OnUpdateStatusDelegate(TrafficController sender, List<User> users);
        public event OnUpdateStatusDelegate OnUpdateStatus;

        public TrafficController()
        {
            xmlInterpreter = new XMLInterpreter(connection);
        }

        public State GetState()
        {
            return connection.State;
        }

        public void SetState(State state)
        {
            connection.State = state;
        }

        public void SetIPAddress(IPAddress ip)
        {
            connection.AddressIP = ip;
        }

        public void SetPort(int port)
        {
            connection.Port = port;
        }

        public string LogIn(string login, string pass)
        {
            string result;
            connection.SetConnection();
            connection.SendingPacket(xmlCreator.MakeLog(login, pass));
            result = xmlInterpreter.LogIn();
            if (!result.Contains("Error"))
            {
                SetStatus(Status.AVAILABLE);
                connection.State = State.LoggedIn;
            }
            return result;
        }

        public void LogOut()
        {
            connection.SendingPacket(xmlCreator.Logout());
        }

        public List<User> GetAddressBook()
        {
            connection.SendingPacket(xmlCreator.Sync_REQ("Book"));
            return xmlInterpreter.GetBook();
        }

        public void SetStatus(Status status)
        {
            connection.SendingPacket(xmlCreator.StatusUpdate_REQ(status.ToString(), null));
        }

        public List<User> GetStatus()
        {
            connection.SendingPacket(xmlCreator.StatusRegister_REQ()); // zgłaszamy, że chcemy obserwować zmiany statusów
            return xmlInterpreter.GetStatus(); // zwraca ramki z obecnymi statusami do listy obiektów
        }

        public void SetDescription(string status, string info)
        {
            connection.SendingPacket(xmlCreator.StatusUpdate_REQ(status, info));
        }

        public void UpdateStatus()
        {
            List<User> users = xmlInterpreter.GetChangedStatus();
            if (users.Count == 0)
                return;
            OnUpdateStatus?.Invoke(this, users);
        }

        public List<User> SetColor(List<User> listToSet)
        {
            List<User> users = new List<User>();
            foreach (var user in listToSet)
            {
                if (user.UserState == Status.AVAILABLE)
                {
                    user.StateColor = Color.LightGreen;
                }
                if (user.UserState == Status.BRB)
                {
                    user.StateColor = Color.LightSkyBlue;
                }
                else if (user.UserState == Status.BUSY)
                {
                    user.StateColor = Color.IndianRed;
                }
                else if (user.UserState == Status.UNAVAILABLE)
                {
                    user.StateColor = Color.LightGray;
                }
                users.Add(user);
            }
            
            return users;
        }

        public void SMSRegister()
        {
            connection.SendingPacket(xmlCreator.SMSRegister_REQ());
            //connection.SendingPacket(xmlCreator.SyncRegister_REQ());
            connection.SendingPacket(xmlCreator.SyncAutoChange_REQ("HistoryMsg"));
        }

        public bool SMSSend(string number, string smsId, string text, string dontBuffer, string userData)
        {
            connection.SendingPacket(xmlCreator.SMSSend_REQ(number, smsId, text, dontBuffer, userData));
            GetData();
            return xmlInterpreter.SMSError();
        }

        public void GetMessage()
        {
            Message message = xmlInterpreter.GetSMSReceive_EV();
            if (message.Text == null)
                return;
            OnMessageReceived?.Invoke(this, message);
        }

        public List<Message> GetMessagesExtended()
        {
            List<Message> messages = xmlInterpreter.GetMessageRecords_EV();
            if (messages.Count == 0)
                return null;

            return messages;
        }

        public List<Message> GetMessagesSimple()
        {
            if (!xmlInterpreter.IsSyncChange_EV())
                return null;

            connection.SendingPacket(xmlCreator.Sync_REQ("HistoryMsg", "30"));
            
            GetData();
            return xmlInterpreter.GetMessageRecords_ANS();
        }

        public void GetData()
        {
            xmlInterpreter.ParsePacket();
        }

        public string FindName(string number)
        {
            string name = number;
            xmlInterpreter.UserInfo.ForEach(item =>
            {
                if (number == item.UserNumber)
                    name = item.UserName;
            });
            return name;
        }

        public string FindNumber(string name)
        {
            string currentNumber = "";
            xmlInterpreter.UserInfo.ForEach(item =>
            {
                if (item.UserName == name)
                    currentNumber = item.UserNumber;
            });
            return currentNumber;
        }
    }
}
