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
using System.Threading;
using System.Windows.Forms;
using SkolProjekt;

namespace SkolProjekt
{
    public partial class AddPrivateContactForm : Form
    {
        public AddPrivateContactForm()
        {
            InitializeComponent();
        }

        private void Btn_AddPrivateContactButton_Click(object sender, EventArgs e)
        {
            //Check for problems in user input
            if (!IPAddress.TryParse(inp_IPAdress.Text, out IPAddress ip))
			{
                IPError.SetError(inp_IPAdress,"Bad IP");
                return;
			}
            if(!int.TryParse(inp_Port.Text, out int port))
			{
                PortError.SetError(inp_Port,"Port needs to be number");
                return;
			}
            else if(port < 0 || port > 65535)
			{
                PortError.SetError(inp_Port, "Port needs to between 0 and 65535");
                return;
            }
            if(Inp_Name.Text.Length > 20)
			{
                nameError.SetError(Inp_Name, "Name can be max 20 charachters");
                return;
			}
            //----------------------------------

            Values.Contacts.Add(new Contact()
            {//Prep new Contact with empty log. Might be unesesary
                Name = Inp_Name.Text,
                Log = new Log(),
                IP = ip,
                Port = port,
                ConnectionType = 1,
            });
            
            //Attempt connection
            try
            {
                Contact c = Values.Contacts[^1];
                //else:
                //https://stackoverflow.com/questions/17118632/how-to-set-the-timeout-for-a-tcpclient
                TcpClient client = new TcpClient();
                var result = client.BeginConnect(c.IP, port,null,null);
                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3));

                if (!success)
                {
                    Values.Contacts[^1].Log.Text.Add("Could not connect, create a new contact to try again.");
                    return;
                }
				else if(client.Connected)
				{
                    Values.Contacts[^1].Log.Text.Add("Connected, say hi!.");
                    Values.Contacts[^1].Connected = true;
                }
                
                client.EndConnect(result);
                Values.Contacts[^1].stream = client.GetStream();
                Values.Contacts[^1].Listener = new Thread(new ParameterizedThreadStart(Listeners.Listen));
                Values.Contacts[^1].Listener.IsBackground = true;
                Values.Contacts[^1].Listener.Start(Values.Contacts.Count - 1);
            }
            catch (Exception exc)
            { //Custom error messages
                if(exc.HResult == -2147467259)
                    Values.Contacts[^1].Log.Text.Add("Kontakten hostar inte på den här porten.");
                else 
                    Values.Contacts[^1].Log.Text.Add(exc.Message);
            }
            Values.mainForm.ReloadContactsList();
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
