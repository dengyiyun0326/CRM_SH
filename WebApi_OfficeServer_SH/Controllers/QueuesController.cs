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

    public class QueuesController : ApiController
    {
        OfficeDBContext caseDBContext = new OfficeDBContext();


        [System.Web.Mvc.HttpGet]
        public List<CaseQueue> Get()
        {
            var sortList = caseDBContext.CaseQueue.OrderBy(c => c.CallingCountry).ThenBy(t => DateTime.ParseExact(t.EndTimeSla,@"MM\/ dd\/ yyyy HH: mm",null)).ToList();
            return sortList;
        }
    }
}