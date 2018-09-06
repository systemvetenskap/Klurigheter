using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klurigheter.Models
{
    public class Player
    {
        public int Player_id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }

        public override string ToString()
        {
            return "hej";
        }
    }
}
