namespace Client_T10_B
{
    partial class UI
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.uxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uxUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uxAddContactBox = new System.Windows.Forms.TextBox();
            this.uxAddContactButton = new System.Windows.Forms.Button();
            this.uxLogin = new System.Windows.Forms.Button();
            this.uxChat = new System.Windows.Forms.Button();
            this.uxAdd = new System.Windows.Forms.Button();
            this.uxLogout = new System.Windows.Forms.Button();
            this.uxMessagebox = new System.Windows.Forms.ListBox();
            this.uxText = new System.Windows.Forms.TextBox();
            this.uxContactList = new System.Windows.Forms.ListView();
            this.Freinds = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxSend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.uxContactList);
            this.splitContainer1.Panel1.Controls.Add(this.uxLogout);
            this.splitContainer1.Panel1.Controls.Add(this.uxAdd);
            this.splitContainer1.Panel1.Controls.Add(this.uxChat);
            this.splitContainer1.Panel1.Controls.Add(this.uxLogin);
            this.splitContainer1.Panel1.Controls.Add(this.uxAddContactButton);
            this.splitContainer1.Panel1.Controls.Add(this.uxAddContactBox);
            this.splitContainer1.Panel1.Controls.Add(this.uxPassword);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.uxUsername);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uxSend);
            this.splitContainer1.Panel2.Controls.Add(this.uxText);
            this.splitContainer1.Panel2.Controls.Add(this.uxMessagebox);
            this.splitContainer1.Size = new System.Drawing.Size(1105, 697);
            this.splitContainer1.SplitterDistance = 192;
            this.splitContainer1.TabIndex = 0;
            // 
            // uxPassword
            // 
            this.uxPassword.Location = new System.Drawing.Point(79, 36);
            this.uxPassword.Name = "uxPassword";
            this.uxPassword.Size = new System.Drawing.Size(100, 22);
            this.uxPassword.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // uxUsername
            // 
            this.uxUsername.Location = new System.Drawing.Point(79, 5);
            this.uxUsername.Name = "uxUsername";
            this.uxUsername.Size = new System.Drawing.Size(100, 22);
            this.uxUsername.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username";
            // 
            // uxAddContactBox
            // 
            this.uxAddContactBox.Location = new System.Drawing.Point(7, 127);
            this.uxAddContactBox.Name = "uxAddContactBox";
            this.uxAddContactBox.Size = new System.Drawing.Size(83, 22);
            this.uxAddContactBox.TabIndex = 8;
            // 
            // uxAddContactButton
            // 
            this.uxAddContactButton.Location = new System.Drawing.Point(96, 122);
            this.uxAddContactButton.Name = "uxAddContactButton";
            this.uxAddContactButton.Size = new System.Drawing.Size(93, 32);
            this.uxAddContactButton.TabIndex = 9;
            this.uxAddContactButton.Text = "Add Contact";
            this.uxAddContactButton.UseVisualStyleBackColor = true;
            this.uxAddContactButton.Click += new System.EventHandler(this.uxAddContactButton_Click);
            // 
            // uxLogin
            // 
            this.uxLogin.Location = new System.Drawing.Point(104, 73);
            this.uxLogin.Name = "uxLogin";
            this.uxLogin.Size = new System.Drawing.Size(75, 33);
            this.uxLogin.TabIndex = 10;
            this.uxLogin.Text = "Login";
            this.uxLogin.UseVisualStyleBackColor = true;
            this.uxLogin.Click += new System.EventHandler(this.uxLogin_Click);
            // 
            // uxChat
            // 
            this.uxChat.Location = new System.Drawing.Point(14, 662);
            this.uxChat.Name = "uxChat";
            this.uxChat.Size = new System.Drawing.Size(75, 23);
            this.uxChat.TabIndex = 12;
            this.uxChat.Text = "Chat";
            this.uxChat.UseVisualStyleBackColor = true;
            this.uxChat.Click += new System.EventHandler(this.uxChat_Click);
            // 
            // uxAdd
            // 
            this.uxAdd.Location = new System.Drawing.Point(95, 662);
            this.uxAdd.Name = "uxAdd";
            this.uxAdd.Size = new System.Drawing.Size(75, 23);
            this.uxAdd.TabIndex = 13;
            this.uxAdd.Text = "Add";
            this.uxAdd.UseVisualStyleBackColor = true;
            // 
            // uxLogout
            // 
            this.uxLogout.Location = new System.Drawing.Point(12, 73);
            this.uxLogout.Name = "uxLogout";
            this.uxLogout.Size = new System.Drawing.Size(75, 33);
            this.uxLogout.TabIndex = 14;
            this.uxLogout.Text = "Logout";
            this.uxLogout.UseVisualStyleBackColor = true;
            // 
            // uxMessagebox
            // 
            this.uxMessagebox.FormattingEnabled = true;
            this.uxMessagebox.ItemHeight = 16;
            this.uxMessagebox.Location = new System.Drawing.Point(3, 3);
            this.uxMessagebox.Name = "uxMessagebox";
            this.uxMessagebox.Size = new System.Drawing.Size(903, 644);
            this.uxMessagebox.TabIndex = 0;
            // 
            // uxText
            // 
            this.uxText.BackColor = System.Drawing.Color.Beige;
            this.uxText.Location = new System.Drawing.Point(4, 648);
            this.uxText.Margin = new System.Windows.Forms.Padding(4);
            this.uxText.Multiline = true;
            this.uxText.Name = "uxText";
            this.uxText.Size = new System.Drawing.Size(811, 45);
            this.uxText.TabIndex = 1;
            // 
            // uxContactList
            // 
            this.uxContactList.BackColor = System.Drawing.Color.Beige;
            this.uxContactList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Freinds});
            this.uxContactList.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxContactList.FullRowSelect = true;
            this.uxContactList.GridLines = true;
            this.uxContactList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.uxContactList.HideSelection = false;
            this.uxContactList.Location = new System.Drawing.Point(2, 157);
            this.uxContactList.Margin = new System.Windows.Forms.Padding(4);
            this.uxContactList.Name = "uxContactList";
            this.uxContactList.Size = new System.Drawing.Size(187, 498);
            this.uxContactList.TabIndex = 15;
            this.uxContactList.UseCompatibleStateImageBehavior = false;
            this.uxContactList.View = System.Windows.Forms.View.Details;
            // 
            // Freinds
            // 
            this.Freinds.Text = "";
            this.Freinds.Width = 160;
            // 
            // uxSend
            // 
            this.uxSend.Location = new System.Drawing.Point(822, 653);
            this.uxSend.Name = "uxSend";
            this.uxSend.Size = new System.Drawing.Size(84, 37);
            this.uxSend.TabIndex = 2;
            this.uxSend.Text = "Send";
            this.uxSend.UseVisualStyleBackColor = true;
            this.uxSend.Click += new System.EventHandler(this.uxSend_Click);
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 697);
            this.Controls.Add(this.splitContainer1);
            this.Name = "UI";
            this.Text = "UI";
            this.Load += new System.EventHandler(this.UI_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox uxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uxUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uxLogout;
        private System.Windows.Forms.Button uxAdd;
        private System.Windows.Forms.Button uxChat;
        private System.Windows.Forms.Button uxLogin;
        private System.Windows.Forms.Button uxAddContactButton;
        private System.Windows.Forms.TextBox uxAddContactBox;
        private System.Windows.Forms.ListBox uxMessagebox;
        private System.Windows.Forms.TextBox uxText;
        public System.Windows.Forms.ListView uxContactList;
        private System.Windows.Forms.ColumnHeader Freinds;
        private System.Windows.Forms.Button uxSend;
    }
}