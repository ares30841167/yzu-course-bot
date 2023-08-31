using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace YZU選課機器人
{
    public partial class statusForm : Form
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		static extern bool AllocConsole();
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool FreeConsole();
		appForm app;
		Queue<appForm.searchListItem> pickList = new Queue<appForm.searchListItem>();
		List<appForm.searchListItem> courseList = new List<appForm.searchListItem>();
		public static bool pickCourse(string course_id, string course_term, string course_class)
		{
			try
			{
				using (HttpClient httpClient = new HttpClient())
				{
					string requestUri = "https://isdna1.yzu.edu.tw/StdSelWebAPI/api/SelCos/Get_AddCosCheck_Str";
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
					{
						{
							"sYear",
							Properties.Settings.Default.year
						},
						{
							"sSmtr",
							Properties.Settings.Default.smtr
						},
						{
							"sStage",
							Properties.Settings.Default.stage
						},
						{
							"sCos_id",
							course_id.Trim()
						},
						{
							"sCos_class",
							course_class.Trim()
						},
						{
							"sCosTerm_id",
							course_term.Trim()
						},
						{
							"sAcadType",
							"Y"
						},
						{
							"sIPAddr",
							"APP"
						},
						{
							"sAPI",
							"Y"
						},
						{
							"sBackDoor",
							"0"
						},
						{
							"sLanguage",
							"TW"
						},
						{
							"sToken",
							Properties.Settings.Default.token
						}
					});
					using (HttpResponseMessage httpResponseMessage = httpClient.PostAsync(requestUri, content).Result)
					{
						if (httpResponseMessage.Content == null)
						{
							Console.WriteLine("[" + DateTime.Now.ToString() + "] 加選" + course_id.Trim() + "," + course_class.Trim() + " 發生錯誤，稍後重試!");
							return false;
						}
						if (httpResponseMessage.IsSuccessStatusCode)
						{
							string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
							if (result != "A1" && result != "A2")
							{
								if (result == "X1")
								{
									Console.WriteLine("[" + DateTime.Now.ToString() + "] 加選" + course_id.Trim() + "," + course_class.Trim() + " 選課系統逾時，稍後重試!");
								}
								else if (result == "此課程本學期已選過！(r)")
								{
									Console.WriteLine("[" + DateTime.Now.ToString() + "] 加選" + course_id.Trim() + "," + course_class.Trim() + " 已經選過!");
									return true;
								}
								else
								{
									Console.WriteLine("[" + DateTime.Now.ToString() + "] 加選" + course_id.Trim() + "," + course_class.Trim() + " " + result);
								}
								return false;
							}
							if (result == "A1")
							{
								Console.WriteLine("[" + DateTime.Now.ToString() + "] 加選" + course_id.Trim() + "," + course_class.Trim() + " 完成加選。");
							}
							if (result == "A2")
							{
								Console.WriteLine("[" + DateTime.Now.ToString() + "] 加選" + course_id.Trim() + "," + course_class.Trim() + " 此課程已經加選,但需經[導師]同意,請於電腦選課期間確認[導師]是否上Portal審核,才算完成加選。");
							}
							return true;
						}
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("[" + DateTime.Now.ToString() + "] 加選" + course_id.Trim() + "," + course_class.Trim() + " 加選失敗(程式錯誤)!");
				Console.WriteLine("[" + DateTime.Now.ToString() + "] 錯誤訊息: " + ex.Message);
				return false;
			}

		}
		public statusForm()
		{
			InitializeComponent();
		}
		public void SetList(List<appForm.searchListItem> receive)
		{
			courseList = receive;
		}
		public void SetQueue(Queue<appForm.searchListItem> receive)
		{
			pickList = receive;
		}
		public void SetAppForm(appForm receive)
		{
			app = receive;
		}

		private void statusForm_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < courseList.Count; ++i)
			{
				appForm.searchListItem item = courseList[i] as appForm.searchListItem;
				waitPickList.Items.Add(item.courseID.Trim() + "," + item.course_class.Trim() + " " + item.CourseName);
			}
		}

		private void statusForm_Shown(object sender, EventArgs e)
		{
			AllocConsole();
			TextWriter writer = new StreamWriter(Console.OpenStandardOutput(), Encoding.Default) { AutoFlush = true };
			Console.SetOut(writer);
			timer1.Enabled = true;
			timer1.Start();
		}

		private async void statusForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			timer1.Stop();
			timer1.Enabled = false;
			pickList.Clear();
			courseList.Clear();
			FreeConsole();
			await app.GetCredit();
			await app.GetSelectedCourse();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if(pickList.Count == 0)
			{
				timer1.Stop();
				timer1.Enabled = false;
				DialogResult result = MessageBox.Show("已搶到所有選取的課程!", "確定?", MessageBoxButtons.OK);
				return;
			}
			appForm.searchListItem item = pickList.Peek();
			if (!pickCourse(item.courseID, item.term_id, item.course_class))
			{
				pickList.Enqueue(item);
			}
			else
			{
				successList.Items.Add(item.courseID.Trim() + "," + item.course_class.Trim() + " " + item.CourseName);
			}
			if(pickList.Count != 0)
				pickList.Dequeue();
		}
	}
}
