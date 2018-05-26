using DeltaX.DataAccess.Implementation;
using DeltaX.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetlaX.API.Infra
{
    public static class ServicesExtension
    {
        public static void AddRepos(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
        }
    }
}
