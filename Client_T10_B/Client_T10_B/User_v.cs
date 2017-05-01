using System;
using System.Collections;
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
            o.messageType = "logout";
            messageType handle = messageType.logout;
            f(sender, e, handle, o, uxUserName.Text.ToString());
          //  refreshContactList(sender, 0, null);
        }


        public void refreshContactList(object sender, int e, string temp)
        {
            if (e == 0)
            {
                Dictionary<string, int> contacts = u.getContactList();
                uxContactList.BeginUpdate();
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

                uxContactList.EndUpdate();
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        public void uxAddContact_Click(object sender, EventArgs e)
        {
            dynamic o = new ExpandoObject();
            o.usernameOrigin = uxUserName.Text.ToString();
            o.usernameAdd = uxPersonName.Text.ToString();
            o.messageType = "contactAdded";
            messageType handle = messageType.contactAdded;
            uxContactList.BeginUpdate();
            f(sender, e, handle, o, uxPersonName.Text.ToString() );
            uxContactList.EndUpdate();
        }

        private void User_v_Load(object sender, EventArgs e)
        {
            uxUserName.Text = u.userName;
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

        public void showChatbox(object sender, int error)
        {
            Button clickedButton = sender as Button;
            if (clickedButton.Text == "Chat")
            {
                if (error == 0)
                {
                    Application.Exit();
                }
                else
                    MessageBox.Show("Logout failed");
            }
        }

        private void uxChat_Click(object sender, EventArgs e)
        {
            dynamic o = new ExpandoObject();
            o.username = uxUserName.Text.ToString();
            if (uxContactList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a contact to chat");
                return;
            }
            o.usernameAdd = uxContactList.SelectedItems[0].Text.ToString();
            o.messageType = messageType.createChat;
            messageType handle = messageType.createChat;
            f(sender, e, handle, o, null);
        }
    }
}
