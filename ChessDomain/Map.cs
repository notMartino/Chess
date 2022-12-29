using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Domain
{
    public class Map
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int cols { get; set; }
        public int rows { get; set; }
    }
}
