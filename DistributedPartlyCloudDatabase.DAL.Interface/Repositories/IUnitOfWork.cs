using System;

namespace DistributedPartlyCloudDatabase.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
