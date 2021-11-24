using BankDemo.Entities;
using BankDemo.Entities.Request;
using BankDemo.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Data.Repository
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientAsync();
        Task<Client> GetClientAsync(int clientId);
        Task<Client> AddClientAsync(Client request);
        Task<Client> EditClientAsync(Client request);
        Task<bool> DeleteClientAsync(int clientId);
    }
}
