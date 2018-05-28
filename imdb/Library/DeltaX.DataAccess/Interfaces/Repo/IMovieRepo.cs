using DeltaX.Core.POCO;
using DeltaX.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.DataAccess.Interfaces.Repo
{
    public interface IMovieRepo : IRepository<Movie, int>
    {
        Task<List<AllMoviesData>> GetAllMoviesData();
        Task UpdateMovie(SaveMoviesData saveMoviesData, string fileName);
    }
}
