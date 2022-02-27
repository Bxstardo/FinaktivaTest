using AutoMapper;
using CustomerFinaktiva.Api.Helpers;
using CustomerFinaktiva.Api.Models;
using CustomerFinaktiva.Core.Enums;
using CustomerFinaktiva.Core.Models;
using CustomerFinaktiva.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerFinaktiva.Api.Controllers
{
    /// <summary>
    /// ClientController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="clientService">The client service.</param>
        /// <param name="mapper">The mapper.</param>
        public ClientController(
            ILogger<ClientController> logger,
            IClientService clientService,
            IMapper mapper
        )
        {
            _logger = logger;
            _clientService = clientService;
            _mapper = mapper;
        }

        // GET: api/client/Get
        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get()
        {
            var clients = await _clientService.GetAll();
            if (clients != null)
            {
                _logger.LogInformation("Processing Client List {@result}", clients);
                return Ok(clients);
            }
            else
            {
                return NotFound();
            }
        }

        // GET : api/client/GetById
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="idClient">The identifier client.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{idClient}")]
        public async Task<IActionResult> GetById(int idClient)
        {
            var client = await _clientService.GetById(idClient);
            if (client != null)
            {
                _logger.LogInformation("Processing Client Model {@client}", client);
                return Ok(client);
            }
            else
            {
                return NotFound();
            }
        }

        // POST : api/client/Create
        /// <summary>
        /// Creates the specified new client.
        /// </summary>
        /// <param name="newClient">The new client.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(ClientModel newClient)
        {
            var result = await _clientService.Add(_mapper.Map<Client>(newClient));
            _logger.LogInformation("Processing Add Client {@result}", result);
            var error = new Error();
            var intResult = (int)result.Result;
            switch (result.Result)
            {
                case GenericResult.Successful:
                    return StatusCode(200, result.Id);
                case GenericResult.ErrorValidation:
                    error.Code = intResult.ToString();
                    error.Message = "No se pueden ingresar clientes con cedula extranjera";
                    return StatusCode(404, error);
                default:
                    return StatusCode(500);
            }
        }

        /// <summary>
        /// Assigns the provider.
        /// </summary>
        /// <param name="clientProvider">The client provider.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AssignProvider(ClientProviderModel clientProvider)
        {
            var result = await _clientService.AssignProvider(_mapper.Map<ClientProvider>(clientProvider));
            var error = new Error();
            var intResult = (int)result;
            _logger.LogInformation("Processing Assign Provider in Client {@result}", result);
            switch (result)
            {
                case GenericResult.Successful:
                    return StatusCode(200);
                case GenericResult.AlreadyExists:
                    error.Code = intResult.ToString();
                    error.Message = "El cliente ya tiene asignado este proveedor";
                    return StatusCode(404, error);
                default:
                    return StatusCode(500);
            }
        }

        /// <summary>
        /// update assign the providers by action, action = 'Add' or action 'Remove'.
        /// </summary>
        /// <param name="clientProviders">The client providers.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AssignProviders(List<ClientProvidersModel> clientProviders)
        {
            var result = await _clientService.AssignProviders(clientProviders);
            _logger.LogInformation("Processing Assign Providers in Client {@result}", result);
            switch (result)
            {
                case GenericResult.Successful:
                    return StatusCode(200);
                default:
                    return StatusCode(500);
            }
        }

        // PUT : api/client/Update
        /// <summary>
        /// Updates the specified new client.
        /// </summary>
        /// <param name="newClient">The new client.</param>
        /// <param name="idClient">The identifier client.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]/{idClient}")]
        public async Task<IActionResult> Update(ClientModel newClient, int idClient)
        {
            var result = await _clientService.Update(_mapper.Map<Client>(newClient), idClient);
            var error = new Error();
            var intResult = (int)result;
            _logger.LogInformation("Processing Update Client {@result}", result);
            switch (result)
            {
                case GenericResult.Successful:
                    return StatusCode(200);
                case GenericResult.NotFound:
                    error.Code = intResult.ToString();
                    error.Message = "No se pudo actualizar debido a que no se encuentra ningun dato con este id";
                    return StatusCode(404, error);
                case GenericResult.ErrorValidation:
                    error.Code = intResult.ToString();
                    error.Message = "No se pueden ingresar clientes con cedula extranjera";
                    return StatusCode(404, error);
                default:
                    return StatusCode(500);
            }
        }

        // DELETE : api/client/Delete

        /// <summary>
        /// Deletes the specified identifier client.
        /// </summary>
        /// <param name="idClient">The identifier client.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]/{idClient}")]
        public async Task<IActionResult> Delete(int idClient)
        {
            var result = await _clientService.Delete(idClient);
            var error = new Error();
            var intResult = (int)result;
            _logger.LogInformation("Processing Delete Client {@result}", result);
            switch (result)
            {
                case GenericResult.Successful:
                    return StatusCode(200);
                case GenericResult.NotFound:
                    error.Code = intResult.ToString();
                    error.Message = "No se pudo eliminar debido a que no se encuentra ningun dato con este id";
                    return StatusCode(404, error);
                default:
                    return StatusCode(500);
            }
        }

    }
}
