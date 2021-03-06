﻿using System;
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
    public partial class LogIn : Form
    {
        InputHandler f1;
        User_m u;
        Controller c;
        dynamic MyDynamic = new ExpandoObject();

        public LogIn(InputHandler f1,User_m u)
        {
            this.f1 = f1;
            this.u = u;
            InitializeComponent();
        }

        private void password_label_Click(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic o = new ExpandoObject();
                o.username = uxUserName.Text.ToString();
                o.password = uxPassword.Text.ToString();
                o.messageType = "login";
                messageType handle = messageType.login;
                f1(sender, e, handle, o , uxUserName.Text.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void login(object sender, int error, string temp)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == uxLogin)
            {
                if (error == 0)
                {
                    User_v userProfile = new User_v(f1,u);//; u, f1,f2, c);
                    Hide();
                    userProfile.ShowDialog();
                }
                else if(error == 1)
                {
                    MessageBox.Show("Password is incorrect");
                }
                else
                {
                    MessageBox.Show("Oops, something went wrong!");
                }
               
            }
        }

    }
}
