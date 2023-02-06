using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruiment.Application.Common.Abstractions
{
    /// <summary>
    /// This interface define the unit of work pattern.
    /// </summary>
    public interface IUnitOfWork: IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}
