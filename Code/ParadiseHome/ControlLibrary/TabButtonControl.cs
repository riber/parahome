using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary
{
    /// <summary>
    /// Button状态
    /// </summary>
    public enum ButtonState
    {
        Default = 1,
        Select,
        LeftSelect,
        LeftNotSelect     
    }

    public partial class TabButtonControl : UserControl
    {
        // Button状态
        private ButtonState _state = ButtonState.Default;
        // 对应的下标
        private int _index = 0;

#region 属性
        /// <summary>
        /// Button状态
        /// </summary>
        public ButtonState State
        {
            set
            {
                _state = value;
            }
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// 对应的下标
        /// </summary>
        public int Index
        {
            set
            {
                _index = value;
            }
            get
            {
                return _index;
            }
        }

        /// <summary>
        /// 字符按钮
        /// </summary>
        public Button Button
        {
            get
            {
                return btnName;
            }
        }
#endregion

        /// <summary>
        /// 初始化显示
        /// </summary>
        public void InitShow()
        {
            switch (_state)
            {
                case ButtonState.Default:
                    this.palLeft.BackgroundImage = global::ControlLibrary.Properties.Resources.b21;
                    this.palMid.BackgroundImage = global::ControlLibrary.Properties.Resources.b8;
                    this.BackgroundImage = global::ControlLibrary.Properties.Resources.b8;
                    this.palRight.BackgroundImage = global::ControlLibrary.Properties.Resources.b41;
                    this.btnName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(217)))), ((int)(((byte)(251)))));
                    break;
                case ButtonState.LeftNotSelect:
                    this.palLeft.BackgroundImage = global::ControlLibrary.Properties.Resources.b111;
                    this.palMid.BackgroundImage = global::ControlLibrary.Properties.Resources.b8;
                    this.BackgroundImage = global::ControlLibrary.Properties.Resources.b8;
                    this.palRight.BackgroundImage = global::ControlLibrary.Properties.Resources.b41;
                    this.btnName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(217)))), ((int)(((byte)(251)))));
                    break;
                case ButtonState.LeftSelect:
                    this.palLeft.BackgroundImage = global::ControlLibrary.Properties.Resources.b3;
                    this.palMid.BackgroundImage = global::ControlLibrary.Properties.Resources.b8;
                    this.BackgroundImage = global::ControlLibrary.Properties.Resources.b8;
                    this.palRight.BackgroundImage = global::ControlLibrary.Properties.Resources.b41;
                    this.btnName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(217)))), ((int)(((byte)(251)))));
                    break;
                case ButtonState.Select:
                    this.palLeft.BackgroundImage = global::ControlLibrary.Properties.Resources.b5;
                    this.palMid.BackgroundImage = global::ControlLibrary.Properties.Resources.b7;
                    this.BackgroundImage = global::ControlLibrary.Properties.Resources.b7;
                    this.palRight.BackgroundImage = global::ControlLibrary.Properties.Resources.b6;
                    this.btnName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0x05)))), ((int)(((byte)(0x55)))), ((int)(((byte)(0x88)))));
                    break;
            }

            // 控制大小
            //this.Width = 18 + labName.Width + 34;
        }

        public TabButtonControl()
        {
            InitializeComponent();
            InitShow();
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, e);
        }
    }
}
