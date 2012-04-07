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
    /// Button״̬
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
        // Button״̬
        private ButtonState _state = ButtonState.Default;
        // ��Ӧ���±�
        private int _index = 0;

#region ����
        /// <summary>
        /// Button״̬
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
        /// ��Ӧ���±�
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
        /// �ַ���ť
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
        /// ��ʼ����ʾ
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

            // ���ƴ�С
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
