using System;
using System.Net;
using IoTProjectWeek6.Data;
using IoTProjectWeek6.Model;
using IoTProjectWeek6.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IoTProjectWeek6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger _logger;
        
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        
        // POST api/values
        [HttpPost]
        public void Post([FromBody] LoginRequestViewModel request)
        {
            IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());
            var ip = heserver.AddressList[0].ToString();
            
            var item = new LoginRequest
            {
                Password = request.Password,
                Username = request.Username,
                IpAddress = ip,
                RequestDate = DateTime.Now
            };

            try
            {
                DbService.InsertLoginRequest(item);
            }
            catch (Exception e)
            {
                _logger.LogError("InsertLoginRequest(item) THROWS AN ERROR", e);
                throw;
            }
        }

        [HttpGet]
        public LoginRequest[] Get()
        {
            try
            {
                return DbService.GetLatestEntries();
            }
            catch (Exception e)
            {
                _logger.LogError("GetLatestEntries() THROWS AN ERROR", e);
                throw;
            }
        }
    }
}