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
            var cashMachines = _cashMachineService.GetCashMachines();
            return Ok(cashMachines);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCashMachine([FromRoute] int id)
        {
            var cashMachine = _cashMachineService.GetCashMachine(id);
            return Ok(cashMachine);
        }

        [HttpPost]
        public IActionResult CreateCashMachine([FromBody] CashMachineCreateDto cashMachineDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _cashMachineService.CreateCashMachine(cashMachineDto);
            return Ok();
        }

        [HttpPatch]
        [Route("Insert/{id:int}")]
        public IActionResult InsertCash([FromBody] OperationCellsDto operationDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _cashMachineService.InsertCash(operationDto, id);
            return Ok();
        }

        [HttpPatch]
        [Route("Retrieve/{id:int}")]
        public IActionResult RetrieveCash([FromBody] OperationCellsDto operationDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _cashMachineService.RetrieveCash(operationDto, id);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCashMachine([FromRoute] int id)
        {
            _cashMachineService.DeleteCashMachine(id);
            return Ok();
        }
    }
}