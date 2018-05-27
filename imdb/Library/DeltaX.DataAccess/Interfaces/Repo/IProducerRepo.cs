using DeltaX.Core.POCO;
using DeltaX.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.DataAccess.Interfaces.Repo
{
    public interface IProducerRepo : IRepository<Producer, int>
    {
        Task<List<ProducerPoco>> GetAllProducers();
    }
}
