using System;
using System.Collections.Generic;
using TinyIoC;
using Xamarin.Forms;

namespace DailyPlanner
{
    /// <summary>
    /// Locates view models from the Ioc container for binding in the xaml files
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// The DI container
        /// </summary>
        static TinyIoCContainer container;

        /// <summary>
        /// The page look up table with the view models as the keys
        /// </summary>
        static Dictionary<Type, Type> viewLookUp;

        /// <summary>
        /// Static constructor
        /// </summary>
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
            container.Register<IAccountService, AccountService>();
        }

        /// <summary>
        /// Resolves all the dependencies
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>() where T : class
        {
            return container.Resolve<T>();
        }

        /// <summary>
        /// Creates a page according to the view model
        /// </summary>
        /// <param name="pageModelType"></param>
        /// <returns></returns>
        public static Page CreatePageFor(Type pageModelType)
        {
            var pageType = viewLookUp[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = container.Resolve(pageModelType);
            page.BindingContext = pageModel;
            return page;
        }

        /// <summary>
        /// Register the view models to their views
        /// </summary>
        /// <typeparam name="TPageViewModel"></typeparam>
        /// <typeparam name="TPage"></typeparam>
        private static void Register<TPageViewModel, TPage>()
            where TPageViewModel : BaseViewModel where TPage : Page
        {
            viewLookUp.Add(typeof(TPageViewModel), typeof(TPage));
            container.Register<TPageViewModel>();
        }
    }
}
