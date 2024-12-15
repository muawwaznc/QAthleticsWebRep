using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Timers;
using System.Net;
using QAthleticsWebRep.Services.IServices;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace QAthleticsWebRep.Pages
{
    public partial class Index : ComponentBase
    {
        #region Injections

        [Inject] ProtectedSessionStorage ProtectedSessionStore { get; set; }
        [Inject] protected IJSRuntime JsRuntime { get; set; }
        [Inject] protected IUserService UserService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IFileManager FileManager { get; set; }

        #endregion

        #region Properties

		protected string? SigninBackground { get; set; } 
        protected string? UserId { get; set; }
        protected string? Password { get; set; }
        protected string? ErrorString { get; set; }

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            SigninBackground = $"{FileManager.GetImageUrl("CompetitionPhotos/competition%20background.jpg")}";
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var userId = (await ProtectedSessionStore.GetAsync<string>("UserId")).Value;
                if (!(userId == null || userId == ""))
                {
                    NavigationManager.NavigateTo("/Competitions");
                }
            }
        }

        #endregion

        #region Login Function

        protected async Task Signin()
        {
            ErrorString = "";
            try
            {
                var user = await UserService.GetUserByEmailAndPassword(UserId, Password);
                if (user != null)
                {
                    await ProtectedSessionStore.SetAsync("UserId", UserId);
                    var userId = (await ProtectedSessionStore.GetAsync<string>("UserId")).Value;
                    NavigationManager.NavigateTo("/Competitions");
                }
                else
                {
                    ErrorString = "Invalid User ID or Password...";
                }
            }
            catch(Exception)
            {
                ErrorString = "Something went wrong, please try again later.";
            }
            
        }

        #endregion
    }
}
