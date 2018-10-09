using System;

namespace BAL.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
