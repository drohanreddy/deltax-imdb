using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using DeltaX.DataAccess;
using Microsoft.EntityFrameworkCore;
using DetlaX.API.Infra;
using DeltaX.Core.Infrastructure;
using Serilog;
using Microsoft.Extensions.Logging;

namespace DetlaX.API
{
    public class Startup
    {
        private readonly ILoggerFactory loggerFactory;
        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
            var config = new LoggerHelper().GetLoggerConfig();
            Log.Logger = config.CreateLogger();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
            services.AddMvc();
            services.AddDbContext<DXContext>(options => options.UseSqlServer(@"data source=.\SQLExpress;initial catalog=DeltaX;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"));
            services.AddRepos();
            services.AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
