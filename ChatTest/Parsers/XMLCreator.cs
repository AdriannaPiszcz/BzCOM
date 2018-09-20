using System;

namespace ChatTest
{
    public class XMLCreator
    {
        private static int id = 1;

        public string Logout()
        {
            XCTIP packet = new XCTIP();
            XCTIPLog xCTIPLog = new XCTIPLog();
            XCTIPLogLogout logout = new XCTIPLogLogout();
            logout.CId = id++.ToString();
            xCTIPLog.Logout = new XCTIPLogLogout[] { logout };
            packet.LogItems = new XCTIPLog[] { xCTIPLog };
            String xml = ServiceXML.GenericSerialize(packet, true);

            return xml;
        }

        public string MakeLog(string login, string pass, out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPLog xCTIPLog = new XCTIPLog();
            XCTIPLogMakeLog makeLog = new XCTIPLogMakeLog();
            makeLog.CId = id++.ToString();
            makeLog.Login = login;
            makeLog.Pass = pass;
            xCTIPLog.MakeLog = new XCTIPLogMakeLog[] { makeLog };
            packet.LogItems = new XCTIPLog[] { xCTIPLog };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = makeLog.CId;
            return xml;
        }

        public string StatusUpdate_REQ(string status, string info, out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPStatus xCTIPStatus = new XCTIPStatus();
            XCTIPStatusUpdate_REQ update = new XCTIPStatusUpdate_REQ();
            update.CId = id++.ToString();
            update.AppState = status;
            update.AppInfo = info;
            xCTIPStatus.Update_REQ = new XCTIPStatusUpdate_REQ[] { update };
            packet.StatusItems = new XCTIPStatus[] { xCTIPStatus };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = update.CId;
            return xml;
        }

        public string StatusRegister_REQ(out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPStatus xCTIPStatus = new XCTIPStatus();
            XCTIPStatusRegister_REQ reg = new XCTIPStatusRegister_REQ();
            reg.CId = id++.ToString();
            xCTIPStatus.Register_REQ = new XCTIPStatusRegister_REQ[] { reg };
            packet.StatusItems = new XCTIPStatus[] { xCTIPStatus };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = reg.CId;
            return xml;
        }

        public string Sync_REQ(string type, out string rid, string limit="10")
        {
            XCTIP packet = new XCTIP();
            XCTIPSync xCTIPSync = new XCTIPSync();
            XCTIPSyncSync_REQ req = new XCTIPSyncSync_REQ();
            req.CId = id++.ToString();
            req.SyncType = type;
            req.Limit = limit;
            xCTIPSync.Sync_REQ = new XCTIPSyncSync_REQ[] { req };
            packet.SyncItems = new XCTIPSync[] { xCTIPSync };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = req.CId;
            return xml;
        }

        public string SyncAutoChange_REQ(string type, out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPSync xCTIPSync = new XCTIPSync();
            XCTIPSyncAutoChange_REQ req = new XCTIPSyncAutoChange_REQ();
            req.CId = id++.ToString();
            req.SyncType = type;
            xCTIPSync.AutoChange_REQ = new XCTIPSyncAutoChange_REQ[] { req };
            packet.SyncItems = new XCTIPSync[] { xCTIPSync };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = req.CId;
            return xml;
        }

        public string SyncRegister_REQ(out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPSync xCTIPSync = new XCTIPSync();
            XCTIPSyncRegister_REQ register_REQ = new XCTIPSyncRegister_REQ();
            register_REQ.CId = id++.ToString();
            register_REQ.SyncType = "HistoryMsg";
            register_REQ.SendOnline = "";
            xCTIPSync.Register_REQ = new XCTIPSyncRegister_REQ[] { register_REQ };
            packet.SyncItems = new XCTIPSync[] { xCTIPSync };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = register_REQ.CId;
            return xml;
        }

        public string EditContact(string number, string comment, string name, string id, out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPSync xCTIPSync = new XCTIPSync();
            XCTIPSyncSendChange_REQ sendChange_REQ = new XCTIPSyncSendChange_REQ();
            XCTIPSyncRecords_ANSRow row = new XCTIPSyncRecords_ANSRow();
            XCTIPSyncRecords_ANSRowContact contact = new XCTIPSyncRecords_ANSRowContact();
            ContactPhone phone = new ContactPhone();
            sendChange_REQ.CId = id;
            sendChange_REQ.Row = new XCTIPSyncRecords_ANSRow[] { row };
            row.RowType = "AddField";
            row.Contact = new XCTIPSyncRecords_ANSRowContact[] { contact };
            //phone.Number = textBox1.Text;
            phone.Number = number;
            //phone.Comment = textBox2.Text;
            phone.Comment = comment;
            phone.PhoneId = "1";
            contact.Phone = new ContactPhone[] { phone };
            //contact.Name = label3.Text;
            contact.Name = name;
            //contact.ContactId = contactId[label3.Text];
            // TODO: fix it
            //contact.ContactId = StaticFields.contactId[id];
            xCTIPSync.SendChange_REQ = new XCTIPSyncSendChange_REQ[] { sendChange_REQ };
            packet.SyncItems = new XCTIPSync[] { xCTIPSync };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = sendChange_REQ.CId;
            return xml;
        }

        public string SMSRegister_REQ(out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPSMS xCTIPSMS = new XCTIPSMS();
            XCTIPSMSRegister_REQ register_REQ = new XCTIPSMSRegister_REQ();
            register_REQ.CId = id++.ToString();
            xCTIPSMS.Register_REQ = new XCTIPSMSRegister_REQ[] { register_REQ };
            packet.SMSItems = new XCTIPSMS[] { xCTIPSMS };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = register_REQ.CId;
            return xml;
        }

        public string SMSUnregister_REQ()
        {
            XCTIP packet = new XCTIP();
            XCTIPSMS xCTIPSMS = new XCTIPSMS();
            XCTIPSMSUnregister_REQ unregister_REQ = new XCTIPSMSUnregister_REQ();
            unregister_REQ.CId = id++.ToString();
            xCTIPSMS.Unregister_REQ = new XCTIPSMSUnregister_REQ[] { unregister_REQ };
            packet.SMSItems = new XCTIPSMS[] { xCTIPSMS };
            String xml = ServiceXML.GenericSerialize(packet, true);

            return xml;
        }

        public string SMSSend_REQ(string number, string smsId, string text, string dontBuffer, string userData, out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPSMS xCTIPSMS = new XCTIPSMS();
            XCTIPSMSSend_REQ send_REQ = new XCTIPSMSSend_REQ();
            send_REQ.CId = id++.ToString();
            send_REQ.Number = number;
            send_REQ.SMSId = smsId;
            send_REQ.Type = "Internal";
            send_REQ.Text = text;
            send_REQ.DontBuffer = dontBuffer;
            send_REQ.UserData = userData;
            xCTIPSMS.Send_REQ = new XCTIPSMSSend_REQ[] { send_REQ };
            packet.SMSItems = new XCTIPSMS[] { xCTIPSMS };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = send_REQ.CId;
            return xml;
        }
    }
}
