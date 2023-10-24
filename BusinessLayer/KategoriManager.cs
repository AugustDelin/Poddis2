using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using DataLayer.Repositories;
using DataLayer.Validation;
using Models;

namespace BusinessLayer;


public class KategoriManager
{

    private KategoriRepository kategoriRepository;
    //KategoriRepository kategoriRepository;
    private Validator validator;

    public KategoriManager()
    {

        validator = new Validator();
        kategoriRepository = new KategoriRepository();
    }



    public bool Add(string kategoriNamn)
    {
        if (validator.ValideraKategori(kategoriNamn))
        {
            
                kategoriRepository.Add(kategoriNamn);
                return true;
            
        }
        return false;
    }

    public List<string> GetAll()
    {
        return kategoriRepository.GetAll();
    }

    public bool Delete(string kategoriNamn)
    {
        kategoriRepository.Delete(kategoriNamn);
        return true;
    }

    public bool AndraKategori(string gammaltNamn, string nyttNamn)
    {
        kategoriRepository.Update(gammaltNamn, nyttNamn);
        return true;
    }

    //public Kategori FindKategoriByIndex(int index)
    //{
    //    return kategoriRepository.GetByIndex(index);
    //}



}

