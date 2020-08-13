using System.Collections.Generic;
using System.Threading.Tasks;

namespace JTM2_Passwords_Mobile_App
{
    public interface IRestService
    {
        Task<List<JTM2_Password>> RefreshDataAsync();
    }
}
