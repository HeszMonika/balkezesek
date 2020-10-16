using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace balkezesek
{
    class balkezesek
    {
        public string nev { get; private set; }
        public string elso { get; private set; }
        public string utolso { get; private set; }
        public int suly { get; private set; }
        public int magassag { get; private set; }


        public balkezesek(string sor)
        {
            string[] a= sor.Split(';');
            nev = a[0];
            elso = a[1];
            utolso = a[2];
            suly = Convert.ToInt32(a[3]);
            magassag = Convert.ToInt32(a[4]);
        }
    }
}
