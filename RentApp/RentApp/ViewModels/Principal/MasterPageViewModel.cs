using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RentApp.Models.Response;
using RentApp.Models.SubCategory;
using RentApp.Service;
using RentApp.ViewModels.Base;
using Xamarin.Forms;

namespace RentApp.ViewModels.Principal
{
    public class MasterPageViewModel : BindableBase
    {
        ServiceClient client = new ServiceClient();

        #region Properties
        public ObservableCollection<SubCategoryModel>ListCategory{ get; set; }
        #endregion

        #region Constructor
        public MasterPageViewModel()
        {
            LoadCategory();
            SelectedItemCommand = new Command<SubCategoryModel>(SelectedItemCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand SelectedItemCommand { get; set; }
        #endregion

        #region Methods
        public async void LoadCategory()
        {
            try
            {
                ListCategory = new ObservableCollection<SubCategoryModel>();
                var token = await client.GetToken();
                if(token != null)
                {
                    var response = await client.Get<Response<List<SubCategoryModel>>>("subcategory/subcategory", token.Token);
                    if(response != null)
                    {
                        if(response.Result != null && response.Count > 0)
                        {
                            foreach(var item in response.Result)
                            {
                                ListCategory.Add(item);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        #endregion

        #region CommandExecuted
        private void SelectedItemCommandExecuted(SubCategoryModel SubCategory)
        {
            try
            {
                if(SubCategory != null)
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
