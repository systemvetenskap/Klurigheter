﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klurigheter.Models
{
    class Robot : IPlayer
    {
        public int Player_id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
    }
}
}
