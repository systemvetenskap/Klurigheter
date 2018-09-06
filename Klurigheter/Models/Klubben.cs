using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klurigheter.Models
{
    class Papper : IWrite
    {
        public string Skriv(string text)
        {
            return "pappret";
        }
    }
}
