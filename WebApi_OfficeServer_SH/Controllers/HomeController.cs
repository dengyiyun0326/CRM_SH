using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Filters;
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
            var sortList = caseDBContext.CaseQueue.OrderBy(c => c.CallingCountry).ThenBy(t => DateTime.ParseExact(t.EndTimeSla, "g", null));
            return View(await sortList.ToListAsync());
        }

        public async Task<ActionResult> Assigned(string _caseID)
        {
            try
            {
                var query = "UPDATE CaseQueue SET ifAssign = 'true' WHERE caseID = {0}";
                caseDBContext.CaseQueue.FromSql(query, _caseID);
                await caseDBContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Bypassed(string _caseID)
        {
            try
            {
                await caseDBContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
