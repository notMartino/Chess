using Chess.Application.DTOs;
using Chess.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Application.Services.Interfaces
{
    public interface IMapService
    {
        Task<List<MapDTO>> GetAll(Expression<Func<Map, bool>> filter = null, Func<IQueryable<Map>, IOrderedQueryable<Map>> orderBy = null, List<string> includes = null);
        Task<MapDTO> Get(Expression<Func<Map, bool>> filter = null, List<string> includes = null);
        Task<MapDTO> Update(MapDTO map, List<string> includes = null);
        Task<MapDTO> Delete(MapDTO map);
    }
}
