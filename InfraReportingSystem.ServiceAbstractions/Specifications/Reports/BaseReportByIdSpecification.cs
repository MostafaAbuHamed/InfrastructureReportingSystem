using InfraReportingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraReportingSystem.ServiceAbstractions.Specifications.Reports
{
    public class BaseReportByIdSpecification : BaseSpecification<Report>
    {
        public BaseReportByIdSpecification(int reportId)
        {
            AddCriteria(r => r.Id == reportId);

            AddInclude(r => r.Category);
            AddInclude(r => r.ReportPics);

            ApplyAsNoTracking();
        }
    }
}
