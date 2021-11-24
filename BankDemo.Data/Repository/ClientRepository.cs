using BankDemo.Entities;
using BankDemo.Entities.Request;
using BankDemo.Entities.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly BankDemoContext _context;

        public ClientRepository(BankDemoContext context)
        {
            _context = context;
        }

        public async Task<Client> AddClientAsync(Client request)
        {
            _context.Clients.Add(request);
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

        public async Task<bool> DeleteClientAsync(int clientId)
        {
            var item = _context.Clients
             .AsNoTracking()
             .Where(x => x.ClientId == clientId)
             .FirstOrDefault();
            if (item == null) return false;
            
            _context.Clients.Remove(item);
            var result = await _context.SaveChangesAsync();

            return result > 0;
            
        }

        public Task<Client> EditClientAsync(Client request)
        {
            _context.Entry(request).State = EntityState.Modified;
            _context.SaveChanges();
            return Task.FromResult(request);
        }

        public async Task<IEnumerable<Client>> GetClientAsync()
        {
            return await _context
                .Clients
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Client> GetClientAsync(int clientId)
        {
            var item = await _context.Clients
               .AsNoTracking()
               .Where(x => x.ClientId == clientId)
               .FirstOrDefaultAsync();

            return item;
        }
    }
}
