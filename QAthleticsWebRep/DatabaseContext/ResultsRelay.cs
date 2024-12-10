using System;
using System.Collections.Generic;

namespace QAthleticsWebRep.DatabaseContext
{
    public partial class ResultsRelay
    {
        public int ChampionshipNo { get; set; }
        public int EventNo { get; set; }
        public int Tluclub { get; set; }
        public short? Col1 { get; set; }
        public int? PibNo { get; set; }
        public string? Athlete { get; set; }
    }
}
