using System;
using System.Collections.Generic;

namespace QAthleticsWebRep.QAthleticsDatabaseContext
{
    public partial class ResultsCombined
    {
        public int ChampionshipNo { get; set; }
        public int EventNo { get; set; }
        public int PibNo { get; set; }
        public short? SubEventOrder { get; set; }
        public string? SubEventName { get; set; }
        public string? SubEventResult { get; set; }
        public float? SubEventPoints { get; set; }
    }
}
