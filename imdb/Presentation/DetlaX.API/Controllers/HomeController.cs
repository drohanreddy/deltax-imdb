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
    [Route("Home")]
    public class HomeController : BaseController
    {
        ILogger _logger;
        IActorService _actorService;
        IMovieService _movieService;
        public HomeController(ILogger<HomeController> logger,
            IActorService actorService,
            IMovieService movieService) : base(logger)
        {
            _logger = logger;
            _actorService = actorService;
            _movieService = movieService;
        }

        [Route("movies")]
        [HttpGet]
        public async Task<List<AllMoviesData>> GetAllMoviesData()
        {
            return await _movieService.GetAllMoviesData();
        }
    }
}
