using PassportIssues.Domain.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PassportIssues.Services.Abstractions
{
    public interface IApplicationFormService
    {
        Task<Guid> AddAsync(FormModel request);
        Task<List<FormModel>> GetAllAsync();
        Task<bool> GetAsync(Guid Id);
    }
}
