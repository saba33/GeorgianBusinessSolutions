using Microsoft.EntityFrameworkCore;
using PassportIssues.Domain.Poco;
using PassportIssues.Repository.Apstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportIssues.Repository.Implementation
{
    public class ApplicationFormRepository : IApplicationFormRepository
    {
        #region private members
        protected readonly DbContext _context;
        protected readonly DbSet<FormModel> _dbSet;
        #endregion

        #region Public Members
        public ApplicationFormRepository(DbContext context)
        {
            _context = context;
            _dbSet  = context.Set<FormModel>();
        }
        public IQueryable<FormModel> Table => _dbSet;
        
        public async Task<Guid> AddAsync(FormModel request)
        {
            await _dbSet.AddAsync(request);
            await _context.SaveChangesAsync();
            return await Task.FromResult(request.Id);
        }

        public async Task <List<FormModel>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<bool> GetAsync(Guid Id)
        {
            return await _dbSet.AnyAsync(x => x.Id == Id);
        }
        #endregion 
    }
}
