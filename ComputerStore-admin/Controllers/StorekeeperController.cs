using ComputerStoreAdmin.Services.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Controllers
{
    public class StorekeeperController : Controller
    {
        private IStorageRepository _storage;

        public StorekeeperController(IStorageRepository storage)
        {
            _storage = storage;
        }

        [Authorize(Roles = "storekeeper")]
        public async Task<IActionResult> List()
        {
            return View(await _storage.List("storekeeper"));
        }
    }
}
