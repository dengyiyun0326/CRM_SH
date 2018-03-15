using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_OfficeServer_SH.Models
{
    public class CaseQueue
    {
        public string _caseID { get; set; }
        public string _severity { get; set; }
        public string _endTimeSLA { get; set; }
        public string _callingCountry { get; set; }
        public string _internalTitle { get; set; }
        public string _customerTitle { get; set; }
        public string _supportTopic { get; set; }
        public string _belongQueue { get; set; }

        public CaseQueue(string caseid, string severity, string endtimesla, string callingcountry,
            string internaltitle, string customertitle, string supporttopic, string belongqueue)
        {
            _caseID = caseid;
            _severity = severity;
            _endTimeSLA = endtimesla;
            _callingCountry = callingcountry;
            _internalTitle = internaltitle;
            _customerTitle = customertitle;
            _supportTopic = supporttopic;
            _belongQueue = belongqueue;
        }
    }
}