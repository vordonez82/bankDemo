using BankDemo.Data.Repository;
using BankDemo.Entities.Request;
using BankDemo.Entities.Response;
using BankDemo.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IClientMapper _mapper;

        public ClientService(IClientRepository repository, IClientMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<ClientResponse> AddClientAsync(AddClientRequest request)
        {
            var entity = _mapper.Map(request);
            var result = await _repository.AddClientAsync(entity);
            return _mapper.Map(result);
        }

        public async Task<bool> DeleteClientAsync(DeleteClientRequest request)
        {
            if (request?.ClientId == null) throw new ArgumentNullException();
            var entity = await _repository.GetClientAsync(request.ClientId);
            if (entity == null) throw new ArgumentException($"No se encontro un registro con el Id {request.ClientId}.");
            var result = await _repository.DeleteClientAsync(request.ClientId);
            return result;
        }

        public async Task<ClientResponse> EditClientAsync(EditClientRequest request)
        {
            var existingRecord = await _repository.GetClientAsync(request.ClientId);
            if (existingRecord == null)
            {
                throw new ArgumentException($"El puesto con Id {request.ClientId} no existe");
            }
            var clientes = await _repository.GetClientAsync();
            var existe = clientes.FirstOrDefault(s => s.RFC.ToLowerInvariant() == request.RFC.ToLowerInvariant() && s.ClientId != request.ClientId);
            if (existe != null)
                throw new ArgumentException("Ya existe un puesto con el mismo nombre.");

            var entity = _mapper.Map(request);
            var result = await _repository.EditClientAsync(entity);
            
            return _mapper.Map(result);
        }

        public async Task<IEnumerable<ClientResponse>> GetClientAsync()
        {
            var result = await _repository.GetClientAsync();
            return result.Select(x => _mapper.Map(x));
        }

        public async Task<ClientResponse> GetClientAsync(GetClientRequest request)
        {
            if (request?.ClientId == null) throw new ArgumentNullException();
            var entity = await _repository.GetClientAsync(request.ClientId);
            return _mapper.Map(entity);
        }
    }
}
