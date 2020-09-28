using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkolProjekt
{
	public class WebManager
	{
		HttpClient client = new HttpClient();
		public Dictionary<string, int> UsernameToContact = new Dictionary<string, int>();

		public async Task SendMessage(string message, string reciever)
		{
			var values = new Dictionary<string, string>
			{
				{ "Token", Values.Token },
				{ "Message", message },
				{ "Reciever", reciever }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await client.PostAsync(Values.Server + "/SendMessage.php", content);

			string responseString = await response.Content.ReadAsStringAsync();

			var sendResponse = JsonSerializer.Deserialize<SendMessageResponse>(responseString);

			if (!UsernameToContact.ContainsKey(reciever))
			{
				Values.Contacts.Add(new Contact()
				{
					ConnectionType = 0,
					Username = reciever,
					Name = reciever
				});
				UsernameToContact.Add(reciever, Values.Contacts.Count - 1);
			}

			if (sendResponse.errorBool)
			{
				Values.Contacts[UsernameToContact[reciever]].Log.Text.Add(sendResponse.error);
			}
			else
			{

			}
		}
		public async Task AddMessageToLog(string messageId)
		{
			var values = new Dictionary<string, string>
			{
				{ "Token", Values.Token },
				{ "MessageId", messageId }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await client.PostAsync(Values.Server + "/GetMessage.php", content);

			string responseString = await response.Content.ReadAsStringAsync();

			var getMessageResp = JsonSerializer.Deserialize<getMessageResponse>(responseString);

			string otherName;
			if (getMessageResp.reciever == Values.ownUsername)
				otherName = getMessageResp.sender;
			else
				otherName = getMessageResp.reciever;

			if (!UsernameToContact.ContainsKey(otherName))
			{
				Values.Contacts.Add(new Contact()
				{
					Name = otherName,
					ConnectionType = 0,
					Username = otherName
				});
				UsernameToContact.Add(otherName, Values.Contacts.Count - 1);
			}

			if (getMessageResp.errorBool)
			{
				Values.Contacts[UsernameToContact[otherName]].Log.Text.Add(getMessageResp.error);
			}
			else
			{
				Values.Contacts[UsernameToContact[otherName]].Log.Text.Add(getMessageResp.sender + ": " + getMessageResp.message);// Bit of formating, innit?
			}

			Values.mainForm.inp_Text.Invoke((MethodInvoker)delegate//Threading stuff, makes it run across to main thread probably
			{
				Values.mainForm.UpdateLog();
				Values.mainForm.ReloadContactsList();
			});
		}
		public async Task LoadLog()
		{
			var values = new Dictionary<string, string>
			{
				{ "Token", Values.Token }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await client.PostAsync(Values.Server + "/GetLog.php", content);

			string responseString = await response.Content.ReadAsStringAsync();

			var getLogResp = JsonSerializer.Deserialize<getLogResponse>(responseString);


			if (getLogResp.errorBool)
			{
				//contact.Log.Text.Add(getLogResp.error);
			}
			else
			{
				if (getLogResp.text != "")
				{
					string[] messageIds = getLogResp.text.Split(',');
					foreach (string s in messageIds)
					{
						if (s != "")
							if (!Values.readMessages.Contains(int.Parse(s)))
							{
								await AddMessageToLog(s); //Await to make sure messages are in order
								Values.readMessages.Add(int.Parse(s));
							}
					}
				}
			}
		}
		public async void RefresherAsync()
		{
			while (true)
			{
				await Task.Delay(1000);
				await LoadLog();
			}
		}
	}
	public class SendMessageResponse
	{
		public string error { get; set; }
		public bool errorBool { get; set; }
		public string messageId { get; set; }
	}
	public class getMessageResponse
	{
		public bool errorBool { get; set; }
		public string error { get; set; }
		public string message { get; set; }
		public int read { get; set; }
		public string sender { get; set; }
		public string reciever { get; set; }
	}
	public class getLogResponse
	{
		public bool errorBool { get; set; }
		public string error { get; set; }
		public string text { get; set; }
		public int newMessages { get; set; }
	}
}
