using DAL.Entities;
using System;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<LookUp> LookUpRepository { get; }
        void Commit();
    }
}
