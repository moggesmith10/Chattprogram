using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SkolProjekt
{
    public partial class NewContactForm : Form
    {
        public NewContactForm()
        {
            InitializeComponent();
        }

        private void Btn_AddWebContact_Click(object sender, EventArgs e)
        {
            AddWebContactForm form = new AddWebContactForm();
            form.Show();
            form.Activate();
            this.Close();
        }

        private void Btn_AddPrivateContact_Click(object sender, EventArgs e)
        {
            AddPrivateContactForm form = new AddPrivateContactForm();
            form.Show();
            form.Activate();
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Values.mainForm.Activate();
            this.Close();
        }
    }
}
