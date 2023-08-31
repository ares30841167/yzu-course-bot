using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YZU選課機器人
{
    public partial class LoginForm : Form
	{
		HttpClient httpClient = new HttpClient();

		string APIKey = "___API_KEY___";
		string APIPassword = "___API_PASSWORD___";

		private class ComboboxItem
		{
			public ComboboxItem(string value, string text)
			{
				Value = value;
				Text = text;
			}
			public string Value
			{
				get;
				set;
			}

			public string Text
			{
				get;
				set;
			}
			public override string ToString()
			{
				return Text;
			}
		}
		public async Task< bool > GetSystemSmtr()
		{
			try
			{
				string requestUri = "https://isdna1.yzu.edu.tw/StdSelWebAPI/api/SelCos/Get_IndexPageSelSemester_DT";
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{
						"sLanguage",
						"TW"
					},
					{
						"sYear",
						"X"
					},
					{
						"sSmtr",
						"X"
					},
					{
						"sStage",
						"X"
					},
					{
						"sAPPFlag",
						"Y"
					}
				});
				HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUri, content);
				if (httpResponseMessage.Content == null)
				{
					systemSelSmtrList.Enabled = false;
					return false;
				}
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
					var data = JArray.Parse(result);
					systemSelSmtrList.Enabled = true;
					var count = 0;
					var selected = 0;
					foreach (var ss in data)
					{
						if (((JObject)ss)["YearSmtr"].ToString() == "00")
							selected = count;
						systemSelSmtrList.Items.Add(new ComboboxItem(((JObject)ss)["YearSmtr"].ToString(), ((JObject)ss)["SelMemo"].ToString()));
						count++;
					}
					systemSelSmtrList.SelectedIndex = selected;
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				systemSelSmtrList.Enabled = false;
				return false;
			}
		}
		public async Task<string> getRSAXMLKey()
		{
			try
			{
				string requestUri = "https://portalx.yzu.edu.tw/NewPortal/api/Auth/RSAkeybyAppID";
				string s = APIKey + ":" + APIPassword;
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(s)));
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{
						"AppID",
						Properties.Settings.Default.AppID
					}
				});
				HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUri, content);
				if (httpResponseMessage.Content == null)
				{
					return "";
				}
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					return httpResponseMessage.Content.ReadAsStringAsync().Result;
				}
				return "";
			}
			catch (Exception error)
			{
				Console.WriteLine(error.Message);
				return null;
			}
		}

		public async Task< bool > getToken(string account, string password)
		{
			string requestUri = "https://portalx.yzu.edu.tw/NewPortal/api/Auth/UserAccessToken";
			string s = APIKey + ":" + APIPassword;
			string parameter = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", parameter);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{
						"AppID",
						Properties.Settings.Default.AppID
					},
					{
						"account",
						account
					},
					{
						"password",
						password
					},
					{
						"BackUID",
						""
					},
					{
						"DeviceSerial",
						"unknown"
					}
				});
			using (HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUri, content))
			{
				string value3 = "[]";
				if (httpResponseMessage.Content != null && httpResponseMessage.IsSuccessStatusCode)
				{
					value3 = httpResponseMessage.Content.ReadAsStringAsync().Result;
				}
				dynamic accessTokenData = JValue.Parse(value3);
				if (accessTokenData != null)
				{
					if (accessTokenData.Result != "")
					{
						Properties.Settings.Default.token = accessTokenData.Token;
						return true;
					}
					else if (accessTokenData.Result == "解密失敗！")
					{
						Properties.Settings.Default.token = "";
						MessageBox.Show("程式錯誤(RSA)!");
						return false;
					}
					else
					{
						Properties.Settings.Default.token = "";
						MessageBox.Show("帳號或密碼錯誤!");
						return false;
					}
				}
				else
				{
					Properties.Settings.Default.token = "";
					return false;
				}
			}
		}
		public async Task< bool > CheckTokenVildate()
		{
			string result = "";
			try
			{
				string requestUri = "https://portal.yzu.edu.tw/AcademicWebAPI/api/Public/CheckValidToken";
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{
						"token",
						Properties.Settings.Default.token
					}
				});
				HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
				httpResponseMessage = httpClient.PostAsync(requestUri, content).Result;
				if (httpResponseMessage.Content == null)
				{
					return false;
				}
				if (!httpResponseMessage.IsSuccessStatusCode)
				{
					return false;
				}
				result = httpResponseMessage.Content.ReadAsStringAsync().Result;
				if(result == "1")
					return true;
				else
					return false;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public LoginForm()
		{
			InitializeComponent();
		}
		private async void LoginForm_Load(object sender, EventArgs e)
		{
			Properties.Settings.Default.year = "";
			Properties.Settings.Default.smtr = "";
			Properties.Settings.Default.stage = "";
			if (!await GetSystemSmtr())
				LoginInButton.Enabled = false;
			accoutTextBox.Text = Properties.Settings.Default.account;
			if (Properties.Settings.Default.token != "")
			{
				if (await CheckTokenVildate())
				{
					accoutTextBox.Enabled = false;
					passwordTextBox.Enabled = false;
					switchAccountButton.Enabled = true;
				}
				else
				{
					MessageBox.Show("Token已過期，請重新輸入密碼!");
					Properties.Settings.Default.token = "";
					accoutTextBox.Enabled = true;
					passwordTextBox.Enabled = true;
					switchAccountButton.Enabled = false;
				}
			}
			else
			{
				accoutTextBox.Enabled = true;
				passwordTextBox.Enabled = true;
				switchAccountButton.Enabled = false;
			}
		}
		private void accountTextBox_changed(object sender, EventArgs e)
		{
			Properties.Settings.Default.account = accoutTextBox.Text;
		}

		private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.Save();
		}

		private async void LoginInButton_Click(object sender, EventArgs e)
		{
			ComboboxItem item = systemSelSmtrList.Items[systemSelSmtrList.SelectedIndex] as ComboboxItem;
			if (Properties.Settings.Default.token != "")
			{
				if(item.Value == "00")
				{
					MessageBox.Show("請選擇學年期!");
					return;
				}
				if (!await CheckTokenVildate())
				{
					MessageBox.Show("Token已過期!");
					Properties.Settings.Default.token = "";
					accoutTextBox.Enabled = true;
					passwordTextBox.Enabled = true;
					switchAccountButton.Enabled = false;
					return;
				}
				else
				{
					//LoginSuccess
					loginSuccess();
				}
			}
			else {
				if (item.Value == "00")
				{
					MessageBox.Show("請選擇學年期!");
					return;
				}
				if (accoutTextBox.Text == "")
				{
					MessageBox.Show("帳號不能為空!");
					return;
				}
				if (passwordTextBox.Text == "")
				{
					MessageBox.Show("密碼不能為空!");
					return;
				}
				if (Properties.Settings.Default.RSAPublicKey == "")
				{
					dynamic json = JValue.Parse(await getRSAXMLKey());
					Properties.Settings.Default.XMLRSAkey = json.RSAkey;
				}
				RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
				RSA.FromXmlString(Properties.Settings.Default.XMLRSAkey);
				string account = Convert.ToBase64String(RSA.Encrypt(Encoding.UTF8.GetBytes(Properties.Settings.Default.account), false));
				string password = Convert.ToBase64String(RSA.Encrypt(Encoding.UTF8.GetBytes(passwordTextBox.Text.ToString()), false));
				if(!await getToken(account, password))
				{
					MessageBox.Show("取得Token失敗!");
					return;
				}
				switchAccountButton.Enabled = true;
				//LoginSuccess
				loginSuccess();
			}
		}

		private void switchAccountButton_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.token = "";
			accoutTextBox.Enabled = true;
			passwordTextBox.Enabled = true;
			switchAccountButton.Enabled = false;
		}
		private void loginSuccess()
		{
			ComboboxItem item = systemSelSmtrList.Items[systemSelSmtrList.SelectedIndex] as ComboboxItem;
			string[] words = item.Value.Split('-');
			Properties.Settings.Default.year = words[0];
			Properties.Settings.Default.smtr = words[1];
			Properties.Settings.Default.stage = words[2];
			appForm app = new appForm();
			app.Show();
			this.Hide();
		}
	}
}
