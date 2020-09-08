namespace SkolProjekt
{
    partial class AddWebContactForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.inp_ServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inp_Username = new System.Windows.Forms.TextBox();
            this.btn_AddWebContact = new System.Windows.Forms.Button();
            this.btn_CancelAddWebContact = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // inp_ServerName
            // 
            this.inp_ServerName.Location = new System.Drawing.Point(12, 27);
            this.inp_ServerName.Name = "inp_ServerName";
            this.inp_ServerName.Size = new System.Drawing.Size(242, 23);
            this.inp_ServerName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // inp_Username
            // 
            this.inp_Username.Location = new System.Drawing.Point(12, 71);
            this.inp_Username.Name = "inp_Username";
            this.inp_Username.Size = new System.Drawing.Size(242, 23);
            this.inp_Username.TabIndex = 3;
            // 
            // btn_AddWebContact
            // 
            this.btn_AddWebContact.Location = new System.Drawing.Point(12, 100);
            this.btn_AddWebContact.Name = "btn_AddWebContact";
            this.btn_AddWebContact.Size = new System.Drawing.Size(75, 23);
            this.btn_AddWebContact.TabIndex = 4;
            this.btn_AddWebContact.Text = "Add";
            this.btn_AddWebContact.UseVisualStyleBackColor = true;
            this.btn_AddWebContact.Click += new System.EventHandler(this.Btn_AddWebContact_Click);
            // 
            // btn_CancelAddWebContact
            // 
            this.btn_CancelAddWebContact.Location = new System.Drawing.Point(179, 100);
            this.btn_CancelAddWebContact.Name = "btn_CancelAddWebContact";
            this.btn_CancelAddWebContact.Size = new System.Drawing.Size(75, 23);
            this.btn_CancelAddWebContact.TabIndex = 5;
            this.btn_CancelAddWebContact.Text = "Cancel";
            this.btn_CancelAddWebContact.UseVisualStyleBackColor = true;
            this.btn_CancelAddWebContact.Click += new System.EventHandler(this.Btn_CancelAddWebContact_Click);
            // 
            // AddWebContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 132);
            this.Controls.Add(this.btn_CancelAddWebContact);
            this.Controls.Add(this.btn_AddWebContact);
            this.Controls.Add(this.inp_Username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inp_ServerName);
            this.Controls.Add(this.label1);
            this.Name = "AddWebContactForm";
            this.Text = "l";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inp_ServerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inp_Username;
        private System.Windows.Forms.Button btn_AddWebContact;
        private System.Windows.Forms.Button btn_CancelAddWebContact;
    }
}