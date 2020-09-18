using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkolProjekt
{
    public partial class AddWebContactForm : Form
    {
        public AddWebContactForm()
        {
            InitializeComponent();
        }

        private void Btn_AddWebContact_Click(object sender, EventArgs e)
        {
            Values.Contacts.Add(new Contact {
                Username = inp_Username.Text,
                ConnectionType = 0,
            });

            Values.mainForm.ReloadContactsList();
            Values.mainForm.Activate();
            this.Close();
        }

        private void Btn_CancelAddWebContact_Click(object sender, EventArgs e)
        {
            Values.mainForm.Activate();
            this.Close();
        }
    }
}
