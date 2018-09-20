using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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

        private Logger logger = new Logger();

        public delegate void OnMessageReceivedDelegate(TrafficController sender, Message msg);
        public event OnMessageReceivedDelegate OnMessageReceived;

        public delegate void OnUpdateStatusDelegate(TrafficController sender, List<User> users);
        public event OnUpdateStatusDelegate OnUpdateStatus;

        public TrafficController()
        {
            Thread thread = new Thread(Start);
            thread.Start();
            xmlInterpreter = new XMLInterpreter(connection);
        }

        //ConcurrentDi

        public void Start()
        {
            while (true)
            {
                try
                {
                    if (connection.State == State.DataSet)
                    {
                        GetData();
                        
                        GetChangedStatus();
                        GetMessage();
                    }
                }
                catch (Exception e)
                {
                    logger.Debug($"Exception: {e}");
                }
                Thread.Sleep(500);
            }
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
            lock (connection)
            {
                connection.SetConnection();
                string rid;
                connection.SendingPacket(xmlCreator.MakeLog(login, pass,out rid));
                var temp = xmlInterpreter.LogIn(GetResponse(rid));
                if (temp != null)
                {
                    SetStatus(Status.AVAILABLE);
                    connection.State = State.LoggedIn;
                    return $"Zalogowano pomyślnie!\n {temp}";
                }
                else
                    return "Wystąpił błąd w trakcie logowania. Spróbuj ponownie.";
            }
        }

        public void LogOut()
        {
            lock (connection)
            {
                connection.SendingPacket(xmlCreator.Logout());
            }
        }

        public List<User> GetAddressBook()
        {
            lock (connection)
            {
                string rid;
                connection.SendingPacket(xmlCreator.Sync_REQ("Book", out rid));
                if (xmlInterpreter.SyncError(GetResponse(rid)))
                    return null;

                return xmlInterpreter.GetBook();
            }
        }

        public void SetStatus(Status status)
        {
            lock (connection)
            {
                string rid;
                connection.SendingPacket(xmlCreator.StatusUpdate_REQ(status.ToString(), null, out rid));
                xmlInterpreter.StatusError(GetResponse(rid));
            }
        }

        public List<User> GetStatus()
        {
            lock (connection)
            {
                connection.SendingPacket(xmlCreator.StatusRegister_REQ()); // zgłaszamy, że chcemy obserwować zmiany statusów
                var data = GetData();
                if (data.Count == 0)
                    return null;
                if (xmlInterpreter.StatusError(data))
                    return null;
                return xmlInterpreter.GetStatus(data); // zwraca ramki z obecnymi statusami do listy obiektów
            }
        }

        public void SetDescription(string status, string info)
        {
            lock (connection)
            {
                connection.SendingPacket(xmlCreator.StatusUpdate_REQ(status, info));
                //xmlInterpreter.StatusError(GetData());
            }
        }

        public void GetChangedStatus(List<XCTIP> data)
        {
            List<User> users = xmlInterpreter.GetChangedStatus(data);
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

        public static ConcurrentDictionary<string, XCTIP> responses = new ConcurrentDictionary<string, XCTIP>();
        public static List<XCTIP> asyncData = new List<XCTIP>();

        public XCTIP GetResponse(string id, int timeoutMs=5000)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            XCTIP result;
            while (stopwatch.ElapsedMilliseconds < timeoutMs)
            {
                if (responses.TryGetValue(id, out result))
                    return result;
            }
            throw new TimeoutException($"Upłynął czas oczekiwania na odpowiedź {id}");
        }

        public void SMSRegister()
        {
            lock (connection)
            {
                string sid;
                connection.SendingPacket(xmlCreator.SMSRegister_REQ(out sid));
                if (xmlInterpreter.SMSError(GetResponse(sid)))
                    return;
                //connection.SendingPacket(xmlCreator.SyncRegister_REQ());
                string rid;
                connection.SendingPacket(xmlCreator.SyncAutoChange_REQ("HistoryMsg", out rid));
                if (xmlInterpreter.SyncError(GetResponse(rid)))
                    return;
                /// udało się zarejestrować do modułów
            }
        }

        public bool SMSSend(string number, string smsId, string text, string dontBuffer, string userData)
        {
            lock (connection)
            {
                string rid;
                connection.SendingPacket(xmlCreator.SMSSend_REQ(number, smsId, text, dontBuffer, userData, out rid));
                return xmlInterpreter.SMSError(GetResponse(rid));
            }
        }

        public void GetMessage(List<XCTIP> data)
        {
            Message message = xmlInterpreter.GetSMSReceive_EV(data);
            if (message.Text == null)
                return;
            OnMessageReceived?.Invoke(this, message);
        }

        public List<Message> GetMessagesExtended(List<XCTIP> data)
        {
            List<Message> messages = xmlInterpreter.GetMessageRecords_EV(data);
            if (messages.Count == 0)
                return null;

            return messages;
        }

        public List<Message> GetMessagesSimple(List<XCTIP> data)
        {
            lock (connection)
            {
                if (!xmlInterpreter.IsSyncChange_EV(data))
                    return null;

                string rid;
                connection.SendingPacket(xmlCreator.Sync_REQ("HistoryMsg", out rid, "30"));
                
                if (xmlInterpreter.SyncError(GetResponse(rid)))
                    return null;

                return xmlInterpreter.GetMessageRecords_ANS();
            }
        }

        public void GetData()
        {
            var packets = xmlInterpreter.ParsePacket();
            foreach (var packet in packets)
            {
                if (packet.LogItems[0].Answer != null || packet.SyncItems[0].Answer != null || packet.StatusItems[0].Answer != null || packet.SMSItems[0].Answer != null)
                {
                    responses.TryAdd(packet.LogItems[0].Answer[0].CId, packet);
                    responses.TryAdd(packet.SyncItems[0].Answer[0].CId, packet);
                    responses.TryAdd(packet.StatusItems[0].Answer[0].CId, packet);
                    responses.TryAdd(packet.SMSItems[0].Answer[0].CId, packet);
                }
                else
                    asyncData.Add(packet);
            }
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
