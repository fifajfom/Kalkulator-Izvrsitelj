using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kalkulator_Izvrsitelj
{
    class Kurs
    {
        MainWindow y;
        public Kurs(MainWindow form)
        {
            y = form;
        }

        public static bool IsInternetConnection()  // Proverava da li ima konekcije 
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create("https://www.google.co.in/");
            System.Net.WebResponse resp;
            try
            {
                resp = req.GetResponse();
                resp.Close();
                req = null;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static void Update() //update kursa
        {


            bool result = Kurs.IsInternetConnection();  //Ukoliko ima net-a radi update, ukoliko ne iscitava prethodne vrednosti
            if (result == true)
            {

                string htmlCode = "";
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.UserAgent, "AvoidError");
                    htmlCode = client.DownloadString("https://www.nbs.rs/kursnaListaModul/srednjiKurs.faces?lang=lat");
                }
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

                doc.LoadHtml(htmlCode);

                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));


                int count = 0;

                using (var file = new StreamWriter("test.txt"))
                {
                    foreach (var row in doc.DocumentNode.SelectNodes("//table[@id='index:srednjiKursLista']/tbody/tr"))
                    {
                        DataRow dr = dt.NewRow();
                        foreach (var cell in row.SelectNodes("td"))
                        {
                            if ((count % 1 == 0))
                            {
                                dr["Name"] = cell.InnerText.Replace("&nbsp;", " ");
                            }
                            else
                            {
                            }

                        }
                        file.WriteLine(dr[0]);

                    }

                }
            }
            else { }
        }

        public void KursMain()
        {

            Update();
            string[] lines = System.IO.File.ReadAllLines("test.txt");

            y.keur.Text = "EUR: " + lines[0];
            y.kusd.Text = "USD: " + lines[15];
            y.kchf.Text = "CHF: " + lines[13];


        }

        //public void nap()
        //{
        //    if (System.Text.RegularExpressions.Regex.IsMatch(y.Naplata.Text, "[^0-9]"))
        //    {
        //        MessageBox.Show("Dozvoljen je unos samo brojeva");
        //        y.Naplata.Text = y.Naplata.Text.Remove(y.Naplata.Text.Length - 1);
        //    }
        //}
        public void Dug()
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(y.Dug.Text, "[^0-9,.]"))
            {
                MessageBox.Show("Dozvoljen je unos samo brojeva");
                y.Dug.Text = y.Dug.Text.Remove(y.Dug.Text.Length - 1);
            }
        }


    }
}
