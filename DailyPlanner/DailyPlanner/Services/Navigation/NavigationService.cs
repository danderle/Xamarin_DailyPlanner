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
            where TPageModelBase : BaseViewModel
        {
            var page = ViewModelLocator.CreatePageFor(typeof(TPageModelBase));

            if(setRoot)
            {
                if(page is TabbedPage tabbedPage)
                {
                    App.Current.MainPage = tabbedPage;
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
            }
            else
            {
                if(page is TabbedPage tabPage)
                {
                    App.Current.MainPage = tabPage;
                }
                else if(App.Current.MainPage is NavigationPage navPage)
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
