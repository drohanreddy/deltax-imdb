using DeltaX.Core.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<AllMoviesData>> GetAllMoviesData();
        Task<bool> SaveMoviesData(SaveMoviesData saveMoviesData, string fileName);
    }
}
