using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Client_T10_B.Program;


namespace Client_T10_B
{
    public class Controller
    {
        private List<Observer> observers = new List<Observer>();  // registry of event handlers
        private User_m user;  // handles to Model objects
        private Dummy_API dummy = new Dummy_API();

        public Controller(User_m u)
        {
            this.user = u;
        }

        // register(f) adds event-handler method  f  to the registry:
        public void register(Observer f) { observers.Add(f); }

        // handles request by dealing a card from the deck to the hand:
        public void loginHandle(object sender, EventArgs e, ExpandoObject o)
        {
            //TODO : do check for the valid user name 
            int error = 0;
            List<string> contactList = new List<string>();
            JObject jo = JObject.FromObject(o);
            jo.Add("messageType", "login");
            string json = jo.ToString();
            //Console.Write(json);
            Console.Write(json);
            string response = dummy.login(json);
            JObject rss = JObject.Parse(response);
          
            foreach(var pair in rss)
            {
                if (pair.Key == "messageType")
                {
                    Debug.Assert((string)pair.Value == "login");
                }

                else if (pair.Key == "username")
                {
                    user.userName = (string)pair.Value;
                    Console.Write(user.userName);
                }

                else if (pair.Key == "error")
                {
                    error = (int)pair.Value;
                }

                else if (pair.Key == "contactList")
                {
                    contactList = pair.Value.ToObject<List<string>>();
                    user.contactList = contactList;
                } 
            }
            signalObservers(sender, error);

        }
        // handles request by dealing TWO cards at a time:
        public void logoutHandle(object sender, EventArgs e)
        {
            // TODO
            //signalObservers();
        }

        public void signalObservers(object sender,int e) { foreach (Observer m in observers) { m(sender,e); } }
    }
}
