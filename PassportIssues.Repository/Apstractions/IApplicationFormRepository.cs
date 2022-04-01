using PassportIssues.Domain.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportIssues.Repository.Apstractions
{
    public interface IApplicationFormRepository
    {
        Task<Guid> AddAsync(FormModel request);
        Task<List<FormModel>> GetAllAsync();
        Task<bool> GetAsync(Guid Id);
        IQueryable<FormModel> Table { get; }
    }
}
