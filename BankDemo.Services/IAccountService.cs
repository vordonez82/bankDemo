using BankDemo.Entities.Request;
using BankDemo.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountResponse>> GetAccountAsync();
        Task<AccountResponse> GetAccountAsync(GetAccountRequest request);
        Task<AccountResponse> AddAccountAsync(AddAccountRequest request);
        Task<AccountResponse> EditAccountAsync(EditAccountRequest request);
        Task<bool> DeleteAccountAsync(DeleteAccountRequest request);
        Task<AccountResponse> DepositOperationAsync(AddMovementRequest request);
        Task<AccountResponse> RetireOperationAsync(AddMovementRequest request);
    }
}
