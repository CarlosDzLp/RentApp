using System;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using RentApp.Controls;
using RentApp.Service;
using RentApp.ViewModels.Presentation;
using RentApp.ViewModels.Principal.Administrator;
using RentApp.ViewModels.Principal.User;
using RentApp.ViewModels.Session;
using RentApp.Views.Principal.Administrator;
using RentApp.Views.Principal.User;
using RentApp.Views.Session;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentApp
{
    public partial class App : PrismApplication
    {
        public static string Email { get; set; }
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            Device.SetFlags(new[] {
                "CarouselView_Experimental",
                "IndicatorView_Experimental"
            });
            NavigationService.NavigateAsync(new System.Uri("/Navigation/CarouselPage", System.UriKind.Absolute));
            //NavigationService.NavigateAsync(new System.Uri("/MasterAdmin", System.UriKind.Absolute));
        }

        public static MasterDetailPage MasterDetail { get; set; }
        public static NavigationViewPage NavigationViewPage { get; set; }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationViewPage>("Navigation");

            //Carousel Presentation
            containerRegistry.RegisterForNavigation<Views.Presentation.CarouselPage, CarouselPageViewModel>();

            //Login And RegisterAccount
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterAdminPage, RegisterAdminPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterUserPage, RegisterUserPageViewModel>();
            containerRegistry.RegisterForNavigation<ValidateUserPopup, ValidateUserPopupViewModel>();
            containerRegistry.RegisterForNavigation<LocationPage, LocationPageViewModel>();


            //MasterDetail User
            containerRegistry.RegisterForNavigation<UserMasterDetailPage>("MasterDetailUser");
            containerRegistry.RegisterForNavigation<UserMasterDetailPageDetail,UserMasterDetailPageDetailViewModel>("HomeUser");
            containerRegistry.RegisterForNavigation<UserMasterDetailPageMaster, UserMasterDetailPageMasterViewModel>("MenuUser");


            //MasterAdministrador
            containerRegistry.RegisterForNavigation<AdminMasterTabbedPage>("MasterAdmin");
            containerRegistry.RegisterForNavigation<AccountAdminPage, AccountAdminPageViewModel>("AccountAdmin");
            containerRegistry.RegisterForNavigation<HomeAdminPage>("HomeAdmin");
            containerRegistry.RegisterForNavigation<SearchAdminPage>("SearchAdmin");

            //Services
            containerRegistry.Register<IServiceClient, ServiceClient>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
