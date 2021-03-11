using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFDbContext _context;

        private readonly IRepository<LookUp> _lookUpRepository;

        public UnitOfWork(EFDbContext context,
             IRepository<LookUp> lookUpRepository)
        {
            _context = context;
            _lookUpRepository = lookUpRepository;
        }

        public IRepository<LookUp> LookUpRepository => _lookUpRepository;

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
