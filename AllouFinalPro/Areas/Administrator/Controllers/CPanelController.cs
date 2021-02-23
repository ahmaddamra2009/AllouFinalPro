using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllouFinalPro.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CPanelController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Name") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account", new { area = "" });
        }
    }
}
