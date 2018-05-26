using DeltaX.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DetlaX.API.Controllers
{
    public class BaseController : Controller
    {
        ILogger _logger;
        public BaseController(ILogger logger)
        {
            _logger = logger;
        }
        public TResult Execute<TService, TResult>(TService service, Expression<Func<TService, TResult>> callMethod)
          where TService : class
        {

            var stopwatch = Stopwatch.StartNew();

            var started = DateTime.Now;
            var success = true;
            try
            {
                return callMethod.Compile().Invoke(service);
            }
            catch (Exception exception)
            {
                success = false;
                _logger.LogError(exception, $"Exception in callmethod {callMethod.Name}");
                throw;
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogMethodExecution(started, stopwatch.Elapsed, success, service.ToString() + " " + callMethod.ToString());
            }
        }
        public void ExecuteVoid<TService>(TService service, Expression<Action<TService>> callMethod)
           where TService : class
        {

            var stopwatch = Stopwatch.StartNew();

            var started = DateTime.Now;
            var success = true;
            try
            {
                callMethod.Compile().Invoke(service);
            }
            catch (Exception exception)
            {
                success = false;
                _logger.LogError(exception, $"Exception in callmethod {callMethod.Name}");
                throw;
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogMethodExecution(started, stopwatch.Elapsed, success, service.ToString() + " " + callMethod.ToString());
            }
        }
        public async Task ExecuteVoidAsync<TService>(TService service, Expression<Func<TService, Task>> callMethod)
           where TService : class
        {

            var stopwatch = Stopwatch.StartNew();

            var started = DateTime.Now;
            var success = true;
            try
            {
                await callMethod.Compile().Invoke(service);
            }
            catch (Exception exception)
            {
                success = false;
                _logger.LogError(exception, $"Exception in callmethod {callMethod.Name}");
                throw;
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogMethodExecution(started, stopwatch.Elapsed, success, service.ToString() + " " + callMethod.ToString());
            }
        }
        public async Task<TResult> ExecuteAsync<TService, TResult>(TService service, Expression<Func<TService, Task<TResult>>> callMethod)
           where TService : class
        {

            var stopwatch = Stopwatch.StartNew();

            var started = DateTime.Now;
            var success = true;
            try
            {
                return await callMethod.Compile().Invoke(service);
            }
            catch (Exception exception)
            {
                success = false;
                _logger.LogError(exception, $"Exception in callmethod {callMethod.Name}");
                return default(TResult);
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogMethodExecution(started, stopwatch.Elapsed, success, service.ToString() + " " + callMethod.ToString());
            }
        }
    }
}
