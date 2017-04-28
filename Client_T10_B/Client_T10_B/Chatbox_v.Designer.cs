namespace Client_T10_B
{
    partial class Chatbox_v
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
            this.uxAdd = new System.Windows.Forms.Button();
            this.uxLeave = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.uxlistBox = new System.Windows.Forms.ListBox();
            this.uxTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.uxAdd);
            this.splitContainer1.Panel1.Controls.Add(this.uxLeave);
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(735, 548);
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.TabIndex = 0;
            // 
            // uxAdd
            // 
            this.uxAdd.BackColor = System.Drawing.Color.LightCyan;
            this.uxAdd.Location = new System.Drawing.Point(115, 513);
            this.uxAdd.Name = "uxAdd";
            this.uxAdd.Size = new System.Drawing.Size(75, 23);
            this.uxAdd.TabIndex = 2;
            this.uxAdd.Text = "Add";
            this.uxAdd.UseVisualStyleBackColor = false;
            // 
            // uxLeave
            // 
            this.uxLeave.BackColor = System.Drawing.Color.LightCyan;
            this.uxLeave.Location = new System.Drawing.Point(12, 513);
            this.uxLeave.Name = "uxLeave";
            this.uxLeave.Size = new System.Drawing.Size(75, 23);
            this.uxLeave.TabIndex = 1;
            this.uxLeave.Text = "Leave";
            this.uxLeave.UseVisualStyleBackColor = false;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Beige;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(202, 500);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.uxlistBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.uxTextbox);
            this.splitContainer2.Size = new System.Drawing.Size(523, 548);
            this.splitContainer2.SplitterDistance = 471;
            this.splitContainer2.TabIndex = 0;
            // 
            // uxlistBox
            // 
            this.uxlistBox.BackColor = System.Drawing.Color.Beige;
            this.uxlistBox.FormattingEnabled = true;
            this.uxlistBox.Location = new System.Drawing.Point(3, 2);
            this.uxlistBox.Name = "uxlistBox";
            this.uxlistBox.Size = new System.Drawing.Size(517, 472);
            this.uxlistBox.TabIndex = 0;
            // 
            // uxTextbox
            // 
            this.uxTextbox.BackColor = System.Drawing.Color.Beige;
            this.uxTextbox.Location = new System.Drawing.Point(3, 3);
            this.uxTextbox.Multiline = true;
            this.uxTextbox.Name = "uxTextbox";
            this.uxTextbox.Size = new System.Drawing.Size(517, 64);
            this.uxTextbox.TabIndex = 0;
            // 
            // Chatbox_v
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(735, 548);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Chatbox_v";
            this.Text = "ChatRoom";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button uxAdd;
        private System.Windows.Forms.Button uxLeave;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox uxlistBox;
        private System.Windows.Forms.TextBox uxTextbox;
    }
}