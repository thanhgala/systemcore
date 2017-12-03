using System;
using System.Collections.Generic;
using System.Text;

namespace SystemCore.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
