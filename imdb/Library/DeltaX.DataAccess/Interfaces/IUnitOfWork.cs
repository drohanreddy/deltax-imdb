using DeltaX.DataAccess.Interfaces.Repo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IActorRepo GetActorRepo();
        IMovieRepo GetMovieRepo();
        IMovieActorRepo GetMovieActorRepo();
        IProducerRepo GetProducerRepo();
        Task Save();
    }
}
