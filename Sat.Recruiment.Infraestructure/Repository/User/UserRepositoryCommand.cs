using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruiment.Application.Common.Abstractions;

namespace Sat.Recruiment.Infraestructure.Repository.User
{
    /// <summary>
    /// User's command repository 
    /// </summary>
    public class UserRepositoryCommand : ICommandRepository<Domain.Models.User>
    {
        private readonly IMemoryContext _memoryContext;
        private readonly IUnitOfWork _unitOfWork;

        public UserRepositoryCommand(IMemoryContext memoryContext, IUnitOfWork unitOfWork)
        {
            _memoryContext = memoryContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Models.User> AddAsync(Domain.Models.User entity)
        {
            _memoryContext.Users.Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }
    }
}
