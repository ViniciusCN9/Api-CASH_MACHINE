using System;
using System.Linq;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTDD.api.Controllers.Customer
{
    [ApiController]
    [Authorize(Roles = "CUSTOMER")]
    [Route("v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        private IOperationService _operationService;

        public CustomerController(ICustomerService customerService, IOperationService operationService)
        {
            _customerService = customerService;
            _operationService = operationService;
        }

        [HttpGet]
        [Route("Balance")]
        public IActionResult GetBalance()
        {
            try
            {
                var userId = User.Claims.First().Value;
                var customer = _customerService.GetCustomer(int.Parse(userId));
                return Ok(customer.Balance.ToString("c"));
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

        [HttpGet]
        [Route("Statement")]
        public IActionResult GetStatement()
        {
            try
            {
                var userId = User.Claims.First().Value;
                var statement = _operationService.GetOperations(int.Parse(userId)); 
                return Ok(statement);
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

        [HttpPost]
        [Route("Withdraw/{cashMachineId:int}/{totalValue:decimal}")]
        public IActionResult PostWithdraw([FromRoute] int cashMachineId, decimal totalValue)
        {
            if (totalValue <= 0)
                return BadRequest();
            try
            {
                var userId = User.Claims.First().Value;
                var operation = _operationService.OperationWithdraw(totalValue, cashMachineId, int.Parse(userId));
                return Ok(operation);
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

        [HttpPost]
        [Route("Deposit/{cashMachineId:int}")]
        public IActionResult PostDeposit([FromBody] CellsDto operationDto, [FromRoute] int cashMachineId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var userId = User.Claims.First().Value;
                _operationService.OperationDeposit(operationDto, cashMachineId, int.Parse(userId));
                return Ok();
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

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateCustomer([FromBody] CustomerUpdateDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var userId = User.Claims.First().Value;
                _customerService.UpdateCustomer(customerDto, int.Parse(userId));
                return Ok();
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

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteCustomer()
        {
            try
            {
                var userId = User.Claims.First().Value;
                _customerService.DeleteCustomer(int.Parse(userId));
                return Ok();
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