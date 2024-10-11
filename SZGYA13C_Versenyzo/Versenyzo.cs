using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SZGYA13C_Versenyzo
{
    internal class Versenyzo
    {
        public string Nev { get; set; }
        public List<int> Pontok { get; set; }

        public Versenyzo(string nev, List<int> pontok)
        { 
            Nev = nev;
            Pontok = pontok;
        }

        public static List<Versenyzo> FromFile(string path)
        {
            List<Versenyzo> versenyzok = new List<Versenyzo>();


            string[] line = File.ReadAllLines(path);

            foreach (var l in line)
            {
                string[] v = l.Split(';');

                if (v.Length > 1)
                {
                    string Nev = v[0];
                    List<int> Pontok = v[1].Split(' ')
                                           .Select(int.Parse)
                                           .ToList();

                    Versenyzo versenyzo = new Versenyzo(Nev, Pontok);
                    versenyzok.Add(versenyzo);
                }

            }

            return versenyzok;
        }

        public override string ToString()
        {
            return $"{Nev}, {string.Join(' ', Pontok)}";
        }
    }
}
