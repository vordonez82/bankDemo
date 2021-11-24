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
    public class ClientMapper : IClientMapper
    {
        public Client Map(AddClientRequest request)
        {
            if (request == null) return null;
            return new Client
            {
                City = request.City,
                Name = request.Name,
                RFC = request.RFC,
                State = request.State
            };
        }

        public Client Map(EditClientRequest request)
        {
            if (request == null) return null;
            return new Client
            {
                ClientId = request.ClientId,
                City = request.City,
                Name = request.Name,
                RFC = request.RFC,
                State = request.State
            };
        }

        public Client Map(DeleteClientRequest request)
        {
            if (request == null) return null;
            return new Client
            {
                ClientId = request.ClientId
            };
        }

        public ClientResponse Map(Client client)
        {
            if (client == null) return null;
            return new ClientResponse
            {
                ClientId = client.ClientId,
                City = client.City,
                Name = client.Name,
                RFC = client.RFC,
                State = client.State
            };
        }
    }
}
