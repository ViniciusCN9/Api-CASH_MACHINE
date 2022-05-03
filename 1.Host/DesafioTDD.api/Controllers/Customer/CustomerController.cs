using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.application.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
            var userId = User.Claims.First().Value;
            var customer = _customerService.GetCustomer(int.Parse(userId));
            return Ok(customer.Balance.ToString("c"));
        }

        [HttpGet]
        [Route("Statement")]
        public IActionResult GetStatement()
        {
            var userId = User.Claims.First().Value;
            var operations = _operationService.GetOperations(int.Parse(userId)); 
            return Ok(operations);
        }

        [HttpPost]
        [Route("Withdraw/{id:int}")]
        public IActionResult PostWithdraw([FromBody] decimal totalValue, [FromRoute] int cashMachineId)
        {
            var userId = User.Claims.First().Value;
            var operation = _operationService.OperationWithdraw(totalValue, cashMachineId, int.Parse(userId));
            return Ok(operation);
        }

        [HttpPost]
        [Route("Deposit/{id:int}")]
        public IActionResult PostDeposit([FromBody] OperationCellsDto operationDto, [FromRoute] int cashMachineId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userId = User.Claims.First().Value;
            _operationService.OperationDeposit(operationDto, cashMachineId, int.Parse(userId));
            return Ok();
        }

        [HttpPost]
        [Route("Options")]
        public IActionResult UpdateCustomer([FromBody] CustomerUpdateDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userId = User.Claims.First().Value;
            _customerService.UpdateCustomer(customerDto, int.Parse(userId));
            return Ok();
        }
    }
}