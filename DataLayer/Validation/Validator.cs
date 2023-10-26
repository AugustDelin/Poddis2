using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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




        public bool ValideraUrl(string url)
            {
                if (string.IsNullOrEmpty(url))
                {
                    return false; 
                }

                if (Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                {
                    return true;
                }

                return false;
            }

        }



    }


