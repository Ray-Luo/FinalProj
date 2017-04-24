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
        User_m user;
        Controller controller;

        public User_v(User_m u, InputHandler h, Controller controller)
        {
            this.handler = h;
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
        }


        public void logout(object sender, int error)
        {
            Button clickedButton = sender as Button;
            if (clickedButton.Text == "Logout")
            {
                if (error == 0)
                {
                    Application.Exit();
                }
                else
                    MessageBox.Show("Logout failed");
            }
        }

        private void usAddContact_Click(object sender, EventArgs e)
        {
            dynamic o = new ExpandoObject();
            o.username = uxUserName.Text.ToString();
            o.usernameAdd = uxPersonName.Text.ToString();
            o.messageType = messageType.contactAdded;
            handler = controller.addContactHandle;
            handler(sender, e, o);
        }

        public void refreshContactList(object sender, int error)
        {
            // uxContactList.DataBindings.Clear();
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
        }
    }
}
