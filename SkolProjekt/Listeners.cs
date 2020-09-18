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
			while (true)
			{
				try
				{
					Values.currentHost.Start();
					TcpClient currentClient = Values.currentHost.AcceptTcpClient();
					Values.Contacts[Values.HostContact].Connected = true;
					Values.Contacts[Values.HostContact].stream = currentClient.GetStream();

					//Send Decrypter i.e their encryptor
					Values.Contacts[Values.HostContact].DecryptProvider = new RSACryptoServiceProvider(4096);
					Values.Contacts[Values.HostContact].stream.Write(UTF8Encoding.UTF8.GetBytes(Values.Contacts[Values.HostContact].DecryptProvider.ToXmlString(false)));

					//Recieve Encryptor, i.e their decryptor
					byte[] buffer = new byte[755];
					Values.Contacts[Values.HostContact].stream.Read(buffer, 0, buffer.Length);
					Values.Contacts[Values.HostContact].EncryptProvider = new RSACryptoServiceProvider(4096);
					string xml = UTF8Encoding.UTF8.GetString(buffer).Trim('\0');
					Values.Contacts[Values.HostContact].EncryptProvider.FromXmlString(xml);

					Values.Contacts[Values.HostContact].aes = Aes.Create();
					Aes aes = Values.Contacts[Values.HostContact].aes;
					List<byte> toSend = new List<byte>();
					toSend.AddRange(aes.Key);
					toSend.AddRange(aes.IV);


					Values.Contacts[Values.HostContact].stream.Write(Values.Contacts[Values.HostContact].EncryptProvider.Encrypt(toSend.ToArray(), false));

					while (true)
					{
						try
						{
							buffer = new byte[512];
							Values.Contacts[Values.HostContact].stream.Read(buffer, 0, buffer.Length);

							buffer = Values.Contacts[Values.HostContact].DecryptProvider.Decrypt(buffer, false);
							if (StructuralComparisons.StructuralEqualityComparer.Equals(buffer, imagePrepper))
							{
								CryptoStream cryptoStream = new CryptoStream(Values.Contacts[Values.HostContact].stream, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read);

								try
								{

									buffer = new byte[512];
									Values.Contacts[Values.HostContact].stream.Read(buffer, 0, buffer.Length);
									buffer = Values.Contacts[Values.HostContact].DecryptProvider.Decrypt(buffer, false);

									int imageLength = BitConverter.ToInt32(buffer, 0);

									buffer = new byte[imageLength];
									var res = cryptoStream.BeginRead(buffer, 0, buffer.Length, null, cryptoStream);
									var succes = res.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));//This keeps me up at night, please, make this better

									Image image = ByteArrayToImage(buffer.ToArray());
									Values.Contacts[Values.HostContact].Log.Text.Add(image);

								}
								catch (Exception e)
								{
									throw e;
								}

								//Hope you like pasta:


								Values.mainForm.inp_Text.Invoke((MethodInvoker)delegate
								{//Threading stuff, makes it run across to main thread probably
									Values.mainForm.UpdateLog();
									Values.mainForm.ReloadContactsList();
								});
								break;
							}
							else
							{
								string recieved = UTF8Encoding.UTF8.GetString(buffer);//Trim ending zeros
																					  //TODO make variable packet size
								Values.Contacts[Values.HostContact].Log.Text.Add(recieved);

								Values.mainForm.inp_Text.Invoke((MethodInvoker)delegate//Threading stuff, makes it run across to main thread probably
								{
									Values.mainForm.UpdateLog();
									Values.mainForm.ReloadContactsList();
								});
							}
						}
						catch (Exception e)
						{

							Values.mainForm.inp_Text.Invoke((MethodInvoker)delegate//Threading stuff, makes it run across to main thread probably
							{
								Values.Contacts[Values.HostContact].Log.Text.Add(e.Message);
								Values.mainForm.UpdateLog();
							});
						}
					}
				}
				catch (Exception e)
				{
					if (Values.HostContact != -1)
						Values.Contacts.RemoveAt(Values.HostContact);
					throw e;
				}
			}
		}

		public static void Listen(object Contact)
		{
			//Get crypto stuffz

			//Recieve Encryptor, i.e their decryptor
			byte[] buffer = new byte[755];
			Values.Contacts[(int)Contact].stream.Read(buffer, 0, buffer.Length);
			Values.Contacts[(int)Contact].EncryptProvider = new RSACryptoServiceProvider(4096);
			string xml = UTF8Encoding.UTF8.GetString(buffer).Trim('\0');
			Values.Contacts[(int)Contact].EncryptProvider.FromXmlString(xml);

			//Send Decrypter i.e their encryptor
			Values.Contacts[(int)Contact].DecryptProvider = new RSACryptoServiceProvider(4096);
			Values.Contacts[(int)Contact].stream.Write(UTF8Encoding.UTF8.GetBytes(Values.Contacts[(int)Contact].DecryptProvider.ToXmlString(false)));

			NetworkStream stream = Values.Contacts[(int)Contact].stream;
			RSACryptoServiceProvider decrypter = Values.Contacts[(int)Contact].DecryptProvider;
			Aes aes;
			buffer = new byte[512];
			stream.Read(buffer, 0, buffer.Length);
			byte[] keys = decrypter.Decrypt(buffer, false);
			Values.Contacts[(int)Contact].aes = Aes.Create();
			Values.Contacts[(int)Contact].aes.Key = keys.Take(32).ToArray();
			Values.Contacts[(int)Contact].aes.IV = keys.Skip(32).ToArray();
			aes = Values.Contacts[(int)Contact].aes;

			while (true)
			{
				try
				{
					buffer = new byte[512];
					Values.Contacts[(int)Contact].stream.Read(buffer, 0, buffer.Length);
					buffer = Values.Contacts[(int)Contact].DecryptProvider.Decrypt(buffer, false);
					if (StructuralComparisons.StructuralEqualityComparer.Equals(buffer, imagePrepper))
					{

						CryptoStream cryptoStream = new CryptoStream(Values.Contacts[(int)Contact].stream, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read);

						try
						{

							buffer = new byte[512];
							Values.Contacts[(int)Contact].stream.Read(buffer, 0, buffer.Length);
							buffer = Values.Contacts[(int)Contact].DecryptProvider.Decrypt(buffer, false);

							int imageLength = BitConverter.ToInt32(buffer, 0);

							buffer = new byte[imageLength];
							var res = cryptoStream.BeginRead(buffer, 0, buffer.Length, null, cryptoStream);
							var succes = res.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));

							Image image = ByteArrayToImage(buffer.ToArray());
							Values.Contacts[(int)Contact].Log.Text.Add(image);

						}
						catch (Exception e)
						{
							throw e;
						}

						//Hope you like pasta:


						Values.mainForm.inp_Text.Invoke((MethodInvoker)delegate
						{//Threading stuff, makes it run across to main thread probably
							Values.mainForm.UpdateLog();
							Values.mainForm.ReloadContactsList();
						});
						break;
					}
					else
					{
						string recieved = UTF8Encoding.UTF8.GetString(buffer);//Trim ending zeros
																			  //TODO make variable packet size
						Values.Contacts[(int)Contact].Log.Text.Add(recieved);
						
						Values.mainForm.inp_Text.Invoke((MethodInvoker)delegate//Threading stuff, makes it run across to main thread probably
						{
							Values.mainForm.UpdateLog();
							Values.mainForm.ReloadContactsList();
						});
					}
				}
				catch (Exception e)
				{
					try
					{
						Values.mainForm.inp_Text.Invoke((MethodInvoker)delegate//Threading stuff, makes it run across to main thread probably
						{
							if (e.HResult != -2146233086 && e.HResult != -2146232800)//-2146233086 == Contact was deleted
							{
								Values.Contacts[(int)Contact].Log.Text.Add(e.Message);
								Values.mainForm.UpdateLog();
							}
						});
					}
					catch (Exception ee)
					{

					}
				}
			}
		}
		public static Image ByteArrayToImage(byte[] byteArrayIn)
		{
			MemoryStream ms = new MemoryStream(byteArrayIn);
			Image returnImage = Image.FromStream(ms);
			return returnImage;
		}
	}
}
