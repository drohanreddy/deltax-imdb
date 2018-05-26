using DeltaX.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeltaX.DataAccess.Interfaces.Repo
{
    public interface IMovieRepo : IRepository<Movie, int>
    {
    }
}
