using BankDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankDemoContext _context;

        public AccountRepository(BankDemoContext context)
        {
            _context = context;
        }

        public async Task<Account> AddAccountAsync(Account request)
        {
            _context.Accounts.Add(request);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return request;
            }
            else
            {
                return null;
            }
        }

        public Task<Account> AddDepositOperation(int accountId, decimal amount)
        {
            var qry = _context.Accounts.FirstOrDefault(s => s.AccountId == accountId);
            if (qry != null)
            {
                qry.CurrentBalance += amount;
                _context.SaveChanges();
            }

            return Task.FromResult(qry);
        }

        public Task<Account> AddRetireOperation(int accountId, decimal amount)
        {
            var qry = _context.Accounts.FirstOrDefault(s => s.AccountId == accountId);
            if (qry != null)
            {
                qry.CurrentBalance -= amount;
                _context.SaveChanges();
            }

            return Task.FromResult(qry);
        }

        public async Task<bool> DeleteAccountAsync(int accountId)
        {
            var item = _context.Accounts
            .AsNoTracking()
            .Where(x => x.AccountId == accountId)
            .FirstOrDefault();
            if (item == null) return false;

            _context.Accounts.Remove(item);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public Task<Account> EditAccountAsync(Account request)
        {
            var qry = _context.Accounts.FirstOrDefault(s => s.AccountId == request.AccountId);
            if (qry != null)
            {
                qry.AccountNumber = request.AccountNumber;
                qry.AccountType = request.AccountType;
                qry.Status = request.Status;
                _context.SaveChanges();
            }
            
            return Task.FromResult(request);
        }

        public async Task<IEnumerable<Account>> GetAccountAsync()
        {
            return await _context
                .Accounts
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Account> GetAccountAsync(int accountId)
        {
            var item = await _context.Accounts
              .AsNoTracking()
              .Where(x => x.AccountId == accountId)
              .FirstOrDefaultAsync();

            return item;
        }
    }
}
