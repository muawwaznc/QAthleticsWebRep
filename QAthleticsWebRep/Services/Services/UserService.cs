using Microsoft.EntityFrameworkCore;
using QAthleticsWebRep.QAthleticsDatabaseContext;
using QAthleticsWebRep.Services.IServices;
using QAthleticsWebRep.ViewModel;
using System.Formats.Asn1;
using System.Security.AccessControl;

namespace QAthleticsWebRep.Services.Services
{
    public class UserService: IUserService
    {
        private readonly IFileManager _fileManager;
        public UserService(IFileManager fileManager) 
        {
            _fileManager = fileManager;
        }

        public async Task<Tuser> GetUserByEmailAndPassword(string userId, string password)
        {
            using (var db = new QAthleticsWebRepContext())
            {
                var user = await db.Tusers.FirstOrDefaultAsync(x => x.Userid1 == userId && x.Password1 == password);
                return user;
            }
        }

        public async Task<List<ChampionViewModel>> GetChampionsList()
        {
            using (var db = new QAthleticsWebRepContext())
            {
                var champions = await db.Tluchampions.Where(x => x.ChampStatus == "1").Select(x => new ChampionViewModel
                {
                    Id = x.No1,
                    Name = x.Descr1,
                    Image = _fileManager.GetImageUrl($"CompetitionPhotos/ChampionshipPhotos/{x.No1}.jpg"),
                    Address = x.Caddress,
                    StartDate = x.StartDate.HasValue ? DateOnly.FromDateTime(x.StartDate.Value).ToString("dd/MM/yyyy") : null,
                    EndDate = x.EndDate.HasValue ? DateOnly.FromDateTime(x.EndDate.Value).ToString("dd/MM/yyyy") : null
                }).ToListAsync();
                return champions;
            }
        }

        public async Task<List<EventsListViewModel>> GetEventsListByCompetetionId(int id)
        {
            using (var db = new QAthleticsWebRepContext())
            {
                var eventsList = await db.EventsLists.Where(x => x.No1 == id).Select(x => new EventsListViewModel
                {
                    Class = x.Class,
                    Event = x.Event,
                    GameGroup = x.GameGroup,
                    GameStage = x.GameStage,
                    Status = x.Status,
                    GameDate = x.GameDate,
                    BeginTime = x.BeginTime,
                    RaceMeasure = x.RaceMeasure,
                    RaceTeam = x.RaceTeam,
                    DownloadStartList = x.DownloadStartList,
                    CommandResult = x.CommandResult,
                    CommandFinalResult = x.CommandFinalResult,
                    DownloadPhotofinish = x.DownloadPhotofinish,
                    DownloadResult = x.DownloadResult,
                    ResultRemark = x.ResultRemark
                }).ToListAsync();
                return eventsList;
            }

        }
    }
}
