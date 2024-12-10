using System;
using System.Collections.Generic;

namespace QAthleticsWebRep.DatabaseContext
{
    public partial class TGame
    {
        public int GameAutono { get; set; }
        public string? GameDescr { get; set; }
        public short? Tlucahmpion { get; set; }
        public short? Tluclass { get; set; }
        public string? GameType { get; set; }
        public short? Tlugame { get; set; }
        public short? GameGroup { get; set; }
        public DateTime? GameDate { get; set; }
        public string? GameParticipates { get; set; }
        public string? WindSpeed { get; set; }
        public string? CallTime { get; set; }
        public string? FieldTime { get; set; }
        public string? BeginTime { get; set; }
        public string? IsElectrical { get; set; }
        public short? TlugameStatus { get; set; }
        public string? UserId1 { get; set; }
        public string? JudgeName { get; set; }
        public string? LastUpdate { get; set; }
        public string? CheckName { get; set; }
        public string? DataEntry { get; set; }
        public string? ElectronicDistance { get; set; }
        public string? Remarks { get; set; }
        public int? RelatedtoGame { get; set; }
        public string? CompititionRecord { get; set; }
        public string? PointsLimit { get; set; }
        public DateTime? ResultFinishedDatetime { get; set; }
        public DateTime? ResultApprovedDateTime { get; set; }
        public short? ResultType { get; set; }

        public virtual Tluchampion? TlucahmpionNavigation { get; set; }
        public virtual Tluclass? TluclassNavigation { get; set; }
        public virtual Tlugame? TlugameNavigation { get; set; }
    }
}
