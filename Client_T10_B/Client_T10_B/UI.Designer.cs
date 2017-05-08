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
            this.uxRemove = new System.Windows.Forms.Button();
            this.uxContactList = new System.Windows.Forms.ListView();
            this.Freinds = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxLogout = new System.Windows.Forms.Button();
            this.uxChat = new System.Windows.Forms.Button();
            this.uxLogin = new System.Windows.Forms.Button();
            this.uxAddContactButton = new System.Windows.Forms.Button();
            this.uxAddContactBox = new System.Windows.Forms.TextBox();
            this.uxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uxUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uxSend = new System.Windows.Forms.Button();
            this.uxText = new System.Windows.Forms.TextBox();
            this.uxMessagebox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.uxChatGroup = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.uxChatGroup);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.uxRemove);
            this.splitContainer1.Panel1.Controls.Add(this.uxContactList);
            this.splitContainer1.Panel1.Controls.Add(this.uxLogout);
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
            this.splitContainer1.Size = new System.Drawing.Size(829, 566);
            this.splitContainer1.SplitterDistance = 144;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // uxRemove
            // 
            this.uxRemove.Location = new System.Drawing.Point(71, 123);
            this.uxRemove.Margin = new System.Windows.Forms.Padding(2);
            this.uxRemove.Name = "uxRemove";
            this.uxRemove.Size = new System.Drawing.Size(63, 26);
            this.uxRemove.TabIndex = 16;
            this.uxRemove.Text = "Remove";
            this.uxRemove.UseVisualStyleBackColor = true;
            this.uxRemove.Click += new System.EventHandler(this.uxRemove_Click);
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
            this.uxContactList.Location = new System.Drawing.Point(2, 154);
            this.uxContactList.Name = "uxContactList";
            this.uxContactList.Size = new System.Drawing.Size(141, 181);
            this.uxContactList.TabIndex = 15;
            this.uxContactList.UseCompatibleStateImageBehavior = false;
            this.uxContactList.View = System.Windows.Forms.View.Details;
            // 
            // Freinds
            // 
            this.Freinds.Text = "";
            this.Freinds.Width = 160;
            // 
            // uxLogout
            // 
            this.uxLogout.Location = new System.Drawing.Point(9, 59);
            this.uxLogout.Margin = new System.Windows.Forms.Padding(2);
            this.uxLogout.Name = "uxLogout";
            this.uxLogout.Size = new System.Drawing.Size(56, 27);
            this.uxLogout.TabIndex = 14;
            this.uxLogout.Text = "Logout";
            this.uxLogout.UseVisualStyleBackColor = true;
            this.uxLogout.Click += new System.EventHandler(this.uxLogout_Click);
            // 
            // uxChat
            // 
            this.uxChat.Location = new System.Drawing.Point(4, 536);
            this.uxChat.Margin = new System.Windows.Forms.Padding(2);
            this.uxChat.Name = "uxChat";
            this.uxChat.Size = new System.Drawing.Size(51, 20);
            this.uxChat.TabIndex = 12;
            this.uxChat.Text = "Chat";
            this.uxChat.UseVisualStyleBackColor = true;
            this.uxChat.Click += new System.EventHandler(this.uxChat_Click);
            // 
            // uxLogin
            // 
            this.uxLogin.Location = new System.Drawing.Point(78, 59);
            this.uxLogin.Margin = new System.Windows.Forms.Padding(2);
            this.uxLogin.Name = "uxLogin";
            this.uxLogin.Size = new System.Drawing.Size(56, 27);
            this.uxLogin.TabIndex = 10;
            this.uxLogin.Text = "Login";
            this.uxLogin.UseVisualStyleBackColor = true;
            this.uxLogin.Click += new System.EventHandler(this.uxLogin_Click);
            // 
            // uxAddContactButton
            // 
            this.uxAddContactButton.Location = new System.Drawing.Point(9, 123);
            this.uxAddContactButton.Margin = new System.Windows.Forms.Padding(2);
            this.uxAddContactButton.Name = "uxAddContactButton";
            this.uxAddContactButton.Size = new System.Drawing.Size(55, 26);
            this.uxAddContactButton.TabIndex = 9;
            this.uxAddContactButton.Text = "Add";
            this.uxAddContactButton.UseVisualStyleBackColor = true;
            this.uxAddContactButton.Click += new System.EventHandler(this.uxAddContactButton_Click);
            // 
            // uxAddContactBox
            // 
            this.uxAddContactBox.Location = new System.Drawing.Point(9, 99);
            this.uxAddContactBox.Margin = new System.Windows.Forms.Padding(2);
            this.uxAddContactBox.Name = "uxAddContactBox";
            this.uxAddContactBox.Size = new System.Drawing.Size(125, 20);
            this.uxAddContactBox.TabIndex = 8;
            // 
            // uxPassword
            // 
            this.uxPassword.Location = new System.Drawing.Point(59, 29);
            this.uxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.uxPassword.Name = "uxPassword";
            this.uxPassword.Size = new System.Drawing.Size(76, 20);
            this.uxPassword.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // uxUsername
            // 
            this.uxUsername.Location = new System.Drawing.Point(59, 4);
            this.uxUsername.Margin = new System.Windows.Forms.Padding(2);
            this.uxUsername.Name = "uxUsername";
            this.uxUsername.Size = new System.Drawing.Size(76, 20);
            this.uxUsername.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username";
            // 
            // uxSend
            // 
            this.uxSend.Location = new System.Drawing.Point(616, 531);
            this.uxSend.Margin = new System.Windows.Forms.Padding(2);
            this.uxSend.Name = "uxSend";
            this.uxSend.Size = new System.Drawing.Size(63, 30);
            this.uxSend.TabIndex = 2;
            this.uxSend.Text = "Send";
            this.uxSend.UseVisualStyleBackColor = true;
            this.uxSend.Click += new System.EventHandler(this.uxSend_Click);
            // 
            // uxText
            // 
            this.uxText.BackColor = System.Drawing.Color.Beige;
            this.uxText.Location = new System.Drawing.Point(3, 526);
            this.uxText.Multiline = true;
            this.uxText.Name = "uxText";
            this.uxText.Size = new System.Drawing.Size(609, 37);
            this.uxText.TabIndex = 1;
            // 
            // uxMessagebox
            // 
            this.uxMessagebox.FormattingEnabled = true;
            this.uxMessagebox.Location = new System.Drawing.Point(3, 2);
            this.uxMessagebox.Margin = new System.Windows.Forms.Padding(2);
            this.uxMessagebox.Name = "uxMessagebox";
            this.uxMessagebox.Size = new System.Drawing.Size(677, 524);
            this.uxMessagebox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 536);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 21);
            this.button1.TabIndex = 17;
            this.button1.Text = "Add To Chat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uxChatGroup
            // 
            this.uxChatGroup.BackColor = System.Drawing.Color.Beige;
            this.uxChatGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.uxChatGroup.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxChatGroup.FullRowSelect = true;
            this.uxChatGroup.GridLines = true;
            this.uxChatGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.uxChatGroup.HideSelection = false;
            this.uxChatGroup.Location = new System.Drawing.Point(2, 362);
            this.uxChatGroup.Name = "uxChatGroup";
            this.uxChatGroup.Size = new System.Drawing.Size(141, 169);
            this.uxChatGroup.TabIndex = 18;
            this.uxChatGroup.UseCompatibleStateImageBehavior = false;
            this.uxChatGroup.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 160;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Chat Group";
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 566);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Button uxChat;
        private System.Windows.Forms.Button uxLogin;
        private System.Windows.Forms.Button uxAddContactButton;
        private System.Windows.Forms.TextBox uxAddContactBox;
        private System.Windows.Forms.ListBox uxMessagebox;
        private System.Windows.Forms.TextBox uxText;
        public System.Windows.Forms.ListView uxContactList;
        private System.Windows.Forms.ColumnHeader Freinds;
        private System.Windows.Forms.Button uxSend;
        private System.Windows.Forms.Button uxRemove;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ListView uxChatGroup;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button button1;
    }
}