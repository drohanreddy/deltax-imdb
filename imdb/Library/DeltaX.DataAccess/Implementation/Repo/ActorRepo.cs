using DeltaX.Core.POCO;
using DeltaX.DataAccess.Entities;
using DeltaX.DataAccess.Interfaces.Repo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeltaX.DataAccess.Implementation.Repo
{
    public class ActorRepo : Repository<Actor, int>, IActorRepo
    {
        DXContext _dXContext;
        public ActorRepo(DXContext dXContext) : base(dXContext) 
        {
            _dXContext = dXContext;
        }

        public async Task<List<ActorMini>> GetAllActorsMini()
        {
            return await _dXContext.ActorMini.FromSql("SELECT Id as ActorID, Name as ActorName from DeltaX.dbo.Actor").ToListAsync();
        }
    }
}
