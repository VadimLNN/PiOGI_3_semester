﻿using System;
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
        public HoverButton() : base()
        {
            ForeColor = Color.White;
            Font = new Font("Microsoft YaHei UI",
             20.25F,
             FontStyle.Bold,
             GraphicsUnit.Point,
             0);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            // отрисовка прямоугольника
            pe.Graphics.FillRectangle(new SolidBrush(color), ClientRectangle);
            // отрисовка текста
            pe.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle);

        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            color = Color.Blue;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            color = Color.SkyBlue;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(new Rectangle(0, 0, Width - 1, Height - 1));
            Region = new Region(graphicsPath);
        }

    }
}
