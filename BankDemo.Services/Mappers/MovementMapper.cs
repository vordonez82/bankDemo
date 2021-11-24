using BankDemo.Entities;
using BankDemo.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Services.Mappers
{
    public class MovementMapper : IMovementMapper
    {
        public Movement Map(AddMovementRequest request)
        {
            if (request == null) return null;
            return new Movement
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                Concept = request.Concept,
                OperationDate = DateTime.Now
            };
        }
    }
}
