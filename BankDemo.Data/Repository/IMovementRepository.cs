using BankDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Data.Repository
{
    public interface IMovementRepository
    {
        Task<Movement> AddOperationAsync(Movement request);
    }
}
