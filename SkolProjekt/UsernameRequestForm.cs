using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SkolProjekt
{
    public partial class UsernameRequestForm : Form
    {
        public UsernameRequestForm()
        {
            InitializeComponent();
        }

        private void Btn_SetUsername_Click(object sender, EventArgs e)
        {
            Values.mainForm.name = Tbx_UsernameInput.Text;
            Values.mainForm.Activate();
            this.Close();
        }
    }
}
