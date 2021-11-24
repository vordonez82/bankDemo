using BankDemo.Entities.Request;
using BankDemo.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientResponse>> GetClientAsync();
        Task<ClientResponse> GetClientAsync(GetClientRequest request);
        Task<ClientResponse> AddClientAsync(AddClientRequest request);
        Task<ClientResponse> EditClientAsync(EditClientRequest request);
        Task<bool> DeleteClientAsync(DeleteClientRequest request);
    }
}
