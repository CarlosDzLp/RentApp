using System;
using System.Windows.Input;
using RentApp.ViewModels.Base;
using Xamarin.Forms;

namespace RentApp.ViewModels.Session
{
    public class RegisterUserPageViewModel : BindableBase
    {
        #region Properties
        public byte[] Image { get; set; }

        public Color ColorName { get; set; } = Color.Black;
        public string Name { get; set; }

        public Color ColorLastName { get; set; } = Color.Black;
        public string LastName { get; set; }


        public string Email { get; set; }

        public Color ColorPassword { get; set; } = Color.Black;
        public string Password { get; set; }

        public Color ColorAddress { get; set; } = Color.Black;
        public string Address { get; set; }
        #endregion

        #region Constructor
        public RegisterUserPageViewModel(string email)
        {
            Email = email;
            RegisterUserCommand = new Command(RegisterUserCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand RegisterUserCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void RegisterUserCommandExecuted()
        {
            if(string.IsNullOrWhiteSpace(Name))
            {
                ColorName = Color.Red;
            }
            if (string.IsNullOrWhiteSpace(LastName))
            {
                ColorLastName = Color.Red;
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                ColorPassword = Color.Red;
            }
            if (string.IsNullOrWhiteSpace(Address))
            {
                ColorAddress = Color.Red;
            }
            Toast("Ingrese los campos");
        }
        #endregion
    }
}
