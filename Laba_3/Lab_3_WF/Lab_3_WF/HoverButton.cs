using Lab_3_WF.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3_WF
{
    partial class HoverButton : Button
    {
        private Color color = Color.SkyBlue;
        private Image basik;
        public Image changed;
        private Image current;
        public HoverButton() : base()
        {
            ForeColor = Color.White;

            Font = new Font("Microsoft YaHei UI",
                             20.25F,
                             FontStyle.Bold,
                             GraphicsUnit.Point,
                             0);

           
            basik = new Bitmap(Resources.basic);
            changed = new Bitmap(Resources.changed);
            current = basik;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            
            this.Image = current; 
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            current = changed;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            current = basik;
        }
    }
}
