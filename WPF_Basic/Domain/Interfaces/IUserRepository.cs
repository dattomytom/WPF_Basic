using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WPF_Basic.DataAccess.EFCore.Interfaces;
using WPF_Basic.Models;

namespace WPF_Basic.Domain.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        IEnumerable<User> GetPopularUsers(int counte);
        bool AuthenticateUser(NetworkCredential credential);
    }
}
