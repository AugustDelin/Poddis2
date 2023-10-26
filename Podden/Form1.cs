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

            // L�s in kategorierna fr�n textfilen till comboBox2
            if (File.Exists("comboBox2Kategorier.txt"))
            {
                string[] kategorier = File.ReadAllLines("comboBox2Kategorier.txt");
                comboBox2.Items.AddRange(kategorier);
            }



            UppdateraKategorierListBox();
            LoadSavedRssFeeds();
        }

        private void UppdateraKategorierListBox()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(kategoriManager.GetAll().ToArray());

            // Spara kategorierna till textfil
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
                    int valtIndex = listBox1.SelectedIndex;
                    string gammaltNamn = listBox1.Items[valtIndex].ToString();

                    if (kategoriManager.AndraKategori(gammaltNamn, nyttKategoriNamn))
                    {
                        // Ta bort den gamla kategorin fr�n textfilen
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
                        MessageBox.Show("Kunde inte �ndra kategorin!");
                    }
                }
                else
                {
                    MessageBox.Show("Ange ett giltigt kategorinamn");
                }
            }
            else
            {
                MessageBox.Show("V�lj en kategori att �ndra");
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string valdKategori = listBox1.SelectedItem.ToString();

                DialogResult dialogResult = MessageBox.Show($"Vill du ta bort kategorin '{valdKategori}'?", "Bekr�ftelse", MessageBoxButtons.YesNo);

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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }






        private void button6_Click(object sender, EventArgs e)
        {
            string kategoriNamn = textBox4.Text.Trim();

            if (!string.IsNullOrEmpty(kategoriNamn))
            {
                // Kontrollera om kategorin redan finns i listan
                if (!listBox1.Items.Contains(kategoriNamn) && !comboBox2.Items.Contains(kategoriNamn))
                {
                    kategoriManager.Add(kategoriNamn);
                    comboBox2.Items.Add(kategoriNamn);

                    // L�gg till kategorin i listbox1
                    listBox1.Items.Add(kategoriNamn);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void txtUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnLaggaTillRss_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            string namn = txtNamn.Text;

            if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(namn))
            {
                string kategoriNamn = comboBox2.SelectedItem?.ToString() ?? "Ok�nd kategori";

                try
                {

                    int avsnitt = H�mtaAntalAvsnittFr�nRSS(url);
                    Rss feed = await rssManager.CreateRss(url, namn, new Kategori(kategoriNamn), avsnitt);

                    if (feed != null)
                    {


                        ListViewItem listViewItem = new ListViewItem(feed.Namn);
                        listViewItem.SubItems.Add(feed.Avsnitt.ToString());
                        listViewItem.SubItems.Add(url);

                        if (feed.Kategori != null)
                        {
                            listViewItem.SubItems.Add(feed.Kategori.Namn);
                        }
                        else
                        {
                            listViewItem.SubItems.Add("Ok�nd kategori");
                        }

                        listView1.Items.Add(listViewItem);




                        txtUrl.Clear();
                        txtNamn.Clear();
                        comboBox2.SelectedItem = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ett fel uppstod vid h�mtning av RSS-feed: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fyll i b�de URL och namn.");
            }
        }

        private void SaveRssFeedsToTextFile()
        {
            // H�mta RSS-fl�den fr�n din ListView och konvertera dem till en lista av Rss-objekt
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

            // Anv�nd RssManager f�r att spara RSS-fl�dena i textfilen
            rssManager.SaveRssFeedsToTextFile(rssFeedsToSave);
        }

        private void LoadSavedRssFeeds()
        {
            List<Rss> savedRssFeeds = rssManager.GetRssData();

            foreach (Rss feed in savedRssFeeds.Where(feed => !feed.IsDeleted))
            {
                // Uppdatera din ListView med de sparade RSS-fl�dena som inte �r borttagna
                ListViewItem listViewItem = new ListViewItem(feed.Namn);
                listViewItem.SubItems.Add(feed.Avsnitt.ToString());
                listViewItem.SubItems.Add(feed.URL);
                listViewItem.SubItems.Add(feed.Kategori != null ? feed.Kategori.Namn : "Ok�nd kategori");
                listView1.Items.Add(listViewItem);
            }
        }



        private int H�mtaAntalAvsnittFr�nRSS(string url)
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

                Console.WriteLine("Fel vid h�mtning av RSS-feed: " + ex.Message);
                return 0;
            }
        }



        private async void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // H�mta den valda poddens URL fr�n listView1
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string selectedNamn = selectedItem.SubItems[0].Text;
                string selectedUrl = selectedItem.SubItems[2].Text;
                string selectedKategori = selectedItem.SubItems[3].Text;

                // Fyll i textf�lten och ComboBox med den valda postens data
                txtNamn.Text = selectedNamn;
                txtUrl.Text = selectedUrl;
                comboBox2.SelectedItem = selectedKategori;

                // H�mta titlar och beskrivningar fr�n den valda podden
                var (titles, _) = await rssManager.H�mtaTitlarOchBeskrivningarFr�nXML(selectedUrl);

                // Visa titlarna i listBox2
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
                MessageBox.Show("V�lj ett RSS-fl�de att ta bort.");
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

                // H�mta befintliga RSS-fl�den fr�n filen
                List<Rss> rssFlows = rssManager.GetRssData();

                // Hitta det valda RSS-fl�det baserat p� namnet
                Rss valtRss = rssFlows.FirstOrDefault(rss => rss.Namn == gammaltNamn);

                if (valtRss != null)
                {
                    // Uppdatera informationen baserat p� anv�ndarinput
                    valtRss.Namn = txtNamn.Text;
                    valtRss.URL = txtUrl.Text;

                    // H�mta den valda kategorin fr�n ComboBox
                    string nyKategoriNamn = comboBox2.SelectedItem?.ToString();
                    if (!string.IsNullOrEmpty(nyKategoriNamn))
                    {
                        // Uppdatera kategorin f�r det valda RSS-fl�det
                        valtRss.Kategori = new Kategori(nyKategoriNamn);
                    }

                    // Spara uppdaterade RSS-fl�den till filen
                    rssManager.SaveRssFeedsToTextFile(rssFlows);

                    // Uppdatera ListView f�r att visa de nya �ndringarna
                    selectedItem.SubItems[0].Text = valtRss.Namn;
                    selectedItem.SubItems[2].Text = valtRss.URL;
                    selectedItem.SubItems[3].Text = valtRss.Kategori != null ? valtRss.Kategori.Namn : "Ok�nd kategori";
                }
            }

        }

        private async void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                // H�mta den valda titeln fr�n listBox2
                string selectedTitle = listBox2.SelectedItem.ToString();

                // H�mta den valda poddens URL fr�n listView1
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = listView1.SelectedItems[0];
                    string selectedUrl = selectedItem.SubItems[2].Text;

                    // H�mta titlar och beskrivningar fr�n den valda podden
                    var (titles, descriptions) = await rssManager.H�mtaTitlarOchBeskrivningarFr�nXML(selectedUrl);

                    // Hitta indexet f�r den valda titeln
                    int selectedIndex = Array.IndexOf(titles, selectedTitle);

                    // Visa beskrivningen i textBox3
                    if (selectedIndex >= 0 && selectedIndex < descriptions.Length)
                    {
                        // Visa beskrivningen inklusive radbrytningar och en linje f�r att separera beskrivningen
                        textBox3.Text = "--------------------------Beskrivning-------------------------\r\n\r\n" + descriptions[selectedIndex];
                    }
                    else
                    {
                        // Om beskrivningen inte hittades eller om indexet �r ogiltigt, visa ett meddelande
                        textBox3.Text = "Ingen beskrivning tillg�nglig.";
                    }
                }
            }
        }
    }
}





