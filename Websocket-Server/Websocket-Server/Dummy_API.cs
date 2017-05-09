using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Diagnostics;

namespace Websocket_Server
{
    class Dummy_API
    {
        public static List<User_m> users = new List<User_m>();
        public static List<ChatRoom_m> chatRooms = new List<ChatRoom_m>();
        public Dummy_API()
        {

        }

        public User_m getUser(String username)
        {
            foreach (User_m u in users)
            {
                if(u.userName == username)
                {
                    return u;
                }
            }
            return null;
        }
        public ChatRoom_m getChatRoom(int roomNo)
        {
            foreach (ChatRoom_m r in chatRooms)
            {
                if(r.roomNumber == roomNo)
                {
                    return r;
                }
            }
            return null;
        }
        /* message type(login),
            error type,
            username(string),
            contactList(string array)*/
        public string login(string json)
        {
            // List<string> contactList = new List<string>(new string[] { "John", "1", "Sarah", "0" } );
            Console.WriteLine(json);
            JObject rss = JObject.Parse(json);
            string username = "";
            string password = "";
            int error = 0;
            List<string> contactList = new List<string>();
            foreach (var pair in rss)
            {
                if (pair.Key == "username")
                {
                    username = (string)pair.Value;
                }
                else if (pair.Key == "password")
                {
                    password = (string)pair.Value;
                }
            }
            if (getUser(username) == null)
            {
                User_m user = new User_m();
                user.userName = username;
                user.password = password;
                user.status = 0;
                contactList = user.contactList;
                users.Add(user);
            }
            else
            {
                User_m user = getUser(username);
                Console.Write(user.password);
                if ( user.password == password)
                {
                    error = 0;
                }
                else
                {
                    error = 1; //password does not match 
                }
                contactList = user.contactList;
                user.status = 0;
            }
            dynamic o = new ExpandoObject();
            JObject jo = JObject.FromObject(o);
            jo.Add("messageType", "login");
            jo.Add("username", username);
            jo.Add("error", error);
            jo.Add("contactList", JToken.FromObject(contactList));//JToken.FromObject(new string[] { "John", "1", "Sarah", "0" }));
            string output = jo.ToString();
            return output;
        }

        public string logout(string json)
        {
            JObject rss = JObject.Parse(json);
            string username = "";
            foreach (var pair in rss)
            {
                if (pair.Key == "username")
                {
                    username = (string)pair.Value;
                }
            }
            int error = 0;
            if(getUser(username) == null)
            {
                error = 1;
            }
            User_m user = getUser(username);
            user.status = 1;

            dynamic o = new ExpandoObject();
            JObject jo = JObject.FromObject(o);
            jo.Add("messageType", "logout");
            jo.Add("username", username);
            jo.Add("error", error);
            string output = jo.ToString();
            return output;
        }

        public string createUser(string json)
        {
            return null;

        }

        public string createChat(string json)
        {
            /*
             client-side request:
             message type(contactAdded),
             username(string),
             usernameAdd(string)
             * */
            /*
             *  message type(createChat),
                error type,
                roomname(integer),
                potentialMembers(string array),
                currentMembers(string array)
             * */
            
            JObject rss = JObject.Parse(json);
            string username = "";
            string friend = "";
            int error = 0;
            List<string> currentMembers = new List<string>();
            Dictionary<string,int> mutualFriends = new Dictionary<string, int>();
            ChatRoom_m chat = new ChatRoom_m();

            foreach (var pair in rss)
            {
                if (pair.Key == "username")
                {
                    username = (string)pair.Value;
                }
                else if(pair.Key == "usernameAdd")
                {
                    friend = (string)pair.Value;
                }
            }
            User_m user1 = getUser(username);
            User_m user2 = getUser(friend);

            if (!user1.contactList.Contains(friend))
            {
                error = 1;
            }
            else
            {
                chat.roomNumber = chatRooms.Count;
                chat.users = new List<string>();
                chat.users.Add(username);
                chat.users.Add(friend);
                chatRooms.Add(chat);
                currentMembers = chat.users;
                Dictionary<string, int> friendList1 = user1.getContactList();
                Dictionary<string, int> friendList2 = user2.getContactList();

                foreach (KeyValuePair<string, int> f1 in friendList1)
                {
                    foreach (KeyValuePair<string, int> f2 in friendList2)
                    {
                        if (f2.Key == f1.Key)
                        {
                            mutualFriends.Add(f1.Key, f1.Value);
                        }
                    }
                }
                chat.mutualFriends = mutualFriends;
                error = 0;
            }
                dynamic o = new ExpandoObject();
                JObject jo = JObject.FromObject(o);
                jo.Add("messageType", "createChat");
                jo.Add("roomNumber", chat.roomNumber);
                jo.Add("username", username);
                jo.Add("potentialMembers", JToken.FromObject(mutualFriends));
                jo.Add("currentMembers", JToken.FromObject(currentMembers));
                jo.Add("error", error);
                string output = jo.ToString();
                return output;
        }

        public string addChatMember(string json)
        {
            /*
             * client-side request:
                message type(addChatMember),
                roomname(int),
                usernameAdded(string)

             *  server-side response(to target):
                message type(addChatMember)
                error type,
                roomname(integer),
                usernameAdded(string),s
                potentialMembers(string array),
                currentMembers(string array),
                messageHistory(string array)          

             * */
            JObject rss = JObject.Parse(json);
            string friend = "";
            int roomname = 0;
            int error = 0;
            List<string> currentMembers = new List<string>();



            foreach (var pair in rss)
            {
                   
                if (pair.Key == "friend")
                {
                    friend = (string)pair.Value;
                }
                else if (pair.Key == "roomNumber")
                {
                    roomname = (int)pair.Value;
                }
            }
            ChatRoom_m chat = getChatRoom(roomname);
            if (chat != null)
            {
                if (!chat.users.Contains(friend))
                {
                    Dictionary<string, int> currentmutualFriends = chat.mutualFriends;
                    List<string> keysToRemove = new List<string>();
                    if (currentmutualFriends.ContainsKey(friend))
                    {
                        User_m user = getUser(friend);
                        Dictionary<string, int> friendList = user.getContactList();
                        if (friendList.Count == 0)
                        {
                            chat.mutualFriends.Clear();
                        }
                        else
                        {

                            foreach (KeyValuePair<string, int> f1 in currentmutualFriends)//cc,dd
                            {
                                    if (!friendList.ContainsKey(f1.Key))
                                    {
                                        keysToRemove.Add(f1.Key);
                                    }
                            }
                            foreach (string key in keysToRemove)
                            {
                                chat.mutualFriends.Remove(key);
                            }
                        }
                        
                        chat.users.Add(friend);
                        if (chat.mutualFriends.ContainsKey(friend))
                        {
                            chat.mutualFriends.Remove(friend);
                        }
                        error = 0;
                    }
                    else
                    {
                        error = 1;
                    }
                }

                else
                {
                    error = 2;
                }
            }
            else
            {
                error = 3;
            }
            dynamic o = new ExpandoObject();
            JObject jo = JObject.FromObject(o);
            jo.Add("messageType", "addChatMember");
            jo.Add("usernameAdded", friend);
            jo.Add("roomNumber", chat.roomNumber);
            jo.Add("potentialMembers", JToken.FromObject(chat.mutualFriends));
            jo.Add("currentMembers", JToken.FromObject(chat.users));
            jo.Add("error", error);
            jo.Add("messageHistory", JToken.FromObject(chat.history));
            string output = jo.ToString();
            return output;

        }

        public string leaveChat(string json)
        {
            /*
            client-side request:
            message type(leaveChat),
            username(string),
            roomname(integer)

            server-side response(to other chatRoom members):
            message type(roomStatusChange),
            error type,
            roomNumber(integer),
            currentMembers(string array)
             * */
            JObject rss = JObject.Parse(json);
            string username = "";
            int roomNumber = 0;
            int error = 0;
            foreach(var pair in rss)
            {
                if(pair.Key == "username")
                {
                    username = (string)pair.Value;
                }
                else if(pair.Key == "roomNumber")
                {
                    roomNumber = (int)pair.Value;
                }
            }
            ChatRoom_m chat = getChatRoom(roomNumber);
            if (chat.users.Contains(username))
            {
                chat.users.Remove(username);
                error = 0;
            }
            else
            {
                error = 1;
            }

            dynamic o = new ExpandoObject();
            JObject jo = JObject.FromObject(o);
            jo.Add("messageType", "leaveChat");
            jo.Add("friend", username);
            jo.Add("error", error);
            jo.Add("roomNumber",roomNumber );
            jo.Add("currentMembers", JToken.FromObject(chat.users));
            string output = jo.ToString();
            return output;
        }

        public string chatMessage(string json)
        {
            /*
             * messageType, username, chatRoom, timeStamp, content
             * */
            JObject rss = JObject.Parse(json);
            int roomNumber = 0;
            string username = "";
            int error = 0;
            string timestamp = "";
            string content = "";

            foreach (var pair in rss)
            {
                if (pair.Key == "username")
                {
                    username = (string)pair.Value;
                }
                else if (pair.Key == "roomNumber")
                {
                    roomNumber = (int)pair.Value;
                }
                else if (pair.Key == "timeStamp")
                {
                    timestamp = (string)pair.Value;
                }
                else if(pair.Key == "content")
                {
                    content = (string)pair.Value;
                }
            }
            
            ChatRoom_m chat = getChatRoom(roomNumber);
            chat.history.Add(timestamp + '\n' + username + ':' + content);

            dynamic o = new ExpandoObject();
            JObject jo = JObject.FromObject(o);
            jo.Add("messageType", "chatMessage");
            jo.Add("roomNumber", chat.roomNumber);
            jo.Add("username", username);
            jo.Add("content", content);
            jo.Add("timeStamp", timestamp);
            jo.Add("error", error);
            jo.Add("currentMembers", JToken.FromObject(chat.users));
            string output = jo.ToString();
            return output;

        }

        public string contactAdded(string json)
        {
            /*
             * roomname(integer),
                potentialMembers(string array),
                currentMembers(string array)
             * */
            Console.WriteLine("AddContact\n"+json);
            JObject rss = JObject.Parse(json);
            string username = "";
            string friend = "";
            int error = 0;
            int status = 0;
            int roomNumber = 0;
            List<string> current = new List<string>();
            Dictionary<string, int> potential = new Dictionary<string, int>();
            foreach(var pair in rss)
            {
                if (pair.Key == "usernameOrigin")
                {
                    username = (string)pair.Value;
                }
                else if (pair.Key == "usernameAdd")
                {
                    friend = (string)pair.Value;
                }
            }
            User_m user = getUser(username);
            User_m newContact = getUser(friend);
            if (user != null)
            {
                if (newContact != null)
                {
                    if (username != friend)
                    { 
                        status = newContact.status;
                        user.contactList.Add(friend);
                        user.contactList.Add(status.ToString());

                    foreach (ChatRoom_m chat in chatRooms)
                    {
                        if (chat.users.Contains(username))
                        {
                            List<string> users = chat.users;
                            int cnt = users.Count;
                            int flag = 0;
                            bool i = false;

                            foreach (string u in users)
                            {
                                User_m chatMember = getUser(u);
                                i = chatMember.contactList.Contains(friend);
                                if (i == true)
                                {
                                    flag++;
                                }
                            }

                            if (flag == cnt)
                            {
                                chat.mutualFriends.Add(friend, newContact.status);
                                current = chat.users;
                                roomNumber = chat.roomNumber;
                                potential = chat.mutualFriends;
                            }
                        }

                    }
                  }
                    else
                    {
                        error = 3; // cannot add yourself as a friend 
                    }
                }
                else
                {
                    error = 2; // friend does not exists 
                }
                
            }
            else
            {
                error = 1; // user not found 
            }
            dynamic o = new ExpandoObject();
            JObject jo = JObject.FromObject(o);
            jo.Add("messageType", "contactAdded");
            jo.Add("username", username);
            jo.Add("usernameAdded", friend);
            jo.Add("status", status);
            jo.Add("error", error);
            jo.Add("roomNumber", roomNumber);
            jo.Add("potentialMembers", JToken.FromObject(potential));
            jo.Add("currentMembers", JToken.FromObject(current));
            string output = jo.ToString();
            return output;

        }

        public string contactRemoved(string json)
        {
            /*
             * 
             * client-side request:
                message type(contactRemoved),
                username(string),
                usernameRemoved(string)

                server-side response(to appropriate users with chatRooms):
                message type(roomStatusChange),
                error type,
                roomname(integer),
                potentialMembers(string array),
                currentMembers(string array)
             * */
            JObject rss = JObject.Parse(json);
            string username = "";
            string friend = "";
            int error = 0;
            int status = 0;
            foreach (var pair in rss)
            {
                if (pair.Key == "username")
                {
                    username = (string)pair.Value;
                }
                else if (pair.Key == "usernameRemoved")
                {
                    friend = (string)pair.Value;
                }
            }
            User_m user = getUser(username);
            if(user.contactList.Contains(friend))
            {
                int index = user.contactList.IndexOf(friend);
                user.contactList.Remove(friend);
                user.contactList.RemoveAt(index);
                error = 0;
            }
            else
            {
                error = 1;

            }

            dynamic o = new ExpandoObject();
            JObject jo = JObject.FromObject(o);
            jo.Add("messageType", "contactRemoved");
            jo.Add("username", username);
            jo.Add("error", error);
            string output = jo.ToString();
            return output;

        }

    }
}
