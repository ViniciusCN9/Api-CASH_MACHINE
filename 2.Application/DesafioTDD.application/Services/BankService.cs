using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.application.Interfaces;
using DesafioTDD.application.Mappers;
using DesafioTDD.domain.Entities;
using DesafioTDD.domain.Repositories;

namespace DesafioTDD.application.Services
{
    public class BankService : IBankService
    {
        private IBankRepository _bankRepository;
        private ICashMachineRepository _cashMachineRepository;
        private ICustomerRepository _customerRepository;

        public BankService(IBankRepository bankRepository, ICashMachineRepository cashMachineRepository, ICustomerRepository customerRepository)
        {
            _bankRepository = bankRepository;
            _cashMachineRepository = cashMachineRepository;
            _customerRepository = customerRepository;
        }

        public void CreateBank(BankCreateDto bankDto)
        {
            if (!VerifyPrefixes(bankDto.CardNumberPrefix))
                throw new Exception("Prefixo(s) já existente(s)");

            _bankRepository.CreateBank(bankDto.ToDomain());
        }

        public void DeleteBank(int id)
        {
            var bank = _bankRepository.GetBank(id);
            if (bank is null)
                throw new ArgumentException("Banco não encontrado");

            var cashMachines = _cashMachineRepository.GetCashMachines().Where(e => e.Bank.Id == bank.Id);
            if (cashMachines.Any())
                throw new Exception ("Não é possível deletar um banco com caixas eletrônicos cadastrados");

            var customers = _customerRepository.GetCustomers().Where(e => e.Bank.Id == bank.Id);
            if (customers.Any())
                throw new Exception ("Não é possível deletar um banco com clientes cadastrados");

            _bankRepository.DeleteBank(bank);
        }

        public Bank GetBank(int id)
        {
            var bank = _bankRepository.GetBank(id);
            if (bank is null)
                throw new ArgumentException("Banco não encontrado");
            
            return bank;
        }

        public List<Bank> GetBanks()
        {
            var banks = _bankRepository.GetBanks();
            if (!banks.Any())
                throw new ArgumentException("Nenhum banco cadastrado");

            return banks;
        }

        public void UpdateBank(BankUpdateDto bankDto, int id)
        {
            var bank = _bankRepository.GetBank(id);
            if (bank is null)
                throw new ArgumentException("Banco não encontrado");

            if (!VerifyPrefixes(bankDto.CardNumberPrefix))
                throw new Exception("Prefixo(s) já existente(s)");

            bank.Name = bankDto.Name ?? bank.Name;
            bank.CardNumberPrefix = bankDto.CardNumberPrefix ?? bank.CardNumberPrefix;

            _bankRepository.UpdateBank(bank);
        }

        //-------------------- Métodos internos --------------------\\

        private bool VerifyPrefixes(string cardNumberPrefix)
        {
            if (string.IsNullOrEmpty(cardNumberPrefix))
                return true;

            var prefixes = cardNumberPrefix.Split("-");
            foreach (var prefix in prefixes)
            {
                var bank = _bankRepository.GetBankByPrefix(prefix);
                if (!(bank is null))
                    return false;
            }

            return true;
        }
    }
}