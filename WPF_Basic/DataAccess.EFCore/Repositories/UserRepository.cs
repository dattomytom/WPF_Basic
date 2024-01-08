using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WPF_Basic.Domain.Interfaces;
using WPF_Basic.Models;

namespace WPF_Basic.DataAccess.EFCore.Repositories
{
    public class UserRepository :GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
           var user =_context.Users.Where(x=>x.UserName == credential.UserName && x.Password == credential.Password).FirstOrDefault();
           return user == null ?false : true;
        }

        public IEnumerable<User> GetPopularUsers(int counte)
        {
            return _context.Users.OrderByDescending(x=>x.UserName).Take(counte).ToList();
        }
    }
}
