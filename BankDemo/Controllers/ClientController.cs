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
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Post(AddClientRequest request)
        {
            try
            {
                var result = await _service.AddClientAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = result.ClientId }, null);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var result = await _service.GetClientAsync();
            var totalItems = result.ToList().Count();
            var itemsOnPage = result
                .OrderBy(s => s.Name)
                .Skip(pageSize * pageIndex)
                .Take(pageSize);

            var model = new PaginatedResponseModel<ClientResponse>(pageSize, pageIndex, totalItems, itemsOnPage);

            return Ok(model);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetClientAsync(new GetClientRequest { ClientId = id });
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, EditClientRequest request)
        {
            try
            {
                request.ClientId = id;
                var result = await _service.EditClientAsync(request);
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
                var request = new DeleteClientRequest { ClientId = id };
                await _service.DeleteClientAsync(request);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
