using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_T10_B
{
    static class Program
    {
        // defines the type of method that observes model updates:
        public delegate void Observer();
        // defines the type of method that handles an input event (button press):
        public delegate void InputHandler(object sender, EventArgs e);
        
        // message types for the server client sync 
        public enum messageType { login, logOut, statusChange, roomStatusChange, createChat, addChatMember, leaveChat, chatMessage, contactAdded, contactRemoved };

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
        }
    }
}
