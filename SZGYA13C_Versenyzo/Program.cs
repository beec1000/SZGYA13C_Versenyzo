using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SZGYA13C_Versenyzo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Versenyzo> versenyzo = new List<Versenyzo>();

            versenyzo = Versenyzo.FromFile(@"..\..\..\src\selejtezo.txt");

            //3.feladat
            Console.WriteLine($"A versenyen {versenyzo.Count()} versenyző vett részt.");

            //4.feladat
            Random rnd = new Random();

            var randomVersenyzo = rnd.Next(0, versenyzo.Count);
            

            Console.WriteLine($"Kérem a zsűritag sorszámát: {string.Join(", ", randomVersenyzo)}");

            // 5.feladat
            var atlagPont = versenyzo[randomVersenyzo].Pontok.Average();
            Console.WriteLine($"A zsűritag által adott pontszámok átlaga: {Math.Round(atlagPont, 1)}");

            //6.feladat
            var sumPontosVersenyzok = versenyzo.Select(v => new { Nev = v.Nev, OsszPont = v.Pontok.Sum() })
                                               .ToList();

            var legtobbPont = sumPontosVersenyzok.Max(v => v.OsszPont);
            var legtobbPontNev = sumPontosVersenyzok.Where(v => v.OsszPont == legtobbPont);

            foreach (var i in legtobbPontNev)
            {
                Console.WriteLine($"A legmagasabb pontszámot elért versenyző: {i.Nev}. Pontszáma: {legtobbPont}");
            }

        }
    }
}
