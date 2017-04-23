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
    public partial class LogIn : Form
    {
        InputHandler f1;
        User_m u;
        Controller c;

        public LogIn(InputHandler f1,User_m u,Controller c)
        {
            this.f1 = f1;
            this.u = u;
            this.c = c;
            InitializeComponent();
        }

        private void password_label_Click(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e )
        {
            try
            {
                f1 = c.loginHandle;
                f1(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
    }
}
