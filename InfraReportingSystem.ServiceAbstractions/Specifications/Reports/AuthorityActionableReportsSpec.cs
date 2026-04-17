using InfraReportingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraReportingSystem.ServiceAbstractions.Specifications.Reports
{
    public class AuthorityActionableReportsSpec : BaseReportListSpecification
    {
        public AuthorityActionableReportsSpec()
        {
            AddCriteria(r =>
                r.Status == ReportStatus.Submitted ||
                r.Status == ReportStatus.Rejected ||
                r.Status == ReportStatus.Blocked);
        }
    }
}
