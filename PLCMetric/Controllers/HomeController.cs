using Microsoft.AspNetCore.Mvc;
using PLCMetric.Models;
using PLCMetric.Services;
using System.Diagnostics;

namespace PLCMetric.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPerformanceDataService _performanceService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IPerformanceDataService performanceService,
            ILogger<HomeController> logger)
        {
            _performanceService = performanceService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var metrics = await _performanceService.GetHouseBomMetricsAsync();
            return View(metrics);
        }

        public async Task<IActionResult> JobBom()
        {
            var metrics = await _performanceService.GetJobBomMetricsAsync();
            return View(metrics);
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
