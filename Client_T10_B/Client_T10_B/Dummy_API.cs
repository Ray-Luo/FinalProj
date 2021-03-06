﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace Client_T10_B
{
    class Dummy_API
    {
        public Dummy_API()
        {

        }

        /* message type(login),
            error type,
            username(string),
            contactList(string array)*/
        public string login(string json)
        {
           // List<string> contactList = new List<string>(new string[] { "John", "1", "Sarah", "0" } );
            dynamic o = new ExpandoObject();
            JObject jo = JObject.FromObject(o);
            jo.Add("messageType", "login");
            jo.Add("username", "vira");
            jo.Add("error",0);
            jo.Add("contactList", JToken.FromObject(new string[] { "John", "1", "Sarah", "0" }));
            string output = jo.ToString();
            return output;

        }

        public string logout(string json)
        {
            dynamic o = new ExpandoObject();
            JObject jo = JObject.FromObject(o);
            jo.Add("messageType", "logout");
            jo.Add("username", "vira");
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
            dynamic o = new ExpandoObject();
            JObject jo = JObject.FromObject(o);
            jo.Add("messageType", "contactAdded");
            jo.Add("status", "0");
            jo.Add("error", 0);
            string output = jo.ToString();
            return output;

        }

        public string contactRemoved(string json)
        {
            return null;

        }
    }
}
