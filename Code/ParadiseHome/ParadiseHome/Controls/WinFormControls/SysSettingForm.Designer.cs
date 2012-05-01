namespace ParadiseHome.Controls.WinFormControls
{
    partial class SysSettingForm
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.colorCmbBooked = new ParadiseHome.Controls.WinFormControls.ColorComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.colorCmbSold = new ParadiseHome.Controls.WinFormControls.ColorComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorCmbDefault = new ParadiseHome.Controls.WinFormControls.ColorComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.colorCmbDefault);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.colorCmbBooked);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.colorCmbSold);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(276, 201);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "颜色";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // colorCmbBooked
            // 
            this.colorCmbBooked.Extended = false;
            this.colorCmbBooked.Location = new System.Drawing.Point(125, 61);
            this.colorCmbBooked.Name = "colorCmbBooked";
            this.colorCmbBooked.SelectedColor = System.Drawing.Color.Black;
            this.colorCmbBooked.Size = new System.Drawing.Size(121, 23);
            this.colorCmbBooked.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "已订福位背景色";
            // 
            // colorCmbSold
            // 
            this.colorCmbSold.Extended = true;
            this.colorCmbSold.Location = new System.Drawing.Point(125, 17);
            this.colorCmbSold.Name = "colorCmbSold";
            this.colorCmbSold.SelectedColor = System.Drawing.Color.Black;
            this.colorCmbSold.Size = new System.Drawing.Size(121, 23);
            this.colorCmbSold.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "已捐福位背景色";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(284, 227);
            this.tabControl1.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(74, 233);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(165, 233);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // colorCmbDefault
            // 
            this.colorCmbDefault.Extended = false;
            this.colorCmbDefault.Location = new System.Drawing.Point(123, 97);
            this.colorCmbDefault.Name = "colorCmbDefault";
            this.colorCmbDefault.SelectedColor = System.Drawing.Color.Black;
            this.colorCmbDefault.Size = new System.Drawing.Size(121, 23);
            this.colorCmbDefault.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "空福位背景色";
            // 
            // SysSettingForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControl1);
            this.Name = "SysSettingForm";
            this.Text = "系统设置";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private ColorComboBox colorCmbBooked;
        private System.Windows.Forms.Label label2;
        private ColorComboBox colorCmbSold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private ColorComboBox colorCmbDefault;
        private System.Windows.Forms.Label label3;

    }
}