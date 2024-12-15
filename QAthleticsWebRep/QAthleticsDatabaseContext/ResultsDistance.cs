using System;
using System.Collections.Generic;

namespace QAthleticsWebRep.QAthleticsDatabaseContext
{
    public partial class ResultsDistance
    {
        public int? ChampionshipNo { get; set; }
        public int? EventNo { get; set; }
        public int? PibNo { get; set; }
        public short? AttemptNo { get; set; }
        public string? AttempResult { get; set; }
        public string? AttempWindSpeed { get; set; }
    }
}
