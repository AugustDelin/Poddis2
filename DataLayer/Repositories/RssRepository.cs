using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using Models;
using System.Xml.Linq;
using System.Net.Http;
using System.Xml;

namespace DataLayer.Repositories
{
    public class RssRepository : IRepository<Rss>
    {

        private string RssFil = "Rss.txt";
        

        Serializer<Rss> rssSerializer;
        List<Rss> rssFeed;

        public RssRepository()
        {
            rssSerializer = new Serializer<Rss>(RssFil);
            rssFeed = GetAll();
        }

        public void SaveRssFeedsToTextFile(List<Rss> rssFeedsToSave)
        {
            rssSerializer.Serialize(rssFeedsToSave);
        }



        public List<Rss> GetRssData()
        {
            return rssFeed;
        }


        public void SaveChanges()
        {
            rssSerializer.Serialize(rssFeed);

        }

        public List<Rss> GetAll()

        {
            List<Rss> deserializedList = rssSerializer.Deserialize();
            return deserializedList ?? new List<Rss>();
        }

        public void Create(Rss entity)
        {
            rssFeed.Add(entity);
            SaveChanges();
        }

        public void Update(Rss item, string nyttNamn)
        {

        }

        public void Add(Rss item)
        {

        }

        public void Delete(Rss item)
        {
            rssFeed.Remove(item); 
            SaveChanges();
        }

        public async Task<Rss> ReadFeedAsync(string url, string namn, Kategori kategori, int avsnitt)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string xmlData = await client.GetStringAsync(url);
                    Rss feed = ParseRss(xmlData, namn, kategori, avsnitt);
                    return feed;
                }
            }
            catch (Exception ex)
            {
                // Hantera fel här, till exempel logga felmeddelandet.
                Console.WriteLine("Fel vid hämtning av RSS-feed: " + ex.Message);
                return null; // Ersätt detta med return Task.FromResult<Rss>(null);
            }
        }

        private Rss ParseRss(string xmlData, string namn, Kategori kategori, int avsnitt)
        {
            try
            {
                XElement xElement = XElement.Parse(xmlData);

                // Extrahera URL från itunes:new-feed-url-elementet
                string url = xElement.Descendants("{http://www.itunes.com/dtds/podcast-1.0.dtd}new-feed-url").FirstOrDefault()?.Value ?? string.Empty;

                return new Rss(url, namn, kategori, avsnitt);
            }
            catch (Exception ex)
            {
                // Hantera fel om XML-data inte kan parsas korrekt.
                Console.WriteLine("Fel vid parsning av RSS-data: " + ex.Message);
                return null;
            }
        }

        public async Task<(string[] Titles, string[] Descriptions)> HämtaTitlarOchBeskrivningarFrånXML(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string xmlData = await client.GetStringAsync(url);

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xmlData);

                    // Hitta alla <item>-element och hämta <title> och <description> inom varje <item>
                    var titles = doc.SelectNodes("//item/title").Cast<XmlNode>()
                                    .Select(node => node.InnerText)
                                    .ToArray();

                    var descriptions = doc.SelectNodes("//item/description").Cast<XmlNode>()
                                          .Select(node => node.InnerText)
                                          .ToArray();

                    return (titles, descriptions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid hämtning av <title> och <description>-elementen: " + ex.Message);
                return (new string[] { "Kunde inte hämta titlar." }, new string[] { "Kunde inte hämta beskrivningar." });
            }
        }


    }
}
    

