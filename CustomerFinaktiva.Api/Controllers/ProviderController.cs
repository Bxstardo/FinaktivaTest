using AutoMapper;
using CustomerFinaktiva.Api.Models;
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
    /// ProviderController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly ILogger<ProviderController> _logger;
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="providerService">The provider service.</param>
        /// <param name="mapper">The mapper.</param>
        public ProviderController(
            ILogger<ProviderController> logger,
            IProviderService providerService,
            IMapper mapper
        )
        {
            _logger = logger;
            _providerService = providerService;
            _mapper = mapper;
        }

        // GET: api/providers/Get
        /// <summary>
        /// Gets providers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get()
        {
            var providers = await _providerService.GetAll();
            if (providers != null)
            {
                var result = _mapper.Map<IEnumerable<ProviderModel>>(providers);
                _logger.LogInformation("Processing Provider List {@result}", result);
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("[action]/{idCliente}")]
        public async Task<IActionResult> GetByClient(int idCliente)
        {
            var providers = await _providerService.GetAllByClient(idCliente);
            if (providers != null)
            {
                _logger.LogInformation("Processing Provider List {@providers}", providers);
                return Ok(providers);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
