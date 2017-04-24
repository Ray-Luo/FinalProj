namespace Client_T10_B
{
    partial class chatRoom
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
            this.uxContacts = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.uxChatRoom = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxContacts
            // 
            this.uxContacts.BackColor = System.Drawing.Color.Beige;
            this.uxContacts.Location = new System.Drawing.Point(12, 12);
            this.uxContacts.Name = "uxContacts";
            this.uxContacts.Size = new System.Drawing.Size(130, 356);
            this.uxContacts.TabIndex = 0;
            this.uxContacts.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCyan;
            this.button1.Location = new System.Drawing.Point(12, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // uxChatRoom
            // 
            this.uxChatRoom.BackColor = System.Drawing.Color.Beige;
            this.uxChatRoom.FormattingEnabled = true;
            this.uxChatRoom.Location = new System.Drawing.Point(148, 13);
            this.uxChatRoom.Name = "uxChatRoom";
            this.uxChatRoom.Size = new System.Drawing.Size(404, 355);
            this.uxChatRoom.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Beige;
            this.textBox1.Location = new System.Drawing.Point(148, 380);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(340, 20);
            this.textBox1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightCyan;
            this.button2.Location = new System.Drawing.Point(494, 377);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // chatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(564, 414);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.uxChatRoom);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uxContacts);
            this.Name = "chatRoom";
            this.Text = "Chat Room";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView uxContacts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox uxChatRoom;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}