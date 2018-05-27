using DeltaX.Core.POCO;
using DeltaX.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetlaX.API.Controllers
{
    [Route("producers")]
    public class ProducerController : BaseController
    {
        ILogger _logger;
        IProducerService _producerService;
        public ProducerController(ILogger<ActorController> logger,
            IProducerService producerService) : base(logger)
        {
            _logger = logger;
            _producerService = producerService;
        }

        [Route("getall")]
        [HttpGet]
        public async Task<List<ProducerPoco>> GetAllActors()
        {
            return await ExecuteAsync(_producerService, a => a.GetAllProducers());
        }
    }
}
