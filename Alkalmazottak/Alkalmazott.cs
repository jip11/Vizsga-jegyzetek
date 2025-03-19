using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alkalmazottak
{
    internal class Alkalmazott
    {
        public int id {  get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int salary { get; set; }
        public string department { get; set; }

        // Konstruktor duh
        public Alkalmazott(int Id, string Name, int Age, int Salary, string Department)
        {
            id = Id;
            name = Name; 
            age = Age; 
            salary = Salary; 
            department = Department;
        }

        public static List<Alkalmazott> initializeAlkalmazottListFromFile(string fileName = "")
        {
            //Szokásos fájlbeolvasós cuccok
            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            StreamReader streamReader = new StreamReader(fileStream);

            // Ebben tároljuk az alkalmazottakat
            List<Alkalmazott> resultList = new List<Alkalmazott>();

            // Első sor átugrása, mert az fejléc
            string line = streamReader.ReadLine();

            // Második sor beolvasása
            line = streamReader.ReadLine();

            while (line != null)
            {
                string[] splittedLine = line.Split('\t'); // Tabulátor mentén darabolni

                resultList.Add  // Hozzáadjuk a listához a lent példányosított Alkalmazott objektumot
                (
                    new Alkalmazott
                    (
                        int.Parse(splittedLine[0]), // id
                        splittedLine[1],            // name
                        int.Parse(splittedLine[2]), // age
                        int.Parse(splittedLine[3]), // salary
                        splittedLine[4]             // department
                    )
                );

                line = streamReader.ReadLine(); // Új sor beolvasása
            }

            return resultList;
        }
    }
}
