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
                string fileName = data.MoviePoster;
                if (file != null && file.Length > 0)
                {
                    var ext = Path.GetExtension(file.FileName);
                    fileName =  DateTime.Now.ToString("yyyyMMddHHmmssffff")+"-"+file.Name+ ext;
                    var path1 = @"E:\StudyArea\deltax-imdb\imdb\Presentation\DeltaX.Web\deltax-clientapp\src\assets\images\movies\";
                    var path2 = @"E:\StudyArea\deltax-imdb\imdb\Presentation\DeltaX.Web\dist\assets\images\movies\";
                    

                    // copying to dev path
                    using (var stream = new FileStream(path1+fileName, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        await stream.FlushAsync();
                    }

                    // copying to prod path
                    using (var stream = new FileStream(path2 + fileName, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        await stream.FlushAsync();
                    }
                }
                await _movieService.SaveMoviesData(data, fileName);
            }
            return false;
        }
    }
}
