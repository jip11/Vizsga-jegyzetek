using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Lajhar
{
    public required string Nev { get; set; }
    public int Eletkor { get; set; }
    public double Testtomeg { get; set; }
    public required string Nem { get; set; }
    public int Utodok { get; set; }
}
namespace _0217
{
    class Program
    {
        static void Main()
        {
            List<Lajhar> lajharok = new List<Lajhar>();

            string[] lines = File.ReadAllLines("lajharok.txt");

            for (int i = 0; i < lines.Length; i += 3)
            {
                var nameAndAge = lines[i].Split(';');
                var name = nameAndAge[0];
                var age = int.Parse(nameAndAge[1]);

                var weight = double.Parse(lines[i + 1]);

                var genderAndOffspring = lines[i + 2].Split(';');
                var gender = genderAndOffspring[0];
                var offspring = int.Parse(genderAndOffspring[1]);

                lajharok.Add(new Lajhar
                {
                    Nev = name,
                    Eletkor = age,
                    Testtomeg = weight,
                    Nem = gender,
                    Utodok = offspring
                });
            }

            var noStenyekSzama = lajharok.Count(l => l.Nem == "nosteny");
            Console.WriteLine($"Nőstény lajhárok száma: {noStenyekSzama}");

            var himekKolykei = lajharok.Where(l => l.Nem == "him")
                                        .Sum(l => l.Utodok);
            Console.WriteLine($"Hímek kölykei összesen: {himekKolykei}");

            var rendezes = lajharok.OrderBy(l => l.Eletkor).ToList();
            Console.WriteLine("Lajhárok életkor szerint rendezetten:");
            foreach (var lajh in rendezes)
            {
                Console.WriteLine($"{lajh.Nev}, {lajh.Eletkor} éves");
            }
            var sikeresParok = lajharok.Where(l => l.Utodok > 0)
                                       .GroupBy(l => l.Utodok)
                                       .Select(g => new { UtodokSzama = g.Key, Parok = g.ToList() })
                                       .ToList();
            Console.WriteLine("Sikeres párok:");
            foreach (var par in sikeresParok)
            {
                Console.WriteLine($"Pár {par.UtodokSzama} kölyökkel: ");
                foreach (var parLajh in par.Parok)
                {
                    Console.WriteLine($"- {parLajh.Nev}, {parLajh.Nem}");
                }
            }
        }
    }
}