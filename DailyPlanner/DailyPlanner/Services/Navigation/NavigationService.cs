using System.Threading.Tasks;
using Xamarin.Forms;

namespace DailyPlanner
{
    public class NavigationService : INavigationService
    {
        public Task GoBackAsync()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task NavigateToAsync<TPageModelBase>(object navigationData = null, bool setRoot = false)
        {
            var page = ViewModelLocator.CreatePageFor(typeof(TPageModelBase));

            if(setRoot)
            {
                App.Current.MainPage = new NavigationPage(page);
            }
            else
            {
                if(App.Current.MainPage is NavigationPage navPage)
                {
                    await navPage.PushAsync(page);
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
            }

            if(page.BindingContext is BaseViewModel baseVM)
            {
                await baseVM.InitializeAsync(navigationData);
            }

            await Task.CompletedTask;
        }
    }
}
