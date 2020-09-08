namespace SkolProjekt
{
    partial class StartHostForm
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
            this.inp_IPAdress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inp_Port = new System.Windows.Forms.TextBox();
            this.Btn_Host = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP-Adress";
            // 
            // inp_IPAdress
            // 
            this.inp_IPAdress.Location = new System.Drawing.Point(12, 27);
            this.inp_IPAdress.Name = "inp_IPAdress";
            this.inp_IPAdress.Size = new System.Drawing.Size(245, 23);
            this.inp_IPAdress.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // inp_Port
            // 
            this.inp_Port.Location = new System.Drawing.Point(12, 71);
            this.inp_Port.Name = "inp_Port";
            this.inp_Port.Size = new System.Drawing.Size(242, 23);
            this.inp_Port.TabIndex = 3;
            // 
            // Btn_Host
            // 
            this.Btn_Host.Location = new System.Drawing.Point(12, 100);
            this.Btn_Host.Name = "Btn_Host";
            this.Btn_Host.Size = new System.Drawing.Size(75, 23);
            this.Btn_Host.TabIndex = 4;
            this.Btn_Host.Text = "Host";
            this.Btn_Host.UseVisualStyleBackColor = true;
            this.Btn_Host.Click += new System.EventHandler(this.Btn_Host_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(182, 100);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // StartHostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 132);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.Btn_Host);
            this.Controls.Add(this.inp_Port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inp_IPAdress);
            this.Controls.Add(this.label1);
            this.Name = "StartHostForm";
            this.Text = "StartHostForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inp_IPAdress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inp_Port;
        private System.Windows.Forms.Button Btn_Host;
        private System.Windows.Forms.Button btn_Cancel;
    }
}