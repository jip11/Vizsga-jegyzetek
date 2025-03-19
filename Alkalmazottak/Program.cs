using System;

namespace Alkalmazottak
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. feladat
            List<Alkalmazott> alkalmazottList = new List<Alkalmazott>();
            alkalmazottList = Alkalmazott.initializeAlkalmazottListFromFile("alkalmazottak.csv");
            Console.WriteLine($"1. feladat: Beolvasott alkalmazottak száma: {alkalmazottList.Count}");

            // 2. feladat
            Dictionary<string, int> employeePerDepartment = new Dictionary<string, int>();
            alkalmazottList.ForEach(alkalmazott =>  // Tipikus lista.ForEach()
            {
                if (employeePerDepartment.ContainsKey(alkalmazott.department))  // Megnézzük, hogy a dictionary-be felvettük-e már azt a department-et
                {
                    employeePerDepartment[alkalmazott.department]++;    // Ha igen, akkor csak növeljük meg az értéket
                } else
                {
                    employeePerDepartment.Add(alkalmazott.department, 1);   // Ha nem, akkor adjuk hozzá, és társítunk mellé 1-es értéket (mert ez az első, amit találtunk)
                }
            });

            Console.WriteLine("2. feladat: Osztályonkénti alkalmazottak száma:");
            foreach (var pair in employeePerDepartment) // Dictionary-ban nincs külön ForEach metódus; itt a pair egy objektum, aminek van Key és Value adattagja
            {
                Console.WriteLine($"    {pair.Key}: {pair.Value}");
            }

            // 3. feladat
            Console.WriteLine("3. feladat: 500000-nél magasabb fizetésű alkalmazottak:");
            alkalmazottList.ForEach((alkalmazott) =>
            {
                if (alkalmazott.salary > 500000)
                {
                    Console.WriteLine($"    {alkalmazott.name}, {alkalmazott.salary}");
                }
            });

            // 4. feladat
            double averageSalary = 0.0;
            int itCounter = 0;  // Az átlagszámításhoz kell majd

            alkalmazottList.ForEach((alkalmazott) =>
            {
                if (alkalmazott.department == "IT")
                {
                    itCounter++;
                    averageSalary += Convert.ToDouble(alkalmazott.salary);
                }
            });

            Console.WriteLine($"4. feladat: IT osztály átlagfizetése: {averageSalary / itCounter}");

            // 5. feladat
            Alkalmazott highestPayed = null;    // Ebben tartjuk nyilván a legmagasabb fizetéssel rendelkező alkalmazottat, egyelőre null mert nem vizsgáltunk semmit.

            alkalmazottList.ForEach((alkalmazott) =>
            {
                if (highestPayed == null || alkalmazott.salary > highestPayed.salary) // Ha a highestPayed null, vagy a vizsgált alkalmazottnak magasabb a fizetése, mint a jelenleg nyilvántartottnak
                {
                    highestPayed = alkalmazott;
                }
            });

            Console.WriteLine($"5. feladat: Legmagasabb fizetésű alkalmazott: {highestPayed.name}, {highestPayed.salary}");

            // 6. feladat
            Alkalmazott youngestEmployee = null;    // Ebbenm tartjuk nyilván a legfiatalabb alkalmazottat, egyelőre null mert nem vizsgáltunk semmit.

            alkalmazottList.ForEach((alkalmazott) =>
            {
                if (youngestEmployee == null || alkalmazott.age < youngestEmployee.age) // Ha a youngestEmployee null, vagy a vizsgált alkalmazott fiatalabb, mint a jelenleg nyilvántartott
                {
                    youngestEmployee = alkalmazott;
                }
            });

            Console.WriteLine($"6. feladat: Legfiatalabb alkalmazott: {youngestEmployee.name}, {youngestEmployee.age} éves");
        }
    }
}
