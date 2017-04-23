using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_T10_B
{
    public class User_m
    {
        public string userName;
        public string password;
        public List<User_m> contactList = new List<User_m>();
        public List<int> roomNumbers = new List<int>();

        public User_m()
        {
        }
    }
}
