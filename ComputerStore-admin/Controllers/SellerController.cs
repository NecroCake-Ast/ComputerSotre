using ComputerStoreAdmin.Models.Seller;
using ComputerStoreAdmin.Services.Seller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Controllers
{
    [Authorize(Roles = "seller")]
    public class SellerController : Controller
    {
        private static string RoleName = "seller";

        private IComplectationRepository _complectations;
        private IChequeRepository _cheques;
        public SellerController(IComplectationRepository complectations, IChequeRepository cheques)
        {
            _complectations = complectations;
            _cheques = cheques;
        }

        [HttpGet]
        public async Task<IActionResult> Complectations()
        {
            ViewBag.List = await _complectations.List(RoleName);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Cheques()
        {
            ViewBag.List = await _cheques.List(RoleName);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ChequeDetails(int id)
        {
            Cheque cheque = await _cheques.FindByID(RoleName, id);
            return View(cheque);
        }

        [HttpGet]
        public async Task<IActionResult> Addition(int id)
        {
            ServicesList services = await _complectations.GetServices(RoleName);
            services.ComplectID = id;
            return View(services);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(ServicesList services)
        {
            int chequeID = await _complectations.SaleComplectation(RoleName, services);
            ChequeGenerator.CreateCheque(await _cheques.FindByID(RoleName, chequeID));
            return RedirectToAction("ChequeDetails", new { id = chequeID });
        }

        [HttpGet]
        public IActionResult LoadCheque(string id)
        {
            string file_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/cheque/" + id + ".pdf");
            string file_type = "application/pdf";
            string file_name = "Заказ " + id + ".pdf";
            return PhysicalFile(file_path, file_type, file_name);
        }
    }
}
