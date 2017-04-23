using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_T10_B
{
    class User_m
    {
        string userName;
        string password;
        List<User_m> contactList;
        List<int> roomNumbers;

        public User_m(string u, string p)
        {
            this.userName = u;
            this.password = p;
            contactList = new List<User_m>();
            roomNumbers = new List<int>();
        }
    }
}
