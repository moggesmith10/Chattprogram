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
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SkolProjekt
{
	public partial class MainForm : Form
	{
		public string name = "Unnamed";
		int typeOfConnection; //0: Web, 1: Private, 2:Host

		bool justRealoaded = false;//Very hacky. stops loop when selecting 
									//Stops loop since
									//Select index in list -->
									//Clear list -->
									//Select index again -->
									//List index has changed. Reload list if unread message is now read -->
									//Repeat
									//This adds a bool to stop at list index has changed

		List<object> logFiles = new List<object>();

		/// <summary>
		/// Runs when form is opened I.E when program is started
		/// </summary>
		public MainForm()
		{
			InitializeComponent();//Generate form
			GetContacts();//Load Contact List
			ReloadContactsList();//Load list to UI
			Values.mainForm = this;//Set form1 to this form, used when setting main form (this) to active
			UpdateLog();

			this.Resize += MainForm_Resize;
			Tsm_ChangeUsername.Click += Tsm_ChangeUsername_Click;
			Tsm_LogOn.Click += Tsm_LogOn_Click;
			Tsm_StartHost.Click += Tsm_StartHost_Click;
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			int messageWidth = this.Size.Width - list_Contact.Size.Width - 48;
			int messageHeight = this.Size.Height - menuStrip1.Size.Height - 14 - 60 - inp_Text.Size.Height;
			pnl_Messages.Size = new Size(messageWidth, messageHeight);

			inp_Text.Location = new Point(231, Size.Height - 77);
			inp_Text.Size = new Size(Size.Width - 421, 27);
			btn_Send.Location = new Point(Size.Width - 103, Size.Height - 77);
			Btn_ImageSend.Location = new Point(Size.Width - 184, Size.Height - 77);
			list_Contact.Size = new Size(213, Size.Height - 125);
			btn_ContactsAdd.Location = new Point(12, Size.Height - 77);
			btn_ContactsRemove.Location = new Point(48, Size.Height - 77);
			vScrollBar1.Location = new Point(pnl_Messages.Width-vScrollBar1.Width,0);
			vScrollBar1.Height = pnl_Messages.Height;
		}

		private void Tsm_StartHost_Click(object sender, EventArgs e)
		{
			StartHostForm startHostForm = new StartHostForm();
			startHostForm.Show();
		}

		private void Tsm_LogOn_Click(object sender, EventArgs e)
		{
			var loginForm = new LoginForm();
			loginForm.Show();
			loginForm.Activate();
		}

		private void Tsm_ChangeUsername_Click(object sender, EventArgs e)
		{
			var usernameForm = new UsernameRequestForm();
			usernameForm.Show();
			usernameForm.Activate();
		}

		private void GetContacts()
		{
			Values.Contacts = new List<Contact>();//Placeholder, just gets empty list
		}
		/// <summary>
		/// Reloads list_Contacts and adds * if there is a new message
		/// </summary>
		public void ReloadContactsList()
		{
			int CurrentIndex = list_Contact.SelectedIndex;//Save current index
			list_Contact.Items.Clear();//Clear list
			int i = 0;
			//Get reserve name
			foreach (Contact c in Values.Contacts)//Foreach contact
			{
				string name;
				if (c.Name == "" && c.ConnectionType == 1)//If private connection and nameless, use IP as name
					name = c.IP.ToString();
				else if (c.Name == "" || c.Name == null && c.ConnectionType == 0)//If web connection and nameless, use username
					name = c.Username;
				else//else use name
					name = c.Name;

				if (c.Log.Text != c.Log.ReadText)//Add a star if something new has been sent.
					name += '*';

				//Add final name to list
				if (list_Contact.Items.Count <= i)//Dont replace already existing items, that will unselect them
					list_Contact.Items.Add(name);
				else
					list_Contact.Items[i] = name;
				i++;
			}

			//CurrentIndex == -1 means nothing is selected
			if (CurrentIndex != -1 && CurrentIndex < list_Contact.Items.Count)//If something is selected, then set justReloaded to true to stop looping and set selected (actuall selected was cleared when list was reloaded)
			{
				justRealoaded = true;
				list_Contact.SetSelected(CurrentIndex, true);
			}
		}

		private void Btn_Send_Click(object sender, EventArgs e)
		{
			Send(inp_Text.Text);
		}

		/// <summary>
		/// Adds name to string
		/// </summary>
		/// <param name="input">Text to format</param>
		/// <returns>String ready to encrypt and send</returns>
		private string FormatText(string input)
		{
			return string.Format("{0}: {1}", name, input);
		}
		public void AddToLog(string toLog)
		{
			Values.Contacts[list_Contact.SelectedIndex].Log.Text.Add(toLog);
			UpdateLog();
		}

		/// <summary>
		/// Formats, Encrypts and sends input to selcted contact in list_Contacts
		/// </summary>
		/// <param name="input"></param>
		/// <returns>true if succesful</returns>
		private bool Send(string input)
		{
			if (list_Contact.SelectedIndex != -1 && list_Contact.SelectedIndex < Values.Contacts.Count && Values.Contacts[list_Contact.SelectedIndex].ConnectionType == 0)
			{
				_ = Values.webManager.SendMessage(input, Values.Contacts[list_Contact.SelectedIndex].Username);
				return true;
			}

			else if (list_Contact.SelectedIndex != -1 && list_Contact.SelectedIndex < Values.Contacts.Count)
			{
				//Make sure we are connected before we send anything
				if (Values.Contacts[list_Contact.SelectedIndex].Connected)
				{
					string formated = FormatText(input);
					AddToLog(formated);
					byte[] encrypted = Encrypt(formated);
					return SendPacket(encrypted);
				}
				return false;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Encrypts input with list_Contact.SelectedIndex's EncryptProvider
		/// </summary>
		/// <param name="toEncrypt">Value to encrypt</param>
		/// <returns>Encrypted byte array ready to send</returns>
		byte[] Encrypt(string toEncrypt)
		{
			if (typeOfConnection > 0)//Contact is not web contact
				return Values.Contacts[list_Contact.SelectedIndex].EncryptProvider.Encrypt(UTF8Encoding.UTF8.GetBytes(toEncrypt), false);
			else
				return new byte[0];

		}
		bool SendPacket(byte[] toSend)
		{
			if (typeOfConnection > 0)
			{
				Values.Contacts[list_Contact.SelectedIndex].stream.Write(toSend);
				return true;
			}
			return false;

		}
		///<summary>
		///Updates tbx_Log to text of selected contact in list_Contact 
		///</summary>
		public void UpdateLog()
		{
			int yDisplace = 12 + vScrollBar1.Value;
			int xDisplace = 12;

			if (logFiles != null)
				foreach (object obj in logFiles)
				{
					if (obj is PictureBox pBox)
						pBox.Dispose();

					else if (obj is Label lbl)
						lbl.Dispose();
				}
			logFiles = new List<object>();

			if (list_Contact.SelectedIndex != -1)
			{
				foreach (object obj in Values.Contacts[list_Contact.SelectedIndex].Log.Text)
				{
					if (obj is Image image)
					{
						var img = new PictureBox
						{
							Image = image,
							Location = new Point(xDisplace, yDisplace),
							Size = new Size(150, 100),
							SizeMode = PictureBoxSizeMode.StretchImage
						};
						//img.SizeMode = PictureBoxSizeMode.StretchImage;
						yDisplace += 50;
						lbl_Scroller.Controls.Add(img);
						logFiles.Add(img);
					}
					else
					{
						var lbl = new Label
						{
							Text = (string)obj,
							Location = new Point(xDisplace, yDisplace),
							Visible = true,
							Size = new Size(500, 20)
						};
						yDisplace += 20;
						lbl_Scroller.Controls.Add(lbl);
						logFiles.Add(lbl);
					}
				}
				bool maxed = false;
				if (vScrollBar1.Value >= vScrollBar1.Maximum - 16) //Margin of error
					maxed = true;

				vScrollBar1.Maximum = yDisplace - pnl_Messages.Height + 24;
				if(vScrollBar1.Maximum < 0)
				{
					vScrollBar1.Maximum = 0;
					vScrollBar1.Minimum = 0;
				}

				if (maxed)
					vScrollBar1.Value = vScrollBar1.Maximum;
				vScrollBar1_Scroll(new object(), new ScrollEventArgs(ScrollEventType.EndScroll, 0));

				//tbx_Log.Text = Values.Contacts[list_Contact.SelectedIndex].Log.Text;
				Values.Contacts[list_Contact.SelectedIndex].Log.ReadText = Values.Contacts[list_Contact.SelectedIndex].Log.Text;
			}
			else
			{
				var lbl = new Label
				{
					Text = "No contact selected. Please select one in the list to the left or create a new contact.",
					Location = new Point(xDisplace, yDisplace),
					Visible = true,
					Size = new Size(500, 20)
				};
				lbl_Scroller.Controls.Add(lbl);
				logFiles.Add(lbl);
			}
		}
		/// <summary>
		/// When object in contacts list is changed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void List_Contact_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (justRealoaded)
			{
				justRealoaded = false;
				return;
			}
			if (list_Contact.SelectedIndex == -1)//When completely unselected
				return;//In that case break and dont change anything

			//TODO Implement web contacts
			if (Values.Contacts[list_Contact.SelectedIndex].ConnectionType == 1) //If private Contact
			{
				typeOfConnection = 1;
				//ConnectToSocket(Values.Contacts[list_Contact.SelectedIndex]);
			}
			else if (Values.Contacts[list_Contact.SelectedIndex].ConnectionType == 2)
			{
				typeOfConnection = 2;
			}

			//-----------------------------

			UpdateLog();
			ReloadContactsList();
		}
		private void Btn_ContactsAdd_Click(object sender, EventArgs e)
		{
			NewContactForm ContactSelectionForm = new NewContactForm();
			ContactSelectionForm.Show();
		}

		private void btn_ContactsRemove_Click(object sender, EventArgs e)
		{
			if (list_Contact.SelectedIndex != -1)
			{
				if (Values.Contacts[list_Contact.SelectedIndex].Listener != null)
					Values.Contacts[list_Contact.SelectedIndex].Listener.Interrupt();
				if (Values.Contacts[list_Contact.SelectedIndex].stream != null)
					Values.Contacts[list_Contact.SelectedIndex].stream.Close();

				Values.Contacts.RemoveAt(list_Contact.SelectedIndex);
				ReloadContactsList();
			}
		}
		private void Btn_Image_Click(object sender, EventArgs e)
		{
			if (list_Contact.SelectedIndex != -1)
			{
				DialogResult result = openFileDialog1.ShowDialog();
				if (result == DialogResult.OK)
				{

					string Path = openFileDialog1.FileName; //Get image path
					Image image = Image.FromFile(Path);//Get image
					byte[] imageArray = ImageToByteArray(image);

					Values.Contacts[list_Contact.SelectedIndex].stream.Write(Values.Contacts[list_Contact.SelectedIndex].EncryptProvider.Encrypt(new byte[] { 0x0, 0x1, 0x2, 0x3, 0x4 }, false));//Send to reciever that we're sending an image

					Aes aes = Values.Contacts[list_Contact.SelectedIndex].aes;

					CryptoStream cryptoStream = new CryptoStream(Values.Contacts[list_Contact.SelectedIndex].stream, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write);
					Values.Contacts[list_Contact.SelectedIndex].stream.Write(Values.Contacts[list_Contact.SelectedIndex].EncryptProvider.Encrypt(BitConverter.GetBytes(imageArray.Length), false));

					//Send it and send end of image code
					cryptoStream.Write(imageArray, 0, imageArray.Length);
					cryptoStream.FlushFinalBlock();
					cryptoStream.Flush();
				}
			}
		}
		public byte[] ImageToByteArray(System.Drawing.Image imageIn)
		{
			using (var ms = new MemoryStream())
			{
				imageIn.Save(ms, imageIn.RawFormat);
				return ms.ToArray();
			}
		}

		private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
		{
			lbl_Scroller.Location = new Point(0, -vScrollBar1.Value);
			lbl_Scroller.Size = new Size(pnl_Messages.Width - vScrollBar1.Width, pnl_Messages.Height + vScrollBar1.Maximum);
		}
	}
}
