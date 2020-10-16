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
            sr.ReadLine();//Kihagyja a fejléc sort.
            while (!sr.EndOfStream)
            {
                balkezes.Add(new balkezesek(sr.ReadLine()));
            }
            sr.Close();
        }


        static void harmadikFeladat()
        {
            int db = 0;
            foreach (var b in balkezes)
            {
                db++;
            }
            Console.WriteLine("3. feladat: {0}", db);
        }


        static void negyedikFeladat()
        {
            Console.WriteLine("4. feladat:");
            double cm = 0;
            foreach (var b in balkezes)
            {
                if (b.utolso.Contains("1999-10"))
                {
                    cm = Math.Round(b.magassag * 2.54);
                    Console.WriteLine($"\t{b.nev}, {cm}");
                }
            }
        }


        static void otodikFeladat()
        {
            //Console.WriteLine("5. feladat:");
            //Console.Write("Kérek egy 1990 és 1999 közötti évszámot: ");
            //int szam = Convert.ToInt32(Console.ReadLine());
            //if (1990 <= szam && szam <= 1999)
            //{
            //    Console.WriteLine(szam);
            //}
            //else
            //{
            //    Console.WriteLine("Hibás adat! Kérek egy 1990 és 1999 közötti évszámot: ");
            //}
        }


        static void hatodikFeladat()
        {
            //int db = 0;
            //double atlag = 0;
            //foreach (var b in balkezes)
            //{
            //    if (b.elso <= "1995-01-01" && b.utolso <= "1995-12-31")
            //    {
            //        atlag = atlag + b.suly;
            //        db++;
            //    }
            //}
            //atlag = atlag / db;
            //Console.WriteLine($"6. feladat: {atlag}");
        }


        static void otodikHatodikFeladat()
        {
            Console.Write("\n5. feladat:");
            int evszam = 0;
            bool hibas;
            do
            {
                hibas = false;
                Console.Write("Kérek egy 1990 és 1999 közötti évszámot: ");
                evszam = Convert.ToInt32(Console.ReadLine());
                if (evszam < 1990  || evszam > 1999)
                {
                    hibas = true;
                    Console.Write("Hibás adat! ");
                }
            } while (hibas);


            Console.Write("\n6. feladat:");
            int db = 0;
            double atlag = 0;
            foreach (var b in balkezes)
            {
                if (Convert.ToInt32(b.elso.Substring(0, 4)) <= evszam &&
                    Convert.ToInt32(b.utolso.Substring(0, 4)) >= evszam)
                {
                    db++;
                    atlag = atlag + b.suly;
                }
            }
            Console.WriteLine($"{atlag / db:N2}");//N2 --> két tizedes jegyet hagy meg!
        }


        static void Kiiras()
        {
            var nevek = from b in balkezes select b.nev;
            var nevLista = nevek.ToList();
            var kezdobetu = from n in nevLista orderby n group n by n[0] into tempNevek select tempNevek;

            Console.WriteLine("\nCsoportosítás kezdőbetű szerint");
            foreach (var csoport in kezdobetu)
            {
                Console.WriteLine("Kezdőbetű: {0}", csoport.Key);
                foreach (var csoportTag in csoport)
                {
                    Console.WriteLine($"\t{csoportTag}");
                }
            }
        }


        static void Main(string[] args)
        {
            Beolvasas();
            //foreach (var b in balkezes)
            //{
            //    Console.WriteLine($"{b.nev, 20} {b.elso} {b.utolso} {b.suly} {b.magassag}");
            //}

            harmadikFeladat();
            negyedikFeladat();
            otodikFeladat();
            hatodikFeladat();
            otodikHatodikFeladat();
            Kiiras();


            Console.ReadKey();
        }
    }
}