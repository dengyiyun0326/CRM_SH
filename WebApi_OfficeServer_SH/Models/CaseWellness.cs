using System;
using System.Collections.Generic;

namespace WebApi_OfficeServer_SH.Models
{
    public partial class CaseWellness
    {
        public string CaseId { get; set; }
        public string CaseTitle { get; set; }
        public string LastCommTime { get; set; }
        public string OpenDays { get; set; }
        public string IdleDays { get; set; }
        public string Labor { get; set; }
        public string WaitState { get; set; }
        public string OwnerAlias { get; set; }
    }
}
