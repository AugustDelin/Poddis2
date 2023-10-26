using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;


namespace DataLayer.Validation
{
    public class Validator
    {
        public Validator()
        {

        }
        public bool ValideraKategori(string kategoriNamn)
        {
            bool valideringLyckades = true;

            try
            {
                if (string.IsNullOrEmpty(kategoriNamn))
                {
                    valideringLyckades = false;
                    throw new Exception("Kategorinamn får inte vara tomt.");
                }

                if (Regex.IsMatch(kategoriNamn, @"[^a-zA-ZåäöÅÄÖ\s]"))
                {
                    valideringLyckades = false;
                    throw new Exception("Kategorinamn får inte innehålla siffror eller specialtecken.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return valideringLyckades;
        }

        public bool ValideraUri(string url, bool exists)
        {
            bool validation = true;

            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    validation = false;
                }
                if (exists)
                {

                    validation = false;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Ett fel uppstod: " + ex.Message);
            }

            return validation;
        }
    }
}


