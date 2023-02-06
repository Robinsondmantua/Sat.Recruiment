using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruiment.Domain.Models;

namespace Sat.Recruiment.Infraestructure.Repository
{
    /// <summary>
    /// Fake context
    /// </summary>
    internal class InMemoryContext : IMemoryContext
    {
        public List<User> Users { get; set; } = new List<User>();
    }

    internal interface IMemoryContext
    {
        List<User> Users { get; set; }
    }
}
