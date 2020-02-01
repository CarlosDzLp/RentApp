using System;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using RentApp.Controls;
using RentApp.Service;
using RentApp.ViewModels.Presentation;
using RentApp.ViewModels.Session;
using RentApp.Views.Session;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            Device.SetFlags(new[] {
                "CarouselView_Experimental",
                "IndicatorView_Experimental"
            });
            NavigationService.NavigateAsync(new System.Uri("/NavigationViewPage/CarouselPage", System.UriKind.Absolute));
        }

        public static NavigationPage NavigationViewPage { get; set; }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationViewPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<Views.Presentation.CarouselPage, CarouselPageViewModel>();




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
