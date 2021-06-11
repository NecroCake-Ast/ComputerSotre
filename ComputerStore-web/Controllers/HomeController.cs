using ComputerStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IComplectationRepositary _complectations;

        public HomeController(ILogger<HomeController> logger,
                              IComplectationRepositary complectations)
        {
            _logger = logger;
            _complectations = complectations;
        }

        public async Task<IActionResult> List()
        {
            ViewBag.Complects = await _complectations.List();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Complect = await _complectations.FindByID(id);
            return View();
        }
    }
}
