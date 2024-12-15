using QAthleticsWebRep.QAthleticsDatabaseContext;
using QAthleticsWebRep.ViewModel;

namespace QAthleticsWebRep.Services.IServices
{
    public interface IUserService
    {
        Task<Tuser> GetUserByEmailAndPassword(string userId, string password);

        Task<List<ChampionViewModel>> GetChampionsList();

        Task<List<EventsListViewModel>> GetEventsListByChampionId(int id);
    }
}
