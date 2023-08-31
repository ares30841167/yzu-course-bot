using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YZU選課機器人
{
    public partial class appForm : Form
	{
		static readonly HttpClient httpClient = new HttpClient();
		public class searchListItem
		{
			public searchListItem(string value1, string value2, string value3, string value6, string text)
			{
				courseID = value1;
				course_class = value2;
				term_id = value3;
				CourseName = value6;
				Text = text;
			}
			public string courseID
			{
				get;
				set;
			}
			public string course_class
			{
				get;
				set;
			}
			public string term_id
			{
				get;
				set;
			}
			public string CourseName
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
		private class haveSelectedListItem
		{
			public haveSelectedListItem(string value1, string value2, string value3, string value4, string value5, string value6, string text)
			{
				courseID = value1;
				course_class = value2;
				term_id = value3;
				selAD = value4;
				TutorCheck = value5;
				CourseName = value6;
				Text = text;
			}
			public string courseID
			{
				get;
				set;
			}
			public string course_class
			{
				get;
				set;
			}
			public string term_id
			{
				get;
				set;
			}
			public string selAD
			{
				get;
				set;
			}
			public string TutorCheck
			{
				get;
				set;
			}
			public string CourseName
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
		public async Task<bool> GetCredit()
		{
			try
			{
				string requestUri = "https://isdna1.yzu.edu.tw/StdSelWebAPI/api/SelCos/Get_SelCosInfoData_DT";
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
						"sLanguage",
						"TW"
					},
					{
						"sToken",
						Properties.Settings.Default.token
					}
				});
				HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUri, content);
				if (httpResponseMessage.Content == null)
				{
					showMaxLabel.Text = "N/A";
					showMinLabel.Text = "N/A";
					showCurrentLabel.Text = "N/A";
					return false;
				}
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string result = "[]";
					result = httpResponseMessage.Content.ReadAsStringAsync().Result;
					dynamic data = JValue.Parse(JArray.Parse(result)[0].ToString());
					showMaxLabel.Text = data.CMax;
					showMinLabel.Text = data.CMin;
					showCurrentLabel.Text = data.SelCredit;
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				showMaxLabel.Text = "N/A";
				showMinLabel.Text = "N/A";
				showCurrentLabel.Text = "N/A";
				return false;
			}
		}
		public async Task<bool> GetSelectedCourse()
		{
			try
			{
				string requestUri = "https://isdna1.yzu.edu.tw/StdSelWebAPI/api/SelCos/Get_SelCosListDataWin_DT";
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{
						"sLanguage",
						"TW"
					},
					{
						"sYear",
						Properties.Settings.Default.year
					},
					{
						"sSmtr",
						Properties.Settings.Default.smtr
					},
					{
						"sToken",
						Properties.Settings.Default.token
					}
				});
				HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUri, content);
				HaveSelectedList.Items.Clear();
				if (httpResponseMessage.Content == null)
				{
					HaveSelectedList.Items.Add("取得資料失敗!");
					return false;
				}
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
					var data = JArray.Parse(result);
					foreach (var ss in data)
					{
						HaveSelectedList.Items.Add(new haveSelectedListItem(((JObject)ss)["cos_id"].ToString(), ((JObject)ss)["cos_class"].ToString(), ((JObject)ss)["term_id"].ToString(), ((JObject)ss)["selAD"].ToString(), ((JObject)ss)["TutorCheck"].ToString(), ((JObject)ss)["cos_name"].ToString(), ((JObject)ss)["cos_id"].ToString().Trim() + "," + ((JObject)ss)["cos_class"].ToString().Trim() + " " + ((JObject)ss)["cos_name"].ToString() + "/" + ((JObject)ss)["teacher_name"].ToString()));
					}
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				HaveSelectedList.Items.Add("取得資料失敗!");
				return false;
			}
		}
		public async Task<bool> searchCourse(string dept, string degree)
		{
			try
			{
				string requestUri = "https://isdna1.yzu.edu.tw/StdSelWebAPI/api/SelCos/Get_CosListDept_DT";
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{
						"sLanguage",
						"TW"
					},
					{
						"sYear",
						Properties.Settings.Default.year
					},
					{
						"sSmtr",
						Properties.Settings.Default.smtr
					},
					{
						"sDeptNo",
						dept
					},
					{
						"sDegree",
						degree
					}
				});
				HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUri, content);
				searchResultList.Items.Clear();
				if (httpResponseMessage.Content == null)
				{
					searchResultList.Items.Add("取得資料失敗!");
					return false;
				}
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
					var data = JArray.Parse(result);
					foreach (var ss in data)
					{
						searchResultList.Items.Add(new searchListItem(((JObject)ss)["cos_id"].ToString(), ((JObject)ss)["cos_class"].ToString(), ((JObject)ss)["term_id"].ToString(), ((JObject)ss)["cos_name"].ToString(), ((JObject)ss)["cos_id"].ToString().Trim() + "," + ((JObject)ss)["cos_class"].ToString().Trim() + " " + ((JObject)ss)["cos_name"].ToString() + "/" + ((JObject)ss)["teacher_name"].ToString()));
					}
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				searchResultList.Items.Add("取得資料失敗!");
				return false;
			}
		}
		public async Task<bool> GetCourseDetail(string course_id, string course_term, string course_class)
		{
			try
			{
				string requestUri = "https://isdna1.yzu.edu.tw/StdSelWebAPI/api/SelCos/Get_CosInfo_Com_DT";
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{
						"sLanguage",
						"TW"
					},
					{
						"sYear",
						Properties.Settings.Default.year
					},
					{
						"sSmtr",
						Properties.Settings.Default.smtr
					},
					{
						"sCos_id",
						course_id
					},
					{
						"sCos_class",
						course_class
					},
					{
						"sCosTerm_id",
						course_term
					}
				});
				HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUri, content);
				HaveSelectedList.Items.Clear();
				if (httpResponseMessage.Content == null)
				{
					MessageBox.Show("課程資料取得失敗!");
					return false;
				}
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
					var data = JArray.Parse(result);
					foreach (var ss in data)
					{
						
					}
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				MessageBox.Show("課程資料取得失敗!");
				return false;
			}
		}
		public async Task<bool> withdrawCourse(string course_id, string course_term, string course_class, string selAD, string TutorCheck)
		{
			try
			{
				string requestUri = "https://isdna1.yzu.edu.tw/StdSelWebAPI/api/SelCos/Get_DelCosCheck_Str";
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
						"sTutorChk",
						TutorCheck.Trim()
					},
					{
						"sSelAD",
						selAD.Trim()
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
				HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUri, content);
				HaveSelectedList.Items.Clear();
				if (httpResponseMessage.Content == null)
				{
					MessageBox.Show("退選失敗!");
					return false;
				}
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
					if (result != "D1" && result != "D2" && result != "D3")
					{
						if (result == "X1")
						{
							MessageBox.Show("逾時，請重新再按一次!");
						}
						else
						{
							MessageBox.Show(result);
						}
						return false;
					}
					if (result == "D1")
					{
						MessageBox.Show("完成退選。");
					}
					if (result == "D2")
					{
						MessageBox.Show("課程已經退選，但還需指導教授同意之後，才算完成退選！(c)<br>");
					}
					if (result == "D3")
					{
						MessageBox.Show("此課程已經退選，但需經[導師]同意,請於電腦選課期間確認[導師]是否上Portal審核，才算完成退選。(c)<br>");
					}
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				MessageBox.Show("退選失敗!(程式錯誤)");
				return false;
			}
		}
		public async Task<bool> GetDeptList()
		{
			try
			{
				string requestUri = "https://isdna1.yzu.edu.tw/StdSelWebAPI/api/SelCos/Get_DeptList_DT";
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
				});
				HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUri, content);
				if (httpResponseMessage.Content == null)
				{
					DeptList.Enabled = false;
					return false;
				}
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
					var data = JArray.Parse(result);
					DeptList.Enabled = true;
					foreach (var ss in data)
					{
						DeptList.Items.Add(new ComboboxItem(((JObject)ss)["dept_no"].ToString(), ((JObject)ss)["dept_name_s"].ToString()));
					}
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				DeptList.Enabled = false;
				return false;
			}
		}
		public async Task<bool> GetDegreeList()
		{
			try
			{
				string requestUri = "https://isdna1.yzu.edu.tw/StdSelWebAPI/api/SelCos/Get_DegreeList_Global_DT";
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{
					"sLanguage",
					"TW"
					}
				});
				HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUri, content);
				if (httpResponseMessage.Content == null)
				{
					DegreeList.Enabled = false;
					return false;
				}
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
					var data = JArray.Parse(result);
					DegreeList.Enabled = true;
					foreach (var ss in data)
					{
						DegreeList.Items.Add(new ComboboxItem(((JObject)ss)["DValue"].ToString(), ((JObject)ss)["DText"].ToString()));
					}
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				DegreeList.Enabled = false;
				return false;
			}
		}
		public appForm()
		{
			InitializeComponent();
		}

		private void appForm_Load(object sender, EventArgs e)
		{

		}
		private async void appForm_Shown(object sender, EventArgs e)
		{
			await GetCredit();
			await GetDeptList();
			await GetDegreeList();
			await GetSelectedCourse();
		}

		private void appForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private async void HaveSelectedDetail_Click(object sender, EventArgs e)
		{
			haveSelectedListItem item = HaveSelectedList.Items[HaveSelectedList.SelectedIndex] as haveSelectedListItem;
			await GetCourseDetail(item.courseID, item.term_id, item.course_class);
		}

		private async void withdraw_Click(object sender, EventArgs e)
		{
			haveSelectedListItem item = HaveSelectedList.Items[HaveSelectedList.SelectedIndex] as haveSelectedListItem;
			DialogResult result = MessageBox.Show("確定要退選"+ item.courseID + "," + item.course_class + item.CourseName + "?", "確定?", MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes)
			{
				await withdrawCourse(item.courseID, item.term_id, item.course_class, item.selAD, item.TutorCheck);
				await GetSelectedCourse();
				await GetCredit();
			}
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			searchListItem item = searchResultList.Items[searchResultList.SelectedIndex] as searchListItem;
			pickCourseList.Items.Add(item);
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			pickCourseList.Items.Remove(pickCourseList.SelectedItem);
		}

		private void startButton_Click(object sender, EventArgs e)
		{
			if (pickCourseList.Items.Count != 0)
			{
				Queue<searchListItem> pickList = new Queue<searchListItem>();
				List<searchListItem> courseList = new List<searchListItem>();
				for (int i = 0; i < pickCourseList.Items.Count; ++i)
				{
					searchListItem item = pickCourseList.Items[i] as searchListItem;
					pickList.Enqueue(item);
					courseList.Add(item);
				}
				statusForm status = new statusForm();
				status.SetQueue(pickList);
				status.SetList(courseList);
				status.SetAppForm(this);
				status.Show();
			}
			else
			{
				MessageBox.Show("請將課程加入搶課清單!");
			}
		}

		private async void DeptList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (DeptList.SelectedIndex != -1 && DegreeList.SelectedIndex != -1)
			{
				ComboboxItem item1 = DeptList.Items[DeptList.SelectedIndex] as ComboboxItem;
				ComboboxItem item2 = DegreeList.Items[DegreeList.SelectedIndex] as ComboboxItem;
				await searchCourse(item1.Value.ToString(), item2.Value.ToString());
			}
		}

		private async void DegreeList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (DeptList.SelectedIndex != -1 && DegreeList.SelectedIndex != -1)
			{
				ComboboxItem item1 = DeptList.Items[DeptList.SelectedIndex] as ComboboxItem;
				ComboboxItem item2 = DegreeList.Items[DegreeList.SelectedIndex] as ComboboxItem;
				await searchCourse(item1.Value.ToString(), item2.Value.ToString());
			}
		}
	}
}
