using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using QAthleticsWebRep.DatabaseContext;
using QAthleticsWebRep.Services.IServices;

namespace QAthleticsWebRep.Pages.UserPages
{
    public partial class Competitions : ComponentBase
    {
        
        #region Injections

        [Inject] protected IUserService UserService { get; set; }
        [Inject] ProtectedSessionStorage ProtectedSessionStore { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        #endregion

        #region Properties

        protected List<Tluchampion> ChampionsList { get; set; } = new();

        #endregion

        #region Load Initials

        protected override async Task OnInitializedAsync()
        {
            ChampionsList = await UserService.GetChampionsList();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var userId = (await ProtectedSessionStore.GetAsync<string>("UserId")).Value;
                if (userId == null || userId == "")
                {
                    NavigationManager.NavigateTo("/");
                }
            }
        }

        #endregion

        #region Navigation Function

        protected async Task Logout()
        {
            await ProtectedSessionStore.DeleteAsync("UserId");
            NavigationManager.NavigateTo("/");
        }

        #endregion
    }
}
