using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetlaX.API.Controllers
{
    [Route("Home")]
    public class HomeController : BaseController
    {
        ILogger _logger;
        public HomeController(ILogger<HomeController> logger) : base(logger)
        {
            _logger = logger;
        }

        [Route("")]
        public string TestMethod()
        {
            var st = Execute(this, t => t.GetString());
            return st;
        }

        private string GetString()
        {
            return "Hello";
        }
    }
}
