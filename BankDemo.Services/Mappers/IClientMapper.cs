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
    public interface IClientMapper
    {
        Client Map(AddClientRequest request);
        Client Map(EditClientRequest request);
        Client Map(DeleteClientRequest request);

        ClientResponse Map(Client client);
    }
}
