using System.Windows.Input;

namespace DailyPlanner
{
    /// <summary>
    /// View Model for the <see cref="LoginPage"/>
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Private Fields

        private INavigationService navigatioService;

        #endregion

        #region Commands

        public ICommand SignInCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="_navigatioService"></param>
        public LoginViewModel(INavigationService _navigatioService)
        {
            navigatioService = _navigatioService;
            SignInCommand = new RelayCommand(SignIn);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Signs in and loads the dashboard page
        /// </summary>
        private void SignIn()
        {
            navigatioService.NavigateToAsync<DashboardViewModel>();
        } 

        #endregion
    }
}
