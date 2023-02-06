using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruiment.Application.Common.Exceptions
{
    /// <summary>
    /// Exception uses when data is duplicated
    /// </summary>

    public class DuplicateDataException: Exception
    {
        public DuplicateDataException() : base()
        {
        }

        public DuplicateDataException(string message)
            : base(message)
        {
            Source = message;
        }

        public DuplicateDataException(string message, Exception innerException)
            : base(message, innerException)
        {
            Source = message;
        }

        public DuplicateDataException(string name, object key)
            : base()
        {
            Source = $"Entity \"{name}\" ({key}) is duplicated.";
        }

    }
}
