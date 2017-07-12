using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;
using ingmmv01.infr.ecc;


using CineTV.Pelicula;

namespace CineTV
{
    public class Program
    {
        static void Main(string[] args)
        {
            RecolectaDatos();
        }

        private static void RecolectaDatos()
        {
            int pagina = 0;
            string Url;
            HtmlWeb web;
            HtmlDocument htmlDoc;
            string xpath;
            HtmlNodeCollection colNodosPeliculas;
            ColECC<CPelicula> colPelis = EngPelicula.ColNueva();

            do
            {
                pagina++;

                Url = "http://sincroguia.tv/es/peliculas?&page=" + pagina.ToString() + "&category=5";
                web = new HtmlWeb();
                htmlDoc = web.Load(Url);

                xpath = "//div[@class = 'programm-desc']";
                colNodosPeliculas = htmlDoc.DocumentNode.SelectNodes(xpath);

                if (colNodosPeliculas != null)
                {
                    foreach (HtmlNode nodoPeli in colNodosPeliculas)
                    {
                        Console.WriteLine(nodoPeli.InnerHtml.ToString());

                        CPelicula peli = new CPelicula(nodoPeli);
                        colPelis.Add(peli);
                        peli.Persist();

                        Console.WriteLine(peli.ToString());
                    }
                }
            }
            while (colNodosPeliculas != null && colNodosPeliculas.Count > 0);            
        }

    }
}
