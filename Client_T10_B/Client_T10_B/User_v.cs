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
        InputHandler handler;
        InputHandler1 handler1;
        User_m user;
        Controller controller;

        public User_v(User_m u, InputHandler h, InputHandler1 h1, Controller controller)
        {
            this.handler = h;
            this.handler1 = h1;
            this.user = u;
            this.controller = controller;
            InitializeComponent();
        }

        private void uxLogout_Click(object sender, EventArgs e)
        {
            dynamic o = new ExpandoObject();
            o.username = uxUserName.Text.ToString();
            o.messageType = messageType.logout;
            handler = controller.logoutHandle;
            handler(sender, e, o);
        }

        private void uxContactList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void User_v_Load(object sender, EventArgs e)
        {
            uxUserName.Text = user.userName;
            Dictionary<string, int> contacts = user.getContactList();
            foreach (KeyValuePair<string, int> c in contacts)
            {
                ListViewItem li = new ListViewItem();
                if (c.Value == 0) //logged in 
                {
                    li.ForeColor = Color.Green;
                }
                else //logged out 
                {
                    li.ForeColor = Color.Red;
                }
                li.Text = c.Key;
                uxContactList.Items.Add(li);
            }
            Console.WriteLine(uxContactList.Items.Count);
        }


        public void logout(object sender, int error)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == uxLogout)
            {
                if (error == 0)
                {
                    Application.Exit();
                }
                else
                    MessageBox.Show("Logout failed");
            }
        }

       

        public void refreshContactList(object sender, int error)
        {
            foreach (ListViewItem i in uxContactList.Items)
            {
                Console.WriteLine(i.Text);
            }
            //Button clickedButton = sender as Button;
            //if (clickedButton == uxAddContact)
            //{
            //    Dictionary<string, int> contacts = user.getContactList();
            //    foreach (KeyValuePair<string, int> c in contacts)
            //    {
            //        ListViewItem item = uxContactList.FindItemWithText(c.Key);

            //        if (!uxContactList.Items.Contains(item))
            //        {
            //            // doesn't exist, add it
            //            ListViewItem li = new ListViewItem();
            //            if (c.Value == 0) //logged in 
            //            {
            //                li.ForeColor = Color.Green;
            //            }
            //            else //logged out 
            //            {
            //                li.ForeColor = Color.Red;
            //            }
            //            li.Text = c.Key;
            //            uxContactList.Items.Add(li);
            //        }
            //    }
            //}
        }

        private void uxAddContact_Click(object sender, EventArgs e)
        {
            dynamic o = new ExpandoObject();
            o.username = uxUserName.Text.ToString();
            o.usernameAdd = uxPersonName.Text.ToString();
            o.messageType = messageType.contactAdded;
            handler1 = controller.addContactHandle;
            handler1(sender, e, o, uxPersonName.Text.ToString());
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
        //    o.messageType = messageType.contactAdded;
        //    handler1 = controller.addContactHandle;
        //    handler1(sender, e, o, uxUserName.Text.ToString());
        //}
        // }
    }
}
