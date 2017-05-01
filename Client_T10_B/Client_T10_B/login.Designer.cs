namespace Client_T10_B
{
    partial class LogIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxUserName = new System.Windows.Forms.TextBox();
            this.uxPassword = new System.Windows.Forms.TextBox();
            this.uxLogin = new System.Windows.Forms.Button();
            this.username_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.status_label = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // uxUserName
            // 
            this.uxUserName.BackColor = System.Drawing.Color.Beige;
            this.uxUserName.Location = new System.Drawing.Point(98, 34);
            this.uxUserName.Name = "uxUserName";
            this.uxUserName.Size = new System.Drawing.Size(107, 20);
            this.uxUserName.TabIndex = 0;
            // 
            // uxPassword
            // 
            this.uxPassword.BackColor = System.Drawing.Color.Beige;
            this.uxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uxPassword.Location = new System.Drawing.Point(98, 64);
            this.uxPassword.Name = "uxPassword";
            this.uxPassword.PasswordChar = '*';
            this.uxPassword.Size = new System.Drawing.Size(107, 20);
            this.uxPassword.TabIndex = 1;
            // 
            // uxLogin
            // 
            this.uxLogin.BackColor = System.Drawing.Color.LightCyan;
            this.uxLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxLogin.Location = new System.Drawing.Point(98, 112);
            this.uxLogin.Name = "uxLogin";
            this.uxLogin.Size = new System.Drawing.Size(75, 23);
            this.uxLogin.TabIndex = 2;
            this.uxLogin.Text = "Login";
            this.uxLogin.UseVisualStyleBackColor = false;
            this.uxLogin.Click += new System.EventHandler(this.login_button_Click);
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_label.Location = new System.Drawing.Point(19, 35);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(77, 16);
            this.username_label.TabIndex = 3;
            this.username_label.Text = "User Name";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_label.Location = new System.Drawing.Point(26, 68);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(68, 16);
            this.password_label.TabIndex = 4;
            this.password_label.Text = "Password";
            this.password_label.Click += new System.EventHandler(this.password_label_Click);
            // 
            // status_label
            // 
            this.status_label.AutoSize = true;
            this.status_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_label.Location = new System.Drawing.Point(80, 148);
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(0, 15);
            this.status_label.TabIndex = 6;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(87, 172);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 13);
            this.linkLabel1.TabIndex = 7;
            // 
            // LogIn
            // 
            this.AcceptButton = this.uxLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(263, 201);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.status_label);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.uxLogin);
            this.Controls.Add(this.uxPassword);
            this.Controls.Add(this.uxUserName);
            this.MaximizeBox = false;
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instant Message App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxUserName;
        private System.Windows.Forms.TextBox uxPassword;
        private System.Windows.Forms.Button uxLogin;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label status_label;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

