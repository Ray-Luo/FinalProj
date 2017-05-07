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

        }

        private void uxLogin_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic o = new ExpandoObject();
                o.username = uxUsername.Text.ToString();
                o.password = uxPassword.Text.ToString();
                o.messageType = "login";
                messageType handle = messageType.login;
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

        public void MessageReceived(object sender, int e, string response, string str, int s)
        {           
            JObject rss = JObject.Parse(response);
            int error = 0;
            int roomName = 0;
            string content = "";
            string username = "";
            string timestamp = "";
            string message = "";
            string messageType = "";
            foreach (var pair in rss)
            {
                if(pair.Key == "messageType")
                {
                    messageType = (string)pair.Value;
                    if (messageType != "chatMessage")
                        return;
                }
               if (pair.Key == "error")
                {
                    error = (int)pair.Value;
                }

                else if (pair.Key == "roomName")
                {
                    roomName = (int)pair.Value;
                }

                else if (pair.Key == "content")
                {
                    content = (string)pair.Value;//(List<string>)pair.Value;
                }

                else if (pair.Key == "username")
                {
                    username = (string)pair.Value;
                    // TODO !!!!!!!!!
                    // if (username != u.userName)
                    //  {

                    //      return true;
                    //  }
                }
                else if (pair.Key == "timestamp")
                {
                    timestamp = (string)pair.Value;
                }
            }
            if (error == 0)
            {
                message = timestamp + "\n" + username + ": " + content;
            }

            Invoke(new Action(() =>
            {
                uxMessagebox.TopIndex = uxMessagebox.Items.Add(message);
                uxText.Text = "";
            }
            ));
  
        }

        private void uxAddContactButton_Click(object sender, EventArgs e)
        {
            dynamic o = new ExpandoObject();
            o.usernameOrigin = uxUsername.Text.ToString();
            o.usernameAdd = uxAddContactBox.Text.ToString();
            o.messageType = "contactAdded";
            messageType handle = messageType.contactAdded;
            f(sender, e, handle, o, uxAddContactBox.Text.ToString());
        }

        public void refreshContactList(object sender, int e, string response, string username, int status)
        {
            Dictionary<string, int> contacts = u.getContactList();

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

                else if (status == 4)
                {
                    Dictionary<string, int> mutual = new Dictionary<string, int>();
                    mutual = u.mutualMembers;

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

                        foreach (KeyValuePair<string, int> m in mutual)
                        {

                            if (m.Key == c.Key)
                            {
                                if (c.Value == 0) //logged in 
                                {
                                    li.ForeColor = Color.BlanchedAlmond;
                                }
                                else //logged out 
                                {
                                    li.ForeColor = Color.Red;
                                }
                            }
                            else
                            {
                                if (c.Value == 0) //logged in 
                                {
                                    li.ForeColor = Color.Green;
                                }
                                else //logged out 
                                {
                                    li.ForeColor = Color.Red;
                                }
                            }
                        }
                        Invoke(new Action(() => uxContactList.Items.Add(li)));
                    }

                }

            }
            else
            {
                MessageBox.Show("oops! Something went wrong!");
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
            o.chatRoom = u.roomNumber;
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
    }
}
