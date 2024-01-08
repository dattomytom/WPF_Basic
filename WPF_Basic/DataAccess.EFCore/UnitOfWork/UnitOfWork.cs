using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Basic.DataAccess.EFCore.Repositories;
using WPF_Basic.Domain.Interfaces;
using WPF_Basic.Models;

namespace WPF_Basic.DataAccess.EFCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserRepository Users { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}
