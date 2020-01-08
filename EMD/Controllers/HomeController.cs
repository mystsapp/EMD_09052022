using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EMD.Models;
using LoggerService;

namespace EMD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoggerManager _ilogger;

        public HomeController(ILogger<HomeController> logger, ILoggerManager ilogger)
        {
            _logger = logger;
            _ilogger = ilogger;
        }

        public IActionResult Index()
        {
            //_ilogger.LogInfo("Here is info message from the controller.");
            //_ilogger.LogDebug("Here is debug message from the controller.");
            //_ilogger.LogWarn("Here is warn message from the controller.");
            //_ilogger.LogError("Here is error message from the controller.");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
