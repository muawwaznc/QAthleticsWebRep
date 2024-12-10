using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Timers;
using System.Net;

namespace QAthleticsWebRep.Pages
{
    public partial class Index : ComponentBase
    {
        #region Injections

        [Inject] protected IJSRuntime JsRuntime { get; set; }

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

        protected string Email { get; set; }
        protected string Password { get; set; }

        #endregion

        #region Load Initials

        protected override void OnInitialized()
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
            // Dispose the timer
            timer?.Dispose();
        }

        #endregion

        #region Login Function

        protected async Task Signin()
        {

        }

        private async Task ScrollToSigninSection()
        {
            await JsRuntime.InvokeVoidAsync("scrollToSection", "#siginin");
        }

        #endregion
    }
}
