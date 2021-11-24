using BankDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Data.Repository
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccountAsync();
        Task<Account> GetAccountAsync(int accountId);
        Task<Account> AddAccountAsync(Account request);
        Task<Account> EditAccountAsync(Account request);
        Task<bool> DeleteAccountAsync(int accountId);

        Task<Account> AddDepositOperation(int accountId, decimal amount);
        Task<Account> AddRetireOperation(int accountId, decimal amount);
    }
}
