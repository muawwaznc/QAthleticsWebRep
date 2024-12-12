using Microsoft.EntityFrameworkCore;
using QAthleticsWebRep.DatabaseContext;
using QAthleticsWebRep.Services.IServices;

namespace QAthleticsWebRep.Services.Services
{
    public class UserService: IUserService
    {
        public async Task<Tuser> GetUserByEmailAndPassword(string userId, string password)
        {
            using (var db = new QAthleticsWebRepContext())
            {
                var user = await db.Tusers.FirstOrDefaultAsync(x => x.Userid1 == userId && x.Password1 == password);
                return user;
            }
        }

        public async Task<List<Tluchampion>> GetChampionsList()
        {
            using (var db = new QAthleticsWebRepContext())
            {
                var champions = await db.Tluchampions.Where(x => x.ChampStatus == "1").ToListAsync();
                return champions;
            }
        }
    }
}
