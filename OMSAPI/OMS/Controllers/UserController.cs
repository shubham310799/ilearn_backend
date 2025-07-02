using Microsoft.AspNetCore.Mvc;
using OMS.Services.Interfaces;

namespace OMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public UserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }
        [HttpPost]           
        public async Task<IActionResult> Login()
        {
            return Ok(_authenticationService.GenerateJwt("userId"));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            return Ok();
        }
    }
}
