using InfraReportingSystem.ServiceAbstractions.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraReportingSystem.Persistence.Specifications
{

    public static class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;

            if (!spec.IsTrackingEnabled)
                query = query.AsNoTracking();

            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);

            query = spec.Includes.Aggregate(query,
                (current, include) => current.Include(include));

            query = spec.IncludeStrings.Aggregate(query,
                (current, include) => current.Include(include));

            return query;
        }
    }

}
