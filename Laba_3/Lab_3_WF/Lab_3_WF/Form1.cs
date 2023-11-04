using Lab_3_WF.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List <Bitmap> memes = new List<Bitmap> { Resources.changed, Resources.changed_2, Resources.changed_3, Resources.changed_4, Resources.changed_5, Resources.changed_6 };

        private void Button_1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            btn.changed = memes[rnd.Next(0, 6)];
        }


    }
}
