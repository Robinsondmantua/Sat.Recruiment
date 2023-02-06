using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruiment.Application.Common.Abstractions;

namespace Sat.Recruiment.Infraestructure.Repository.User
{
    /// <summary>
    /// User's command repository 
    /// </summary>

    public class UserRepositoryQueries : IQueryRepository<Domain.Models.User>
    {
        private readonly IMemoryContext _memoryContext;

        public UserRepositoryQueries(IMemoryContext memoryContext)
        {
            _memoryContext = memoryContext;
        }

        public async Task<bool> CheckDuplicatesEntriesAsync(Domain.Models.User request)
        {
            var areDuplicatedEntries = Task.FromResult(_memoryContext.Users?.Any(x=> x.Email == request.Email 
            || x.Phone == request.Phone
            || x.Name == request.Name
            || x.Address == request.Address));
            return await areDuplicatedEntries ?? true;
        }
    }
}
