using AutoMapper;
using DirtyThreats.API.DataContracts;
using DirtyThreats.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using S = DirtyThreats.Services.Model;

namespace DirtyThreats.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/urlcheck")]//required for default versioning
    [Route("api/v{version:apiVersion}/urlcheck")]
    [ApiController]
    public class UrlCheckController : Controller
    {

        private readonly IUrlCheckService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<UrlCheckController> _logger;

        public UrlCheckController(ILogger<UrlCheckController> logger, IMapper mapper, IUrlCheckService service)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }

        #region GET
        /// <summary>
        /// 
        /// </summary>
        /// <param name="urlCheck"></param>
        /// <returns>
        /// 
        /// </returns>
        /// <response code="200"></response>
        /// <response code="204"></response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UrlCheck))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(UrlCheck))]
        [HttpPost]
        public async Task<UrlCheck> Post(UrlCheck urlCheck)
        {
            if (urlCheck == null)
                throw new ArgumentNullException(nameof(urlCheck));

            _logger.LogDebug($"UrlCheckController::Post");

            var data = await _service.GetAsync(urlCheck.Url);

            if (data != null)
                return _mapper.Map<UrlCheck>(data);
            else
                return null;
        }
        #endregion


    }
}
