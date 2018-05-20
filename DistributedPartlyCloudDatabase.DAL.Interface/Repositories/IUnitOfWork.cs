using System;
using System.Data.Entity;

namespace DistributedPartlyCloudDatabase.DAL.Interface
{
    public interface IUnitOfWork<U> where U : DbContext, IDisposable
    {
        void Commit();
    }
}
