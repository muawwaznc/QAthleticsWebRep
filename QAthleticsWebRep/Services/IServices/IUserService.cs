using QAthleticsWebRep.DatabaseContext;

namespace QAthleticsWebRep.Services.IServices
{
    public interface IUserService
    {
        Task<Tuser> GetUserByEmailAndPassword(string userId, string password);
    }
}
