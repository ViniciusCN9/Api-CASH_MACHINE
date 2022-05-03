using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTDD.api.Controllers.Manager
{
    [ApiController]
    [Route("v1/Manager/[controller]")]
    public class BankController : ControllerBase
    {
        private IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public IActionResult GetBanks()
        {
            var banks = _bankService.GetBanks();
            return Ok(banks);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetBank([FromRoute] int id)
        {
            var bank = _bankService.GetBank(id);
            return Ok(bank);
        }

        [HttpPost]
        public IActionResult CreateBank([FromBody] BankCreateDto bankDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _bankService.CreateBank(bankDto);
            return Ok();
        }

        [HttpPatch]
        [Route("{id:int}")]
        public IActionResult UpdateBank([FromBody] BankUpdateDto bankDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _bankService.UpdateBank(bankDto, id);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteBank([FromRoute] int id)
        {
            _bankService.DeleteBank(id);
            return Ok();
        }
    }
}