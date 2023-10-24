using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
            try
            {
                if (string.IsNullOrEmpty(kategoriNamn))
                {
                    throw new Exception("Kategorinamn får inte vara tomt.");
                }

                return true;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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


