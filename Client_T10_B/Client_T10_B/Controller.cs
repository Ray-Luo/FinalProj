using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Client_T10_B.Program;
using WebSocketSharp;
using System.Drawing;

namespace Client_T10_B
{
    public class Controller
    {
        private List<Observer> observers = new List<Observer>();  // registry of event handlers
        private User_m u;  // handles to Model objects
        private Dummy_API dummy = new Dummy_API();
        public static WebSocket ws;

        // Event for when a message is received from the server
        public event Message MessageReceived;

        public Controller(User_m u)
        {
            this.u = u;
            // Connects to the server
            ws = new WebSocket("ws://127.0.0.1:3111/chat");
            string host = "localhost";
            Queue<JObject> buffer = new Queue<JObject>();
            ws.OnOpen += (ss, ee) =>
                System.Windows.Forms.MessageBox.Show("Connection establised!");
            ws.OnError += (ss, ee) =>
               System.Windows.Forms.MessageBox.Show("Error:" +ee.Message);
            ws.OnMessage += (ss, ee) =>
                { MessageReceived?.Invoke(ee.Data);  };
            ws.OnClose += (ss, ee) =>
               System.Windows.Forms.MessageBox.Show("Disconnected with {0}", host);
            ws.Connect();
       
        }

        // Handles when a new message is entered by the user
        public bool MessageEntered(string message)
        {
            // Send the message to the server if connection is alive
            if (ws.IsAlive)
            {
                ws.Send(message);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Makes sure to close the websocket when the controller is destructed
        ~Controller()
        {
            ws.Close();
        }


        public bool sendMessage(string message)
        {
            // Send the message to the server if connection is alive
            if (ws.IsAlive)
            {
                ws.Send(message);
                return true;
            }
            else
            {
                while (!ws.IsAlive)
                {
                    ws.Connect();
                }
                ws.Send(message);
                return true;
            }
        }

        public string messageResponse()
        {
            string response = "";
            ws.OnMessage += (sender1, e1) => {
                if (MessageReceived != null)
                {
                    MessageReceived(e1.Data);
                    response = e1.Data.ToString();
                }
            };
            System.Threading.Thread.Sleep(2000);
            return response;
        }
        public void updatelist(IList list)
        {
            if (list != null)
            {
                foreach (KeyValuePair<string, int> c in u.getContactList())
                {
                    list.Add(c.Key);
                }
            }
        }
        public void handle(object sender, EventArgs e, messageType handle, ExpandoObject o, string temp )
        {
            switch (handle)
            {
                case messageType.login:
                    loginHandle(sender, e, handle, o, temp );
                    break;
                case messageType.chatMessage:
                    chatMessageHandle(sender, e, handle, o, temp);
                    break;
                case messageType.contactAdded:
                    contactAddedHandle(sender, e, handle, o, temp);
                    break;
                //case messageType.addChatMember:
                //    addChatMemberHandle(sender, e, handle, o, temp);
                //    break;
                //case messageType.contactRemoved:
                //    contactRemovedHandle(sender, e, handle, o, temp);
                //    break;
                case messageType.createChat:
                    createChatHandle(sender, e, handle, o, temp);
                    break;
                //case messageType.leaveChat:
                //    leaveChatHandle(sender, e, handle, o, temp);
                //    break;
                case messageType.logout:
                    logoutHandle(sender, e, handle, o, temp);
                    break;
                    //case messageType.roomStatusChange:
                    //    roomStatusChangeHandle(sender, e, handle, o, temp);
                    //    break;
                    //case messageType.statusChange:
                    //    statusChangeHandle(sender, e, handle, o, temp);
                    //    break;

            }
        }

        public bool handle2(string message)
        {
            return true;
        }

        // register(f) adds event-handler method  f  to the registry:
        public void register(Observer f) { observers.Add(f); }

        // handles request by dealing a card from the deck to the hand:
        private void loginHandle(object sender, EventArgs e, messageType handle, ExpandoObject o, string username)
        {
            //TODO : do check for the valid user name 
            int error = 0;
            List<string> contactList = new List<string>();
            JObject jo = JObject.FromObject(o);
            string json = jo.ToString();

            if (!sendMessage(json))
            {
                System.Windows.Forms.MessageBox.Show("Cannot connect to the server");
                return;
            }
            else
            {
                string response = messageResponse();
                if (response == "")
                {
                    System.Windows.Forms.MessageBox.Show("Cannot connect to the server");
                    return;
                }
                else
                {
                    JObject rss = JObject.Parse(response);

                    foreach (var pair in rss)
                    {
                        if (pair.Key == "messageType")
                        {
                            Debug.Assert((string)pair.Value == "login");
                        }

                        else if (pair.Key == "username")
                        {
                            u.userName = (string)pair.Value;
                            if (u.userName != username)
                                return;
                            //Debug.Assert(u.userName == username);
                            //Console.Write(u.userName);
                        }

                        else if (pair.Key == "error")
                        {
                            error = (int)pair.Value;
                            if (error == 0)
                                u.status = 0;
                            else
                                u.status = 1;
                        }

                        else if (pair.Key == "contactList")
                        {
                            contactList = pair.Value.ToObject<List<string>>();
                            u.contactList = contactList;
                        }
                    }
                    signalObservers(sender, error, null);
                }
            }
                
        }
        // handles request by dealing TWO cards at a time:
        public void logoutHandle(object sender, EventArgs e, messageType handle, ExpandoObject o, string username)
        {
            int error = 0;
            JObject jo = JObject.FromObject(o);
            string json = jo.ToString();
            string user_name = "";
            string response = dummy.logout(json);
            JObject rss = JObject.Parse(response);
            foreach (var pair in rss)
            {
                if (pair.Key == "messageType")
                {
                    Debug.Assert((string)pair.Value == "logout");
                }

                else if (pair.Key == "error")
                {
                    error = (int)pair.Value;
                    if (error == 0)
                    {
                        // user.status = 1 means it is offline
                        u.status = 0;
                    }
                    else 
                    {
                        u.status = 1;
                    }
                }

                else if (pair.Key == "username")
                {
                    user_name = (string)pair.Value;
                    if (!u.contactList.Contains(user_name))
                    {
                        user_name = null ;
                    }
                }
            }
            signalObservers(sender, error, user_name);
        }

        public void contactAddedHandle(object sender, EventArgs e, messageType handle, ExpandoObject o, string username)
        {
            int error = 0;
            int status = 0;
            JObject jo = JObject.FromObject(o);
            string json = jo.ToString();
            // string response = dummy.contactAdded(json);
            string friend = "";
            if (!sendMessage(json))
            {
                System.Windows.Forms.MessageBox.Show("Cannot connect to the server");
                return;
            }
            else
            {
                string response = messageResponse();
                if (response == "")
                {
                    System.Windows.Forms.MessageBox.Show("Cannot connect to the server");
                    return;
                }
                else
                {
                    JObject rss = JObject.Parse(response);
                    foreach (var pair in rss)
                    {
                        if (pair.Key == "messageType")
                        {
                            Debug.Assert((string)pair.Value == "contactAdded");
                        }

                        else if (pair.Key == "error")
                        {
                            error = (int)pair.Value;
                        }

                        else if (pair.Key == "status")
                        {
                            status = (int)pair.Value;
                        }

                    }
                    if (error == 0)
                    {
                        u.contactList.Add(username);
                        u.contactList.Add(status.ToString());
                    }
                    signalObservers(sender, error, null);
                }
            }
        }

        public void createChatHandle(object sender, EventArgs e, messageType handle, ExpandoObject o, string usernameo)
        {
            int error = 0;
            int roomName = 0;
            List<string> currentMembers = new List<string>();
            List<string> mutualMembers = new List<string>();
            JObject jo = JObject.FromObject(o);
            string json = jo.ToString();
            //string response = dummy.createChat(json);

            if (!sendMessage(json))
            {
                System.Windows.Forms.MessageBox.Show("Cannot connect to the server");
                return;
            }
            else
            {
                string response = messageResponse();
                if (response == "")
                {
                    System.Windows.Forms.MessageBox.Show("Cannot connect to the server");
                    return;
                }
                else
                {

                    JObject rss = JObject.Parse(response);

                    foreach (var pair in rss)
                    {
                        if (pair.Key == "messageType")
                        {
                            Debug.Assert((string)pair.Value == "createChat");
                        }

                        else if (pair.Key == "error")
                        {
                            error = (int)pair.Value;
                        }

                        else if (pair.Key == "roomName")
                        {
                            roomName = (int)pair.Value;
                        }

                        else if (pair.Key == "currentMembers")
                        {
                            currentMembers = pair.Value.ToObject<List<string>>();//(List<string>)pair.Value;
                        }

                        else if (pair.Key == "mutualMembers")
                        {
                            mutualMembers = pair.Value.ToObject<List<string>>();
                        }

                    }
                    if (error == 0)
                    {
                        ChatRoom_m chat = new ChatRoom_m();
                        chat.currentMembers = currentMembers;
                        chat.mutualMembers = mutualMembers;
                        chat.roomNumber = roomName;
                        Chatbox_v chatbox = new Chatbox_v(chat, MessageEntered,chatMessageHandle);

                        Task.Factory.StartNew(() => chatbox.ShowDialog(), TaskCreationOptions.LongRunning);

                        //chatbox.ShowDialog();
                        //new Chatbox_v(new ChatRoom_m(new List<string>(new string[] { username_1,username_2 }), roomNumber), MessageEntered).ShowDialog();

                        MessageReceived = chatbox.MessageReceived;
                    }
                    else if (error == 1)
                        System.Windows.Forms.MessageBox.Show("The person is not in your friend list. Please add first!");
                    else
                        System.Windows.Forms.MessageBox.Show("Cannot connect tho the server!");

                    signalObservers(sender, error, null);
                }
            }
        }

        public void chatMessageHandle(object sender, EventArgs e, messageType handle, ExpandoObject o, string temp)
        {
            JObject jo = JObject.FromObject(o);
            jo.Add("username", u.userName);
            string json = jo.ToString();


            if (!sendMessage(json))
            {
                System.Windows.Forms.MessageBox.Show("Cannot connect to the server");
                return;
            }
            else
            {
                string response = messageResponse();
                if (response == "")
                {
                    System.Windows.Forms.MessageBox.Show("Cannot connect to the server");
                    return;
                }
                else
                {
                    JObject rss = JObject.Parse(response);
                    int error = 0;
                    int roomName = 0;
                    string content = "";
                    string username = "";
                    string timestamp = "";
                    string message = "";
                    foreach (var pair in rss)
                    {
                        if (pair.Key == "messageType")
                        {
                            Debug.Assert((string)pair.Value == "chatMessage");
                        }

                        else if (pair.Key == "error")
                        {
                            error = (int)pair.Value;
                        }

                        else if (pair.Key == "roomName")
                        {
                            roomName = (int)pair.Value;
                        }

                        else if (pair.Key == "content")
                        {
                            content = (string)pair.Value;//(List<string>)pair.Value;
                        }

                        else if (pair.Key == "username")
                        {
                            username = (string)pair.Value;
                            if (username != u.userName)
                            {
                                return;
                            }
                        }
                        else if (pair.Key == "timestamp")
                        {
                            timestamp = (string)pair.Value;
                        }
                    }
                    if (error == 0)
                    {
                        message = username + ":" + content;
                    }
                    signalObservers(sender, error, message);


                }
            }

       }

        public void signalObservers(object sender,int e, string str) { foreach (Observer m in observers) { m(sender,e, str); } }
    }
}
