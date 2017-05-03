using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using static Client_T10_B.Program;

namespace Client_T10_B
{
    public partial class Chatbox_v : Form
    {
        public Chatbox_v(ChatRoom_m room, Program.Message newMessageHandler, InputHandler f)
        {
            InitializeComponent();
            uxTextbox.KeyDown += (o, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string message = uxTextbox.Text;
                    dynamic obj = new ExpandoObject();
                    obj.message = message;
                    obj.messageType = "chatMessage";
                    messageType handle = messageType.chatMessage;                
                    JObject jo = JObject.FromObject(obj);
                    f(o, e, handle, obj, "");
                    //string json = jo.ToString();


                    // if (newMessageHandler(json))
                    // {
                    //     uxTextbox.Text = "";
                    //  }
                }
            };


            //uxmessageBox.Select();
        }

        public bool MessageReceived(string message)
        {
            // Add message to messageListBox and scroll to bottom
            // Invoke is used to make sure that this is done in the GUI thread
            //if (!this.IsHandleCreated)
            //{
            //    this.CreateHandle();
            //}
            //Invoke(new Action(() => uxmessageBox.TopIndex = uxmessageBox.Items.Add(message)));            
            return true;
        }

    }
}
