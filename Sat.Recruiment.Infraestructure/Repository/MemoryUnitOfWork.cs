using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using Sat.Recruiment.Application.Common.Abstractions;

namespace Sat.Recruiment.Infraestructure.Repository
{
    /// <summary>
    /// Unit of work pattern to confirm operations related with the BB.DD repository. 
    /// </summary>
    public class MemoryUnitOfWork : IUnitOfWork
    {
        private bool _disposedValue;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        public async Task CommitAsync()
        {
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task RollbackAsync()
        {
            await Task.CompletedTask;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
