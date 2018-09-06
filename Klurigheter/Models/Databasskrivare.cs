using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klurigheter.Models
{
    class Databasskrivare : IWrite, IRead
    {
        public void Insert(string text)
        {

        }

        public void Read()
        {
            //
        }

        public string Skriv(string text)
        {
            return "databasen";
        }
    }
}
