using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationCore.Interfaces.IGenericRepository;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }

}
