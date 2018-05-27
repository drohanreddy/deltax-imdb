using DeltaX.Core.POCO;
using DeltaX.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.DataAccess.Interfaces.Repo
{
    public interface IActorRepo : IRepository<Actor, int>
    {        
        Task<List<ActorMini>> GetAllActorsMini();
    }
}
