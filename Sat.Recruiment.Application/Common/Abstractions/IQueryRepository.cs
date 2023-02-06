using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruiment.Application.Common.Abstractions
{
    /// <summary>
    /// This interface defines methods for queries.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueryRepository<T> where T: class
    {
        Task<bool> CheckDuplicatesEntriesAsync(T request);
    }
}
