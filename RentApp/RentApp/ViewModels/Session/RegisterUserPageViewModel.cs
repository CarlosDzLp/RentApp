using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RentApp.Helpers;
using RentApp.Models.Municipality;
using RentApp.Models.Response;
using RentApp.Service;
using RentApp.ViewModels.Base;
using Xamarin.Forms;

namespace RentApp.ViewModels.Session
{
    public class RegisterUserPageViewModel : BindableBase
    {
        ServiceClient client = new ServiceClient();
        #region Properties

        public Color ColorImage { get; set; } = Color.Transparent;
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

        public Color ColorCalendar { get; set; } = Color.Black;
        public DateTime Calendar { get; set; }
        public string ValidCalendar { get; set; }

        public Color ColorMunicipality { get; set; } = Color.Black;
        public ObservableCollection<MunicipalityModel> ListMunicipality { get; set; }

        private MunicipalityModel selectedMunicipality;
        public MunicipalityModel SelectedMunicipality
        {
            get { return selectedMunicipality; }
            set { SetProperty(ref selectedMunicipality, value); }
        }
        #endregion

        #region Constructor
        public RegisterUserPageViewModel(string email)
        {
            ValidCalendar = string.Empty;
            Calendar = DateTime.Now;
            Email = email;
            RegisterUserCommand = new Command(RegisterUserCommandExecuted);
            TapImageCommand = new Command(TapImageCommandExecuted);
            LoadMunicipality();
        }
        #endregion

        #region Methods
        private async void LoadMunicipality()
        {
            ListMunicipality = new ObservableCollection<MunicipalityModel>();
            var response = await client.Get<Response<List<MunicipalityModel>>>("rentapp/municipality");
            if(response != null)
            {
                if(response.Result != null && response.Count > 0)
                {
                    foreach (var item in response.Result)
                    {
                        ListMunicipality.Add(item);
                    }
                }
                else
                {
                    Toast(response.Message);
                }
            }
            else
            {
                Toast("Algo salio mal intente mas tarde");
            }
        }
        #endregion

        #region Command
        public ICommand RegisterUserCommand { get; set; }
        public ICommand TapImageCommand { get; set; }
        #endregion

        #region CommandExecuted
        bool valid = false;
        private async void RegisterUserCommandExecuted()
        {
            try
            {
                if (Image == null)
                {
                    ColorImage = Color.Red;
                    valid = true;
                }
                else
                {
                    ColorImage = Color.Transparent;
                }
                if (string.IsNullOrWhiteSpace(Name))
                {
                    ColorName = Color.Red;
                    valid = true;
                }
                else
                {
                    ColorName = Color.Black;
                }
                if (string.IsNullOrWhiteSpace(LastName))
                {
                    ColorLastName = Color.Red;
                    valid = true;
                }
                else
                {
                    ColorLastName = Color.Black;
                }
                if (string.IsNullOrWhiteSpace(Password))
                {
                    ColorPassword = Color.Red;
                    valid = true;
                }
                else
                {
                    ColorPassword = Color.Black;
                }
                if (string.IsNullOrWhiteSpace(Address))
                {
                    ColorAddress = Color.Red;
                    valid = true;
                }
                else
                {
                    ColorAddress = Color.Black;
                }
                DateTime naci = new DateTime(Calendar.Year, Calendar.Month, Calendar.Day);
                int edad = DateTime.Today.AddTicks(-naci.Ticks).Year - 1;
                if (edad >= 18)
                {
                    ValidCalendar = string.Empty;
                    ColorCalendar = Color.Black;

                }
                else
                {
                    ValidCalendar = "Debe se mayor de edad";
                    ColorCalendar = Color.Red;
                    valid = true;
                }

                if (SelectedMunicipality == null)
                {
                    ColorMunicipality = Color.Red;
                    valid = true;
                }
                else
                {
                    ColorMunicipality = Color.Black;
                }

                if (valid)
                {
                    //hay campos vacios
                    Toast("llene todos los campos");
                    valid = false;
                }
                else
                {
                    Show("Obteniendo datos...");
                    var data = new
                    {
                        NameMunicipality = SelectedMunicipality.Name,
                        Address = Address,
                        Status = true,
                        TypeUser = 0,
                        Datebirth = Calendar,
                        LastName = LastName,
                        Password = Password,
                        IdUser = Guid.NewGuid(),
                        Name = Name,
                        Users = Email,
                        Image = string.Empty,
                        IdMunicipality = SelectedMunicipality.IdMunicipality,
                        ImageByte = Image
                    };
                    var serializer = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var response = await client.Post<Response<bool>>(serializer, "rentapp/insertuser");
                    Hide();
                    if (response != null)
                    {
                        if (response.Result && response.Count > 0)
                        {
                            Snack("Se guardo el usuario", "RentApp", TypeSnackbar.Success);
                            await App.NavigationPage.Navigation.PopToRootAsync(true);
                        }
                        else
                        {
                            Toast(response.Message);
                        }
                    }
                    else
                    {
                        Toast("Algo salio mal, intente mas tarde");
                    }
                    //SelectedMunicipality = null;
                }
            }
            catch(Exception ex)
            {
                Hide();
            }
        }

        private async void TapImageCommandExecuted()
        {
            try
            {
                string action = await App.Current.MainPage.DisplayActionSheet("RentApp?", "Cancel", null, "Galeria", "Camara");
                if(action == "Galeria")
                {
                    var photo = await Utils.PermissionsStatus(Plugin.Permissions.Abstractions.Permission.Photos);
                    if(photo)
                    {
                        Image = await PhotoCamera.PickPhoto();
                        if (Image != null)
                            ColorImage = Color.Transparent;
                    }
                    else
                    {
                        Toast("Debe de aceptar los permisos");
                    }
                }
                else if(action == "Camara")
                {
                    var camera = await Utils.PermissionsStatus(Plugin.Permissions.Abstractions.Permission.Camera);
                    if (camera)
                    {
                        Image = await PhotoCamera.TakePhoto();
                        if (Image != null)
                            ColorImage = Color.Transparent;
                    }
                    else
                    {
                        Toast("Debe de aceptar los permisos");
                    }
                }
                else
                {

                }
            }
            catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
