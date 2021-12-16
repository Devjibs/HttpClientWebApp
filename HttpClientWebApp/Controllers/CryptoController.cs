using HttpClientWebApp.Interface;
using HttpClientWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HttpClientWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService _cryptoService;

        public CryptoController(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }


        [HttpGet]
        [Route("GetCryptoData")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _cryptoService.GetData<CryptoModel>();
                return (response is null) ? NotFound(response) : Ok(response);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
