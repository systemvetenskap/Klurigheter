using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klurigheter.Models
{
    class Yatzygame
    {
        public List<IPlayer> Players { get; private set; } = new List<IPlayer>();

        public void AddPlayer(IPlayer p)
        {
            Players.Add(p);
        }

       

    }
}
