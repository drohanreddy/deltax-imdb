using DeltaX.DataAccess.Entities;
using DeltaX.DataAccess.Interfaces.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeltaX.DataAccess.Implementation.Repo
{
    public class MovieRepo : Repository<Movie, int>, IMovieRepo
    {
        public MovieRepo(DXContext dXContext) : base(dXContext)
        {

        }
    }
}
