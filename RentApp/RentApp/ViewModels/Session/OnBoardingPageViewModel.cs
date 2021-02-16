using System;
using System.Windows.Input;
using RentApp.ViewModels.Base;
using Xamarin.Forms;

namespace RentApp.ViewModels.Session
{
    public class OnBoardingPageViewModel : BindableBase
    {
        #region Properties

        #endregion

        #region Constructor
        public OnBoardingPageViewModel()
        {
            LogInCommand = new Command(LogInCommandExecuted);
            RegisterCommand = new Command(RegisterCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand LogInCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void LogInCommandExecuted()
        {
            try
            {
                App.Current.MainPage.Navigation.PushAsync(new Views.Session.LogInPage());
            }
            catch(Exception ex)
            {

            }
        }

        private void RegisterCommandExecuted()
        {
            try
            {
                App.Current.MainPage.Navigation.PushAsync(new Views.Session.RegisterPage());
            }
            catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
