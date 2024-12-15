using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using QAthleticsWebRep.QAthleticsDatabaseContext;
using QAthleticsWebRep.Services.IServices;
using QAthleticsWebRep.ViewModel;
using System.ComponentModel.Design;

namespace QAthleticsWebRep.Pages.UserPages
{
    public partial class Competitions : ComponentBase
    {

        #region Injections

        [Inject] protected IUserService UserService { get; set; }
        [Inject] protected ProtectedSessionStorage ProtectedSessionStore { get; set; }
        [Inject] protected NavigationManager NavigationManager { get; set; }

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
        protected string? SelectedClassFilter { get; set; } = "All";
        protected string? SelectedRaceMeasureFilter { get; set; } = "All";
        protected string? SelectedGameDateFilter { get; set; } = "All";

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
            GameDateFilterList = FilteredEventsList.DistinctBy(x => x.GameDate).Select(x => x.GameDate).ToList();
            IsDialogOpen = true;
        }

        protected void CloseDialog()
        {
            IsDialogOpen = false;
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
                FilteredEventsList = FilteredEventsList
                    .Where(x => x.GameDate == SelectedGameDateFilter)
                    .ToList();
            }
        }

        #endregion
    }
}
