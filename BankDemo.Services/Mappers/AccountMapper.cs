using BankDemo.Entities;
using BankDemo.Entities.Request;
using BankDemo.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Services.Mappers
{
    public class AccountMapper : IAccountMapper
    {
        public Account Map(AddAccountRequest request)
        {
            if (request == null) return null;
            return new Account
            {
               AccountNumber = request.AccountNumber,
               AccountType = request.AccountType,
               ClientId = request.ClientId,
               Status = request.Status
            };
        }

        public Account Map(EditAccountRequest request)
        {
            if (request == null) return null;
            return new Account
            {
                AccountId = request.AccountId,
                AccountNumber = request.AccountNumber,
                AccountType = request.AccountType,
                Status = request.Status
            };
        }

        public Account Map(DeleteAccountRequest request)
        {
            if (request == null) return null;
            return new Account
            {
                AccountId = request.AccountId
            };
        }


        public AccountResponse Map(Account account)
        {
            if (account == null) return null;
            return new AccountResponse
            {
                AccountId = account.AccountId,
                AccountNumber = account.AccountNumber,
                AccountType = account.AccountType,
                ClientId = account.ClientId,
                CurrentBalance = account.CurrentBalance,
                Status = account.Status
            };
        }
    }
}
