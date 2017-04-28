using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Client_T10_B.Program;

namespace Client_T10_B
{
    public partial class User_v : Form
    {
        InputHandler f;
        User_m u;

        public User_v(InputHandler f, User_m u)//User_m u, InputHandler h, Controller controller)
        {
            this.f = f;
            this.u = u;
            InitializeComponent();
        }


        private void uxContactList_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        //private void User_v_Load(object sender, EventArgs e)
        //{
        //    uxUserName.Text = user.userName;
        //    Dictionary<string, int> contacts = user.getContactList();
        //    foreach (KeyValuePair<string, int> c in contacts)
        //    {
        //        ListViewItem li = new ListViewItem();
        //        if (c.Value == 0) //logged in 
        //        {
        //            li.ForeColor = Color.Green;
        //        }
        //        else //logged out 
        //        {
        //            li.ForeColor = Color.Red;
        //        }
        //        li.Text = c.Key;
        //        uxContactList.Items.Add(li);
        //    }
        //}

        public void logout(object sender, int error, string username)
        {
            Button clickedButton = sender as Button;
            if (clickedButton.Text == "Logout")
            {
                if (error == 0)
                {
                    if (username != null)
                    {
                        MessageBox.Show(username + " loggout");
                    }
                    Application.Exit();
                }
                else
                    MessageBox.Show("Logout failed");
            }
        }

        private void uxLogout_Click(object sender, EventArgs e)
        {
            dynamic o = new ExpandoObject();
            o.username = uxUserName.Text.ToString();
            o.messageType = messageType.logout;
            messageType handle = messageType.logout;
            f(sender, e, handle, o, uxUserName.Text.ToString());
        }


        public void refreshContactList(object sender, int e, string temp)
        {
            // uxContactList.DataBindings.Clear();
            if (e == 0)
            {
                Dictionary<string, int> contacts = u.getContactList();
                foreach (KeyValuePair<string, int> c in contacts)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = c.Key;
                    if (c.Value == 0) //logged in 
                    {
                        li.ForeColor = Color.Green;
                    }
                    else //logged out 
                    {
                        li.ForeColor = Color.Red;
                    }
                    uxContactList.Items.Add(li);
                }
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        public void uxAddContact_Click(object sender, EventArgs e)
        {
            dynamic o = new ExpandoObject();
            o.username = uxUserName.Text.ToString();
            o.friend = uxPersonName.Text.ToString();
            o.messageType = messageType.contactAdded;
            messageType handle = messageType.contactAdded;
            f(sender, e, handle, o, uxPersonName.Text.ToString());
        }

        //private void uxChat_Click(object sender, EventArgs e)
        //{
        //    dynamic o = new ExpandoObject();
        //    o.username = uxUserName.Text.ToString();
        //    if (uxContactList.SelectedItems.Count == 0)
        //    {
        //        MessageBox.Show("Please select a contact to chat");
        //        return;
        //    }
        //    o.usernameAdd = uxContactList.SelectedItems[0].Text.ToString();
        //    o.messageType = messageType.createChat;
        //    handler = controller.createChatHandle;
        //    handler(sender, e, o);
        //}

        //public void showChatbox(object sender, int error)
        //{
        //    Button clickedButton = sender as Button;
        //    if (clickedButton.Text == "Chat")
        //    {
        //        if (error == 0)
        //        {
        //            Application.Exit();
        //        }
        //        else
        //            MessageBox.Show("Logout failed");
        //    }
        //}
    }
}
