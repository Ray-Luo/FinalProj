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
using WebSocketSharp.Server;
using System.Drawing;

namespace Client_T10_B
{
    public class Controller
    { 
        private List<Observer> observers = new List<Observer>();  // registry of event handlers
        private User_m u;  // handles to Model objects
        private Dummy_API dummy = new Dummy_API();
        public static WebSocket ws;
        public static InputHandler myHandler;
        // Event for when a message is received from the server
        public event Message MessageReceived;
        public static object _sender;
        public static EventArgs _e;
        public static messageType _handle;
        public static ExpandoObject _o;
        public static string _temp;
        public string response;
        public  string name = "";

        public bool flag = false;

        public Controller(User_m u)
        {
            this.u = u;
            name = u.userName;
            // Connects to the server
            ws = new WebSocket("ws://127.0.0.1:3111/chat");
            ws.Connect();
            ws.OnMessage += (sender, e) =>
            {
                response = e.Data.ToString();
                if (response == null)
                {
                   System.Windows.Forms.MessageBox.Show("Cannot connect to the server");
                   return;
                }
                if (response.Contains("chatMessage"))
                { // if (MessageReceived != null)
                   // {
                        JObject r = JObject.Parse(response);
                        foreach(var pair in r)
                        {
                            if (pair.Key == "roomNumber")
                            {
                                if((int)pair.Value == u.roomNumber)
                                {
                                // MessageReceived(e.Data);
                                // myHandler(_sender, _e, _handle, _o, _temp);
                                chatMessageHandle(_sender, _e, _handle, _o, _temp);
                                return;
                                }
                            }
                        }
                      //  MessageReceived(e.Data);
                      //  return;
                    }
                else if(response.Contains("createChat"))
                {
                    List<string> currentMem = new List<string>();
                    JObject r = JObject.Parse(response);
                    foreach(var pair in r)
                    {
                        if(pair.Key == "currentMembers")
                        {
                             currentMem = pair.Value.ToObject<List<string>>();
                            if (currentMem.Contains(u.userName))
                            {
                                createChatHandle(_sender, _e, _handle, _o, _temp);
                                return;
                               // myHandler(_sender, _e, _handle, _o, _temp);
                            }
                        }
                    }
                }
                 else if (response.Contains("addChatMember"))
                {
                    List<string> currentMem = new List<string>();
                    Dictionary<string,int> potentialMem = new Dictionary<string,int>();
                    JObject r = JObject.Parse(response);
                    int roomNumber = 0;
                    string friend = "";

                    foreach (var pair in r)
                    {
                        if(pair.Key == "roomNumber")
                        {
                            roomNumber = (int)pair.Value;

                        }
                        if (pair.Key == "currentMembers")
                        {
                            currentMem = pair.Value.ToObject<List<string>>();  
                        }
                        if(pair.Key == "usernameAdded")
                        {
                            friend = (string)pair.Value;
                        }

                    }
                   
                    if(friend == u.userName)
                    {
                        addChatMemberHandle_2(_sender, _e, _handle, _o, _temp);
                        return;
                    }
                    else if (roomNumber == u.roomNumber)
                    {
                        addChatMemberHandle_1(_sender, _e, _handle, _o, _temp);
                        return;
                    }
                 

                }
                //else if (response.Contains("contactAdded"))
                //{
                //    JObject r = JObject.Parse(response);
                //    List<string> current = new List<string>();
                //    string user = "";
                //    foreach(var pair in r)
                //    {
                //        if(pair.Key == "currentMembers")
                //        {
                //            current = pair.Value.ToObject<List<string>>();
                //        }
                //        else if(pair.Key == "username")
                //        {
                //            user = (string)pair.Value;
                //        }
                //    }
                //    if(user == u.userName)
                //    {
                //        contactAddedHandle_1(_sender, _e, _handle, _o, _temp);
                //    }
                //    else if(current.Contains(user))
                //    {
                //        contactAddedHandle_2(_sender, _e, _handle, _o, _temp);
                //    }

                //}

                JObject rss = JObject.Parse(response);
                string username = "";
                string messagetype = "";
                foreach (var pair in rss)
                {
                    if (pair.Key == "username")
                        username = (string)pair.Value;
                    if (pair.Key == "messageType")
                        messagetype = (string)pair.Value;
                    
                }


                if (flag == true)
                {
                    if (messagetype == "login" && u.userName == null)
                    {
                        myHandler(_sender, _e, _handle, _o, _temp);
                    }

                    else if (username != "" && messagetype != "")
                    {
                        if (u.userName != username && u.contactList.Contains(username))
                        {
                            if (messagetype == "login")
                                friendLoginHandle(_sender, _e, _handle, _o, _temp);
                            if (messagetype == "logout")
                                friendLogoutHandle(_sender, _e, _handle, _o, _temp);
                        }
                       else if(u.userName == username)
                        {
                            myHandler(_sender, _e, _handle, _o, _temp);
                        }
                    }
                       
                  }
                
            };
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
        public void handle(object sender, EventArgs e, messageType handle, ExpandoObject o, string temp)
        {
            switch (handle)
            {
                case messageType.login:
                    _sender = sender;
                    _e = e;
                    _handle = handle;
                    _o = o;
                    _temp = temp;                    
                    myHandler = loginHandle;
                    flag = true; // logged in                   
                    break;
                case messageType.chatMessage:
                    _sender = sender;
                    _e = e;
                    _handle = handle;
                    _o = o;
                    _temp = temp;
                    myHandler = chatMessageHandle;
                    break;
                case messageType.contactAdded:
                    _sender = sender;
                    _e = e;
                    _handle = handle;
                    _o = o;
                    _temp = temp;
                    myHandler = contactAddedHandle_1;
                    break;
                case messageType.addChatMember:
                    _sender = sender;
                    _e = e;
                    _handle = handle;
                    _o = o;
                    _temp = temp;
              // myHandler = addChatMemberHandle;
                    break;
                case messageType.contactRemoved:
                    _sender = sender;
                    _e = e;
                    _handle = handle;
                    _o = o;
                    _temp = temp;
                 myHandler = contactRemovedHandle;
                    break;
                case messageType.createChat:
                    _sender = sender;
                    _e = e;
                    _handle = handle;
                    _o = o;
                    _temp = temp;
                    myHandler = createChatHandle;
                    break;
                //case messageType.leaveChat:
                //    leaveChatHandle(sender, e, handle, o, temp);
                //    break;
                case messageType.logout:
                    _sender = sender;
                    _e = e;
                    _handle = handle;
                    _o = o;
                    _temp = temp;
                    myHandler = logoutHandle;
                    break;
                    //case messageType.roomStatusChange:
                    //    roomStatusChangeHandle(sender, e, handle, o, temp);
                    //    break;
                    //case messageType.statusChange:
                    //    statusChangeHandle(sender, e, handle, o, temp);
                    //    break;

            }
            sendMessage(o);
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
                    JObject rss = JObject.Parse(response);

                    foreach (var pair in rss)
                    {
                        if (pair.Key == "username")
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
                    {
                        flag = false;
                        u.status = 1;
                        
                    }
                        }

                        else if (pair.Key == "contactList")
                        {
                            contactList = pair.Value.ToObject<List<string>>();
                            u.contactList = contactList;
                        }
                    }
                    signalObservers(sender, error, response,null, 2);
        }
        // handles request by dealing TWO cards at a time:
        public void logoutHandle(object sender, EventArgs e, messageType handle, ExpandoObject o, string username)
        {
            int error = 0;
            JObject jo = JObject.FromObject(o);
            string json = jo.ToString();
            string user_name = "";
         //   string response = dummy.logout(json);
            JObject rss = JObject.Parse(response);
            foreach (var pair in rss)
            {
                 if (pair.Key == "error")
                {
                    error = (int)pair.Value;
                    if (error == 0)
                    {
                        // user.status = 1 means it is offline
                        u.status = 1;
                    }
                    else 
                    {
                        u.status = 0;
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
            signalObservers(sender, error, response,user_name, 3);
        }

        public void contactAddedHandle_1(object sender, EventArgs e, messageType handle, ExpandoObject o, string username)
        {
            int error = 0;
            int status = 0;
            List<string> current = new List<string>();
            JObject jo = JObject.FromObject(o);
            string json = jo.ToString();
            int roomNumber = 0;
            Dictionary<string, int> mutualFriends = new Dictionary<string, int>();
            JObject rss = JObject.Parse(response);
            foreach (var pair in rss)
            {
                if (pair.Key == "error")
                {
                    error = (int)pair.Value;
                }

                else if (pair.Key == "status")
                {
                    status = (int)pair.Value;
                }
                //else if(pair.Key == "roomNumber")
                //{
                //    roomNumber = (int)pair.Value;
                //}
                //else if(pair.Key == "potentialMembers")
                //{
                //    mutualFriends = pair.Value.ToObject<Dictionary<string, int>>();
                //}

            }
            if (error == 0)
            {
                u.contactList.Add(username);
                u.contactList.Add(status.ToString());
                signalObservers(sender, error, response, null, 7);
                //if(mutualFriends != u.mutualMembers || u.mutualMembers == null)
                //{
                //    signalObservers(sender, error, response, null, 7);

                //}
                //else 
                //{
                //    signalObservers(sender, error, response, null, 8);
                //}
            }
                
            
        }
        public void contactAddedHandle_2(object sender, EventArgs e, messageType handle, ExpandoObject o, string usernameo)
        {

        }
        public void createChatHandle(object sender, EventArgs e, messageType handle, ExpandoObject o, string usernameo)
        {
            int error = 0;
            int roomnumber = 0;
            JObject jo = JObject.FromObject(o);
            string json = jo.ToString();
            List<string> currentMembers = new List<string>();
            Dictionary<string,int> mutualMembers = new Dictionary<string, int>();

            JObject rss = JObject.Parse(response);

            foreach (var pair in rss)
            {
                if (pair.Key == "error")
                {
                    error = (int)pair.Value;
                }

                else if (pair.Key == "currentMembers")
                {
                    currentMembers = pair.Value.ToObject<List<string>>();//(List<string>)pair.Value;
                }

                else if (pair.Key == "potentialMembers")
                {
                    mutualMembers = pair.Value.ToObject<Dictionary<string, int>>();
                }
                else if(pair.Key == "roomNumber")
                {
                    roomnumber = (int)pair.Value;
                }

            }
            if (error == 0)
            { 
                u.currentMembers = currentMembers;
                u.mutualMembers = mutualMembers;
                u.roomNumber = roomnumber;

                // MessageReceived = chatbox.MessageReceived;
            }
            else if (error == 1)
                System.Windows.Forms.MessageBox.Show("The person is not in your friend list. Please add first!");
            else
                System.Windows.Forms.MessageBox.Show("Cannot connect tho the server!");

            signalObservers(sender, error,response, null, 4);
                
            
        }

        public void chatMessageHandle(object sender, EventArgs e, messageType handle, ExpandoObject o, string temp)
        {

            JObject jo = JObject.FromObject(o);
            string json = jo.ToString();
            JObject rss = JObject.Parse(response);
                    int error = 0;
                    int roomName = 0;
                    string content = "";
                    string username = "";
                    string timestamp = "";
                    string message = "";
                    foreach (var pair in rss)
                    {
                        if (pair.Key == "error")
                        {
                            error = (int)pair.Value;
                        }


                        else if (pair.Key == "content")
                        {
                            content = (string)pair.Value;//(List<string>)pair.Value;
                        }

                        else if (pair.Key == "username")
                        {
                            username = (string)pair.Value;
                            
                        }
                        else if (pair.Key == "timeStamp")
                        {
                            timestamp = (string)pair.Value;
                        }

                else if (pair.Key == "roomNumber")
                {
                    roomName = (int)pair.Value;
                }
            }
                    if (error == 0)
                    {
                        
                        message = timestamp + "\n" + username + ": " + content;
                    }

                    if(u.roomNumber == roomName)
                        signalObservers(sender, error, response, message, 10);


                
            

       }

        public void friendLoginHandle(object sender, EventArgs e, messageType handle, ExpandoObject o, string temp)
        {
            int error = 0;
            string username = "";
            JObject jo = JObject.FromObject(o);
            string json = jo.ToString();
            JObject rss = JObject.Parse(response);

            foreach (var pair in rss)
            {
                if (pair.Key == "username")
                {
                    username = (string)pair.Value;   
                    //Debug.Assert(u.userName == username);
                    //Console.Write(u.userName);
                }

                else if (pair.Key == "error")
                {
                    error = (int)pair.Value;
                }        
            }
            int index = u.contactList.IndexOf(username);
            u.contactList[index + 1] = "0";
            signalObservers(sender, error, response, username, 0); // 0 is login
        }

        public void friendLogoutHandle(object sender, EventArgs e, messageType handle, ExpandoObject o, string temp)
        {
            int error = 0;
            string username = "";
            JObject jo = JObject.FromObject(o);
            string json = jo.ToString();
            JObject rss = JObject.Parse(response);

            foreach (var pair in rss)
            {
                if (pair.Key == "username")
                {
                    username = (string)pair.Value;
                    //Debug.Assert(u.userName == username);
                    //Console.Write(u.userName);
                }

                else if (pair.Key == "error")
                {
                    error = (int)pair.Value;
                }
            }
            int index = u.contactList.IndexOf(username);
            u.contactList[index + 1] = "1";
            signalObservers(sender, error, response, username, 1); // 0 is login
        }

        public void contactRemovedHandle(object sender, EventArgs e, messageType handle, ExpandoObject o, string usernameRemoved)
        {
            JObject jo = JObject.FromObject(o);
            string json = jo.ToString();
            JObject rss = JObject.Parse(response);
            int error = 0;
            
            foreach(var pair in rss)
            {
                if(pair.Key == "error")
                {
                    error = (int)pair.Value;
                }
            }
            int index = u.contactList.IndexOf(usernameRemoved);

            u.contactList.Remove(usernameRemoved);
            u.contactList.RemoveAt(index);
            signalObservers(sender, error, response, usernameRemoved,7); // 0 is login

        }

        public void addChatMemberHandle_1(object sender, EventArgs e, messageType handle, ExpandoObject o, string temp)
        {
            JObject jo = JObject.FromObject(o);
            string json = jo.ToString();
            JObject rss = JObject.Parse(response);

            /*
             * server-side response(to target):
                message type(addChatMember)
                error type,
                roomNumber(integer),
                potentialMembers(string array),
                currentMembers(string array),
                messageHistory(string array)

                server-side response(to chat members):
                message type(roomStatusChange),
                error type,
                roomNumner(integer),
                potentialMembers(string array),
                currentMembers(string array)

             * */
            int error = 0;
            int roomNumber = 0;
            Dictionary<string, int> potentialMem = new Dictionary<string, int>();
            List<string> currentMem = new List<string>();
            foreach(var pair in rss)
            {
                if(pair.Key == "error")
                {
                    error = (int)pair.Value;
                }
                else if(pair.Key == "roomNumber")
                {
                    roomNumber = (int)pair.Value;
                }
                else if(pair.Key == "potentialMembers")
                {
                    potentialMem = pair.Value.ToObject<Dictionary<string, int>>();
                }
                else if(pair.Key == "currentMembers")
                {
                    currentMem = pair.Value.ToObject<List<string>>();

                }
            }
            if(error == 0 && u.roomNumber == roomNumber)
            {
                u.mutualMembers = potentialMem;
            }
            signalObservers(sender, error, response, temp , 4); // 0 is login


        }

        public void addChatMemberHandle_2(object sender, EventArgs e, messageType handle, ExpandoObject o, string temp)
        {
            JObject jo = JObject.FromObject(o);
            string json = jo.ToString();
            JObject rss = JObject.Parse(response);

            /*
             * server-side response(to target):
                message type(addChatMember)
                error type,
                roomNumber(integer),
                potentialMembers(string array),
                currentMembers(string array),
                messageHistory(string array)

                server-side response(to chat members):
                message type(roomStatusChange),
                error type,
                roomNumner(integer),
                potentialMembers(string array),
                currentMembers(string array)

             * */
            int error = 0;
            int roomNumber = 0;
            Dictionary<string, int> potentialMem = new Dictionary<string, int>();
            List<string> currentMem = new List<string>();
            List<string> history = new List<string>();
            foreach (var pair in rss)
            {
                if (pair.Key == "error")
                {
                    error = (int)pair.Value;
                }
                else if (pair.Key == "roomNumber")
                {
                    roomNumber = (int)pair.Value;
                }
                else if (pair.Key == "potentialMembers")
                {
                    potentialMem = pair.Value.ToObject<Dictionary<string, int>>();
                }
                else if (pair.Key == "currentMembers")
                {
                    currentMem = pair.Value.ToObject<List<string>>();

                }
                else if(pair.Key == "messageHistory")
                {
                    history = pair.Value.ToObject<List<string>>();
                }
            }
            if (error == 0 )
            {
                u.roomNumber = roomNumber;
                u.currentMembers = currentMem;
                u.mutualMembers = potentialMem;
                u.history = history;
            }

            signalObservers(sender, error, response, temp, 5); // 0 is login


        }


        public bool sendMessage(ExpandoObject o)
        {

            JObject jo = JObject.FromObject(o);
            string json = jo.ToString();
            // Send the message to the server if connection is alive
            if (ws.IsAlive)
            {
                ws.Send(json);
                return true;
            }
            else
            {
                while(!ws.IsAlive)
                {
                    ws.Connect();
                }
                ws.Send(json);
                return true;
            }
        }


        public void signalObservers(object sender,int e, string response, string str, int s) { foreach (Observer m in observers) { m(sender,e, response,str,s); } }
    }
}
