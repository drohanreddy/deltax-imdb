using DeltaX.DataAccess.Implementation.Repo;
using DeltaX.DataAccess.Interfaces;
using DeltaX.DataAccess.Interfaces.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static DeltaX.Core.Infrastructure.LoggerHelper;

namespace DeltaX.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DXContext _dXContext = default(DXContext);
        private IActorRepo _actorRepo = null;
        private IMovieRepo _movieRepo = null;
        private IMovieActorRepo _movieActorRepo = null;
        private IProducerRepo _producerRepo = null;
        public UnitOfWork(DXContext dXContext)
        {
            _dXContext = dXContext;
        }

        public DXContext getDXContext(){
            return _dXContext;
        }

        public IActorRepo GetActorRepo()
        {
            if (_actorRepo == null)
            {
                _actorRepo = new ActorRepo(_dXContext);
            }
            return _actorRepo;
        }

        public IMovieActorRepo GetMovieActorRepo()
        {
            if (_movieActorRepo == null)
            {
                _movieActorRepo = new MovieActorRepo(_dXContext);
            }
            return _movieActorRepo;
        }

        public IMovieRepo GetMovieRepo()
        {
            if (_movieRepo == null)
            {
                _movieRepo = new MovieRepo(_dXContext);
            }
            return _movieRepo;
        }

        public IProducerRepo GetProducerRepo()
        {
            if (_producerRepo == null)
            {
                _producerRepo = new ProducerRepo(_dXContext);
            }
            return _producerRepo;
        }

        public async Task Save()
        {
            if (this._dXContext != null) await this._dXContext.SaveChangesAsync();
        }
    }
}
