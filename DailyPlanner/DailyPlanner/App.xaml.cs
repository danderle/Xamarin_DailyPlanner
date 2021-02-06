using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyPlanner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        Task InitNavigation()
        {
            var navService = ViewModelLocator.Resolve<INavigationService>();
            return navService.NavigateToAsync<LoginViewModel>();
        }

        protected override async void OnStart()
        {
            await InitNavigation();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
