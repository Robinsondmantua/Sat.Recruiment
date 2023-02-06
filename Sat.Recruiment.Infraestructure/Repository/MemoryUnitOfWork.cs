using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruiment.Application.Common.Abstractions;

namespace Sat.Recruiment.Infraestructure.Repository
{
    /// <summary>
    /// Unit of work pattern to confirm operations related with the BB.DD repository. 
    /// </summary>
    public class MemoryUnitOfWork : IUnitOfWork
    {
        public async Task CommitAsync()
        {
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public async Task RollbackAsync()
        {
            await Task.CompletedTask;
        }
    }
}
