using ComputerStoreAdmin.Models.Admin;
using ComputerStoreAdmin.Services.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Controllers
{
    [Authorize(Roles = "administrator")]
    public class AdminController : Controller
    {
        private static string RoleName = "administrator";
        private IUsersRepository _users;
        private IRolesRepository _roles;

        public AdminController(IUsersRepository users, IRolesRepository roles)
        {
            _users = users;
            _roles = roles;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.List = await _users.List(RoleName);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Find(UserSearchData data)
        {
            if (data.LoginEtalon == null)
                data.LoginEtalon = "";
            try
            {
                ViewBag.List = await _users.Find(RoleName, data);
            }
            catch (Exception e)
            {
                ViewBag.Msg = e.Message.Substring(e.Message.IndexOf(':') + 1);
            }
            return View("List");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Roles = await _roles.List(RoleName);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegistrationData data)
        {
            await _users.Add(RoleName, data);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string login)
        {
            if (await _users.isRegistered(RoleName, login))
                return View(new ChangePasswordData() { login = login });
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ChangePasswordData data)
        {
            data.login ??= "";
            data.password ??= "";
            data.confirm ??= "";
            await _users.Update(RoleName, data);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string Login)
        {
            await _users.Remove(RoleName, Login);
            return RedirectToAction("List");
        }
    }
}
