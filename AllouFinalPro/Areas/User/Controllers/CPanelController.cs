using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllouFinalPro.Areas.User.Controllers
{
    [Area("User")]
    public class CPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
