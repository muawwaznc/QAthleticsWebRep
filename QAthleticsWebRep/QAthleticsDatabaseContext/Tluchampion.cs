using System;
using System.Collections.Generic;

namespace QAthleticsWebRep.QAthleticsDatabaseContext
{
    public partial class Tluchampion
    {
        public Tluchampion()
        {
            TGames = new HashSet<TGame>();
        }

        public short No1 { get; set; }
        public string? Descr1 { get; set; }
        public string? Edescr1 { get; set; }
        public string? Caddress { get; set; }
        public string? Calculatedby { get; set; }
        public string? TeamsType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ChampStatus { get; set; }
        public string? Remarks { get; set; }
        public string? ShowCahmpPhoto { get; set; }
        public string? ShowClubPhoto { get; set; }
        public string? ShowAthletePhoto { get; set; }

        public virtual ICollection<TGame> TGames { get; set; }
    }
}
