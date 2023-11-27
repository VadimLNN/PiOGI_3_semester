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
        public string Category { get; set; }
        public List<string> Tags { get; set; }
        public Mem() { }
        public Mem(string name, string img, string category)
        {
            Name = name;
            Img = img;
            Category = category;
        }

        public void add_tag(string tag)
        {
            Tags.Add(tag);
        }
        public List<string> get_tags()
        {
            return Tags;
        }
    }
}
