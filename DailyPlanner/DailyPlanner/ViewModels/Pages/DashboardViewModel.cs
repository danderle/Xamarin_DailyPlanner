using System.Threading.Tasks;

namespace DailyPlanner
{
    /// <summary>
    /// The view model for the <see cref="DashboardPage"/>
    /// </summary>
    public class DashboardViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The View Model for the <see cref="PlanPage"/>
        /// </summary>
        public PlanViewModel PlanPageViewModel { get; set; }

        /// <summary>
        /// The View Model for the <see cref="ProfilePage"/>
        /// </summary>
        public ProfileViewModel ProfilePageViewModel { get; set; }

        /// <summary>
        /// The view model for the <see cref="SettingsPage"/>
        /// </summary>
        public SettingsViewModel SettingsPageViewModel { get; set; }

        /// <summary>
        /// The view model for the <see cref="SummaryPage"/>
        /// </summary>
        public SummaryViewModel SummaryPageViewModel { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="profileVM"></param>
        /// <param name="settingsVM"></param>
        /// <param name="summaryVM"></param>
        public DashboardViewModel(ProfileViewModel profileVM,
            SettingsViewModel settingsVM,
            SummaryViewModel summaryVM,
            PlanViewModel planVM)
        {
            ProfilePageViewModel = profileVM;
            SettingsPageViewModel = settingsVM;
            SummaryPageViewModel = summaryVM;
            PlanPageViewModel = planVM;
        }

        #endregion

        /// <summary>
        /// Initializes all the pages held by the <see cref="DashboardPage"/>
        /// </summary>
        /// <param name="navigationData"></param>
        /// <returns></returns>
        public override Task InitializeAsync(object navigationData = null)
        {
            return Task.WhenAny(base.InitializeAsync(navigationData),
                ProfilePageViewModel.InitializeAsync(null),
                SettingsPageViewModel.InitializeAsync(null),
                SummaryPageViewModel.InitializeAsync(null),
                PlanPageViewModel.InitializeAsync(null));
        }
    }
}
