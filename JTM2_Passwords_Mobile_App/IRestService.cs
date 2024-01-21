using System.Collections.Generic;
using System.Threading.Tasks;

namespace JTM2_Passwords_Mobile_App
{
    public interface IRestService
    {
        Task<List<ItemViewModel>> RefreshDataAsync();
        Task<bool> SaveDataAsync(ItemViewModel pw);
        Task<bool> DeleteDataAsync(string strPasswordId);
        Task<bool> CreateDataAsync(string strWebsite, string strPassword, string strUrl, string strNotes);

    }
}
