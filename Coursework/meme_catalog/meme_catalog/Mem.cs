using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meme_catalog
{
    internal class Mem
    {
        public string Name { get; set; }
        public string Img { get; set; }
        public string Tag { get; set; }
        public Mem() { }
        public Mem(string name, string img)
        {
            Name = name;
            Img = img;
            Tag = "";
        }
        public Mem(string name, string img, string tag)
        {
            Name = name;
            Img = img;
            Tag = tag;
        }

    }
}
