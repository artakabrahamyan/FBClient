using FBClient.Services;
using FBClient.Views;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace FBClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var nav = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => nav);

            var dialogService = new DialogService();
            SimpleIoc.Default.Register<IDialogService>(() => dialogService);

            //Navigation to the first page.
            var _appNavigationPage = new NavigationPage(new FBAppInfoPage());

            nav.Initialize(_appNavigationPage);
            dialogService.Initialize(_appNavigationPage);

            // The root page of your application
            MainPage = _appNavigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
