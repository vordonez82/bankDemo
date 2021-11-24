using BankDemo.Entities.Request;
using BankDemo.Entities.Response;
using BankDemo.ResponseModel;
using BankDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddAccountRequest request)
        {
            try
            {
                var result = await _service.AddAccountAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = result.AccountId }, null);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var result = await _service.GetAccountAsync();
            var totalItems = result.ToList().Count();
            var itemsOnPage = result
                .OrderBy(s => s.AccountNumber)
                .Skip(pageSize * pageIndex)
                .Take(pageSize);

            var model = new PaginatedResponseModel<AccountResponse>(pageSize, pageIndex, totalItems, itemsOnPage);

            return Ok(model);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetAccountAsync(new GetAccountRequest { AccountId = id });
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, EditAccountRequest request)
        {
            try
            {
                request.AccountId = id;
                var result = await _service.EditAccountAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var request = new DeleteAccountRequest { AccountId = id };
                await _service.DeleteAccountAsync(request);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("deposit")]
        public async Task<IActionResult> DepositAccount(AddMovementRequest request)
        {
            try
            {
                var result = await _service.DepositOperationAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("retire")]
        public async Task<IActionResult> RetireAccount(AddMovementRequest request)
        {
            try
            {
                var result = await _service.RetireOperationAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
