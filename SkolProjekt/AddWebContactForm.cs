/*
    Chatting Program
    Copyright (C) 2020  Morgan Smith

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
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
            Values.webManager.UsernameToContact.Add(inp_Username.Text, Values.Contacts.Count - 1);
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
