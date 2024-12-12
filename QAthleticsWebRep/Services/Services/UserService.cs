using Microsoft.EntityFrameworkCore;
using QAthleticsWebRep.DatabaseContext;
using QAthleticsWebRep.Services.IServices;
using QAthleticsWebRep.ViewModel;

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

        public async Task<List<ChampionViewModel>> GetChampionsList()
        {
            using (var db = new QAthleticsWebRepContext())
            {
                var champions = await db.Tluchampions.Where(x => x.ChampStatus == "1").Select(x => new ChampionViewModel
                {
                    Name = x.Descr1,
                    Address = x.Caddress,
                    StartDate = x.StartDate.HasValue ? DateOnly.FromDateTime(x.StartDate.Value).ToString("dd/MM/yyyy") : null,
                    EndDate = x.EndDate.HasValue ? DateOnly.FromDateTime(x.EndDate.Value).ToString("dd/MM/yyyy") : null
                }).ToListAsync();
                return champions;
            }
        }
    }
}
