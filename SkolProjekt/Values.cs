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
        public static TcpListener currentHost;
        public static List<Contact> Contacts;
        public static int HostContact = -1;
        public static string Token;
        public static string Server;
        public static string ownUsername;
        public static bool logedIn = false;
        public static WebManager webManager = new WebManager();
        public static List<int> readMessages = new List<int>();
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
