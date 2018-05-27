using DeltaX.Core.Infrastructure;
using DeltaX.Core.POCO;
using DeltaX.DataAccess.Entities;
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

        public async Task<bool> SaveMoviesData(SaveMoviesData saveMoviesData, string fileName)
        {
            var context = _unitOfWork.getDXContext();
            Movie movie = new Movie
            {
                Name = saveMoviesData.MovieName,
                Plot = saveMoviesData.Plot,
                PosterFileName = fileName,
                YearOfRelease = new DateTime(saveMoviesData.YearOfRelease, 1, 1),
                Producer = saveMoviesData.ProducerID
            };
            var addedMovie = _movieRepo.InsertAndReturnEntity(movie);
            context.Movies.Add(movie);
            await _unitOfWork.Save();
            bool save = false;
            foreach (var item in saveMoviesData.Actors)
            {
                MovieActor movieActor = new MovieActor
                {
                    ActorID = item.ActorID,
                    MovieID = addedMovie.Id
                };
                _unitOfWork.getDXContext().MovieActors.Add(movieActor);
                save = true;
            }
            if (save)
            {
                await _unitOfWork.Save();
            }
            return false;
        }
    }
}
