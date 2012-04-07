namespace ControlLibrary
{
    partial class TabButtonControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.palMid = new System.Windows.Forms.Panel();
            this.btnName = new System.Windows.Forms.Button();
            this.palRight = new System.Windows.Forms.Panel();
            this.palLeft = new System.Windows.Forms.Panel();
            this.palMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // palMid
            // 
            this.palMid.BackgroundImage = global::ControlLibrary.Properties.Resources.b7;
            this.palMid.Controls.Add(this.btnName);
            this.palMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palMid.Location = new System.Drawing.Point(8, 0);
            this.palMid.Name = "palMid";
            this.palMid.Size = new System.Drawing.Size(118, 24);
            this.palMid.TabIndex = 2;
            // 
            // btnName
            // 
            this.btnName.BackColor = System.Drawing.Color.Transparent;
            this.btnName.FlatAppearance.BorderSize = 0;
            this.btnName.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnName.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(217)))), ((int)(((byte)(251)))));
            this.btnName.Location = new System.Drawing.Point(-16, -13);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(158, 50);
            this.btnName.TabIndex = 1;
            this.btnName.Text = "测试";
            this.btnName.UseVisualStyleBackColor = false;
            this.btnName.Click += new System.EventHandler(this.btnName_Click);
            // 
            // palRight
            // 
            this.palRight.BackColor = System.Drawing.Color.Transparent;
            this.palRight.BackgroundImage = global::ControlLibrary.Properties.Resources.b6;
            this.palRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.palRight.Location = new System.Drawing.Point(126, 0);
            this.palRight.Name = "palRight";
            this.palRight.Size = new System.Drawing.Size(24, 24);
            this.palRight.TabIndex = 1;
            // 
            // palLeft
            // 
            this.palLeft.BackColor = System.Drawing.Color.Transparent;
            this.palLeft.BackgroundImage = global::ControlLibrary.Properties.Resources.b111;
            this.palLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.palLeft.Location = new System.Drawing.Point(0, 0);
            this.palLeft.Name = "palLeft";
            this.palLeft.Size = new System.Drawing.Size(8, 24);
            this.palLeft.TabIndex = 0;
            // 
            // TabButtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::ControlLibrary.Properties.Resources.b5;
            this.Controls.Add(this.palMid);
            this.Controls.Add(this.palRight);
            this.Controls.Add(this.palLeft);
            this.Name = "TabButtonControl";
            this.Size = new System.Drawing.Size(150, 24);
            this.palMid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel palLeft;
        private System.Windows.Forms.Panel palRight;
        private System.Windows.Forms.Panel palMid;
        private System.Windows.Forms.Button btnName;
    }
}
