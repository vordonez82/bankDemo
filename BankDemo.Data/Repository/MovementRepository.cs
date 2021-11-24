using BankDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Data.Repository
{
    public class MovementRepository : IMovementRepository
    {
        private readonly BankDemoContext _context;

        public MovementRepository(BankDemoContext context)
        {
            _context = context;
        }

        public async Task<Movement> AddOperationAsync(Movement request)
        {
            _context.Movements.Add(request);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return request;
            }
            else
                return null;
        }
    }
}
