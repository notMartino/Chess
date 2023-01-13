using Chess.Application.DTOs;
using Chess.Domain.Entities;
using System.Linq.Expressions;

namespace Chess.Application.Services.Interfaces
{
    public interface IBoxService
    {
        Task<List<BoxDTO>> GetAll(Expression<Func<Box, bool>> filter = null, Func<IQueryable<Box>, IOrderedQueryable<Box>> orderBy = null, List<string> includes = null);
        Task<BoxDTO> Get(Expression<Func<Box, bool>> filter = null, List<string> includes = null);
    }
}