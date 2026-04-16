using InfraReportingSystem.ServiceAbstractions.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfraReportingSystem.Services.Specifications
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>>? Criteria { get; private set; }
        public List<Expression<Func<T, object>>> Includes { get; } = new();
        public List<string> IncludeStrings { get; } = new();

        public bool IsTrackingEnabled { get; private set; } = true;

        protected void AddCriteria(Expression<Func<T, bool>> criteria)
            => Criteria = criteria;

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
            => Includes.Add(includeExpression);

        protected void AddInclude(string includeString)
            => IncludeStrings.Add(includeString);

        protected void ApplyAsNoTracking()
            => IsTrackingEnabled = false;
    }
}
