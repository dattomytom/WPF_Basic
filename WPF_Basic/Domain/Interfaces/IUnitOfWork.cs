using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Basic.Domain.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository Users { get; }
        int Complete();
    }
}
