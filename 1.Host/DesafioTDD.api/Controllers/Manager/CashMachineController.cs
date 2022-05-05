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
    public class CashMachineController : ControllerBase
    {
        private ICashMachineService _cashMachineService;
        public CashMachineController(ICashMachineService cashMachineService)
        {
            _cashMachineService = cashMachineService;
        }

        [HttpGet]
        public IActionResult GetCashMachines()
        {
            try
            {
                var cashMachines = _cashMachineService.GetCashMachines();
                return Ok(cashMachines);
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
        public IActionResult GetCashMachine([FromRoute] int id)
        {
            try
            {
                var cashMachine = _cashMachineService.GetCashMachine(id);
                return Ok(cashMachine);
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
        public IActionResult CreateCashMachine([FromBody] CashMachineCreateDto cashMachineDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                _cashMachineService.CreateCashMachine(cashMachineDto);
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
        [Route("Insert/{id:int}")]
        public IActionResult InsertCash([FromBody] CellsDto cellsDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                _cashMachineService.InsertCash(cellsDto, id);
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
        [Route("Retrieve/{id:int}")]
        public IActionResult RetrieveCash([FromBody] CellsDto cellsDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                _cashMachineService.RetrieveCash(cellsDto, id);
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
        [Route("{id:int}")]
        public IActionResult DeleteCashMachine([FromRoute] int id)
        {
            try
            {
                _cashMachineService.DeleteCashMachine(id);
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