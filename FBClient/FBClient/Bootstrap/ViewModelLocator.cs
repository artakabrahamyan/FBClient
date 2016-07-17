using FBClient.Bootstrap;
using FBClient.Managers.RestAPI;
using FBClient.Models.RestAPI.Interfaces;
using FBClient.Services;
using FBClient.Services.RestAPI;
using FBClient.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System.Dynamic;
using Xamarin.Forms;

namespace FBClient.Bootstrap
{
    public class ViewModelLocator : DynamicObject
    {
        static ViewModelResolver _resolver;
        public static NavigationPage _appNavigationPage;

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            //============================================
            //============================================
            // WebAPI client
            SimpleIoc.Default.Register<IErrorResponseBuilder, ErrorResponseBuilder>();
            SimpleIoc.Default.Register<IRestClientService, RestClientService>();
            SimpleIoc.Default.Register<IRestRequestService, RestRequestService>();

            SimpleIoc.Default.Register<IFBWebAPIContract, FBWebAPIManager>();
            SimpleIoc.Default.Register<IFBClientDispatcher, FBClientDispatcher>();

            // ----
            //Registration of ViewModel pages
            SimpleIoc.Default.Register<FBAppInfoViewModel>();
        }

        //public static NavigationPage AppNavigationPage
        //{
        //    get { return _appNavigationPage; }
        //}

        public static ViewModelResolver Resolver
        {
            get
            {
                if (_resolver == null)
                {
                    _resolver = new ViewModelResolver();
                }

                return _resolver;
            }
        }

        public object this[string viewModelName]
        {
            get
            {
                return Resolver.Resolve(viewModelName);
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this[binder.Name];
            return true;
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
            //SimpleIoc.Default.Unregister<LoginViewModel>();
        }
    }
}

