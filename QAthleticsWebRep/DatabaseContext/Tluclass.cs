﻿using System;
using System.Collections.Generic;

namespace QAthleticsWebRep.DatabaseContext
{
    public partial class Tluclass
    {
        public Tluclass()
        {
            TGames = new HashSet<TGame>();
        }

        public short No1 { get; set; }
        public string? Descr1 { get; set; }
        public string? Edescr1 { get; set; }

        public virtual ICollection<TGame> TGames { get; set; }
    }
}