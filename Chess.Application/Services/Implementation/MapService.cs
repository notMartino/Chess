using Chess.Application.DTOs;
using Chess.Application.Services.Interfaces;
using Chess.Domain.Entities;
using Chess.Infrastructure.DAL;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Application.Services.Implementations
{
    public class MapService : BaseService, IMapService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MapService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MapDTO>> GetAll(Expression<Func<Map, bool>> filter = null, Func<IQueryable<Map>, IOrderedQueryable<Map>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public async Task<MapDTO> Get(Expression<Func<Map, bool>> filter = null, List<string> includes = null)
        {
            var map = await _unitOfWork.mapRepository.Get(filter, includes);
            var mapDTO = new MapDTO();

            if (map != null)
            {
                mapDTO = _mapper.Map<MapDTO>(map);
            }

            return mapDTO;
        }
    }
}
