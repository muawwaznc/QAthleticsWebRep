using System;
using System.Collections.Generic;

namespace QAthleticsWebRep.QAthleticsDatabaseContext
{
    public partial class EventsList
    {
        public short No1 { get; set; }
        public string? Competition { get; set; }
        public int GameAutono { get; set; }
        public string? Class { get; set; }
        public string? Event { get; set; }
        public short? GameGroup { get; set; }
        public string? GameType { get; set; }
        public string? GameStage { get; set; }
        public string? Status { get; set; }
        public string? GameDate { get; set; }
        public string? GameParticipates { get; set; }
        public string? CallTime { get; set; }
        public string? FieldTime { get; set; }
        public string? BeginTime { get; set; }
        public string? IsElectrical { get; set; }
        public short? TlugameStatus { get; set; }
        public string? UserId1 { get; set; }
        public string? Remarks { get; set; }
        public int? RelatedtoGame { get; set; }
        public string? RaceMeasure { get; set; }
        public string? RaceTeam { get; set; }
        public string? WindSpeedReq { get; set; }
        public string? TrackNoReq { get; set; }
        public string? DownloadStartList { get; set; }
        public string? CommandResult { get; set; }
        public string? CommandFinalResult { get; set; }
        public string? DownloadPhotofinish { get; set; }
        public string? DownloadResult { get; set; }
        public string? ResultRemark { get; set; }
    }
}
