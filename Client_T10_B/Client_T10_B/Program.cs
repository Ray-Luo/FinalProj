using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_T10_B
{
    public static class Program
    {
        // defines the type of method that observes model updates:
        public delegate void Observer(object sender, int e);

        // defines the type of method that handles an input event (button press):
        public delegate void InputHandler(object sender, EventArgs e, ExpandoObject o);
        public delegate void InputHandler1(object sender, EventArgs e, ExpandoObject o, string name);
       

        public delegate bool Message(string message);

        // message types for the server client sync 
        public enum messageType { login, logout, statusChange, roomStatusChange, createChat, addChatMember, leaveChat, chatMessage, contactAdded, contactRemoved };

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            User_m u = new User_m();
            Controller c = new Controller(u);
            LogIn l = new LogIn(c.loginHandle,c.addContactHandle, u, c);
            User_v user_main = new User_v(u, c.logoutHandle,c.addContactHandle, c);
            c.register(l.login);
            c.register(user_main.logout);
            c.register(user_main.refreshContactList);
            Application.Run(l);
        }
    }
}
