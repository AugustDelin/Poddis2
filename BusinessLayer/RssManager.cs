using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Validation;
using DataLayer.Repositories;
using Models;

namespace BusinessLayer
{
    public class RssManager
    {
        private RssRepository rssRepository;
        private Serializer<List<Rss>> rssSerializer;
        Validator validator;
        public RssManager()
        {
            rssRepository = new RssRepository();
            rssSerializer = new Serializer<List<Rss>>("Rss.txt");
            validator = new Validator();
        }

   

        public List<Rss> GetRssData()
        {
            // Här returnerar du den aktuella listan av RSS-flöden från rssRepository
            return rssRepository.GetRssData();
        }




        public async Task<Rss> CreateRss(string url, string namn, Kategori kategori, int avsnitt)
        {
            // Anropa ValideraUri för att validera URL:en
            bool urlIsValid = validator.ValideraUri(url, false); // Om URL:en inte får existera redan

            if (!urlIsValid)
            {
                // URL:en är ogiltig, gör något (t.ex. returnera null eller kasta ett undantag)
                return null;
            }

            Rss feed = await rssRepository.ReadFeedAsync(url, namn, kategori, avsnitt);

            if (feed != null)
            {
                if (!string.IsNullOrEmpty(namn))
                {
                    feed.Namn = namn;
                }
                rssRepository.Create(feed);
                rssRepository.SaveChanges();
            }

            return feed; // Returnera Rss-objektet
        }

        public void SaveRssFeedsToTextFile(List<Rss> rssFeedsToSave)
        {
            rssRepository.SaveRssFeedsToTextFile(rssFeedsToSave);
        }

        public void DeleteRss(Rss rssItem)
        {
           
            rssRepository.Delete(rssItem);
            
        }

        public async Task<(string[] Titles, string[] Descriptions)> HämtaTitlarOchBeskrivningarFrånXML(string url)
        {
            return await rssRepository.HämtaTitlarOchBeskrivningarFrånXML(url);
        }

    }
    }

