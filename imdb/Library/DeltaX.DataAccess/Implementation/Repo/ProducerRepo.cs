using DeltaX.DataAccess.Entities;
using DeltaX.DataAccess.Interfaces.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeltaX.DataAccess.Implementation.Repo
{
    public class ProducerRepo : Repository<Producer, int>, IProducerRepo
    {
        public ProducerRepo(DXContext dXContext) : base(dXContext)
        {

        }
    }
}
