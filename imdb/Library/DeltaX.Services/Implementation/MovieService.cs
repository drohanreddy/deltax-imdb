using DeltaX.Core.Infrastructure;
using DeltaX.Core.POCO;
using DeltaX.DataAccess.Interfaces;
using DeltaX.DataAccess.Interfaces.Repo;
using DeltaX.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.Services.Implementation
{
    public class MovieService : IMovieService
    {
        IMovieRepo _movieRepo;
        IUnitOfWork _unitOfWork;
        IMovieActorRepo _movieActorRepo;
        public MovieService(IUnitOfWork unitOfWork)
        {
            _movieRepo = unitOfWork.GetMovieRepo();
            _unitOfWork = unitOfWork;
            _movieActorRepo = unitOfWork.GetMovieActorRepo();
        }

        public async Task<List<AllMoviesData>> GetAllMoviesData()
        {
            var allMovies = await _movieRepo.GetAllMoviesData();
            if (!allMovies.IsNullOrDefault() && allMovies.Count > 0)
            {
                var movieIds = allMovies.Select(i => i.MovieID).ToList();
                var getActorsForMovies = await _movieActorRepo.GetMovieActorsByID(movieIds);
                for (int i = 0; i < allMovies.Count; i++)
                {
                    allMovies[i].Actors = getActorsForMovies
                                          .Where(j => j.MovieID == allMovies[i].MovieID)
                                          .Select(k => new ActorPoco
                                          {
                                              ActorID = k.ActorID,
                                              ActorName = k.ActorName
                                          }).ToList();
                }

            }
            return allMovies;
        }
    }
}
