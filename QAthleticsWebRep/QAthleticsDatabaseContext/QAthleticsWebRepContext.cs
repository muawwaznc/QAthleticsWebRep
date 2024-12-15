using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QAthleticsWebRep.QAthleticsDatabaseContext
{
    public partial class QAthleticsWebRepContext : DbContext
    {
        public QAthleticsWebRepContext()
        {
        }

        public QAthleticsWebRepContext(DbContextOptions<QAthleticsWebRepContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventsList> EventsLists { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<ResultsCombined> ResultsCombineds { get; set; } = null!;
        public virtual DbSet<ResultsDistance> ResultsDistances { get; set; } = null!;
        public virtual DbSet<ResultsHeight> ResultsHeights { get; set; } = null!;
        public virtual DbSet<ResultsRelay> ResultsRelays { get; set; } = null!;
        public virtual DbSet<TGame> TGames { get; set; } = null!;
        public virtual DbSet<TGameSresult> TGameSresults { get; set; } = null!;
        public virtual DbSet<TluChampionV> TluChampionVs { get; set; } = null!;
        public virtual DbSet<Tluchampion> Tluchampions { get; set; } = null!;
        public virtual DbSet<Tluclass> Tluclasses { get; set; } = null!;
        public virtual DbSet<Tluclub> Tluclubs { get; set; } = null!;
        public virtual DbSet<Tlugame> Tlugames { get; set; } = null!;
        public virtual DbSet<TlugameType> TlugameTypes { get; set; } = null!;
        public virtual DbSet<TlugamesStatus> TlugamesStatuses { get; set; } = null!;
        public virtual DbSet<Tlunationality> Tlunationalities { get; set; } = null!;
        public virtual DbSet<TluplayerStatus> TluplayerStatuses { get; set; } = null!;
        public virtual DbSet<TluresultType> TluresultTypes { get; set; } = null!;
        public virtual DbSet<Tuser> Tusers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:qafplayers.database.windows.net,1433;Database=QAthleticsWebRep;User ID=Val1;Password=Val@123456;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Arabic_CS_AS");

            modelBuilder.Entity<EventsList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Events List");

                entity.Property(e => e.BeginTime)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CallTime)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Class)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CommandFinalResult)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CommandResult)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Competition)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.DownloadPhotofinish)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DownloadResult)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DownloadStartList)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Event)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FieldTime)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.GameDate)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Game Date");

                entity.Property(e => e.GameParticipates)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GameStage)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Game Stage");

                entity.Property(e => e.GameType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IsElectrical)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.No1).HasColumnName("NO1");

                entity.Property(e => e.RaceMeasure)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RaceTeam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Remarks)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ResultRemark)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TlugameStatus).HasColumnName("TLUGameStatus");

                entity.Property(e => e.TrackNoReq)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("UserID1");

                entity.Property(e => e.WindSpeedReq)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CountryNo).HasColumnName("Country No");

                entity.Property(e => e.EventClass)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Event Class");

                entity.Property(e => e.EventName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Event Name");

                entity.Property(e => e.EventNo).HasColumnName("Event No");

                entity.Property(e => e.PibNo).HasColumnName("Pib No");

                entity.Property(e => e.PlayerCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Player Country");

                entity.Property(e => e.PlayerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Player Name");

                entity.Property(e => e.PlayerOrder).HasColumnName("Player Order");

                entity.Property(e => e.Points)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Result1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Result");

                entity.Property(e => e.Result10)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Result11)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Result12)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Result13)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Result14)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Result3)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Result4)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Result5)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Result6)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Result7)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Result8)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Result9)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Row1).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ResultsCombined>(entity =>
            {
                entity.HasKey(e => new { e.ChampionshipNo, e.EventNo, e.PibNo })
                    .HasName("PK_TV_Combined");

                entity.ToTable("Results_Combined");

                entity.Property(e => e.EventNo).HasColumnName("Event No");

                entity.Property(e => e.PibNo).HasColumnName("Pib No");

                entity.Property(e => e.SubEventName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Sub Event Name");

                entity.Property(e => e.SubEventOrder).HasColumnName("Sub Event Order");

                entity.Property(e => e.SubEventPoints).HasColumnName("Sub Event Points");

                entity.Property(e => e.SubEventResult)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Sub Event Result");
            });

            modelBuilder.Entity<ResultsDistance>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Results_Distance");

                entity.Property(e => e.AttempResult)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AttempWindSpeed)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EventNo).HasColumnName("Event No");

                entity.Property(e => e.PibNo).HasColumnName("Pib No");
            });

            modelBuilder.Entity<ResultsHeight>(entity =>
            {
                entity.HasKey(e => new { e.ChampionshipNo, e.EventNo, e.PibNo })
                    .HasName("PK_TV_HEIGHTS");

                entity.ToTable("Results_HEIGHT");

                entity.Property(e => e.EventNo).HasColumnName("Event No");

                entity.Property(e => e.PibNo).HasColumnName("Pib No");

                entity.Property(e => e.Hight)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Result)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ResultsRelay>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Results_Relays");

                entity.Property(e => e.Athlete)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Athlete ");

                entity.Property(e => e.EventNo).HasColumnName("Event No");

                entity.Property(e => e.PibNo).HasColumnName("Pib No");

                entity.Property(e => e.Tluclub).HasColumnName("TLUCLUB");
            });

            modelBuilder.Entity<TGame>(entity =>
            {
                entity.HasKey(e => e.GameAutono)
                    .HasName("PK_tGame_1");

                entity.ToTable("tGame");

                entity.Property(e => e.GameAutono).ValueGeneratedNever();

                entity.Property(e => e.BeginTime)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CallTime)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CheckName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CommandFinalResult)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CommandResult)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompititionRecord)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Compitition Record");

                entity.Property(e => e.DataEntry)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DownloadPhotofinish)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DownloadResult)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DownloadStartList)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ElectronicDistance)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FieldTime)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.GameDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.GameDescr)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.GameGroup).HasDefaultValueSql("((0))");

                entity.Property(e => e.GameParticipates)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength();

                entity.Property(e => e.GameType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength();

                entity.Property(e => e.IsElectrical)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.JudgeName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PointsLimit)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Points Limit");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ResultApprovedDateTime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Result Approved DateTime");

                entity.Property(e => e.ResultFinishedDatetime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Result Finished Datetime");

                entity.Property(e => e.ResultRemark)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tlucahmpion)
                    .HasColumnName("TLUCahmpion")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tluclass)
                    .HasColumnName("tluclass")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tlugame)
                    .HasColumnName("TLUGame")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TlugameStatus).HasColumnName("TLUGameStatus");

                entity.Property(e => e.UserId1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("UserID1");

                entity.Property(e => e.WindSpeed)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.TlucahmpionNavigation)
                    .WithMany(p => p.TGames)
                    .HasForeignKey(d => d.Tlucahmpion)
                    .HasConstraintName("FK_tGame_TLUChampion");

                entity.HasOne(d => d.TluclassNavigation)
                    .WithMany(p => p.TGames)
                    .HasForeignKey(d => d.Tluclass)
                    .HasConstraintName("FK_tGame_TLUClass");

                entity.HasOne(d => d.TlugameNavigation)
                    .WithMany(p => p.TGames)
                    .HasForeignKey(d => d.Tlugame)
                    .HasConstraintName("FK_tGame_TLUGame");
            });

            modelBuilder.Entity<TGameSresult>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tGameSResults");

                entity.Property(e => e.GameNo).HasColumnName("GameNO");

                entity.Property(e => e.PlayerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerRemark)
                    .HasMaxLength(50)
                    .HasComment("new record or DQ remarks or micro seconds for result for equeals");

                entity.Property(e => e.PlayerResult)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TluChampionV>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("tluChampionV");

                entity.Property(e => e.Caddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAddress");

                entity.Property(e => e.Descr1)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Expr1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EXPR1");

                entity.Property(e => e.No1).HasColumnName("no1");

                entity.Property(e => e.Startdate)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("startdate");
            });

            modelBuilder.Entity<Tluchampion>(entity =>
            {
                entity.HasKey(e => e.No1);

                entity.ToTable("TLUChampion");

                entity.Property(e => e.No1)
                    .ValueGeneratedNever()
                    .HasColumnName("no1");

                entity.Property(e => e.Caddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAddress");

                entity.Property(e => e.Calculatedby)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ChampStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Descr1)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Edescr1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EDescr1");

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShowAthletePhoto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShowCahmpPhoto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShowClubPhoto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TeamsType)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tluclass>(entity =>
            {
                entity.HasKey(e => e.No1);

                entity.ToTable("TLUClass");

                entity.Property(e => e.No1)
                    .ValueGeneratedNever()
                    .HasColumnName("no1");

                entity.Property(e => e.Descr1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Edescr1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EDescr1");
            });

            modelBuilder.Entity<Tluclub>(entity =>
            {
                entity.HasKey(e => e.No1);

                entity.ToTable("TLUClub");

                entity.Property(e => e.No1)
                    .ValueGeneratedNever()
                    .HasColumnName("no1");

                entity.Property(e => e.Descr1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Edescr1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EDescr1");
            });

            modelBuilder.Entity<Tlugame>(entity =>
            {
                entity.HasKey(e => e.No1);

                entity.ToTable("TLUGame");

                entity.Property(e => e.No1)
                    .ValueGeneratedNever()
                    .HasColumnName("no1");

                entity.Property(e => e.Descr1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Edescr1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EDescr1");

                entity.Property(e => e.OshSecondsReq)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RaceField)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RaceMeasure)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RaceTeam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TrackNoReq)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WindSpeedReq)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TlugameType>(entity =>
            {
                entity.HasKey(e => e.No1);

                entity.ToTable("TLUGameTypes");

                entity.Property(e => e.No1)
                    .ValueGeneratedNever()
                    .HasColumnName("NO1");

                entity.Property(e => e.Descr1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("descr1");

                entity.Property(e => e.Edescr1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("edescr1");
            });

            modelBuilder.Entity<TlugamesStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TLUGamesStatus");

                entity.Property(e => e.Descr1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("descr1");

                entity.Property(e => e.Edescr1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("edescr1");

                entity.Property(e => e.No1).HasColumnName("no1");
            });

            modelBuilder.Entity<Tlunationality>(entity =>
            {
                entity.HasKey(e => e.No1);

                entity.ToTable("TLUNationality");

                entity.Property(e => e.No1)
                    .ValueGeneratedNever()
                    .HasColumnName("no1");

                entity.Property(e => e.Descr1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Edescr1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EDescr1");
            });

            modelBuilder.Entity<TluplayerStatus>(entity =>
            {
                entity.HasKey(e => e.No1);

                entity.ToTable("TLUPlayerStatus");

                entity.Property(e => e.No1)
                    .ValueGeneratedNever()
                    .HasColumnName("no1");

                entity.Property(e => e.Descr1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Edescr1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EDescr1");
            });

            modelBuilder.Entity<TluresultType>(entity =>
            {
                entity.HasKey(e => e.No1);

                entity.ToTable("TLUResultTypes");

                entity.Property(e => e.No1)
                    .ValueGeneratedNever()
                    .HasColumnName("NO1");

                entity.Property(e => e.Descr1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("descr1");

                entity.Property(e => e.Edescr1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("edescr1");
            });

            modelBuilder.Entity<Tuser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TUSERS");

                entity.Property(e => e.Password1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD1");

                entity.Property(e => e.UserIdno1)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("UserIDNo1");

                entity.Property(e => e.UserLetters)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserName1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserRemarks)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Userfunctions)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USERFUNCTIONS");

                entity.Property(e => e.Userid1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USERID1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
