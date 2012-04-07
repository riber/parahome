using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ControlLibrary
{
    public class BlueFaceButton:Button
    {
        private String m_BitMapDir;
        private Bitmap m_BitMap;
        public BlueFaceButton()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlueFaceButton));
            m_BitMapDir = "..\\..\\..\\file\\images\\btn.gif";
            this.BackgroundImage = Image.FromFile(m_BitMapDir);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Font = new System.Drawing.Font("ËÎÌו", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        }
        public String BitMapDir
        {
            get
            {
                return m_BitMapDir;
            }
            set
            {
                m_BitMapDir = value;
            }
        }
        
    }
}
