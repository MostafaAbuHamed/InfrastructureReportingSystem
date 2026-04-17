using InfraReportingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraReportingSystem.ServiceAbstractions.Specifications.Reports
{
    public abstract class BaseReportListSpecification : BaseSpecification<Report>
    {
        protected BaseReportListSpecification()
        {
            AddInclude(r => r.Category);
            AddInclude(r => r.ReportPics);

            ApplyAsNoTracking();
        }
    }
}
