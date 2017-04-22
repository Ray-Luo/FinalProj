namespace Client_T10_B
{
    partial class User_v
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
            this.uxContactList = new System.Windows.Forms.ListView();
            this.uxLogout = new System.Windows.Forms.Button();
            this.uxChat = new System.Windows.Forms.Button();
            this.uxUnfriend = new System.Windows.Forms.Button();
            this.uxUserName = new System.Windows.Forms.Label();
            this.uxPersonName = new System.Windows.Forms.TextBox();
            this.usAddContact = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxContactList
            // 
            this.uxContactList.BackColor = System.Drawing.Color.Beige;
            this.uxContactList.Location = new System.Drawing.Point(12, 101);
            this.uxContactList.Name = "uxContactList";
            this.uxContactList.Size = new System.Drawing.Size(161, 297);
            this.uxContactList.TabIndex = 1;
            this.uxContactList.UseCompatibleStateImageBehavior = false;
            // 
            // uxLogout
            // 
            this.uxLogout.BackColor = System.Drawing.Color.LightCyan;
            this.uxLogout.Location = new System.Drawing.Point(12, 433);
            this.uxLogout.Name = "uxLogout";
            this.uxLogout.Size = new System.Drawing.Size(75, 23);
            this.uxLogout.TabIndex = 2;
            this.uxLogout.Text = "Logout";
            this.uxLogout.UseVisualStyleBackColor = false;
            // 
            // uxChat
            // 
            this.uxChat.BackColor = System.Drawing.Color.LightCyan;
            this.uxChat.Location = new System.Drawing.Point(12, 404);
            this.uxChat.Name = "uxChat";
            this.uxChat.Size = new System.Drawing.Size(75, 23);
            this.uxChat.TabIndex = 3;
            this.uxChat.Text = "Chat";
            this.uxChat.UseVisualStyleBackColor = false;
            // 
            // uxUnfriend
            // 
            this.uxUnfriend.BackColor = System.Drawing.Color.LightCyan;
            this.uxUnfriend.Location = new System.Drawing.Point(98, 404);
            this.uxUnfriend.Name = "uxUnfriend";
            this.uxUnfriend.Size = new System.Drawing.Size(75, 23);
            this.uxUnfriend.TabIndex = 4;
            this.uxUnfriend.Text = "Unfriend";
            this.uxUnfriend.UseVisualStyleBackColor = false;
            // 
            // uxUserName
            // 
            this.uxUserName.AutoSize = true;
            this.uxUserName.Location = new System.Drawing.Point(12, 26);
            this.uxUserName.Name = "uxUserName";
            this.uxUserName.Size = new System.Drawing.Size(55, 13);
            this.uxUserName.TabIndex = 5;
            this.uxUserName.Text = "userName";
            // 
            // uxPersonName
            // 
            this.uxPersonName.BackColor = System.Drawing.SystemColors.Info;
            this.uxPersonName.Location = new System.Drawing.Point(15, 60);
            this.uxPersonName.Name = "uxPersonName";
            this.uxPersonName.Size = new System.Drawing.Size(99, 20);
            this.uxPersonName.TabIndex = 6;
            // 
            // usAddContact
            // 
            this.usAddContact.BackColor = System.Drawing.Color.LightCyan;
            this.usAddContact.Location = new System.Drawing.Point(120, 57);
            this.usAddContact.Name = "usAddContact";
            this.usAddContact.Size = new System.Drawing.Size(53, 23);
            this.usAddContact.TabIndex = 7;
            this.usAddContact.Text = "Add";
            this.usAddContact.UseVisualStyleBackColor = false;
            // 
            // User_v
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(185, 481);
            this.Controls.Add(this.usAddContact);
            this.Controls.Add(this.uxPersonName);
            this.Controls.Add(this.uxUserName);
            this.Controls.Add(this.uxUnfriend);
            this.Controls.Add(this.uxChat);
            this.Controls.Add(this.uxLogout);
            this.Controls.Add(this.uxContactList);
            this.Name = "User_v";
            this.Text = "IM App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView uxContactList;
        private System.Windows.Forms.Button uxLogout;
        private System.Windows.Forms.Button uxChat;
        private System.Windows.Forms.Button uxUnfriend;
        private System.Windows.Forms.Label uxUserName;
        private System.Windows.Forms.TextBox uxPersonName;
        private System.Windows.Forms.Button usAddContact;
    }
}