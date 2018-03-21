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
            var sortList = caseDBContext.CaseQueue.OrderBy(t => DateTime.ParseExact(t.EndTimeSla, "g", null));
            return View(await sortList.ToListAsync());
        }

        public async Task<ActionResult> Assigned(string id)
        {
            var caseEntity = caseDBContext.CaseQueue.SingleOrDefault(c => c.CaseId == id);
            CaseQueue reCase = new CaseQueue(caseEntity.CaseId,caseEntity.Severity,caseEntity.EndTimeSla,caseEntity.CallingCountry,caseEntity.InternalTitle,
                                            caseEntity.CustomerTitle,caseEntity.SupportTopic,caseEntity.BelongQueue);
            reCase.IfAssign = "true";
            caseDBContext.CaseQueue.Remove(caseEntity);
            await caseDBContext.SaveChangesAsync();
            caseDBContext.CaseQueue.Add(reCase);
            await caseDBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Bypassed(string id)
        {
            var caseEntity = caseDBContext.CaseQueue.SingleOrDefault(c => c.CaseId == id);
            CaseQueue reCase = new CaseQueue(caseEntity.CaseId, caseEntity.Severity, caseEntity.EndTimeSla, caseEntity.CallingCountry, caseEntity.InternalTitle,
                                            caseEntity.CustomerTitle, caseEntity.SupportTopic, caseEntity.BelongQueue);
            reCase.IfBypass = "true";
            caseDBContext.CaseQueue.Remove(caseEntity);
            await caseDBContext.SaveChangesAsync();
            caseDBContext.CaseQueue.Add(reCase);
            await caseDBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
