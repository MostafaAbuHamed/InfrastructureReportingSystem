using InfraReportingSystem.ServiceAbstractions.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraReportingSystem.ServiceAbstractions.Repositories { 

    public interface IRepositoy<T> where T : class 
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

        Task<T?> GetBySpecAsync(ISpecification<T> spec);

        Task<IEnumerable<T>> ListBySpecAsync(ISpecification<T> spec);

        Task<bool> AnyAsync(ISpecification<T> spec);

    }
}