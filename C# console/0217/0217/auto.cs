using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0217
{
    class Auto
    {
        public required string Tipus { get; set; }
        public int FutottKm { get; set; }
    }

    internal class Program
    {
        private static void Main()
        {
            List<Auto> autok = new List<Auto>();

            string[] lines = File.ReadAllLines("autok2sorban.txt");


            for (int i = 0; i < lines.Length; i += 2)
            {
                var tipus = lines[i];
                var km = int.Parse(lines[i + 1]);

                autok.Add(new Auto
                {
                    Tipus = tipus,
                    FutottKm = km
                });
            }

            var kevesebbMint20000 = autok.Count(a => a.FutottKm < 20000);
            Console.WriteLine($"Autók, melyek 20000 km-nél kevesebbet futottak: {kevesebbMint20000}");

            var toyotaAutok = autok.Count(a => a.Tipus.Contains("Toyota"));
            Console.WriteLine($"Toyota autók száma: {toyotaAutok}");

            var legtobbKm = autok.OrderByDescending(a => a.FutottKm).First();
            Console.WriteLine($"A legtöbbet futott autó: {legtobbKm.Tipus}, {legtobbKm.FutottKm} km");

            var atlagKm = autok.Average(a => a.FutottKm);
            Console.WriteLine($"Autók átlagos futott km: {atlagKm}");
        }
    }
}
