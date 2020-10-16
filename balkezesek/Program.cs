using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace balkezesek
{
    class Program
    {
        static List<balkezesek> balkezes = new List<balkezesek>();


        static void Beolvasas()
        {
            StreamReader sr = new StreamReader("balkezesek.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                balkezes.Add(new balkezesek(sr.ReadLine()));
            }
            sr.Close();
        }


        static void Main(string[] args)
        {
            Beolvasas();
            foreach (var b in balkezes)
            {
                Console.WriteLine($"{b.nev, 20} {b.elso} {b.utolso} {b.suly} {b.magassag}");
            }


            Console.ReadKey();
        }
    }
}
