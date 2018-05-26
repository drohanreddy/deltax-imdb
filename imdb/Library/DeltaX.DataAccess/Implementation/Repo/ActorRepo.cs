using DeltaX.DataAccess.Entities;
using DeltaX.DataAccess.Interfaces.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeltaX.DataAccess.Implementation.Repo
{
    public class ActorRepo : Repository<Actor, int>, IActorRepo
    {
        public ActorRepo(DXContext dXContext) : base(dXContext) 
        {

        }

        public void InserTestActor()
        {
           
        }
    }
}
