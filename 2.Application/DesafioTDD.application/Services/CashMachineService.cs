using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.application.Helpers;
using DesafioTDD.application.Interfaces;
using DesafioTDD.application.Mappers;
using DesafioTDD.domain.Entities;
using DesafioTDD.domain.Repositories;

namespace DesafioTDD.application.Services
{
    public class CashMachineService : ICashMachineService
    {
        private ICashMachineRepository _cashMachineRepository;
        private IBankRepository _bankRepository;

        public CashMachineService(ICashMachineRepository cashMachineRepository, IBankRepository bankRepository)
        {
            _cashMachineRepository = cashMachineRepository;
            _bankRepository = bankRepository;
        }

        public void CreateCashMachine(CashMachineCreateDto operationDto)
        {
            var bank = _bankRepository.GetBank(operationDto.BankId);
            if (bank is null)
                throw new ArgumentException("Banco não encontrado");

            var cashMachine = operationDto.ToDomain();
            cashMachine.Bank = bank;

            _cashMachineRepository.CreateCashMachine(cashMachine);   
        }

        public void DeleteCashMachine(int id)
        {
            var cashMachine = _cashMachineRepository.GetCashMachine(id);
            if (cashMachine is null)
                throw new ArgumentException("Caixa eletrônico não encontrado");

            if (cashMachine.TotalValue > 0m)
                throw new Exception("Não é possível deletar um caixa eletrônico com dinheiro");

            _cashMachineRepository.DeleteCashMachine(cashMachine);
        }

        public CashMachine GetCashMachine(int id)
        {
            var cashMachine = _cashMachineRepository.GetCashMachine(id);
            if (cashMachine is null)
                throw new ArgumentException("Caixa eletrônico não encontrado");
            
            return cashMachine;
        }

        public List<CashMachine> GetCashMachines()
        {
            var cashMachines = _cashMachineRepository.GetCashMachines();
            if (!cashMachines.Any())
                throw new ArgumentException("Caixa eletrônico não encontrado");

            return cashMachines;
        }

        public void InsertCash(OperationCellsDto operationDto, int id)
        {
            var cashMachine = _cashMachineRepository.GetCashMachine(id);
            if (cashMachine is null)
                throw new ArgumentException("Caixa eletrônico não encontrado");
            
            OperationHelper.InsertCash(cashMachine, operationDto);

            _cashMachineRepository.UpdateCashMachine(cashMachine);
        }

        public void RetrieveCash(OperationCellsDto operationDto, int id)
        {
            var cashMachine = _cashMachineRepository.GetCashMachine(id);
            if (cashMachine is null)
                throw new ArgumentException("Caixa eletrônico não encontrado");

            if (!OperationHelper.CheckQuantity(cashMachine, operationDto))
                throw new Exception("Células disponíveis insuficientes");

            OperationHelper.RetrieveCash(cashMachine, operationDto);
 
            _cashMachineRepository.UpdateCashMachine(cashMachine);
        }
    }
}
