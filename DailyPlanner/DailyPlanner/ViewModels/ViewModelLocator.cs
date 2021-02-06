using System;
using System.Collections.Generic;
using TinyIoC;
using Xamarin.Forms;

namespace DailyPlanner
{
    public class ViewModelLocator
    {
        static TinyIoCContainer container;
        static Dictionary<Type, Type> viewLookUp;

        static ViewModelLocator()
        {
            container = new TinyIoCContainer();
            viewLookUp = new Dictionary<Type, Type>();

            // Register pages and page models
            Register<DashboardViewModel, DashboardPage>();
            Register<LoginViewModel, LoginPage>();
            Register<ProfileViewModel, ProfilePage>();


            //Register services (services are registered as singletons default)
            container.Register<INavigationService, NavigationService>();
        }

        public static T Resolve<T>() where T : class
        {
            return container.Resolve<T>();
        }

        public static Page  CreatePageFor(Type pageModelType)
        {
            var pageType = viewLookUp[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = container.Resolve(pageModelType);
            page.BindingContext = pageModel;
            return page;
        }

        private static void Register<TPageViewModel, TPage>()
            where TPageViewModel : BaseViewModel where TPage : Page
        {
            viewLookUp.Add(typeof(TPageViewModel), typeof(TPage));
            container.Register<TPageViewModel>();
        }
    }
}
