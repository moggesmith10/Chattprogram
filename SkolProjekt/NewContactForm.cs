﻿/*
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
