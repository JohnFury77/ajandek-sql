using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ajandek_sql
{
    class Ajandek
    {
        int id;
        string nev;
        string uzlet;

        public Ajandek(int id, string nev, string uzlet)
        {
            this.Id = id;
            this.Nev = nev;
            this.Uzlet = uzlet;
        }
        public override string ToString()
        {
            return nev;
        }
        public int Id { get => id; set => id = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Uzlet { get => uzlet; set => uzlet = value; }
    }
}
