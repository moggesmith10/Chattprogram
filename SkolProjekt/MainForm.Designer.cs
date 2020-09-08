namespace SkolProjekt
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.inp_Text = new System.Windows.Forms.TextBox();
			this.btn_Send = new System.Windows.Forms.Button();
			this.list_Contact = new System.Windows.Forms.ListBox();
			this.btn_ContactsAdd = new System.Windows.Forms.Button();
			this.btn_ContactsRemove = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.Tsm_ChangeUsername = new System.Windows.Forms.ToolStripMenuItem();
			this.Tsm_StartHost = new System.Windows.Forms.ToolStripMenuItem();
			this.Tsm_LogOn = new System.Windows.Forms.ToolStripMenuItem();
			this.Tsm_Register = new System.Windows.Forms.ToolStripMenuItem();
			this.Btn_ImageSend = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.pnl_Messages = new System.Windows.Forms.Panel();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// inp_Text
			// 
			this.inp_Text.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.inp_Text.Location = new System.Drawing.Point(231, 412);
			this.inp_Text.Name = "inp_Text";
			this.inp_Text.Size = new System.Drawing.Size(395, 27);
			this.inp_Text.TabIndex = 0;
			// 
			// btn_Send
			// 
			this.btn_Send.Location = new System.Drawing.Point(713, 412);
			this.btn_Send.Name = "btn_Send";
			this.btn_Send.Size = new System.Drawing.Size(75, 30);
			this.btn_Send.TabIndex = 1;
			this.btn_Send.Text = "Send";
			this.btn_Send.UseVisualStyleBackColor = true;
			this.btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
			// 
			// list_Contact
			// 
			this.list_Contact.FormattingEnabled = true;
			this.list_Contact.ItemHeight = 15;
			this.list_Contact.Items.AddRange(new object[] {
            "Contact1",
            "Contact2",
            "Contact3"});
			this.list_Contact.Location = new System.Drawing.Point(12, 42);
			this.list_Contact.Name = "list_Contact";
			this.list_Contact.Size = new System.Drawing.Size(213, 364);
			this.list_Contact.TabIndex = 2;
			this.list_Contact.SelectedIndexChanged += new System.EventHandler(this.List_Contact_SelectedIndexChanged);
			// 
			// btn_ContactsAdd
			// 
			this.btn_ContactsAdd.Location = new System.Drawing.Point(12, 412);
			this.btn_ContactsAdd.Name = "btn_ContactsAdd";
			this.btn_ContactsAdd.Size = new System.Drawing.Size(30, 30);
			this.btn_ContactsAdd.TabIndex = 4;
			this.btn_ContactsAdd.Text = "+";
			this.btn_ContactsAdd.UseVisualStyleBackColor = true;
			this.btn_ContactsAdd.Click += new System.EventHandler(this.Btn_ContactsAdd_Click);
			// 
			// btn_ContactsRemove
			// 
			this.btn_ContactsRemove.Location = new System.Drawing.Point(48, 412);
			this.btn_ContactsRemove.Name = "btn_ContactsRemove";
			this.btn_ContactsRemove.Size = new System.Drawing.Size(30, 30);
			this.btn_ContactsRemove.TabIndex = 4;
			this.btn_ContactsRemove.Text = "-";
			this.btn_ContactsRemove.UseVisualStyleBackColor = true;
			this.btn_ContactsRemove.Click += new System.EventHandler(this.btn_ContactsRemove_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tsm_ChangeUsername,
            this.Tsm_StartHost,
            this.Tsm_LogOn,
            this.Tsm_Register});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// Tsm_ChangeUsername
			// 
			this.Tsm_ChangeUsername.Name = "Tsm_ChangeUsername";
			this.Tsm_ChangeUsername.Size = new System.Drawing.Size(116, 20);
			this.Tsm_ChangeUsername.Text = "Change Username";
			// 
			// Tsm_StartHost
			// 
			this.Tsm_StartHost.Name = "Tsm_StartHost";
			this.Tsm_StartHost.Size = new System.Drawing.Size(110, 20);
			this.Tsm_StartHost.Text = "Start Private Host";
			// 
			// Tsm_LogOn
			// 
			this.Tsm_LogOn.Name = "Tsm_LogOn";
			this.Tsm_LogOn.Size = new System.Drawing.Size(56, 20);
			this.Tsm_LogOn.Text = "Log on";
			// 
			// Tsm_Register
			// 
			this.Tsm_Register.Name = "Tsm_Register";
			this.Tsm_Register.Size = new System.Drawing.Size(61, 20);
			this.Tsm_Register.Text = "Register";
			// 
			// Btn_ImageSend
			// 
			this.Btn_ImageSend.Location = new System.Drawing.Point(632, 412);
			this.Btn_ImageSend.Name = "Btn_ImageSend";
			this.Btn_ImageSend.Size = new System.Drawing.Size(75, 30);
			this.Btn_ImageSend.TabIndex = 1;
			this.Btn_ImageSend.Text = "Image";
			this.Btn_ImageSend.UseVisualStyleBackColor = true;
			this.Btn_ImageSend.Click += new System.EventHandler(this.Btn_Image_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 15);
			this.label1.TabIndex = 7;
			this.label1.Text = "Contacts";
			// 
			// pnl_Messages
			// 
			this.pnl_Messages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnl_Messages.Location = new System.Drawing.Point(231, 42);
			this.pnl_Messages.Name = "pnl_Messages";
			this.pnl_Messages.Size = new System.Drawing.Size(557, 364);
			this.pnl_Messages.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Btn_ImageSend);
			this.Controls.Add(this.btn_ContactsRemove);
			this.Controls.Add(this.btn_ContactsAdd);
			this.Controls.Add(this.list_Contact);
			this.Controls.Add(this.btn_Send);
			this.Controls.Add(this.inp_Text);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.pnl_Messages);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Form1";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox inp_Text;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.ListBox list_Contact;
        private System.Windows.Forms.Button btn_ContactsAdd;
        private System.Windows.Forms.Button btn_ContactsRemove;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Tsm_ChangeUsername;
        private System.Windows.Forms.Button Btn_ImageSend;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel pnl_Messages;
		private System.Windows.Forms.ToolStripMenuItem Tsm_StartHost;
		private System.Windows.Forms.ToolStripMenuItem Tsm_LogOn;
		private System.Windows.Forms.ToolStripMenuItem Tsm_Register;
	}
}

