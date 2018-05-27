using DeltaX.Core.POCO;
using DeltaX.DataAccess.Entities;
using DeltaX.DataAccess.Interfaces;
using DeltaX.DataAccess.Interfaces.Repo;
using DeltaX.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.Services.Implementation
{
    public class ActorService : IActorService
    {
        IActorRepo _actorRepo;
        IUnitOfWork _unitOfWork;
        public ActorService(IUnitOfWork unitOfWork)
        {
            _actorRepo = unitOfWork.GetActorRepo();
            _unitOfWork = unitOfWork;
        }

        public async Task InsertTestActor()
        {
            Actor actor = new Actor
            {
                Bio = "Yo yo Honey Singh",
                DOB = new DateTime(1994, 12, 05),
                Name = "yo boy",
                Sex = "M"
            };
            await _actorRepo.Insert(actor);
            await _unitOfWork.Save();
        }

        public async Task<List<ActorMini>> GetAllActors()
        {
            return await _actorRepo.GetAllActorsMini();
        }
    }
}
