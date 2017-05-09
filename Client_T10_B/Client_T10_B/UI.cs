using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Client_T10_B.Program;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Client_T10_B
{
    public partial class UI : Form
    {
        InputHandler f;
        User_m u;
        Controller c;
        dynamic MyDynamic = new ExpandoObject();

        public UI(InputHandler f, User_m u)
        {
            this.f = f;
            this.u = u;
            InitializeComponent();
        }

        private void UI_Load(object sender, EventArgs e)
        {
            uxLogout.Enabled = false;
            uxAddContactButton.Enabled = false;
            uxRemove.Enabled = false;
            uxChat.Enabled = true;
            button1.Enabled = true;
            uxSend.Enabled = false;
        }

        private void uxLogin_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic o = new ExpandoObject();
                o.username = uxUsername.Text.ToString();
                o.password = uxPassword.Text.ToString();
                o.messageType = "login";
                u.userName = uxUsername.Text.ToString();
                messageType handle = messageType.login;
                u.userName = uxUsername.Text.ToString();
                f(sender, e, handle, o, uxUsername.Text.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void login(object sender, int error, string response, string username, int s)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == uxLogin)
            {
                if (error == 0)
                {
                    Invoke(new Action(() =>
                    {
                        uxLogin.Enabled = false;
                        uxLogout.Enabled = true;
                        uxAddContactButton.Enabled = true;
                        uxRemove.Enabled = true;
                        uxChat.Enabled = true;
                        button1.Enabled = true;
                        uxSend.Enabled = false;
                        uxUsername.Enabled = false;
                        uxPassword.Enabled = false;
                    }
                    ));

                    // messagebox.show("logged in");
                }
                else if (error == 1)
                {
                    MessageBox.Show("Password is incorrect");
                }
                else
                {
                    MessageBox.Show("Oops, something went wrong!");
                }

            }

        }

        public void MessageReceived(object sender, int error, string response, string message, int s)
        {
            if (response.Contains("chatMessage"))
            {

                Invoke(new Action(() =>
                {
                    uxMessagebox.TopIndex = uxMessagebox.Items.Add(message);
                    uxText.Text = "";
                }
                ));
            }
        }

        private void uxAddContactButton_Click(object sender, EventArgs e)
        {
            dynamic o = new ExpandoObject();
            o.usernameOrigin = uxUsername.Text.ToString();
            o.usernameAdd = uxAddContactBox.Text.ToString();
            o.messageType = "contactAdded";
            messageType handle = messageType.contactAdded;
            f(sender, e, handle, o, uxAddContactBox.Text.ToString());
            Invoke(new Action(() =>
            {
                uxAddContactBox.Text = "";
            }));
        }

        public void removeContact(object sender, int e, string response, string username, int status)
        {
            
           if(e == 1)
            { 
                 MessageBox.Show("No More contacts to remove");
            }
            
        }

        public void refreshContactList(object sender, int e, string response, string username, int status)
        {
            Dictionary<string, int> contacts = u.getContactList();
            if (status != 10 && status != 4 && status != 5)
            {
                if (e == 0)
                {
                    if (status != 4)
                    {
                        if (status == 0) // log in
                        {
                            MessageBox.Show(username + " logged in");
                        }
                        else if (status == 1) // log out
                        {
                            MessageBox.Show(username + " logged out");
                        }
                        else if (status == 2) // I logged in 
                        {
                            MessageBox.Show("Logged In");
                        }
                        else if (status == 3) // I logged in 
                        {
                            if (MessageBox.Show("Are you sure you want to Log out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                MessageBox.Show("Logged out");

                                // user clicked yes
                                Application.Exit();
                                MessageBox.Show("Logged out");
                            }

                        }
                      

                        Invoke(new Action(() =>
                        {
                            uxContactList.Items.Clear();
                            uxContactList.Update();
                            uxContactList.Refresh();
                        }));


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


                            Invoke(new Action(() => uxContactList.Items.Add(li)));
                        }

                        //uxContactList.EndUpdate();
                    }  

                }
                else
                {
                    MessageBox.Show("oops! Something went wrong!");
                }
            }
        }

        public void refreshChatGroup(object sender, int e, string response, string username, int status)
        {
            if (status == 4 || status == 5 || status == 8)
            {
                Dictionary<string, int> mutual = u.mutualMembers;
                List<string> current = u.currentMembers;

                Invoke(new Action(() =>
                {
                    uxChatGroup.Items.Clear();
                    uxChatGroup.Update();
                    uxChatGroup.Refresh();
                }));

                foreach (KeyValuePair<string, int> c in mutual)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = c.Key;
                    Invoke(new Action(() => uxChatGroup.Items.Add(li)));
                }
                foreach (string c in current)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = c;
                    Invoke(new Action(() => uxChatGroup.Items.Add(li)));
                }
            }
        }
        public void chatHistory(object sender, int e, string response, string username, int status)
        {

            if (status == 5)
            {
                foreach (string message in u.history)
                {
                    Invoke(new Action(() =>
                    {
                        uxMessagebox.TopIndex = uxMessagebox.Items.Add(message);
                        uxText.Text = "";
                    }
                  ));
                }
            }
        }

        private void uxChat_Click(object sender, EventArgs e)
        {
            dynamic o = new ExpandoObject();
            o.username = uxUsername.Text.ToString();
            if (uxContactList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a contact to chat");
                return;
            }
            o.usernameAdd = uxContactList.SelectedItems[0].Text.ToString();
            o.messageType = "createChat";
            messageType handle = messageType.createChat;
            f(sender, e, handle, o, null);
            Invoke(new Action(() =>
            { uxSend.Enabled = true; }));
        }

        private void uxSend_Click(object sender, EventArgs e)
        {
            string message = uxText.Text;
            dynamic o = new ExpandoObject();
            o.message = message;
            o.messageType = "chatMessage";
            o.username = uxUsername.Text;
            o.content = uxText.Text;
            o.timeStamp = DateTime.Now.ToString("HH:mm:ss tt");
            o.roomNumber = u.roomNumber;
            messageType handle = messageType.chatMessage;
            JObject jo = JObject.FromObject(o);
            f(sender, e, handle, o, "");
        }

        private void uxLogout_Click(object sender, EventArgs e)
        {
            dynamic o = new ExpandoObject();
            o.username = uxUsername.Text.ToString();
            o.messageType = "logout";
            messageType handle = messageType.logout;
            f(sender, e, handle, o, uxUsername.Text.ToString());
        }

        public void logout(object sender, int error, string response, string username, int s)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == uxLogout)
            {
                if (error == 0)
                {

                    //if (MessageBox.Show("Are you sure you want to Log out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                    //    // user clicked yes
                    //    Application.Exit();
                    //    MessageBox.Show("Logged out");
                    //}
                 
                }
                else
                {
                    MessageBox.Show("Oops, something went wrong!");
                }

            }
            else
            {
                //if (error == 0)
                //{

                //        // user clicked yes
                //        if (username != null)
                //        {
                //            MessageBox.Show(username + " loggout");
                //        }

                //}
            }

        }

        private void uxRemove_Click(object sender, EventArgs e)
        {
            dynamic o = new ExpandoObject();
            o.username = uxUsername.Text.ToString();
            o.usernameRemoved = uxContactList.SelectedItems[0].Text.ToString();
            o.messageType = "contactRemoved";
            messageType handle = messageType.contactRemoved;
            f(sender, e, handle, o, uxContactList.SelectedItems[0].Text.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
             * message type(addChatMember),
                username(string),
                friend(string)
             * */
            dynamic o = new ExpandoObject();
            o.username = uxUsername.Text.ToString();
            o.friend = uxChatGroup.SelectedItems[0].Text.ToString();
            o.messageType = "addChatMember";
            messageType handle = messageType.addChatMember;
            f(sender, e, handle, o, uxChatGroup.SelectedItems[0].Text.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            client - side request:
            message type(leaveChat),
            username(string),
            roomname(integer)*/
  
            dynamic o = new ExpandoObject();
            o.username = u.userName;
            o.roomNumer = u.roomNumber;
            o.messageType = "leaveChat";
            messageType handle = messageType.leaveChat;
            f(sender, e, handle, o, null);
        }
        public void leaveChat(object sender, int error, string response, string username, int s)
        {
            if(response.Contains("leaveChat"))
            {
                if(error == 0)
                {
                    if (username != u.userName)
                    {
                        MessageBox.Show(username + "left the chat");
                    }
                    else
                    {
                        MessageBox.Show("You left the chat");
                    }
                }
                else
                {
                    if(username == u.userName)
                        MessageBox.Show("You already left the chat");
                }
            }
        }
    }
}
