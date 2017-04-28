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
            this.uxLogout = new System.Windows.Forms.Button();
            this.uxChat = new System.Windows.Forms.Button();
            this.uxUnfriend = new System.Windows.Forms.Button();
            this.uxUserName = new System.Windows.Forms.Label();
            this.uxPersonName = new System.Windows.Forms.TextBox();
            this.uxAddContact = new System.Windows.Forms.Button();
            this.uxContactList = new System.Windows.Forms.ListView();
            this.Freinds = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
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
            this.uxLogout.Click += new System.EventHandler(this.uxLogout_Click);
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
            this.uxUserName.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxUserName.Location = new System.Drawing.Point(12, 26);
            this.uxUserName.Name = "uxUserName";
            this.uxUserName.Size = new System.Drawing.Size(98, 24);
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
            // uxAddContact
            // 
            this.uxAddContact.BackColor = System.Drawing.Color.LightCyan;
            this.uxAddContact.Location = new System.Drawing.Point(120, 57);
            this.uxAddContact.Name = "uxAddContact";
            this.uxAddContact.Size = new System.Drawing.Size(53, 23);
            this.uxAddContact.TabIndex = 7;
            this.uxAddContact.Text = "Add";
            this.uxAddContact.UseVisualStyleBackColor = false;
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
            this.uxContactList.Location = new System.Drawing.Point(15, 86);
            this.uxContactList.Name = "uxContactList";
            this.uxContactList.Size = new System.Drawing.Size(158, 312);
            this.uxContactList.TabIndex = 8;
            this.uxContactList.UseCompatibleStateImageBehavior = false;
            this.uxContactList.View = System.Windows.Forms.View.Details;
            // 
            // Freinds
            // 
            this.Freinds.Text = "";
            this.Freinds.Width = 160;
            // 
            // User_v
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(185, 481);
            this.Controls.Add(this.uxContactList);
            this.Controls.Add(this.uxAddContact);
            this.Controls.Add(this.uxPersonName);
            this.Controls.Add(this.uxUserName);
            this.Controls.Add(this.uxUnfriend);
            this.Controls.Add(this.uxChat);
            this.Controls.Add(this.uxLogout);
            this.Name = "User_v";
            this.Text = "IM App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button uxLogout;
        private System.Windows.Forms.Button uxChat;
        private System.Windows.Forms.Button uxUnfriend;
        public System.Windows.Forms.Label uxUserName;
        private System.Windows.Forms.TextBox uxPersonName;
        private System.Windows.Forms.Button uxAddContact;
        private System.Windows.Forms.ListView uxContactList;
        private System.Windows.Forms.ColumnHeader Freinds;
    }
}