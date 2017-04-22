using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_T10_B
{
    class User
    {
        string userName;
        string password;
        List<User> contactList;

        public User(string u, string p)
        {
            this.userName = u;
            this.password = p;
            contactList = new List<User>();
        }
    }
}
