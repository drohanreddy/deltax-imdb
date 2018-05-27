using DeltaX.Core.Infrastructure;
using DeltaX.Core.POCO;
using DeltaX.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DetlaX.API.Controllers
{
    [Route("movies")]
    public class MoviesController : BaseController
    {
        ILogger _logger;
        IActorService _actorService;
        IMovieService _movieService;
        public MoviesController(ILogger<HomeController> logger,
            IActorService actorService,
            IMovieService movieService) : base(logger)
        {
            _logger = logger;
            _actorService = actorService;
            _movieService = movieService;
        }

        [Route("getall")]
        [HttpGet]
        public async Task<List<AllMoviesData>> GetAllMoviesData()
        {
            return await ExecuteAsync(_movieService, m => m.GetAllMoviesData());
        }

        [Route("saveMovieData")]
        [HttpPost]
        public async Task<bool> PostFormData([FromForm] SaveMoviesData data)
        {
            if (!data.IsNullOrDefault())
            {
                var file = data.poster;
                if (file != null && file.Length > 0)
                {
                    var fileName =  DateTime.Now.ToString("yyyyMMddHHmmssffff")+"-"+file.Name;
                    var path1 = @"E:\StudyArea\deltax-imdb\imdb\Presentation\DeltaX.Web\dist\assets\images\movies\";
                    var path2 = @"E:\StudyArea\deltax-imdb\imdb\Presentation\DeltaX.Web\dist\assets\images\movies\";

                    var memory = new MemoryStream();
                    await _movieService.SaveMoviesData(data, fileName);
                    using (var stream = new FileStream(path1, FileMode.Create))
                    {
                        await stream.CopyToAsync(memory);
                    }
                    using (var stream = new FileStream(path2, FileMode.Create))
                    {
                        await stream.CopyToAsync(memory);
                    }
                    memory.Position = 0;
                }
            }
            return false;
        }
    }
}
