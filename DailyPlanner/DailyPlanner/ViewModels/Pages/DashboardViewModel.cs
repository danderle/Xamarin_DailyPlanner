using System.Threading.Tasks;

namespace DailyPlanner
{
    public class DashboardViewModel : BaseViewModel
    {
        #region Public Properties

        public ProfileViewModel ProfilePageViewModel { get; set; }
        public SettingsViewModel SettingsPageViewModel { get; set; }

        #endregion

        #region Constructor

        public DashboardViewModel(ProfileViewModel profileVM,
            SettingsViewModel settingsVM)
        {
        }

        #endregion

        public override Task InitializeAsync(object navigationData = null)
        {
            return Task.WhenAny(base.InitializeAsync(navigationData),
                ProfilePageViewModel.InitializeAsync(null),
                SettingsPageViewModel.InitializeAsync(null));
        }
    }
}
