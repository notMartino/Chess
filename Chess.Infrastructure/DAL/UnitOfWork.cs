using Chess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Infrastructure.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChessContext _dbContext;
        private IGenericRepository<Map> _mapRepository;
        private IGenericRepository<Box> _boxRepository;

        public UnitOfWork(ChessContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<Map> mapRepository => _mapRepository ??= new GenericRepository<Map>(_dbContext);
        public IGenericRepository<Box> boxRepository => _boxRepository ??= new GenericRepository<Box>(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
