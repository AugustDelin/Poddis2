using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Rss
    {
        public String URL { get; set; }
        public String Namn { get; set; }
        public int Avsnitt { get; set; }

       public Kategori Kategori { get; set; }
        public bool IsDeleted { get; set; }

        public Rss()
        {
        }


        public Rss(string url, string namn, Kategori kategori, int avsnitt)
        {
            URL = url;
            Namn = namn;
            Kategori = kategori;
            Avsnitt = avsnitt;
        }
    }
}
