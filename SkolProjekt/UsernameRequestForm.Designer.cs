namespace SkolProjekt
{
    partial class UsernameRequestForm
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
            this.Tbx_UsernameInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_SetUsername = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Tbx_UsernameInput
            // 
            this.Tbx_UsernameInput.Location = new System.Drawing.Point(12, 27);
            this.Tbx_UsernameInput.Name = "Tbx_UsernameInput";
            this.Tbx_UsernameInput.Size = new System.Drawing.Size(197, 23);
            this.Tbx_UsernameInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // Btn_SetUsername
            // 
            this.Btn_SetUsername.Location = new System.Drawing.Point(12, 56);
            this.Btn_SetUsername.Name = "Btn_SetUsername";
            this.Btn_SetUsername.Size = new System.Drawing.Size(197, 23);
            this.Btn_SetUsername.TabIndex = 2;
            this.Btn_SetUsername.Text = "Set Username";
            this.Btn_SetUsername.UseVisualStyleBackColor = true;
            this.Btn_SetUsername.Click += new System.EventHandler(this.Btn_SetUsername_Click);
            // 
            // UsernameRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 90);
            this.Controls.Add(this.Btn_SetUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tbx_UsernameInput);
            this.Name = "UsernameRequestForm";
            this.Text = "UsernameRequestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Tbx_UsernameInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_SetUsername;
    }
}