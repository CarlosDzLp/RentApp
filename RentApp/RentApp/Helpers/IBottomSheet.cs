using System;
using System.Threading.Tasks;
namespace RentApp.Helpers
{
    public interface IBottomSheet
    {
        Task<string> Bottom();
    }
}
