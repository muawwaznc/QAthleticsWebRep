using System;
using System.Collections.Generic;

namespace QAthleticsWebRep.QAthleticsDatabaseContext
{
    public partial class Tlugame
    {
        public Tlugame()
        {
            TGames = new HashSet<TGame>();
        }

        public short No1 { get; set; }
        public string? Descr1 { get; set; }
        public string? Edescr1 { get; set; }
        public string? RaceField { get; set; }
        public string? RaceMeasure { get; set; }
        public string? RaceTeam { get; set; }
        public string? WindSpeedReq { get; set; }
        public string? TrackNoReq { get; set; }
        public string? OshSecondsReq { get; set; }

        public virtual ICollection<TGame> TGames { get; set; }
    }
}
