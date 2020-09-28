namespace SkolProjekt
{
	partial class LoginForm
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
			this.label2 = new System.Windows.Forms.Label();
			this.Inp_Domain = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.Inp_Username = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.Inp_Password = new System.Windows.Forms.TextBox();
			this.Btn_Login = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.Erp_ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.Btn_Register = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Erp_ErrorProvider)).BeginInit();
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "https://";
			// 
			// Inp_Domain
			// 
			this.Inp_Domain.Location = new System.Drawing.Point(57, 25);
			this.Inp_Domain.Name = "Inp_Domain";
			this.Inp_Domain.Size = new System.Drawing.Size(328, 23);
			this.Inp_Domain.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "Username";
			// 
			// Inp_Username
			// 
			this.Inp_Username.Location = new System.Drawing.Point(12, 69);
			this.Inp_Username.Name = "Inp_Username";
			this.Inp_Username.Size = new System.Drawing.Size(373, 23);
			this.Inp_Username.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 95);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 15);
			this.label4.TabIndex = 5;
			this.label4.Text = "Password";
			// 
			// Inp_Password
			// 
			this.Inp_Password.Location = new System.Drawing.Point(13, 113);
			this.Inp_Password.Name = "Inp_Password";
			this.Inp_Password.Size = new System.Drawing.Size(372, 23);
			this.Inp_Password.TabIndex = 6;
			this.Inp_Password.UseSystemPasswordChar = true;
			// 
			// Btn_Login
			// 
			this.Btn_Login.Location = new System.Drawing.Point(12, 142);
			this.Btn_Login.Name = "Btn_Login";
			this.Btn_Login.Size = new System.Drawing.Size(75, 23);
			this.Btn_Login.TabIndex = 7;
			this.Btn_Login.Text = "Login";
			this.Btn_Login.UseVisualStyleBackColor = true;
			this.Btn_Login.Click += new System.EventHandler(this.button1_ClickAsync);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(310, 142);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// Erp_ErrorProvider
			// 
			this.Erp_ErrorProvider.ContainerControl = this;
			// 
			// Btn_Register
			// 
			this.Btn_Register.Location = new System.Drawing.Point(114, 142);
			this.Btn_Register.Name = "Btn_Register";
			this.Btn_Register.Size = new System.Drawing.Size(75, 23);
			this.Btn_Register.TabIndex = 9;
			this.Btn_Register.Text = "Register";
			this.Btn_Register.UseVisualStyleBackColor = true;
			this.Btn_Register.Click += new System.EventHandler(this.Btn_Register_Click);
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(397, 173);
			this.Controls.Add(this.Btn_Register);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.Btn_Login);
			this.Controls.Add(this.Inp_Password);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.Inp_Username);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Inp_Domain);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "LoginForm";
			this.Text = "Login";
			this.Load += new System.EventHandler(this.LoginForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.Erp_ErrorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox Inp_Domain;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox Inp_Username;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox Inp_Password;
		private System.Windows.Forms.Button Btn_Login;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ErrorProvider Erp_ErrorProvider;
		private System.Windows.Forms.Button Btn_Register;
	}
}