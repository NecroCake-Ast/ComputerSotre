using ComputerStoreAdmin.Models.Store;
using ComputerStoreAdmin.Services.Items;
using ComputerStoreAdmin.Services.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Controllers
{
    [Authorize(Roles = "storekeeper")]
    public class StorekeeperController : Controller
    {
        private static string RoleName = "storekeeper";
        private IStorageRepository _storage;
        private IItemRepository _item;

        public StorekeeperController(IStorageRepository storage, IItemRepository item)
        {
            _storage = storage;
            _item = item;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.List = await _storage.List(RoleName);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Find(StoredItemSearchData data)
        {
            if (data.Etalon == null)
                data.Etalon = "";
            try {
                ViewBag.List = await _storage.Find(RoleName, data);
            }
            catch (Exception e) {
                ViewBag.Msg = e.Message.Substring(e.Message.IndexOf(':') + 1);
            }
            return View("List");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Items = await _item.List(RoleName);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(StoredItem storedItem)
        {
            await _storage.Add(RoleName, storedItem);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Items = await _item.List(RoleName);
            StoredItem storedItem = await _storage.Find(RoleName, id);
            if (storedItem != null)
                return View(storedItem);
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StoredItem storedItem)
        {
            await _storage.Update(RoleName, storedItem);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _storage.Remove(RoleName, id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Deficit()
        {
            ViewBag.List = await _item.DeficitList(RoleName);
            return View();
        }
    }
}
