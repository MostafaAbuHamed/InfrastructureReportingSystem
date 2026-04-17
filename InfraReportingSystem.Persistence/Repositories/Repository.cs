using InfraReportingSystem.Persistence.Data;
using InfraReportingSystem.Persistence.Specifications;
using InfraReportingSystem.ServiceAbstractions.Repositories;
using InfraReportingSystem.ServiceAbstractions.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraReportingSystem.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id)
            => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity is not null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T?> GetBySpecAsync(ISpecification<T> spec)
            => await SpecificationEvaluator<T>
                .GetQuery(_dbSet.AsQueryable(), spec)
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<T>> ListBySpecAsync(ISpecification<T> spec)
            => await SpecificationEvaluator<T>
                .GetQuery(_dbSet.AsQueryable(), spec)
                .ToListAsync();

        public async Task<bool> AnyAsync(ISpecification<T> spec)
            => await SpecificationEvaluator<T>
                .GetQuery(_dbSet.AsQueryable(), spec)
                .AnyAsync();
    }
}
