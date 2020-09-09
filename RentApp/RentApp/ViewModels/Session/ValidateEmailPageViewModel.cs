using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RentApp.Font;
using RentApp.Helpers;
using RentApp.Models.Municipality;
using RentApp.Models.Response;
using RentApp.Models.Users;
using RentApp.Service;
using RentApp.ViewModels.Base;
using Xamarin.Forms;

namespace RentApp.ViewModels.Session
{
    public class ValidateEmailPageViewModel : BindableBase
    {
        ServiceClient client = new ServiceClient();
        #region Properties
        public Color ColorEmail { get; set; } = Color.FromHex("#D1D1D1");
        public Color ColorName { get; set; } = Color.FromHex("#D1D1D1");
        public Color ColorLastName { get; set; } = Color.FromHex("#D1D1D1");
        public Color ColorPassword { get; set; } = Color.FromHex("#D1D1D1");
        public Color TintColorImage { get; set; } = Color.Black;
        public bool IsVisible { get; set; } = false;
        public bool ValEmail { get; set; } = false;
        public bool ValName { get; set; } = false;
        public bool ValLastName { get; set; } = false;
        public bool ValPassword { get; set; } = false;
        public string Img { get; set; } = FontAwesomeIcons.Close;
        private string email;
        private string name;
        private string lastName;
        private string password;

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    SetProperty(ref email, value);
                    ValidateEmail();
                }
            }
        }
        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
                if (!string.IsNullOrWhiteSpace(name))
                    ValName = true;
                else
                    ValName = false;
                ValidateButtonActive();
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                SetProperty(ref lastName, value);
                if (!string.IsNullOrWhiteSpace(lastName))
                    ValLastName = true;                   
                else
                    ValLastName = false;
                ValidateButtonActive();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                SetProperty(ref password, value);
                if (!string.IsNullOrWhiteSpace(password))
                    ValPassword = true;
                else
                    ValPassword = false;
                ValidateButtonActive();
            }
        }
        public bool ActiveButton { get; set; }
        #endregion

        #region Constructor
        public ValidateEmailPageViewModel()
        {
#if DEBUG
            Email = "ryankar90@hotmail.com";
#endif
        }
        #endregion

        #region Methods
        private void ValidateButtonActive()
        {
            if(ValEmail && ValName && ValLastName && ValPassword)
            {
                ActiveButton = true;
            }
            else
            {
                ActiveButton = false;
            }
        }

        private void ValidateEmail()
        {
            if (!string.IsNullOrWhiteSpace(Email))
            {
                if (Validate.Email(Email))
                {
                    Img = FontAwesomeIcons.Done;
                    TintColorImage = Color.FromHex("#F4364C");
                    ValEmail = true;
                    IsVisible = true;
                    ValidateButtonActive();
                    ValEmailService();
                }
                else
                {
                    IsVisible = false;
                    ValEmail = false;
                    Img = FontAwesomeIcons.Close;
                    TintColorImage = Color.Red;
                }
            }
            else
            {
                IsVisible = false;
                Img = FontAwesomeIcons.Close;
                TintColorImage = Color.Red;
                ValEmail = false;
            }
            ValidateButtonActive();
        }
        #endregion

        #region CommandExecuted
        public async void ValidateEmailCommandExecuted()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Email))
                {
                    ColorEmail = Color.Red;
                    return;
                }
                else
                    ColorEmail = Color.FromHex("#D1D1D1");


                if (string.IsNullOrWhiteSpace(LastName))
                {
                    ColorLastName = Color.Red;
                    return;
                }
                else
                    ColorLastName = Color.FromHex("#D1D1D1");


                if (string.IsNullOrWhiteSpace(Password))
                {
                    ColorPassword = Color.Red;
                    return;
                }
                else
                    ColorPassword = Color.FromHex("#D1D1D1");



                ActiveButton = false;
                if (!string.IsNullOrWhiteSpace(Email))
                {
                    if (Validate.Email(Email))
                    {
                        Img = FontAwesomeIcons.Done;
                        TintColorImage = Color.FromHex("#F4364C");

                        Show("Obteniendo datos");
                        var response = await client.Get<Response<UserModel>>($"rentapp/validateuser?user={Email}");
                        Hide();
                        ActiveButton = true;
                        if (response != null)
                        {
                            if (response.Result == null && response.Count == 0)
                            {
                                //aqui se va a la otra pagina
                                var user = new UserModel()
                                {
                                    Address = string.Empty,
                                    Datebirth = null,
                                    IdMunicipality = null,
                                    IdUser = Guid.NewGuid(),
                                    Image = string.Empty,
                                    ImageByte = null,
                                    LastName = LastName,
                                    Name = name,
                                    NameMunicipality = string.Empty,
                                    Password = Password,
                                    Status = true,
                                    TypeUser = 0,
                                    Users = Email
                                };
                                await App.NavigationPage.Navigation.PushAsync(new Views.Session.SelectMunicipalityPage(user));

                                //await App.NavigationPage.Navigation.PushAsync(new Views.Session.RegisterUserPage(user));
                            }
                            else
                            {
                                ActiveButton = true;
                                Snack("El correo ya esta en uso", "RentApp", TypeSnackbar.Error);
                            }
                        }
                        else
                        {
                            Toast("Ocurrio un error, intentelo mas tarde");
                        }
                    }
                    else
                    {
                        ActiveButton = false;
                        Img = FontAwesomeIcons.Close;
                        TintColorImage = Color.Red;
                    }
                }
                else
                {
                    Toast("Ingrese un correo");
                    Img = FontAwesomeIcons.Close;
                    TintColorImage = Color.Red;
                }
            }
            catch (Exception ex)
            {
                Hide();
                ActiveButton = false;
            }
        }



        private async void ValEmailService()
        {
            Show("Obteniendo datos");
            var response = await client.Get<Response<UserModel>>($"rentapp/validateuser?user={Email}");
            Hide();
            if (response != null)
            {
                if (response.Result != null && response.Count > 0)
                {
                    Snack("El correo ya esta en uso", "RentApp", TypeSnackbar.Error);
                }
                else
                    Toast("Puede utilizar el correo");
            }
            else
            {
                Toast("Ocurrio un error, intentelo mas tarde");
            }
        }
        #endregion
    }
}
