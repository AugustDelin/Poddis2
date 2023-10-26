using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml;
using BusinessLayer;
using DataAccessLayer;
using DataLayer.Repositories;
using Models;

namespace Podden
{
    public partial class Form1 : Form
    {
        private KategoriManager kategoriManager;
        private RssManager rssManager;

        public Form1()
        {
            kategoriManager = new KategoriManager();
            rssManager = new RssManager();
            InitializeComponent();

            if (File.Exists("listBoxKategorier.txt"))
            {
                string[] kategorier = File.ReadAllLines("listBoxKategorier.txt");
                listBox1.Items.AddRange(kategorier);
            }

            if (File.Exists("comboBox2Kategorier.txt"))
            {
                string[] kategorier = File.ReadAllLines("comboBox2Kategorier.txt");
                comboBox2.Items.AddRange(kategorier);
            }
            UppdateraKategorierListBox();
            LoadSavedRssFeeds();
            label7.Text = "Antalet kategorier: " + kategoriManager.GetTotalCategories();
        }

        private void UppdateraKategorierListBox()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(kategoriManager.GetAll().ToArray());
            File.WriteAllLines("listBoxKategorier.txt", listBox1.Items.Cast<string>().ToArray());
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(listBox1.Items.Cast<string>().ToArray());

        }

        private void UppdateraComboBox2Kategorier()
        {
            comboBox2.Items.Clear();

            foreach (string kategori in listBox1.Items)
            {
                comboBox2.Items.Add(kategori);
            }

            File.WriteAllLines("comboBox2Kategorier.txt", comboBox2.Items.Cast<string>().ToArray());
        }


        private void TaBortKategoriFranTextfil(string gammaltNamn)
        {
            string kategoriFil = "kategorier.txt";

            if (File.Exists(kategoriFil))
            {
                var kategorier = File.ReadAllLines(kategoriFil).ToList();
                kategorier.Remove(gammaltNamn);
                File.WriteAllLines(kategoriFil, kategorier);
            }

            comboBox2.Items.Remove(gammaltNamn);
            UppdateraComboBox2Kategorier();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string nyttKategoriNamn = textBox4.Text.Trim();

                if (!string.IsNullOrEmpty(nyttKategoriNamn))
                {

                    if (kategoriManager.Add(nyttKategoriNamn))
                    {
                        int valtIndex = listBox1.SelectedIndex;
                        string gammaltNamn = listBox1.Items[valtIndex].ToString();
                        TaBortKategoriFranTextfil(gammaltNamn);
                        listBox1.Items[valtIndex] = nyttKategoriNamn;
                        textBox4.Text = string.Empty;

                        if (comboBox2.Items.Contains(gammaltNamn))
                        {
                            int comboBox2Index = comboBox2.Items.IndexOf(gammaltNamn);
                            comboBox2.Items[comboBox2Index] = nyttKategoriNamn;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kunde inte ändra kategorin. Kategorinamn får inte innehålla specialtecken eller siffror.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Välj en kategori att ändra");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string valdKategori = listBox1.SelectedItem.ToString();

                DialogResult dialogResult = MessageBox.Show($"Vill du ta bort kategorin '{valdKategori}'?", "Bekräftelse", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (kategoriManager.Delete(valdKategori))
                    {
                        listBox1.Items.RemoveAt(listBox1.SelectedIndex);

                        if (comboBox2.Items.Contains(valdKategori))
                        {
                            comboBox2.Items.Remove(valdKategori);
                        }
                        var kategorier = File.ReadAllLines("kategorier.txt").ToList();
                        kategorier.Remove(valdKategori);
                        File.WriteAllLines("kategorier.txt", kategorier);
                        kategoriManager.Delete(valdKategori);
                        label7.Text = "Antalet kategorier: " + kategoriManager.GetTotalCategories();
                    }
                    else
                    {
                        MessageBox.Show("Kunde inte ta bort kategorin!");
                    }
                }
                else
                {
                    MessageBox.Show("Kategori ej borttagen!");
                }
            }
        }








        private void button6_Click(object sender, EventArgs e)
        {
            string kategoriNamn = textBox4.Text.Trim();

            if (!string.IsNullOrEmpty(kategoriNamn))
            {

                if (listBox1.Items.Cast<string>().Any(item => item.Equals(kategoriNamn, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Kategorinamnet finns redan i listan.");
                }
                else
                {
                    bool success = kategoriManager.Add(kategoriNamn);

                    if (success)
                    {
                        comboBox2.Items.Add(kategoriNamn);
                        listBox1.Items.Add(kategoriNamn);
                        label7.Text = "Antalet kategorier: " + kategoriManager.GetTotalCategories();
                    }
                    else
                    {

                        MessageBox.Show("Kunde inte lägga till kategorin. Den är ogiltig.");
                    }
                }
            }
        }



        private async void btnLaggaTillRss_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            string namn = txtNamn.Text;

            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(namn))
            {
                MessageBox.Show("Fyll i både URL och namn.");
                return;
            }

            try
            {
                int avsnitt = HämtaAntalAvsnittFrånRSS(url);
                Rss feed = await rssManager.CreateRss(url, namn, new Kategori("Okänd kategori"), avsnitt);

                if (feed != null)
                {
                    ListViewItem listViewItem = new ListViewItem(feed.Namn);
                    listViewItem.SubItems.Add(feed.Avsnitt.ToString());
                    listViewItem.SubItems.Add(url);
                    listViewItem.SubItems.Add(feed.Kategori != null ? feed.Kategori.Namn : "Okänd kategori");
                    listView1.Items.Add(listViewItem);
                    txtUrl.Clear();
                    txtNamn.Clear();
                    comboBox2.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Det gick inte att lägga till RSS-feed. Kontrollera att URL:en är giltig.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod vid hämtning av RSS-feed: " + ex.Message);
            }
        }


        private void SaveRssFeedsToTextFile()
        {

            List<Rss> rssFeedsToSave = new List<Rss>();

            foreach (ListViewItem item in listView1.Items)
            {
                string namn = item.SubItems[0].Text;
                int avsnitt = int.Parse(item.SubItems[1].Text);
                string url = item.SubItems[2].Text;
                string kategoriNamn = item.SubItems[3].Text;
                Kategori kategori = new Kategori(kategoriNamn);
                Rss rssFeed = new Rss(url, namn, kategori, avsnitt);

                rssFeedsToSave.Add(rssFeed);
            }
            rssManager.SaveRssFeedsToTextFile(rssFeedsToSave);
        }

        private void LoadSavedRssFeeds()
        {
            List<Rss> savedRssFeeds = rssManager.GetRssData();
            foreach (Rss feed in savedRssFeeds.Where(feed => !feed.IsDeleted))
            {
                ListViewItem listViewItem = new ListViewItem(feed.Namn);
                listViewItem.SubItems.Add(feed.Avsnitt.ToString());
                listViewItem.SubItems.Add(feed.URL);
                listViewItem.SubItems.Add(feed.Kategori != null ? feed.Kategori.Namn : "Okänd kategori");
                listView1.Items.Add(listViewItem);
            }
        }



        private int HämtaAntalAvsnittFrånRSS(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string xmlData = client.GetStringAsync(url).Result;
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xmlData);
                    int antalAvsnitt = doc.GetElementsByTagName("item").Count;
                    return antalAvsnitt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid hämtning av RSS-feed: " + ex.Message);
                return 0;
            }
        }

        private async void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string selectedNamn = selectedItem.SubItems[0].Text;
                string selectedUrl = selectedItem.SubItems[2].Text;
                string selectedKategori = selectedItem.SubItems[3].Text;
                txtNamn.Text = selectedNamn;
                txtUrl.Text = selectedUrl;
                comboBox2.SelectedItem = selectedKategori;
                var (titles, _) = await rssManager.HämtaTitlarOchBeskrivningarFrånXML(selectedUrl);
                listBox2.Items.Clear();
                
                foreach (var title in titles)
                {
                    listBox2.Items.Add(title);
                }

            }
        }

        private void btnTaBortRss_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string namn = selectedItem.SubItems[0].Text;
                Rss rssItem = GetRssItemByName(namn);
                rssManager.DeleteRss(rssItem);
                listView1.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Välj ett RSS-flöde att ta bort.");
            }
            listBox2.Items.Clear();
            textBox3.Clear();
        }

        private Rss GetRssItemByName(string namn)
        {
            Rss rssItem = rssManager.GetRssData().FirstOrDefault(rss => rss.Namn == namn);
            return rssItem;
        }

        private void btnAndraRss_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string gammaltNamn = selectedItem.SubItems[0].Text;
                List<Rss> rssFlows = rssManager.GetRssData();
                Rss valtRss = rssFlows.FirstOrDefault(rss => rss.Namn == gammaltNamn);

                if (valtRss != null)
                {
                    valtRss.Namn = txtNamn.Text;
                    string nyKategoriNamn = comboBox2.SelectedItem?.ToString();
                    
                    if (!string.IsNullOrEmpty(nyKategoriNamn))
                    {
                        valtRss.Kategori = new Kategori(nyKategoriNamn);
                    }
                    rssManager.SaveRssFeedsToTextFile(rssFlows);
                    selectedItem.SubItems[0].Text = valtRss.Namn;
                    selectedItem.SubItems[3].Text = valtRss.Kategori != null ? valtRss.Kategori.Namn : "Okänd kategori";
                }
            }

        }

        private async void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                string selectedTitle = listBox2.SelectedItem.ToString();

                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = listView1.SelectedItems[0];
                    string selectedUrl = selectedItem.SubItems[2].Text;
                    var (titles, descriptions) = await rssManager.HämtaTitlarOchBeskrivningarFrånXML(selectedUrl);
                    int selectedIndex = Array.IndexOf(titles, selectedTitle);

                    if (selectedIndex >= 0 && selectedIndex < descriptions.Length)
                    {
                        textBox3.Text = "--------------------------Beskrivning-------------------------\r\n\r\n" + descriptions[selectedIndex];
                    }
                    else
                    {
                        textBox3.Text = "Ingen beskrivning tillgänglig.";
                    }
                }
            }
        }

        private void btnFiltrera_Click(object sender, EventArgs e)
        {
            string valdKategori = comboBox2.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(valdKategori))
            {
                LoadSavedRssFeeds();
            }
            else
            {
                listView1.Items.Clear();
                List<Rss> rssFeedsToDisplay = rssManager.GetRssData().Where(feed => feed.Kategori?.Namn == valdKategori).ToList();

                foreach (Rss feed in rssFeedsToDisplay)
                {
                    ListViewItem listViewItem = new ListViewItem(feed.Namn);
                    listViewItem.SubItems.Add(feed.Avsnitt.ToString());
                    listViewItem.SubItems.Add(feed.URL);
                    listViewItem.SubItems.Add(feed.Kategori != null ? feed.Kategori.Namn : "Okänd kategori");
                    listView1.Items.Add(listViewItem);
                }
            }
        }

        private void btnAterstall_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = null;
            listView1.Items.Clear();
            List<Rss> originalRssFeeds = rssManager.GetRssData().Where(feed => !feed.IsDeleted).ToList();

            foreach (Rss feed in originalRssFeeds)
            {
                ListViewItem listViewItem = new ListViewItem(feed.Namn);
                listViewItem.SubItems.Add(feed.Avsnitt.ToString());
                listViewItem.SubItems.Add(feed.URL);
                listViewItem.SubItems.Add(feed.Kategori != null ? feed.Kategori.Namn : "Okänd kategori");
                listView1.Items.Add(listViewItem);
            }
        }
    }
}





