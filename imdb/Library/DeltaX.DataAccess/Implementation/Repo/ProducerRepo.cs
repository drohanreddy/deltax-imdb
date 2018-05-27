using DeltaX.Core.POCO;
using DeltaX.DataAccess.Entities;
using DeltaX.DataAccess.Interfaces.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.DataAccess.Implementation.Repo
{
    public class ProducerRepo : Repository<Producer, int>, IProducerRepo
    {
        DXContext _dXContext;
        public ProducerRepo(DXContext dXContext) : base(dXContext)
        {
            _dXContext = dXContext;
        }

        public async Task<List<ProducerPoco>> GetAllProducers()
        {
            return await _dXContext.ProducersMini.FromSql("SELECT Id ProducerID, Name ProducerName from DeltaX.dbo.Producer").ToListAsync();
        }
    }
}
