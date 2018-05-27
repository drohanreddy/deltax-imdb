using DeltaX.Core.POCO;
using DeltaX.DataAccess.Entities;
using DeltaX.DataAccess.Interfaces.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
