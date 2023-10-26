using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using Models;

namespace DataLayer.Repositories
{
    public class KategoriRepository : IRepository<string>
    {
        private string kategoriFil = "kategorier.txt";
        private List<string> _kategorier;

        public KategoriRepository()
        {
            LaddaKategorier();
        }

        public void Add(string kategoriNamn)
        {
            _kategorier.Add(kategoriNamn);
            SparaKategorier();
        }

        public List<string> GetAll()
        {
            return _kategorier;
        }

        public List<string> GetAll(int maxItems)
        {
            return _kategorier.Take(maxItems).ToList();
        }

        public void Update(string nyttNamn, string gammaltNamn)
        {
            int index = _kategorier.FindIndex(k => k == gammaltNamn);
            if (index >= 0)
            {
                _kategorier[index] = nyttNamn;
                SparaKategorier();
            }
        }

        public void Delete(string kategoriNamn)
        {
            _kategorier.Remove(kategoriNamn);
            SparaKategorier();
        }

        public string GetByIndex(int index)
        {
            if (index >= 0 && index < _kategorier.Count)
            {
                return _kategorier[index];
            }
            else
            {
                return null;
            }
        }

        private void LaddaKategorier()
        {
            if (File.Exists(kategoriFil))
            {
                _kategorier = File.ReadLines(kategoriFil).ToList();
            }
            else
            {
                _kategorier = new List<string>();
            }
        }

        public void SparaKategorier()
        {
            File.WriteAllLines(kategoriFil, _kategorier);
        }

        public void Create(string kategori)
        {

        }
    }
}
