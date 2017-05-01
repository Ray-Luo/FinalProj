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
        List<User_m> users = new List<User_m>();
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
            dynamic o = new ExpandoObject();
            JObject jo = JObject.FromObject(o);
            jo.Add("messageType", "logout");
            jo.Add("username", username);
            jo.Add("error", 0);
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
             usernameOrigin(string),
             usernameAdd(string)
             * */
            JObject rss = JObject.Parse(json);
            string username = "";
            foreach (var pair in rss)
            {
                if (pair.Key == "username")
                {
                    username = (string)pair.Value;
                }
            }
            dynamic o = new ExpandoObject();
            JObject jo = JObject.FromObject(o);
            jo.Add("messageType", "createChat");
            jo.Add("username_1", "Ray");
            jo.Add("username_2", "John");
            jo.Add("roomNumber", "0");
            jo.Add("error", 0);
            string output = jo.ToString();
            return output;

        }

        public string addChatMember(string json)
        {
            return null;

        }

        public string leaveChat(string json)
        {
            return null;

        }

        public string chatMessage(string json)
        {
            return null;

        }

        public string contactAdded(string json)
        {
            JObject rss = JObject.Parse(json);
            string username = "";
            string friend = "";
            int error = 0;
            int status = 0;
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
            if(getUser(username) != null)
            {
                User_m user = getUser(username);
                if(getUser(friend) != null)
                {
                    User_m newContact = getUser(friend);
                    status = newContact.status;
                    user.contactList.Add(friend);
                    user.contactList.Add(status.ToString());
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
            jo.Add("status", status);
            jo.Add("error", error);
            string output = jo.ToString();
            return output;

        }

        public string contactRemoved(string json)
        {
            return null;

        }
    }
}
