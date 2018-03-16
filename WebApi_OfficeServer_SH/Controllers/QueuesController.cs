using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_OfficeServer_SH.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebApi_OfficeServer_SH.Controllers
{
    public class QueuesController : ApiController
    {
        OfficeDBContext caseDBContext = new OfficeDBContext();

        // GET api/<controller>
        public List<CaseQueue> Get()
        {
            return caseDBContext.CaseQueue.ToList();
        }

        // POST api/<controller>
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

            return CreatedAtRoute("DefaultApi", new { id=caseQueueList.Count},caseQueueList.Select(p=>p.CaseId));

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}