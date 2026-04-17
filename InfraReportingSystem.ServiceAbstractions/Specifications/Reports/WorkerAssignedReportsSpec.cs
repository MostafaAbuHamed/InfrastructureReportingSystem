using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraReportingSystem.ServiceAbstractions.Specifications.Reports
{
    public class WorkerAssignedReportsSpec : BaseReportListSpecification
    {
        public WorkerAssignedReportsSpec(string workerId)
        {
            AddCriteria(r => r.AssignedWorkerId == workerId);
        }
    }
}
