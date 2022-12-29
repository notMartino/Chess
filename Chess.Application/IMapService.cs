using Chess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Application
{
    public interface IMapService
    {
        int[] GetAllPositions();
        List<Map> GetAllMaps();
    }
}
