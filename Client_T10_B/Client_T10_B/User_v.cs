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

namespace Client_T10_B
{
    public partial class User_v : Form
    {
        InputHandler handler;
        User_m user;

        public User_v(User_m u, InputHandler h)
        {
            this.handler = h;
            this.user = u;
            InitializeComponent();
        }

        private void uxLogout_Click(object sender, EventArgs e)
        {

        }
    }
}
