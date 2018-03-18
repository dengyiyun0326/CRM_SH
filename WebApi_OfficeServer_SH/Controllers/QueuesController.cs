using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApi_OfficeServer_SH.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebApi_OfficeServer_SH.Controllers
{
    [System.Web.Mvc.AllowAnonymous]
    public class QueuesController : ApiController
    {
        OfficeDBContext caseDBContext = new OfficeDBContext();

        // GET api/<controller>
        /*
        public List<CaseQueue> Get()
        {
            return caseDBContext.CaseQueue.ToList();
        }
        */

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> Post([FromBody]List<CaseQueue> caseQueueList)
        {
            //Clear Azure DB table
            try
            {
                caseDBContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [CaseQueue]");
                await caseDBContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }

            if (caseQueueList.Any())
            {
                //Fill Azure DB table with client list
                foreach (CaseQueue caseItem in caseQueueList)
                {
                    caseDBContext.CaseQueue.Add(caseItem);
                }
                try
                {
                    await caseDBContext.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    return Conflict();
                }
            }

            return CreatedAtRoute("DefaultApi", new { id=caseQueueList.Count},caseQueueList.Select(p=>p.CaseId));
        }
    }
}