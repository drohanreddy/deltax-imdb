using DeltaX.DataAccess.Entities;
using DeltaX.DataAccess.Interfaces.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeltaX.DataAccess.Implementation.Repo
{
    public class MovieActorRepo : Repository<MovieActor, int>, IMovieActorRepo
    {
        public MovieActorRepo(DXContext dXContext) : base(dXContext)
        {

        }
    }
}
