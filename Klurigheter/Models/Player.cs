using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klurigheter.Models
{
    interface IPlayer
    {
        int Player_id { get; set; }
        string Name { get; set; }
        string Nickname { get; set; }

    }

    public class Player : IPlayer
    {
        public int Player_id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
    }
}
