using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace SkolProjekt
{
    public static class Values
    {
        public static MainForm mainForm;
        //public static List<WebContact> WebContacts;
        //public static List<PrivateContact> PrivateContacts;
        //public static List<TcpClient> currentConnections;
        public static TcpListener currentHost;
        //public static Thread hostingThread;
        //public static NetworkStream hostStream;
        //public static List<Log> Logs; Replaced
        public static List<Contact> Contacts;
        public static int HostContact = -1;
    }

    public class Log
    {
        public List<object> Text = new List<object>();
        public List<object> ReadText = new List<object>();//Past tense

    }
    public class Contact
    {
        public Log Log = new Log();
        public int ConnectionType;
        public string Name;
        public bool Connected = false;

        //Public
        public string Server;
        public string Username;

        //Private
        public IPAddress IP;
        public int Port;

        //Private/Host
        public NetworkStream stream;
        public Thread Listener;

        //Encryption
        public RSACryptoServiceProvider EncryptProvider;
        public RSACryptoServiceProvider DecryptProvider;
        public Aes aes;
    }
}
