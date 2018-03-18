using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApi_OfficeServer_SH.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi_OfficeServer_SH.Controllers
{
    public class HomeController : Controller
    {
        OfficeDBContext caseDBContext = new OfficeDBContext();

        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Purple Star No.999";

            return View(await caseDBContext.CaseQueue.ToListAsync());
        }
    }
}
