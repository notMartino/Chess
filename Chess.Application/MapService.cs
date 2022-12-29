using Chess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Application
{
    public class MapService : IMapService
    {
        private readonly IMapRepository _mapRepository;
        public MapService(IMapRepository mapRepository)
        {
            _mapRepository = mapRepository;
        }

        public int[] GetAllPositions()
        {
            var map = _mapRepository.GetAllPositions();

            return map;
        }

        public List<Map> GetAllMaps()
        {
            return _mapRepository.GetAllMaps();
        }
    }
}
