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
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IAccountMapper _mapper;
        private readonly IMovementRepository _movementRepository;
        private readonly IMovementMapper _movementMapper;

        public AccountService(IAccountRepository repository, IAccountMapper mapper, IMovementRepository movementRepository, IMovementMapper movementMapper)
        {
            _repository = repository;
            _mapper = mapper;
            _movementRepository = movementRepository;
            _movementMapper = movementMapper;
        }
        public async Task<AccountResponse> AddAccountAsync(AddAccountRequest request)
        {
            var entity = _mapper.Map(request);
            entity.CurrentBalance = 0;
            var result = await _repository.AddAccountAsync(entity);
            return _mapper.Map(result);
        }

        public async Task<bool> DeleteAccountAsync(DeleteAccountRequest request)
        {
            if (request?.AccountId == null) throw new ArgumentNullException();
            var entity = await _repository.GetAccountAsync(request.AccountId);
            if (entity == null) throw new ArgumentException($"No se encontro un registro con el Id {request.AccountId}.");
            var result = await _repository.DeleteAccountAsync(request.AccountId);
            return result;
        }

        public async Task<AccountResponse> DepositOperationAsync(AddMovementRequest request)
        {
            if (request.Amount < 0)
            {
                throw new ArgumentException($"No puede haber depositos negativos");
            }
            var existingRecord = await _repository.GetAccountAsync(request.AccountId);
            if (existingRecord == null)
            {
                throw new ArgumentException($"La cuenta con Id {request.AccountId} no existe");
            }
            var movement = _movementMapper.Map(request);
            movement.MovementType = 1;
            _ = await _movementRepository.AddOperationAsync(movement);
            var result = await _repository.AddDepositOperation(request.AccountId, request.Amount);
            return _mapper.Map(result);

        }

        public async Task<AccountResponse> EditAccountAsync(EditAccountRequest request)
        {
            var existingRecord = await _repository.GetAccountAsync(request.AccountId);
            if (existingRecord == null)
            {
                throw new ArgumentException($"La cuenta con Id {request.AccountId} no existe");
            }
            var accounts = await _repository.GetAccountAsync();
            var existe = accounts.FirstOrDefault(s => s.AccountNumber.ToLowerInvariant() == request.AccountNumber.ToLowerInvariant() && s.AccountId != request.AccountId);
            if (existe != null)
                throw new ArgumentException("Ya existe una cuenta con el mismo nombre.");

            var entity = _mapper.Map(request);
            var result = await _repository.EditAccountAsync(entity);

            return _mapper.Map(result);
        }

        public async Task<IEnumerable<AccountResponse>> GetAccountAsync()
        {
            var result = await _repository.GetAccountAsync();
            return result.Select(x => _mapper.Map(x));
        }

        public async Task<AccountResponse> GetAccountAsync(GetAccountRequest request)
        {
            if (request?.AccountId == null) throw new ArgumentNullException();
            var entity = await _repository.GetAccountAsync(request.AccountId);
            return _mapper.Map(entity);
        }

        public async Task<AccountResponse> RetireOperationAsync(AddMovementRequest request)
        {
            var existingRecord = await _repository.GetAccountAsync(request.AccountId);
            if (existingRecord == null)
            {
                throw new ArgumentException($"La cuenta con Id {request.AccountId} no existe");
            }
            if (existingRecord.CurrentBalance < request.Amount)
            {
                throw new ArgumentException($"Fondos insuficientes");
            }

            var movement = _movementMapper.Map(request);
            movement.MovementType = 2;
            _ = await _movementRepository.AddOperationAsync(movement);
            var result = await _repository.AddRetireOperation(request.AccountId, request.Amount);
            return _mapper.Map(result);
        }
    }
}
