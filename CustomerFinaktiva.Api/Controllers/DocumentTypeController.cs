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
    /// DocumentTypeController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly ILogger<DocumentTypeController> _logger;
        private readonly IDocumentTypeService _documentTypeService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTypeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="documentTypeService">The documentType service.</param>
        /// <param name="mapper">The mapper.</param>
        public DocumentTypeController(
            ILogger<DocumentTypeController> logger,
            IDocumentTypeService documentTypeService,
            IMapper mapper
        )
        {
            _logger = logger;
            _documentTypeService = documentTypeService;
            _mapper = mapper;
        }

        // GET: api/documentType/Get
        /// <summary>
        /// Gets documentType
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get()
        {
            var documentTypes = await _documentTypeService.GetAll();
            if (documentTypes != null)
            {
                var result = _mapper.Map<IEnumerable<DocumentTypeModel>>(documentTypes);
                _logger.LogInformation("Processing documentType List {@result}", result);
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

    

    }
}
