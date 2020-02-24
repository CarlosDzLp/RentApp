using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RentApp.Models.Menus;
using RentApp.ViewModels.Base;
using Xamarin.Forms;

namespace RentApp.ViewModels.Principal.User
{
    public class UserMasterDetailPageMasterViewModel : BindableViewBase
    {
        #region properties
        private ObservableCollection<MenusModel> _listMenuUser;
        public ObservableCollection<MenusModel> ListMenuUser
        {
            get { return _listMenuUser; }
            set { SetProperty(ref _listMenuUser, value); }
        }
        #endregion

        #region Constructor
        public UserMasterDetailPageMasterViewModel()
        {
            LoadMenu();
            SelectedMenuUser = new Command<MenusModel>(SelectedMenuUserExecuted); 
        }
        #endregion

        #region Methods
        private async Task LoadMenu()
        {
            ListMenuUser = new ObservableCollection<MenusModel>();
            ListMenuUser.Clear();
            ListMenuUser.Add(new MenusModel
            {
                Id = 0,
                ColorBox = Color.Black,
                Title = "Inicio",
                Icon = "ic_home",
                NavigationPath = string.Empty
            });
            ListMenuUser.Add(new MenusModel
            {
                Id = 1,
                ColorBox = Color.FromHex("#EDEDED"),
                Title = "Mensajes",
                Icon = "ic_message",
                NavigationPath = "Navigation/ProfileUser"
            });
            ListMenuUser.Add(new MenusModel
            {
                Id = 2,
                ColorBox = Color.FromHex("#EDEDED"),
                Title = "Mi Cuenta",
                Icon = "ic_account",
                NavigationPath = "Navigation/ProfileUser"
            });

        }

        private void ResetList(MenusModel menus)
        {
            foreach(var item in ListMenuUser)
            {
                if (menus.Id == item.Id)
                    item.ColorBox = Color.Black;
                else
                    item.ColorBox = Color.FromHex("#EDEDED");
            }
        }
        #endregion

        #region Command
        public Command<MenusModel> SelectedMenuUser { get; set; }
        #endregion

        #region CommandExecuted
        private void SelectedMenuUserExecuted(MenusModel obj)
        {
            if(obj != null)
            {
                ResetList(obj);
                if (!string.IsNullOrWhiteSpace(obj.NavigationPath))
                {
                    App.MasterDetail.IsPresented = false;
                    //NavigationService.NavigateAsync(obj.NavigationPath);
                }
                else
                {
                    App.MasterDetail.IsPresented = false;
                }
            }
        }
        #endregion
    }
}
