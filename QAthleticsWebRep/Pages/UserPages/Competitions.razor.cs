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
            RaceMeasureFilterList = FilteredEventsList.DistinctBy(x => x.RaceMeasure).Select(x => x.RaceMeasure).ToList();
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
            var selectedGameDateFilter = e.Value?.ToString();
            if(selectedGameDateFilter == "All")
            {
                FilteredEventsList = EventsList;
                return;
            }
            FilteredEventsList = EventsList.Where(x => x.GameDate == selectedGameDateFilter).ToList();
        }

        protected void OnRaceMeasureFilterChange(ChangeEventArgs e)
        {
            var selectedRaceMeasureFilter = e.Value?.ToString();
            if (selectedRaceMeasureFilter == "All")
            {
                FilteredEventsList = EventsList;
                return;
            }
            FilteredEventsList = EventsList.Where(x => x.RaceMeasure == selectedRaceMeasureFilter).ToList();
        }

        protected void OnClassFilterChange(ChangeEventArgs e)
        {
            var selectedClassFilter = e.Value?.ToString();
            if (selectedClassFilter == "All")
            {
                FilteredEventsList = EventsList;
                return;
            }
            FilteredEventsList = EventsList.Where(x => x.Class == selectedClassFilter).ToList();
        }

        #endregion
    }
}
