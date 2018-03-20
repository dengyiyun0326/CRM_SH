using System;
using System.Collections.Generic;

namespace WebApi_OfficeServer_SH.Models
{
    public partial class CaseQueue
    {
        public string CaseId { get; set; }
        public string Severity { get; set; }
        public string EndTimeSla { get; set; }
        public string CallingCountry { get; set; }
        public string InternalTitle { get; set; }
        public string CustomerTitle { get; set; }
        public string SupportTopic { get; set; }
        public string BelongQueue { get; set; }
        public string IfBypass { get; set; }
        public string IfAssign { get; set; }
    }
}
