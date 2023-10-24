using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Kategori
    {
        public string Namn { get; set; }

        internal Kategori()
        {

        }
        public Kategori(string namn)
        {
            Namn = namn;
        }
    }
}
