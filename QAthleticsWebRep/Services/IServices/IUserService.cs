using QAthleticsWebRep.QAthleticsDatabaseContext;
using QAthleticsWebRep.ViewModel;

namespace QAthleticsWebRep.Services.IServices
{
    public interface IUserService
    {
        Task<Tuser?> GetUserByUserIdAndPassword(string? userId, string? password);

        Task<Tuser?> GetUserByUserId(string? userId);

        Task<List<ChampionViewModel>> GetChampionsList();

        Task<List<EventsListViewModel>> GetEventsListByChampionId(int id);
    }
}
