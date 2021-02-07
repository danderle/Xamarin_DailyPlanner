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

        private IAccountService accountService;

        #endregion

        #region Public Properties

        public string Username { get; set; }

        public string Password { get; set; }

        #endregion

        #region Commands

        public ICommand SignInCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="_navigatioService"></param>
        public LoginViewModel(INavigationService _navigatioService, IAccountService _accountSerivice)
        {
            accountService = _accountSerivice;
            navigatioService = _navigatioService;
            SignInCommand = new RelayCommand(SignIn);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Signs in and loads the dashboard page
        /// </summary>
        private async void SignIn()
        {
            var loginAttempt = await accountService.LogAsync(Username, Password);
            if(loginAttempt)
            {
                //navigate to the Dashboard
                await navigatioService.NavigateToAsync<DashboardViewModel>();
            }
            else
            {
                // TODO: Display an Alert for Failure!
            }

        } 

        #endregion
    }
}
