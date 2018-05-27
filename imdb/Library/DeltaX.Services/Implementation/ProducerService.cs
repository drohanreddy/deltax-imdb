using DeltaX.Core.POCO;
using DeltaX.DataAccess.Interfaces;
using DeltaX.DataAccess.Interfaces.Repo;
using DeltaX.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.Services.Implementation
{
    public class ProducerService : IProducerService
    {
        IProducerRepo _movieRepo;
        IUnitOfWork _unitOfWork;
        public ProducerService(IUnitOfWork unitOfWork)
        {
            _movieRepo = unitOfWork.GetProducerRepo();
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ProducerPoco>> GetAllProducers()
        {
            return await _movieRepo.GetAllProducers();
        }
    }
}
