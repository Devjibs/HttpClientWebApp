using HttpClientWebApp.Models;
using System.Threading.Tasks;

namespace HttpClientWebApp.Interface
{
    public interface IHttpCallService
    {
        Task<T> GetData<T>();
    }
}
