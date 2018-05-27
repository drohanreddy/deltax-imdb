using DeltaX.DataAccess.Implementation;
using DeltaX.DataAccess.Interfaces;
using DeltaX.Services.Implementation;
using DeltaX.Services.Interfaces;
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IProducerService, ProducerService>();
            services.AddScoped<IMovieService, MovieService>();
        }
    }
}
