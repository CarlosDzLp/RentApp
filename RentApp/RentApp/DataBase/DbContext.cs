using System;
using System.Threading.Tasks;
using RentApp.Helpers;
using RentApp.Models.Company;
using RentApp.Models.Tokens;
using RentApp.Models.Users;
using SQLite;
using Xamarin.Forms;

namespace RentApp.DataBase
{
    public class DbContext
    {
        #region Singleton
        private static DbContext _instance = null;
        public static DbContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbContext();
                }
                return _instance;
            }
        }
        #endregion


        #region Constructor
        private readonly SQLiteConnection connection;
        public DbContext()
        {
            try
            {
                var dbPath = DependencyService.Get<IPath>().FilePath();
                connection = new SQLiteConnection(dbPath, true);
                connection.CreateTable<TokenRequest>();
                connection.CreateTable<UserModel>();
                connection.CreateTable<CompanyModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Token
        public void InsertToken(TokenRequest token)
        {
            try
            {
                connection.DeleteAll<TokenRequest>();
                connection.Insert(token);
            }
            catch(Exception ex)
            {

            }
        }
        public async Task<TokenRequest> GettToken()
        {
            try
            {
                return connection.Table<TokenRequest>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region User
        public void InsertUser(UserModel user)
        {
            try
            {
                connection.DeleteAll<UserModel>();
                connection.Insert(user);
            }
            catch(Exception ex)
            {

            }
        }
        public UserModel GetUser()
        {
            try
            {
                return connection.Table<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Company
        public void InsertCompany(CompanyModel company)
        {
            try
            {
                connection.DeleteAll<CompanyModel>();
                connection.Insert(company);
            }
            catch(Exception ex)
            {

            }
        }
        public CompanyModel GetCompany()
        {
            try
            {
                return connection.Table<CompanyModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
