using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_OfficeServer_SH.Models;

namespace WebApi_OfficeServer_SH.Controllers
{
    public class QueuesController : ApiController
    {
        List<CaseQueue> caseQueueList = new List<CaseQueue>();

        //initial test

        // GET api/<controller>
        public List<CaseQueue> Get()
        {
            return caseQueueList;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]List<CaseQueue> clientQueueList)
        {

            var response = Request.CreateResponse(HttpStatusCode.Created, "OfficeQueue");
            return response;
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