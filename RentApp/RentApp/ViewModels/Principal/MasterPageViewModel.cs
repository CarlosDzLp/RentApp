using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RentApp.DataBase;
using RentApp.Models.Response;
using RentApp.Models.SubCategory;
using RentApp.Models.Tokens;
using RentApp.Service;
using RentApp.ViewModels.Base;

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
        }
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
    }
}
