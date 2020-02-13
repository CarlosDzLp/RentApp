using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using RentApp.Helpers;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;
using Prism.Commands;

namespace RentApp.ViewModels.Base
{
    public class BindableViewBase : BindableBase, INavigationAware, IDestructible
    {
        #region Properties
        private string title;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        #endregion

        protected INavigationService NavigationService { get; private set; }
        protected IDialogs UserDialogsService { get; private set; }

        #region Constructor
        public BindableViewBase(INavigationService navigationService, IDialogs userDialogsService)
        {
            NavigationService = navigationService;
            UserDialogsService = userDialogsService;
            GoBackCommand = new DelegateCommand(GoBackCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand GoBackCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void GoBackCommandExecuted()
        {
            NavigationService.GoBackAsync();
        }
        #endregion

        public virtual void OnNavigatedFrom(INavigationParameters parameters)  {  }

        public virtual void OnNavigatedTo(INavigationParameters parameters)  { }

        public virtual void Destroy() { }
    }
}
