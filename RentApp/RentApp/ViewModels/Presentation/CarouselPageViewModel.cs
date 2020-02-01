using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using RentApp.Helpers;
using RentApp.ViewModels.Base;
using RentApp.Views.Session;

namespace RentApp.ViewModels.Presentation
{
    public class CarouselPageViewModel : BindableViewBase
    {
        #region Constructor
        public CarouselPageViewModel(INavigationService navigationService, IDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
            GetStarted = new DelegateCommand<object>(GetStartedExecuted);
        }       
        #endregion


        #region Command
        public ICommand GetStarted { get; set; }
        #endregion


        #region CommandExecuted
        private void GetStartedExecuted(object obj)
        {
            NavigationService.NavigateAsync(nameof(LoginPage), animated: true);
        }
        #endregion
    }
}
