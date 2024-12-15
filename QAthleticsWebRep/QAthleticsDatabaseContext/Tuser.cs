using System;
using System.Collections.Generic;

namespace QAthleticsWebRep.QAthleticsDatabaseContext
{
    public partial class Tuser
    {
        public string Userid1 { get; set; } = null!;
        public string? Password1 { get; set; }
        public string? Userfunctions { get; set; }
        public string? UserName1 { get; set; }
        public string? UserIdno1 { get; set; }
        public short? Usertype { get; set; }
        public int? UserBalance { get; set; }
        public string? UserRemarks { get; set; }
        public int? UserNo { get; set; }
        public string? UserLetters { get; set; }
    }
}
