namespace SkolProjekt
{
    partial class AddPrivateContactForm
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.inp_IPAdress = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.inp_Port = new System.Windows.Forms.TextBox();
			this.btn_AddPrivateContactButton = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.IPError = new System.Windows.Forms.ErrorProvider(this.components);
			this.PortError = new System.Windows.Forms.ErrorProvider(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.Inp_Name = new System.Windows.Forms.TextBox();
			this.nameError = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.IPError)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PortError)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nameError)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "IP-Adress";
			// 
			// inp_IPAdress
			// 
			this.inp_IPAdress.Location = new System.Drawing.Point(12, 71);
			this.inp_IPAdress.Name = "inp_IPAdress";
			this.inp_IPAdress.Size = new System.Drawing.Size(245, 23);
			this.inp_IPAdress.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 97);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Port";
			// 
			// inp_Port
			// 
			this.inp_Port.Location = new System.Drawing.Point(12, 115);
			this.inp_Port.Name = "inp_Port";
			this.inp_Port.Size = new System.Drawing.Size(245, 23);
			this.inp_Port.TabIndex = 3;
			// 
			// btn_AddPrivateContactButton
			// 
			this.btn_AddPrivateContactButton.Location = new System.Drawing.Point(12, 153);
			this.btn_AddPrivateContactButton.Name = "btn_AddPrivateContactButton";
			this.btn_AddPrivateContactButton.Size = new System.Drawing.Size(75, 23);
			this.btn_AddPrivateContactButton.TabIndex = 4;
			this.btn_AddPrivateContactButton.Text = "Add";
			this.btn_AddPrivateContactButton.UseVisualStyleBackColor = true;
			this.btn_AddPrivateContactButton.Click += new System.EventHandler(this.Btn_AddPrivateContactButton_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(179, 153);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 5;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
			// 
			// IPError
			// 
			this.IPError.ContainerControl = this;
			this.IPError.DataSource = this.inp_IPAdress.Controls;
			// 
			// PortError
			// 
			this.PortError.ContainerControl = this;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 15);
			this.label3.TabIndex = 6;
			this.label3.Text = "Name";
			// 
			// Inp_Name
			// 
			this.Inp_Name.Location = new System.Drawing.Point(12, 27);
			this.Inp_Name.Name = "Inp_Name";
			this.Inp_Name.Size = new System.Drawing.Size(245, 23);
			this.Inp_Name.TabIndex = 7;
			// 
			// nameError
			// 
			this.nameError.ContainerControl = this;
			// 
			// AddPrivateContactForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(290, 188);
			this.Controls.Add(this.Inp_Name);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_AddPrivateContactButton);
			this.Controls.Add(this.inp_Port);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.inp_IPAdress);
			this.Controls.Add(this.label1);
			this.Name = "AddPrivateContactForm";
			this.Text = "IP-Adress";
			((System.ComponentModel.ISupportInitialize)(this.IPError)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PortError)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nameError)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inp_IPAdress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inp_Port;
        private System.Windows.Forms.Button btn_AddPrivateContactButton;
        private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.ErrorProvider IPError;
		private System.Windows.Forms.ErrorProvider PortError;
		private System.Windows.Forms.TextBox Inp_Name;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ErrorProvider nameError;
	}
}