namespace YZU選課機器人
{
	partial class statusForm
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
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.successList = new System.Windows.Forms.ListBox();
			this.successListLabel = new System.Windows.Forms.Label();
			this.waitPickListLabel = new System.Windows.Forms.Label();
			this.waitPickList = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Interval = 50;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// successList
			// 
			this.successList.FormattingEnabled = true;
			this.successList.ItemHeight = 16;
			this.successList.Location = new System.Drawing.Point(416, 45);
			this.successList.Name = "successList";
			this.successList.Size = new System.Drawing.Size(364, 548);
			this.successList.TabIndex = 1;
			// 
			// successListLabel
			// 
			this.successListLabel.AutoSize = true;
			this.successListLabel.Location = new System.Drawing.Point(413, 26);
			this.successListLabel.Name = "successListLabel";
			this.successListLabel.Size = new System.Drawing.Size(88, 16);
			this.successListLabel.TabIndex = 3;
			this.successListLabel.Text = "已選到課程";
			// 
			// waitPickListLabel
			// 
			this.waitPickListLabel.AutoSize = true;
			this.waitPickListLabel.Location = new System.Drawing.Point(15, 25);
			this.waitPickListLabel.Name = "waitPickListLabel";
			this.waitPickListLabel.Size = new System.Drawing.Size(72, 16);
			this.waitPickListLabel.TabIndex = 5;
			this.waitPickListLabel.Text = "選課清單";
			// 
			// waitPickList
			// 
			this.waitPickList.FormattingEnabled = true;
			this.waitPickList.ItemHeight = 16;
			this.waitPickList.Location = new System.Drawing.Point(18, 45);
			this.waitPickList.Name = "waitPickList";
			this.waitPickList.Size = new System.Drawing.Size(364, 548);
			this.waitPickList.TabIndex = 4;
			// 
			// statusForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(799, 605);
			this.Controls.Add(this.waitPickListLabel);
			this.Controls.Add(this.waitPickList);
			this.Controls.Add(this.successListLabel);
			this.Controls.Add(this.successList);
			this.Font = new System.Drawing.Font("新細明體", 12F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "statusForm";
			this.Text = "搶課中";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.statusForm_FormClosed);
			this.Load += new System.EventHandler(this.statusForm_Load);
			this.Shown += new System.EventHandler(this.statusForm_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ListBox successList;
		private System.Windows.Forms.Label successListLabel;
		private System.Windows.Forms.Label waitPickListLabel;
		private System.Windows.Forms.ListBox waitPickList;
	}
}