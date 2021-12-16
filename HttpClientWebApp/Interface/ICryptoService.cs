using HttpClientWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientWebApp.Interface
{
    public interface ICryptoService
    {
        Task<CryptoModel> GetData<T>();
    }
}
