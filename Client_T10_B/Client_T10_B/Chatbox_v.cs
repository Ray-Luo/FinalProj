﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_T10_B
{
    public partial class Chatbox_v : Form
    {
        public Chatbox_v(ChatRoom_m room, Program.Message newMessageHandler)
        {
            InitializeComponent();

            uxTextbox.KeyDown += (o, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string message = uxTextbox.Text;
                    if (newMessageHandler(message))
                    {
                        uxTextbox.Text = "";
                    }
                }
            };
        }

    }
}