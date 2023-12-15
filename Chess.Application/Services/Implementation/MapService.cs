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
            try
            {
                List<Map> maps = await _unitOfWork.mapRepository.GetAll(filter, orderBy, includes);
                List<MapDTO> mapsDTO = _mapper.Map<List<MapDTO>>(maps);

                return mapsDTO;
            }
            catch (Exception ex)
            {
                this.AddError(ex.Message);
                return new ();
            }
        }

        public async Task<MapDTO> Get(Expression<Func<Map, bool>> filter = null, List<string> includes = null)
        {
            try
            {
                Map map = await _unitOfWork.mapRepository.Get(filter, includes);
                MapDTO mapDTO = _mapper.Map<MapDTO>(map);

                return mapDTO;
            }
            catch (Exception ex)
            {
                this.AddError(ex.Message);
                return new ();
            }
        }

        public async Task<MapDTO> Update(MapDTO mapDTO, List<string> includes = null)
        {
            try
            {
                Map map = _mapper.Map<Map>(mapDTO);
                _unitOfWork.mapRepository.Update(map);

                mapDTO = await Get(x => x.Id == map.Id, includes);
                return mapDTO;
            }
            catch (Exception ex)
            {
                this.AddError(ex.Message);
                return new ();
            }
        }

        public Task<MapDTO> Delete(MapDTO map)
        {
            throw new NotImplementedException();
        }
    }
}
