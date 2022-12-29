using Chess.Application;
using Chess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Infrastructure
{
    public class MapRepository : IMapRepository
    {
        public static int[] mapPositions = new int[] { 8, 8 };
        public static List<Map> maps = new List<Map>()
        {
            new Map() { Id = 1, Name = "Standard Map", cols = mapPositions[0], rows = mapPositions[1]}
        };

        public int[] GetAllPositions()
        {
            return mapPositions;
        }
        public List<Map> GetAllMaps()
        {
            return maps;
        }

    }
}
