namespace YZU選課機器人
{
	partial class appForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.creditMaxLabel = new System.Windows.Forms.Label();
			this.showMaxLabel = new System.Windows.Forms.Label();
			this.creditMinLabel = new System.Windows.Forms.Label();
			this.showMinLabel = new System.Windows.Forms.Label();
			this.currentCreditLabel = new System.Windows.Forms.Label();
			this.showCurrentLabel = new System.Windows.Forms.Label();
			this.HaveSelectedList = new System.Windows.Forms.ListBox();
			this.HaveSelectedLabel = new System.Windows.Forms.Label();
			this.withdraw = new System.Windows.Forms.Button();
			this.DeptList = new System.Windows.Forms.ComboBox();
			this.DegreeList = new System.Windows.Forms.ComboBox();
			this.searchResultLabel = new System.Windows.Forms.Label();
			this.searchResultList = new System.Windows.Forms.ListBox();
			this.DeptLabel = new System.Windows.Forms.Label();
			this.DegreeLabel = new System.Windows.Forms.Label();
			this.pickCourseListLabel = new System.Windows.Forms.Label();
			this.pickCourseList = new System.Windows.Forms.ListBox();
			this.startButton = new System.Windows.Forms.Button();
			this.AddButton = new System.Windows.Forms.Button();
			this.RemoveButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// creditMaxLabel
			// 
			this.creditMaxLabel.AutoSize = true;
			this.creditMaxLabel.Location = new System.Drawing.Point(13, 13);
			this.creditMaxLabel.Name = "creditMaxLabel";
			this.creditMaxLabel.Size = new System.Drawing.Size(72, 16);
			this.creditMaxLabel.TabIndex = 0;
			this.creditMaxLabel.Text = "學分上限";
			// 
			// showMaxLabel
			// 
			this.showMaxLabel.AutoSize = true;
			this.showMaxLabel.Location = new System.Drawing.Point(82, 13);
			this.showMaxLabel.Name = "showMaxLabel";
			this.showMaxLabel.Size = new System.Drawing.Size(46, 16);
			this.showMaxLabel.TabIndex = 1;
			this.showMaxLabel.Text = "label2";
			// 
			// creditMinLabel
			// 
			this.creditMinLabel.AutoSize = true;
			this.creditMinLabel.Location = new System.Drawing.Point(129, 13);
			this.creditMinLabel.Name = "creditMinLabel";
			this.creditMinLabel.Size = new System.Drawing.Size(72, 16);
			this.creditMinLabel.TabIndex = 2;
			this.creditMinLabel.Text = "學分下限";
			// 
			// showMinLabel
			// 
			this.showMinLabel.AutoSize = true;
			this.showMinLabel.Location = new System.Drawing.Point(198, 13);
			this.showMinLabel.Name = "showMinLabel";
			this.showMinLabel.Size = new System.Drawing.Size(46, 16);
			this.showMinLabel.TabIndex = 3;
			this.showMinLabel.Text = "label4";
			// 
			// currentCreditLabel
			// 
			this.currentCreditLabel.AutoSize = true;
			this.currentCreditLabel.Location = new System.Drawing.Point(243, 13);
			this.currentCreditLabel.Name = "currentCreditLabel";
			this.currentCreditLabel.Size = new System.Drawing.Size(72, 16);
			this.currentCreditLabel.TabIndex = 4;
			this.currentCreditLabel.Text = "已選學分";
			// 
			// showCurrentLabel
			// 
			this.showCurrentLabel.AutoSize = true;
			this.showCurrentLabel.Location = new System.Drawing.Point(313, 13);
			this.showCurrentLabel.Name = "showCurrentLabel";
			this.showCurrentLabel.Size = new System.Drawing.Size(46, 16);
			this.showCurrentLabel.TabIndex = 5;
			this.showCurrentLabel.Text = "label6";
			// 
			// HaveSelectedList
			// 
			this.HaveSelectedList.FormattingEnabled = true;
			this.HaveSelectedList.ItemHeight = 16;
			this.HaveSelectedList.Location = new System.Drawing.Point(16, 83);
			this.HaveSelectedList.Name = "HaveSelectedList";
			this.HaveSelectedList.Size = new System.Drawing.Size(343, 532);
			this.HaveSelectedList.TabIndex = 6;
			// 
			// HaveSelectedLabel
			// 
			this.HaveSelectedLabel.AutoSize = true;
			this.HaveSelectedLabel.Location = new System.Drawing.Point(13, 64);
			this.HaveSelectedLabel.Name = "HaveSelectedLabel";
			this.HaveSelectedLabel.Size = new System.Drawing.Size(72, 16);
			this.HaveSelectedLabel.TabIndex = 7;
			this.HaveSelectedLabel.Text = "已選課程";
			// 
			// withdraw
			// 
			this.withdraw.Location = new System.Drawing.Point(284, 621);
			this.withdraw.Name = "withdraw";
			this.withdraw.Size = new System.Drawing.Size(75, 32);
			this.withdraw.TabIndex = 9;
			this.withdraw.Text = "退選";
			this.withdraw.UseVisualStyleBackColor = true;
			this.withdraw.Click += new System.EventHandler(this.withdraw_Click);
			// 
			// DeptList
			// 
			this.DeptList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DeptList.FormattingEnabled = true;
			this.DeptList.Location = new System.Drawing.Point(501, 5);
			this.DeptList.Name = "DeptList";
			this.DeptList.Size = new System.Drawing.Size(226, 24);
			this.DeptList.TabIndex = 10;
			this.DeptList.SelectedIndexChanged += new System.EventHandler(this.DeptList_SelectedIndexChanged);
			// 
			// DegreeList
			// 
			this.DegreeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DegreeList.FormattingEnabled = true;
			this.DegreeList.Location = new System.Drawing.Point(501, 37);
			this.DegreeList.Name = "DegreeList";
			this.DegreeList.Size = new System.Drawing.Size(226, 24);
			this.DegreeList.TabIndex = 11;
			this.DegreeList.SelectedIndexChanged += new System.EventHandler(this.DegreeList_SelectedIndexChanged);
			// 
			// searchResultLabel
			// 
			this.searchResultLabel.AutoSize = true;
			this.searchResultLabel.Location = new System.Drawing.Point(423, 64);
			this.searchResultLabel.Name = "searchResultLabel";
			this.searchResultLabel.Size = new System.Drawing.Size(72, 16);
			this.searchResultLabel.TabIndex = 13;
			this.searchResultLabel.Text = "搜尋結果";
			// 
			// searchResultList
			// 
			this.searchResultList.FormattingEnabled = true;
			this.searchResultList.ItemHeight = 16;
			this.searchResultList.Location = new System.Drawing.Point(426, 83);
			this.searchResultList.Name = "searchResultList";
			this.searchResultList.Size = new System.Drawing.Size(343, 532);
			this.searchResultList.TabIndex = 12;
			// 
			// DeptLabel
			// 
			this.DeptLabel.AutoSize = true;
			this.DeptLabel.Location = new System.Drawing.Point(455, 9);
			this.DeptLabel.Name = "DeptLabel";
			this.DeptLabel.Size = new System.Drawing.Size(40, 16);
			this.DeptLabel.TabIndex = 14;
			this.DeptLabel.Text = "系所";
			// 
			// DegreeLabel
			// 
			this.DegreeLabel.AutoSize = true;
			this.DegreeLabel.Location = new System.Drawing.Point(455, 40);
			this.DegreeLabel.Name = "DegreeLabel";
			this.DegreeLabel.Size = new System.Drawing.Size(40, 16);
			this.DegreeLabel.TabIndex = 15;
			this.DegreeLabel.Text = "年級";
			// 
			// pickCourseListLabel
			// 
			this.pickCourseListLabel.AutoSize = true;
			this.pickCourseListLabel.Location = new System.Drawing.Point(881, 64);
			this.pickCourseListLabel.Name = "pickCourseListLabel";
			this.pickCourseListLabel.Size = new System.Drawing.Size(72, 16);
			this.pickCourseListLabel.TabIndex = 18;
			this.pickCourseListLabel.Text = "搶課清單";
			// 
			// pickCourseList
			// 
			this.pickCourseList.FormattingEnabled = true;
			this.pickCourseList.ItemHeight = 16;
			this.pickCourseList.Location = new System.Drawing.Point(884, 83);
			this.pickCourseList.Name = "pickCourseList";
			this.pickCourseList.Size = new System.Drawing.Size(343, 532);
			this.pickCourseList.TabIndex = 17;
			// 
			// startButton
			// 
			this.startButton.Location = new System.Drawing.Point(1139, 621);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(88, 32);
			this.startButton.TabIndex = 19;
			this.startButton.Text = "開始搶課";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.startButton_Click);
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(791, 289);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(75, 32);
			this.AddButton.TabIndex = 20;
			this.AddButton.Text = ">>";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// RemoveButton
			// 
			this.RemoveButton.Location = new System.Drawing.Point(791, 327);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new System.Drawing.Size(75, 32);
			this.RemoveButton.TabIndex = 21;
			this.RemoveButton.Text = "<<";
			this.RemoveButton.UseVisualStyleBackColor = true;
			this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
			// 
			// appForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1247, 688);
			this.Controls.Add(this.RemoveButton);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.pickCourseListLabel);
			this.Controls.Add(this.pickCourseList);
			this.Controls.Add(this.DegreeLabel);
			this.Controls.Add(this.DeptLabel);
			this.Controls.Add(this.searchResultLabel);
			this.Controls.Add(this.searchResultList);
			this.Controls.Add(this.DegreeList);
			this.Controls.Add(this.DeptList);
			this.Controls.Add(this.withdraw);
			this.Controls.Add(this.HaveSelectedLabel);
			this.Controls.Add(this.HaveSelectedList);
			this.Controls.Add(this.showCurrentLabel);
			this.Controls.Add(this.currentCreditLabel);
			this.Controls.Add(this.showMinLabel);
			this.Controls.Add(this.creditMinLabel);
			this.Controls.Add(this.showMaxLabel);
			this.Controls.Add(this.creditMaxLabel);
			this.Font = new System.Drawing.Font("新細明體", 12F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "appForm";
			this.Text = "YZU搶課機器人2020";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.appForm_FormClosed);
			this.Load += new System.EventHandler(this.appForm_Load);
			this.Shown += new System.EventHandler(this.appForm_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label creditMaxLabel;
		private System.Windows.Forms.Label showMaxLabel;
		private System.Windows.Forms.Label creditMinLabel;
		private System.Windows.Forms.Label showMinLabel;
		private System.Windows.Forms.Label currentCreditLabel;
		private System.Windows.Forms.Label showCurrentLabel;
		private System.Windows.Forms.ListBox HaveSelectedList;
		private System.Windows.Forms.Label HaveSelectedLabel;
		private System.Windows.Forms.Button withdraw;
		private System.Windows.Forms.ComboBox DeptList;
		private System.Windows.Forms.ComboBox DegreeList;
		private System.Windows.Forms.Label searchResultLabel;
		private System.Windows.Forms.ListBox searchResultList;
		private System.Windows.Forms.Label DeptLabel;
		private System.Windows.Forms.Label DegreeLabel;
		private System.Windows.Forms.Label pickCourseListLabel;
		private System.Windows.Forms.ListBox pickCourseList;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.Button RemoveButton;
	}
}