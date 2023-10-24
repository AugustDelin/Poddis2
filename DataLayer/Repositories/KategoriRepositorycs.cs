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
            _kategorier.Add(kategoriNamn); // Lägg till i samlingen
            SparaKategorier(); // Spara till filen
        }

        public List<string> GetAll()
        {
            return _kategorier; // Returnera samlingen
        }

        public void Update(string nyttNamn, string gammaltNamn)
        {
            int index = _kategorier.FindIndex(k => k == gammaltNamn);
            if (index >= 0)
            {
                _kategorier[index] = nyttNamn;
                SparaKategorier(); // Spara den uppdaterade samlingen
            }
        }

        public void Delete(string kategoriNamn)
        {
            _kategorier.Remove(kategoriNamn);
            SparaKategorier(); // Spara den uppdaterade samlingen
        }

        public string GetByIndex(int index)
        {
            if (index >= 0 && index < _kategorier.Count)
            {
                return _kategorier[index];
            }
            else
            {
                return null; // Hantera ogiltigt index enligt ditt behov
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







        //public void Add(string kategoriNamn)
        //{
        //    using (StreamWriter writer = File.AppendText(kategoriFil))
        //    {
        //        writer.WriteLine(kategoriNamn);
        //    }
        //}
        //public void Create(string kategoriNamn)
        //{

        //}
        

        
        //public List<string> GetAll()
        //{
        //    List<string> kategorier = new List<string>();

        //    if (File.Exists(kategoriFil))
        //    {
        //        using (StreamReader reader = File.OpenText(kategoriFil))
        //        {
        //            string line;
        //            while ((line = reader.ReadLine()) != null)
        //            {
        //                kategorier.Add(line);
        //            }
        //        }
        //    }

        //    return kategorier;

        //}

        //public void Update(string nyttNamn, string gammaltNamn)
        //{
        //    List<string> kategorier = GetAll();
        //    int index = kategorier.FindIndex(k => k == gammaltNamn);
        //    if (index >= 0)
        //    {
        //        kategorier[index] = nyttNamn;
        //        SparaKategorier(kategorier);
        //    }
        //}



        //public void Delete(string kategoriNamn)
        //{
        //    List<string> kategorier = GetAll();
        //    if (kategorier.Contains(kategoriNamn))
        //    {
        //        kategorier.Remove(kategoriNamn);
        //        SparaKategorier(kategorier);
        //    }
        //}

        //public void SparaKategorier(List<string> kategorier)
        //{
        //    using (StreamWriter writer = new StreamWriter(kategoriFil))
        //    {
        //        foreach (string kategori in kategorier)
        //        {
        //            writer.WriteLine(kategori);
        //        }
        //    }
        //}







        //public Kategori GetByIndex(int index)
        //{
        //    if (index >= 0 && index < _kategorier.Count)
        //    {
        //        return _kategorier[index];
        //    }
        //    else
        //    {
        //        // Felhantering om index är ogiltigt.
        //        // Du kan returnera null eller kasta ett undantag beroende på ditt programflöde.
        //        return null;
        //    }
        //}










    }


}
