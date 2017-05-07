using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websocket_Server
{
    public class ChatRoom_m
    {
        public List<string> users;
        public int roomNumber;
        public Dictionary<string, int> mutualFriends;

        public ChatRoom_m()
        {
          
        }

        //public Dictionary<string, int> getmutualFriends()
        //{
        //    int c = 1;
        //    Dictionary<string, int> contacts = new Dictionary<string, int>(); //key name , value status 
        //    List<string> friends = new List<string>();
        //    List<int> status = new List<int>();
        //    foreach (string s in this.mutualFriends)
        //    {
        //        if (c % 2 != 0)
        //        {
        //            //Console.Write(s);
        //            friends.Add(s);
        //            c++;
        //        }
        //        else
        //        {
        //            // Console.Write(s);
        //            status.Add(Convert.ToInt32(s));
        //            c++;
        //        }
        //    }

        //    using (var e1 = friends.GetEnumerator())
        //    using (var e2 = status.GetEnumerator())
        //    {
        //        while (e1.MoveNext() && e2.MoveNext())
        //        {
        //            contacts.Add(e1.Current, e2.Current);
        //        }
        //    }

        //    return contacts;
        //}
    }
}
