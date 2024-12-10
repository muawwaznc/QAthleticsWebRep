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

        #endregion

        #region Properties

        private string[] backstretchImages = new[]
        {
            "images/home-bg-slider-img1.jpg",
            "images/home-bg-slider-img2.jpg"
        };

        protected string currentBackground { get; set; } = "images/home-bg-slider-img1.jpg";
        private int currentIndex = 0;
        private System.Timers.Timer timer;

        protected string UserId { get; set; }
        protected string Password { get; set; }

        #endregion

        #region Load Initials

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(() =>
            {
                StartTimer();
            });
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var userId = (await ProtectedSessionStore.GetAsync<string>("UserName")).Value;
                if (!(userId == null || userId == ""))
                {
                    NavigationManager.NavigateTo("/Dashboard/" + userId);
                }
            }
        }

        #endregion

        #region Login Function

        protected async Task Signin()
        {
            var user = UserService.GetUserByEmailAndPassword(UserId, Password);
            if(user != null)
            {
                await ProtectedSessionStore.SetAsync("UserId", UserId);
                NavigationManager.NavigateTo("/Dashboard/" + UserId);
            }
            else
            {
                //Show error
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
            currentBackground = backstretchImages[currentIndex];

            InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        #endregion
    }
}
