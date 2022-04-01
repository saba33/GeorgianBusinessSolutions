using PassportIssues.Domain.Poco;
using PassportIssues.Repository.Apstractions;
using PassportIssues.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportIssues.Services.Implementations
{
    public class ApplicationFormService : IApplicationFormService
    {
        #region Private Members
        protected readonly IApplicationFormRepository _repo;
        #endregion
        public ApplicationFormService(IApplicationFormRepository repo)
        {
            _repo = repo;
        }
        public async Task<Guid> AddAsync(FormModel request)
        {
            return await _repo.AddAsync(request);
        }

        public async Task<List<FormModel>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<bool> GetAsync(Guid Id)
        {
            return await _repo.GetAsync(Id);
        }
    }
}
