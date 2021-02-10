using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: ExportFont("Font Awesome 5 Brands-Regular-400.otf", Alias = "FontAwesomeBrands")]
[assembly: ExportFont("Font Awesome 5 Free-Regular-400.otf", Alias = "FontAwesomeRegular")]
[assembly: ExportFont("Font Awesome 5 Free-Solid-900.otf", Alias = "FontAwesomeSolid")]

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
