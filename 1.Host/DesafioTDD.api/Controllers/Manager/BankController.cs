using System;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTDD.api.Controllers.Manager
{
    [ApiController]
    [Authorize(Roles = "MANAGER")]
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
            try
            {
                var banks = _bankService.GetBanks();
                return Ok(banks);
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
        [Route("{id:int}")]
        public IActionResult GetBank([FromRoute] int id)
        {
            try
            {   
                var bank = _bankService.GetBank(id);
                return Ok(bank);
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
        public IActionResult CreateBank([FromBody] BankCreateDto bankDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            try
            {
                _bankService.CreateBank(bankDto);
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

        [HttpPatch]
        [Route("{id:int}")]
        public IActionResult UpdateBank([FromBody] BankUpdateDto bankDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                _bankService.UpdateBank(bankDto, id);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message); 
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteBank([FromRoute] int id)
        {
            try
            {
                _bankService.DeleteBank(id);
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