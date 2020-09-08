namespace SkolProjekt
{
    partial class NewContactForm
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
            this.btn_AddWebContact = new System.Windows.Forms.Button();
            this.btn_AddPrivateContact = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_AddWebContact
            // 
            this.btn_AddWebContact.Location = new System.Drawing.Point(12, 12);
            this.btn_AddWebContact.Name = "btn_AddWebContact";
            this.btn_AddWebContact.Size = new System.Drawing.Size(113, 23);
            this.btn_AddWebContact.TabIndex = 0;
            this.btn_AddWebContact.Text = "Web Connection";
            this.btn_AddWebContact.UseVisualStyleBackColor = true;
            this.btn_AddWebContact.Click += new System.EventHandler(this.Btn_AddWebContact_Click);
            // 
            // btn_AddPrivateContact
            // 
            this.btn_AddPrivateContact.Location = new System.Drawing.Point(131, 12);
            this.btn_AddPrivateContact.Name = "btn_AddPrivateContact";
            this.btn_AddPrivateContact.Size = new System.Drawing.Size(134, 23);
            this.btn_AddPrivateContact.TabIndex = 0;
            this.btn_AddPrivateContact.Text = "Private Connection";
            this.btn_AddPrivateContact.UseVisualStyleBackColor = true;
            this.btn_AddPrivateContact.Click += new System.EventHandler(this.Btn_AddPrivateContact_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(271, 12);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancel.TabIndex = 1;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 47);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.btn_AddPrivateContact);
            this.Controls.Add(this.btn_AddWebContact);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_AddWebContact;
        private System.Windows.Forms.Button btn_AddPrivateContact;
        private System.Windows.Forms.Button Btn_Cancel;
    }
}