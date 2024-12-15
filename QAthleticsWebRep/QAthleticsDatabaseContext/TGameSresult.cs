using System;
using System.Collections.Generic;

namespace QAthleticsWebRep.QAthleticsDatabaseContext
{
    public partial class TGameSresult
    {
        public int? GameNo { get; set; }
        public short? PlayerSerial { get; set; }
        public short? PlayerOrder { get; set; }
        public int BipNo { get; set; }
        public string? PlayerName { get; set; }
        public short? LuClub { get; set; }
        public string? PlayerResult { get; set; }
        public float? Points { get; set; }
        public short? LuNationality { get; set; }
        /// <summary>
        /// new record or DQ remarks or micro seconds for result for equeals
        /// </summary>
        public byte[]? PlayerRemark { get; set; }
    }
}
