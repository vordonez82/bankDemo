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
    public interface IAccountMapper
    {
        Account Map(AddAccountRequest request);
        Account Map(EditAccountRequest request);
        Account Map(DeleteAccountRequest request);

        AccountResponse Map(Account account);
    }
}
