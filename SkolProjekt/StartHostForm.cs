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
