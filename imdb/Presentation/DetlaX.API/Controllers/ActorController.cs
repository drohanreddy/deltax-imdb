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
    [Route("actors")]
    public class ActorController : BaseController
    {
        ILogger _logger;
        IActorService _actorService;
        public ActorController(ILogger<ActorController> logger,
            IActorService actorService) : base(logger)
        {
            _logger = logger;
            _actorService = actorService;
        }

        [Route("getall")]
        [HttpGet]
        public async Task<List<ActorMini>> GetAllActors()
        {
            return await ExecuteAsync(_actorService, a => a.GetAllActors());
        }
    }
}
