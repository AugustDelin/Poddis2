using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Models;


namespace DataAccessLayer
{
    public class RssGetter
    {

        
        public RssGetter()
        {

        }

        

        public List<Rss> GetRssFeed(string url)
        {
            List<Rss> rssList = new List<Rss>();

            try
            {
                XDocument xdoc = XDocument.Load(url);

                var items = xdoc.Descendants("item");
                foreach (var item in items)
                {
                    string title = item.Element("title")?.Value ?? "Title Not Found";
                    string description = item.Element("description")?.Value ?? "Description Not Found";

                    
                    string kategoriNamn = item.Element("category")?.Value ?? "Default Category Name";
                    Kategori kategori = new Kategori(kategoriNamn); 

                    
                    int avsnitt;
                    if (int.TryParse(description, out avsnitt))
                    {
                        Rss rssItem = new Rss(url, title, kategori, avsnitt); 
                        rssList.Add(rssItem);
                    }
                    else
                    {
                        
                        Console.WriteLine("Invalid 'Avsnitt' value: " + description);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching and parsing the RSS feed.");
                Console.WriteLine(ex);
            }

            return rssList;
        }
    }
}
