using DeltaX.Core.POCO;
using DeltaX.DataAccess.Entities;
using DeltaX.DataAccess.Interfaces.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.DataAccess.Implementation.Repo
{
    public class MovieActorRepo : Repository<MovieActor, int>, IMovieActorRepo
    {
        public DXContext _dXContext;
        public MovieActorRepo(DXContext dXContext) : base(dXContext)
        {
            _dXContext = dXContext;

        }

        public async Task<List<MovieAndActor>> GetMovieActorsByID(List<int> movieIDs)
        {
            var query = (from ma in _dXContext.MovieActors
                         join act in _dXContext.Actors on ma.ActorID equals act.Id
                         where movieIDs.Contains(ma.MovieID)
                         select new MovieAndActor
                         {
                             MovieID = ma.MovieID,
                             ActorID = act.Id,
                             ActorName = act.Name
                         });
            return await query.ToListAsync();


        }
    }
}
