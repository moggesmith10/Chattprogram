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
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace SkolProjekt
{
    public partial class StartHostForm : Form
    {
        public StartHostForm()
        {
            InitializeComponent();
        }

        private void Btn_Host_Click(object sender, EventArgs e)
        {
            if (Values.currentHost != null)
                Values.currentHost.Stop();
            Values.currentHost = new System.Net.Sockets.TcpListener(IPAddress.Parse(inp_IPAdress.Text), int.Parse(inp_Port.Text));
            Values.Contacts.Add(new Contact()
            {
                Name = "host",
                ConnectionType = 2,
                Log = new Log()
            });
            Values.HostContact = Values.Contacts.Count - 1;//TODO make better
            Values.mainForm.ReloadContactsList();
            Values.Contacts[Values.HostContact].Listener = new System.Threading.Thread(Listeners.HostListen);
            Values.Contacts[Values.HostContact].Listener.IsBackground = true;
            Values.Contacts[Values.HostContact].Listener.Start();
            Values.mainForm.Activate();
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Values.mainForm.Activate();
            this.Close();
        }

    }
}
