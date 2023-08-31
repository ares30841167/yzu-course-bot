namespace YZU選課機器人
{
	partial class LoginForm
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.accoutTextBox = new System.Windows.Forms.TextBox();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.accountLabel = new System.Windows.Forms.Label();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.LoginInButton = new System.Windows.Forms.Button();
			this.switchAccountButton = new System.Windows.Forms.Button();
			this.systemSelSmtrList = new System.Windows.Forms.ComboBox();
			this.systemSelSmtrLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// accoutTextBox
			// 
			this.accoutTextBox.Location = new System.Drawing.Point(74, 63);
			this.accoutTextBox.Name = "accoutTextBox";
			this.accoutTextBox.Size = new System.Drawing.Size(151, 22);
			this.accoutTextBox.TabIndex = 0;
			this.accoutTextBox.TextChanged += new System.EventHandler(this.accountTextBox_changed);
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Location = new System.Drawing.Point(74, 100);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size(151, 22);
			this.passwordTextBox.TabIndex = 1;
			this.passwordTextBox.UseSystemPasswordChar = true;
			// 
			// accountLabel
			// 
			this.accountLabel.AutoSize = true;
			this.accountLabel.Font = new System.Drawing.Font("新細明體", 12F);
			this.accountLabel.Location = new System.Drawing.Point(32, 66);
			this.accountLabel.Name = "accountLabel";
			this.accountLabel.Size = new System.Drawing.Size(40, 16);
			this.accountLabel.TabIndex = 2;
			this.accountLabel.Text = "帳號";
			// 
			// passwordLabel
			// 
			this.passwordLabel.AutoSize = true;
			this.passwordLabel.Font = new System.Drawing.Font("新細明體", 12F);
			this.passwordLabel.Location = new System.Drawing.Point(32, 103);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(40, 16);
			this.passwordLabel.TabIndex = 3;
			this.passwordLabel.Text = "密碼";
			// 
			// LoginInButton
			// 
			this.LoginInButton.Location = new System.Drawing.Point(69, 140);
			this.LoginInButton.Name = "LoginInButton";
			this.LoginInButton.Size = new System.Drawing.Size(75, 23);
			this.LoginInButton.TabIndex = 5;
			this.LoginInButton.Text = "登入";
			this.LoginInButton.UseVisualStyleBackColor = true;
			this.LoginInButton.Click += new System.EventHandler(this.LoginInButton_Click);
			// 
			// switchAccountButton
			// 
			this.switchAccountButton.Location = new System.Drawing.Point(150, 140);
			this.switchAccountButton.Name = "switchAccountButton";
			this.switchAccountButton.Size = new System.Drawing.Size(75, 23);
			this.switchAccountButton.TabIndex = 6;
			this.switchAccountButton.Text = "切換帳戶";
			this.switchAccountButton.UseVisualStyleBackColor = true;
			this.switchAccountButton.Click += new System.EventHandler(this.switchAccountButton_Click);
			// 
			// systemSelSmtrList
			// 
			this.systemSelSmtrList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.systemSelSmtrList.FormattingEnabled = true;
			this.systemSelSmtrList.Location = new System.Drawing.Point(74, 30);
			this.systemSelSmtrList.Name = "systemSelSmtrList";
			this.systemSelSmtrList.Size = new System.Drawing.Size(151, 20);
			this.systemSelSmtrList.TabIndex = 7;
			// 
			// systemSelSmtrLabel
			// 
			this.systemSelSmtrLabel.AutoSize = true;
			this.systemSelSmtrLabel.Font = new System.Drawing.Font("新細明體", 12F);
			this.systemSelSmtrLabel.Location = new System.Drawing.Point(16, 32);
			this.systemSelSmtrLabel.Name = "systemSelSmtrLabel";
			this.systemSelSmtrLabel.Size = new System.Drawing.Size(56, 16);
			this.systemSelSmtrLabel.TabIndex = 8;
			this.systemSelSmtrLabel.Text = "學年期";
			// 
			// LoginForm
			// 
			this.AcceptButton = this.LoginInButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(264, 191);
			this.Controls.Add(this.systemSelSmtrLabel);
			this.Controls.Add(this.systemSelSmtrList);
			this.Controls.Add(this.switchAccountButton);
			this.Controls.Add(this.LoginInButton);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.accountLabel);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.accoutTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(280, 230);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(280, 230);
			this.Name = "LoginForm";
			this.Text = "YZU搶課機器人2020";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
			this.Load += new System.EventHandler(this.LoginForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox accoutTextBox;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Label accountLabel;
		private System.Windows.Forms.Label passwordLabel;
		private System.Windows.Forms.Button LoginInButton;
		private System.Windows.Forms.Button switchAccountButton;
		private System.Windows.Forms.ComboBox systemSelSmtrList;
		private System.Windows.Forms.Label systemSelSmtrLabel;
	}
}

