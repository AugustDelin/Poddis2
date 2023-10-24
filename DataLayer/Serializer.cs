using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace DataLayer
{
    public class Serializer<T>
    {
        private string fileName;

        public Serializer(String fileName)
        {
            this.fileName = fileName; 
        }
  
    public void Serialize(List<T> list)
        {
            XmlSerializer serializer= new XmlSerializer(typeof(List<T>));

            using (FileStream xmlOut = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(xmlOut, list);

            }
        }

        public List<T> Deserialize()
        {
            List<T> listan = new List<T>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));

            try {


                using (FileStream xmlIn = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    listan = (List<T>)xmlSerializer.Deserialize(xmlIn);
                }
            }
            
            catch (FileNotFoundException)
            {
                Console.WriteLine("Filen hittades inte");
                listan = new List<T>();
            }
             catch (Exception ex) 
            {
                Console.WriteLine(ex.Message, "Filen hittades inte");
            }
            return listan;
        }

       
    
    }



}
