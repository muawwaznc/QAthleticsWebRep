using System;
using System.Collections.Generic;

namespace QAthleticsWebRep.QAthleticsDatabaseContext
{
    public partial class ResultsHeight
    {
        public int ChampionshipNo { get; set; }
        public int EventNo { get; set; }
        public int PibNo { get; set; }
        public short? Col { get; set; }
        public string? Hight { get; set; }
        public string? Result { get; set; }
    }
}
