using DeltaX.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeltaX.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DXContext _dXContext = default(DXContext);
        private object _syncLock = new Object();
        public UnitOfWork(DXContext dXContext)
        {
            _dXContext = dXContext;
        }
    }
}
