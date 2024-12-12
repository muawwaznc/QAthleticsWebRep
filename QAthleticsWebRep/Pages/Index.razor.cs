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

        private string[] backstretchImages = new[]
        {
            "",
            ""
        };

        protected string CurrentBackground { get; set; } = "";
		protected string SigninBackground { get; set; } = "";
		private int currentIndex = 0;
        private System.Timers.Timer timer;

        protected string UserId { get; set; }
        protected string Password { get; set; }

        protected string ErrorString { get; set; }

        #endregion

        #region Load Initials

        protected override async Task OnInitializedAsync()
        {
			SigninBackground = $"{FileManager.GetImageUrl("CompetitionPhotos/competition%20background.jpg")}";
			CurrentBackground = $"{FileManager.GetImageUrl("CompetitionPhotos/competition%20background.jpg")}";
            backstretchImages[0] = $"{FileManager.GetImageUrl("CompetitionPhotos/competition%20background.jpg")}";
            backstretchImages[1] = $"{FileManager.GetImageUrl("CompetitionPhotos/competition%20background.jpg")}";
            await Task.Run(() =>
            {
                StartTimer();
            });
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

        private async Task ScrollToSigninSection()
        {
            await JsRuntime.InvokeVoidAsync("scrollToSection", "#siginin");
        }

        #endregion

        #region Timer Functions

        private void StartTimer()
        {
            timer = new System.Timers.Timer(2000);
            timer.Elapsed += ChangeBackground;
            timer.Start();
        }

        private void ChangeBackground(object sender, ElapsedEventArgs e)
        {
            currentIndex = (currentIndex + 1) % backstretchImages.Length;
            CurrentBackground = backstretchImages[currentIndex];

            InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        #endregion
    }
}
