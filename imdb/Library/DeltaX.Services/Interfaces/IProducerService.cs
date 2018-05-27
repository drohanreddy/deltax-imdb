using DeltaX.Core.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.Services.Interfaces
{
    public interface IProducerService
    {
        Task<List<ProducerPoco>> GetAllProducers();
    }
}
