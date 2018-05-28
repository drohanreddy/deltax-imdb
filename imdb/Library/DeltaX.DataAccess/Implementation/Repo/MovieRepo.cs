using DeltaX.Core.Infrastructure;
using DeltaX.Core.POCO;
using DeltaX.DataAccess.Entities;
using DeltaX.DataAccess.Interfaces.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.DataAccess.Implementation.Repo
{
    public class MovieRepo : Repository<Movie, int>, IMovieRepo
    {
        DXContext _dXContext;
        public MovieRepo(DXContext dXContext) : base(dXContext)
        {
            _dXContext = dXContext;
        }

        public async Task<List<AllMoviesData>> GetAllMoviesData()
        {
            var data = await _dXContext.AllMoviesData.FromSql("usp_GetAllMovieData").ToListAsync();
            return data;
        }

        /// <summary>
        /// Updates movies data and movie actors relations
        /// </summary>
        /// <returns></returns>
        public async Task UpdateMovie(SaveMoviesData saveMoviesData, string fileName)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter> {
                new SqlParameter{ParameterName = "@MovieID"        , Value = saveMoviesData.MovieID  },
                new SqlParameter{ParameterName = "@MovieName"      , Value=saveMoviesData.MovieName  },
                new SqlParameter{ParameterName = "@YearOfRelease"  , Value=saveMoviesData.YearOfRelease  },
                new SqlParameter{ParameterName = "@Plot"           , Value=saveMoviesData.Plot  },
                new SqlParameter{ParameterName = "@PosterFileName" , Value=fileName},
                new SqlParameter{ParameterName = "@ActorsCSV"      , Value=saveMoviesData.actorsCSV}
            };
            //
            await _dXContext.Database.ExecuteSqlCommandAsync("usp_UpdateMovieDetails @MovieID,@MovieName,@YearOfRelease,@Plot,@PosterFileName,@ActorsCSV", sqlParameters);
        }
    }
}






