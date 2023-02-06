using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruiment.Application.Common.Abstractions
{
    /// <summary>
    /// This interface defines methods for commands (Insert,Update and delete actions).
    /// </summary>
    public interface ICommandRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
    }
}
