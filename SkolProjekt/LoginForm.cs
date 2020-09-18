using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Windows.Forms;

namespace SkolProjekt
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

		private async void button1_ClickAsync(object sender, EventArgs e)
		{
			HttpClient client = new HttpClient();
			Dictionary<string, string> toSend = new Dictionary<string, string>
			{
				{"Name", Inp_Username.Text},
				{"Password", Inp_Password.Text}
			};
			var response = await client.PostAsync("https://" + Inp_Domain.Text + "/Chat/Connect.php", new FormUrlEncodedContent(toSend));
			if (!response.IsSuccessStatusCode)
			{
				Erp_ErrorProvider.SetError(Btn_Login, response.ReasonPhrase);
				return;
			}
			string json = await response.Content.ReadAsStringAsync();
			LoginResponse loginResponse = JsonSerializer.Deserialize<LoginResponse>(json);
			if (loginResponse.errorBool)
			{
				Erp_ErrorProvider.SetError(Btn_Login, loginResponse.error);
			}
			else
			{
				Thread t = new Thread(Values.webManager.RefresherAsync);
				t.IsBackground = true;
				Values.ownUsername = Inp_Username.Text;
				Values.Token = loginResponse.token;
				Values.Server = "https://" + Inp_Domain.Text + "/Chat";
				await Values.webManager.LoadLog();
				t.Start();
				this.Close();
			}
		}

		private void LoginForm_Load(object sender, EventArgs e)
		{

		}

		private async void Btn_Register_Click(object sender, EventArgs e)
		{
			HttpClient client = new HttpClient();
			Dictionary<string, string> toSend = new Dictionary<string, string>
			{
				{"Name", Inp_Username.Text},
				{"Password", Inp_Password.Text}
			};
			var response = await client.PostAsync("https://" + Inp_Domain.Text + "/Chat/Register.php", new FormUrlEncodedContent(toSend));
			string json = await response.Content.ReadAsStringAsync();
			LoginResponse loginResponse = JsonSerializer.Deserialize<LoginResponse>(json);
			if (loginResponse.errorBool)
			{
				Erp_ErrorProvider.SetError(Btn_Login, loginResponse.error);
			}
			else
			{
				Values.Token = loginResponse.token;
				Values.Server = "https://" + Inp_Domain.Text + "/Chat";
				await Values.webManager.LoadLog();
				Thread t = new Thread(Values.webManager.RefresherAsync);
				t.IsBackground = true;
				t.Start();
				Values.ownUsername = Inp_Username.Text;
				this.Close();
			}
		}
	}
	class LoginResponse
	{
		public string token { get; set; }
		public bool errorBool { get; set; }
		public string error { get; set; }
	}
}
