using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTDD.api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class HomeController : ControllerBase
    {
        private ICustomerService _customerService;
        private IManagerService _managerService;
        private ITokenService _tokenService;

        public HomeController(ICustomerService customerService, IManagerService managerService, ITokenService tokenService)
        {
            _customerService = customerService;
            _managerService = managerService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult CustomerRegister([FromBody] CustomerRegisterDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _customerService.CustomerRegister(customerDto);

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult LoginCustomer([FromBody] CustomerLoginDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _customerService.LoginCustomer(customerDto.CardNumber, customerDto.Password);
            var token = _tokenService.GenerateToken(customer);

            return Ok(token);
        }

        [HttpPost]
        [Route("Manager")]
        public IActionResult LoginManager([FromBody] ManagerLoginDto managerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var manager = _managerService.LoginManager(managerDto.Username, managerDto.Password);
            var token = _tokenService.GenerateToken(manager);

            return Ok(token);
        }
    }
}