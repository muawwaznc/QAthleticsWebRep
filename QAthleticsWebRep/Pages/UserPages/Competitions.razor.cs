using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using QAthleticsWebRep.QAthleticsDatabaseContext;
using QAthleticsWebRep.Services.IServices;
using QAthleticsWebRep.Services.Services;
using QAthleticsWebRep.ViewModel;
using System;
using System.ComponentModel.Design;
using System.Globalization;

namespace QAthleticsWebRep.Pages.UserPages
{
    public partial class Competitions : ComponentBase
    {
        #region Parameters

        [Parameter] public string? UserType { get; set; }

        #endregion

        #region Injections

        [Inject] protected IUserService UserService { get; set; }
        [Inject] protected ProtectedSessionStorage ProtectedSessionStore { get; set; }
        [Inject] protected NavigationManager NavigationManager { get; set; }
        [Inject] protected IFileManager FileManager { get; set; }
        [Inject] HttpClient HttpClient { get; set; }
        [Inject] IJSRuntime JSRuntime { get; set; }

        #endregion

        #region Properties

        protected List<ChampionViewModel> ChampionsList { get; set; } = new();
        protected bool IsDialogOpen { get; set; } = false;
        protected ChampionViewModel? SelectedChampionForDialogBox { get; set; } = null;
        protected List<EventsListViewModel> EventsList { get; set; } = new();
        protected List<EventsListViewModel> FilteredEventsList { get; set; } = new();
        protected List<string?> ClassFilterList { get; set; } = new();
        protected List<string?> RaceMeasureFilterList { get; set; } = new();
        protected List<string?> GameDateFilterList { get; set; } = new();
        protected List<string?> GameDayFilterList { get; set; } = new();
        protected string? SelectedClassFilter { get; set; } = "All";
        protected string? SelectedRaceMeasureFilter { get; set; } = "All";
        protected string? SelectedGameDateFilter { get; set; } = "All";

        #endregion

        #region Load Initials

        protected string PhotoFinishUrl { get; set; } = "";

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

        #region Navigation and Dilogue Function

        protected async Task Logout()
        {
            await ProtectedSessionStore.DeleteAsync("UserId");
            NavigationManager.NavigateTo("/");
        }

        protected async Task OpenDialog(ChampionViewModel champion)
        {
            SelectedChampionForDialogBox = champion;
            EventsList = await UserService.GetEventsListByChampionId(champion.Id);
            FilteredEventsList = EventsList;
            ClassFilterList = FilteredEventsList.DistinctBy(x => x.Class).Select(x => x.Class).ToList();
            RaceMeasureFilterList = FilteredEventsList
                .Select(x =>
                    x.RaceMeasure?.ToLower() == "t" ? "Track" :
                    (x.RaceMeasure?.ToLower() == "d" || x.RaceMeasure?.ToLower() == "h" ? "Field" : x.RaceMeasure))
                .Distinct()
                .ToList();
            GameDateFilterList = FilteredEventsList
                    .Select(x => x.GameDate)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();
            GameDayFilterList = GameDateFilterList?.Select((x, index) => $"{GetOrdinal(index + 1)}").ToList();
            IsDialogOpen = true;
        }

        protected void CloseDialog()
        {
            IsDialogOpen = false;
        }

        private string GetOrdinal(int number)
        {
            if (number <= 0)
            {
                return number.ToString();
            }
            else if(number == 1)
            {
                return "First Day";
            }
            else if (number == 2)
            {
                return "Second Day";
            }
            else if (number == 3)
            {
                return "Third Day";
            }
            else
            {
                return number + "th Day";
            }
        }

        #endregion

        #region OnChange Functions

        protected void OnGameDateFilterChange(ChangeEventArgs e)
        {
            SelectedGameDateFilter = e.Value?.ToString();
            OnFilterChange();
        }

        protected void OnRaceMeasureFilterChange(ChangeEventArgs e)
        {
            SelectedRaceMeasureFilter = e.Value?.ToString();
            OnFilterChange();
        }

        protected void OnClassFilterChange(ChangeEventArgs e)
        {
            SelectedClassFilter = e.Value?.ToString();
            OnFilterChange();
        }

        private void OnFilterChange()
        {
            FilteredEventsList = EventsList;

            if (SelectedClassFilter != "All")
            {
                FilteredEventsList = FilteredEventsList
                    .Where(x => x.Class == SelectedClassFilter)
                    .ToList();
            }

            if (SelectedRaceMeasureFilter != "All")
            {
                if(SelectedRaceMeasureFilter == "Track")
                {
                    FilteredEventsList = FilteredEventsList
                        .Where(x => x.RaceMeasure?.ToLower() == "t")
                        .ToList();
                }
                else if(SelectedRaceMeasureFilter == "Field")
                {
                    FilteredEventsList = FilteredEventsList
                        .Where(x => x.RaceMeasure?.ToLower() == "d" || x.RaceMeasure?.ToLower() == "h")
                        .ToList();
                }
            }

            if (SelectedGameDateFilter != "All")
            {
                int index = GameDayFilterList.IndexOf(SelectedGameDateFilter);
                FilteredEventsList = FilteredEventsList
                    .Where(x => x.GameDate == GameDateFilterList[index])
                    .ToList();
            }
        }

        #endregion

        #region Download Functions

        protected async Task DownloadPhotoFinish(int number, int gameAutono)
        {
            var photoFinishUrl = FileManager.GetImageUrl($"CompetitionPhotos/photofinish/{number}/{gameAutono}.jpg");
            var response = await HttpClient.GetAsync(photoFinishUrl);
            if (response.IsSuccessStatusCode)
            {
                string fileName = "photoFinish.jpg";
                await JSRuntime.InvokeVoidAsync("downloadFileFromUrl", photoFinishUrl, fileName);
            }
        }

        protected async Task DownloadResult(int number, int gameAutono)
        {
            var reportUrl = FileManager.GetImageUrl($"CompetitionPhotos/ResultsPDF/{number}/{gameAutono}.pdf");
            var response = await HttpClient.GetAsync(reportUrl);
            if (response.IsSuccessStatusCode)
            {
                string fileName = "Report.pdf";
                await JSRuntime.InvokeVoidAsync("downloadFileFromUrl", reportUrl, fileName);
            }
        }

        #endregion
    }
}
