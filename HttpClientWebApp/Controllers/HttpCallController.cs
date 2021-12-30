using HttpClientWebApp.Interface;
using HttpClientWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HttpClientWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HttpCallController : ControllerBase
    {
        private readonly IHttpCallService _httpCallService;

        public HttpCallController(IHttpCallService httpCallService)
        {
            _httpCallService = httpCallService;
        }


        [HttpGet]
        [Route("GetData")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _httpCallService.GetData<DataModel>();
                return (response is null) ? NotFound(response) : Ok(response);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
