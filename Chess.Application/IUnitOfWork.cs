using Chess.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Infrastructure.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Map> mapRepository { get; }
        IGenericRepository<Box> boxRepository { get; }
        Task Save();
    }
}
