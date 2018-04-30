using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApi_OfficeServer_SH.Models;

namespace WebApi_OfficeServer_SH.Controllers
{
    public class IdleController : Controller
    {
        OfficeDBContext officeDBContext = new OfficeDBContext();

        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Purple Star No.999";
            var sortList = officeDBContext.CaseWellness.OrderBy(p => p.OwnerAlias).ThenBy(q => q.WaitState);
            return View(await sortList.ToListAsync());
        }
    }
}