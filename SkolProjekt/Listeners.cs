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
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkolProjekt
{
	class Listeners
	{
		static readonly byte[] imagePrepper = new byte[] { 0, 1, 2, 3, 4 };
		public static void HostListen()
		{
			while (true) //Loop to recieve new contacts
			{
				try
				{
					//Wait until client connects and then recieve them
					RecieveClient();

					//Send Decrypter i.e their encryptor
					SendRSA(Values.Contacts[Values.HostContact]);

					//Recieve Encryptor, i.e their decryptor
					RecieveRSA(Values.Contacts[Values.HostContact]);

					//Send AES for encrypting images
					Aes aes = SendAES(Values.Contacts[Values.HostContact]);

					while (true)//Loop to recieve new messages
					{
						try
						{
							Recieve(Values.Contacts[Values.HostContact]);//Recieve image or text
						}
						catch (Exception e)
						{
							ReportException(Values.Contacts[Values.HostContact], e);
						}
					}
				}
				catch (Exception e)//If error, delete contact. Most likely issue is contact being removed
				{
					break;
				}
			}
		}

		public static void Listen(object Contact)
		{

			//Recieve Encryptor, i.e their decryptor
			RecieveRSA(Values.Contacts[(int)Contact]);

			//Send Decrypter i.e their encryptor
			SendRSA(Values.Contacts[(int)Contact]);

			Aes aes = RecieveAES(Values.Contacts[(int)Contact]);

			while (true)
			{
				try
				{
					Recieve(Values.Contacts[(int)Contact]);
				}
				catch (Exception e)
				{
					ReportException(Values.Contacts[(int)Contact], e);
				}
			}
		}
		private static void RecieveClient()
		{
			Values.currentHost.Start();
			TcpClient currentClient = Values.currentHost.AcceptTcpClient(); //Recieve Client
			Values.Contacts[Values.HostContact].Connected = true;
			Values.Contacts[Values.HostContact].stream = currentClient.GetStream();
		}
		public static Image ByteArrayToImage(byte[] byteArrayIn)
		{
			MemoryStream ms = new MemoryStream(byteArrayIn);
			Image returnImage = Image.FromStream(ms);
			return returnImage;
		}
		private static void SendRSA(Contact c)
		{
			c.DecryptProvider = new RSACryptoServiceProvider(4096);
			c.stream.Write(UTF8Encoding.UTF8.GetBytes(c.DecryptProvider.ToXmlString(false)));
		}
		private static void RecieveRSA(Contact c)
		{
			byte[] buffer = new byte[755];
			c.stream.Read(buffer, 0, buffer.Length);
			c.EncryptProvider = new RSACryptoServiceProvider(4096);
			string xml = UTF8Encoding.UTF8.GetString(buffer).Trim('\0');
			c.EncryptProvider.FromXmlString(xml);
		}
		private static Aes SendAES(Contact c)
		{
			c.aes = Aes.Create();
			Aes aes = c.aes;
			List<byte> toSend = new List<byte>();
			toSend.AddRange(aes.Key);
			toSend.AddRange(aes.IV);
			c.stream.Write(c.EncryptProvider.Encrypt(toSend.ToArray(), false));
			return aes;
		}
		private static Aes RecieveAES(Contact c)
		{
			Aes aes;
			byte[] buffer = new byte[512];
			c.stream.Read(buffer, 0, buffer.Length);
			byte[] keys = c.DecryptProvider.Decrypt(buffer, false);
			c.aes = Aes.Create();
			c.aes.Key = keys.Take(32).ToArray();
			c.aes.IV = keys.Skip(32).ToArray();
			aes = c.aes;
			return aes;
		}
		private static void Recieve(Contact c)
		{
			byte[] buffer;
			try
			{
				buffer = new byte[512];
				c.stream.Read(buffer, 0, buffer.Length);

				buffer = c.DecryptProvider.Decrypt(buffer, false);
				if (!RecievingImage(buffer, c))
				{
					RecieveText(c, buffer);
				}
			}
			catch (Exception e)
			{

			}
		}

		private static void RecieveText(Contact c, byte[] buffer)
		{
			string recieved = UTF8Encoding.UTF8.GetString(buffer);//Trim ending zeros
																  //TODO make variable packet size
			c.Log.Text.Add(recieved);

			Values.mainForm.inp_Text.Invoke((MethodInvoker)delegate//Threading stuff, makes it run across to main thread probably
			{
				Values.mainForm.UpdateLog();
				Values.mainForm.ReloadContactsList();
			});
		}

		private static bool RecievingImage(byte[] buffer, Contact c)
		{
			if (StructuralComparisons.StructuralEqualityComparer.Equals(buffer, imagePrepper))
			{
				CryptoStream cryptoStream = GenerateCryptoStream(c);
				try
				{
					Image image = RecieveImage(c, cryptoStream);
					Values.Contacts[Values.HostContact].Log.Text.Add(image);
				}
				catch (Exception e)
				{
					throw e;
				}

				Values.mainForm.inp_Text.Invoke((MethodInvoker)delegate
				{//Threading stuff, makes it run across to main thread probably
				Values.mainForm.UpdateLog();
					Values.mainForm.ReloadContactsList();
				});
				return true;
			}
			else
				return false;
		}
		private static Image RecieveImage(Contact c, CryptoStream crypto)
		{
			byte[] buffer = new byte[512];
			Values.Contacts[Values.HostContact].stream.Read(buffer, 0, buffer.Length);
			buffer = Values.Contacts[Values.HostContact].DecryptProvider.Decrypt(buffer, false);
			int imageLength = BitConverter.ToInt32(buffer, 0);
			buffer = new byte[imageLength];
			var res = crypto.BeginRead(buffer, 0, buffer.Length, null, crypto);
			var succes = res.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));//This keeps me up at night, please, make this better
			return ByteArrayToImage(buffer.ToArray());
		}
		private static CryptoStream GenerateCryptoStream(Contact c)
		{
			return new CryptoStream(c.stream, c.aes.CreateDecryptor(c.aes.Key, c.aes.IV), CryptoStreamMode.Read);
		}
		private static void ReportException(Contact c, Exception e)
		{
			if (e.HResult != -2146233086 && e.HResult != -2146232800)//-2146233086 == Contact was deleted
				Values.mainForm.inp_Text.Invoke((MethodInvoker)delegate//Threading stuff, makes it run across to main thread probably
				{
					c.Log.Text.Add(e.Message);
					Values.mainForm.UpdateLog();
				});
		}
	}
}
