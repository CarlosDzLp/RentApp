using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RentApp.Models.Municipality;
using RentApp.Models.Response;
using RentApp.Models.Users;
using RentApp.Service;
using RentApp.ViewModels.Base;
using Xamarin.Forms;

namespace RentApp.ViewModels.Session
{
    public class SelectMunicipalityPageViewModel : BindableBase
    {
        #region Properties
        ServiceClient client = new ServiceClient();
        public ObservableCollection<MunicipalityModel> ListMunicipality { get; set; }
        public UserModel UserModel { get; set; }
        #endregion

        #region Constructor
        public SelectMunicipalityPageViewModel(UserModel user)
        {
            this.UserModel = user;
            LoadMunicipality();
            SelectedItemMunicipalityCommand = new Command<MunicipalityModel>(SelectedItemMunicipalityCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand SelectedItemMunicipalityCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void SelectedItemMunicipalityCommandExecuted(MunicipalityModel municipality)
        {
            try
            {
                if(municipality != null)
                {

                }
            }
            catch(Exception ex)
            {

            }
        }
        #endregion

        #region Methods
        private async void LoadMunicipality()
        {
            ListMunicipality = new ObservableCollection<MunicipalityModel>();
            var response = await client.Get<Response<List<MunicipalityModel>>>("rentapp/municipality");
            if (response != null)
            {
                if (response.Result != null && response.Count > 0)
                {
                    foreach (var item in response.Result.OrderBy(c=>c.Name))
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
    }
}
