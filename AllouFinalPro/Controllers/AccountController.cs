using AllouFinalPro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllouFinalPro.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext db;
        public AccountController(AppDbContext _db )
        {
            db = _db;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var chkUser = db.Users.Where(u => u.UserName.Equals(user.UserName) && u.Password.Equals(user.Password)).Include(d=>d.Role);

            if (chkUser.Any())
            {
                if (chkUser.SingleOrDefault().Role.RoleName=="admin")
                {
                    HttpContext.Session.SetString("Name", chkUser.SingleOrDefault().UserName);
                    return RedirectToAction("Index", "CPanel", new { area = "Administrator" });
                }
                else
                {
                    HttpContext.Session.SetString("Name", chkUser.SingleOrDefault().UserName);
                    return RedirectToAction("Index", "CPanel", new { area = "User" });
                }

               

            }
            return View(user);
        }
    }
}
