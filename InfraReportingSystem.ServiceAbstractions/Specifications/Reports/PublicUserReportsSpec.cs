using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraReportingSystem.ServiceAbstractions.Specifications.Reports
{
    public class PublicUserReportsSpec : BaseReportListSpecification
    {
        public PublicUserReportsSpec(string userId)
        {
            AddCriteria(r => r.SubmittedById == userId);
        }
    }
}
