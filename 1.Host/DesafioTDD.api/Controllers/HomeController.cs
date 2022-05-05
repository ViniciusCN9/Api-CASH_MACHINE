using System;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.application.Interfaces;
using Microsoft.AspNetCore.Http;
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
            
            try
            {
                var customer = _customerService.CustomerRegister(customerDto);
                return Ok(customer);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message); 
            }
        }

        /// <remarks>
        /// Example:
        ///
        ///     User
        ///     {
        ///        "cardNumber": "0000000000000000",
        ///        "password": "user"
        ///     }
        /// </remarks>
        [HttpPost]
        [Route("Login")]
        public IActionResult LoginCustomer([FromBody] CustomerLoginDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var customer = _customerService.LoginCustomer(customerDto.CardNumber, customerDto.Password);
                var token = _tokenService.GenerateToken(customer);
                return Ok(token);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message); 
            }
        }

        /// <remarks>
        /// Example:
        ///
        ///     Admin
        ///     {
        ///        "username": "admin",
        ///        "password": "admin"
        ///     }
        /// </remarks>
        [HttpPost]
        [Route("Manager")]
        public IActionResult LoginManager([FromBody] ManagerLoginDto managerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var manager = _managerService.LoginManager(managerDto.Username, managerDto.Password);
                var token = _tokenService.GenerateToken(manager);
                return Ok(token);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message); 
            }
        }
    }
}