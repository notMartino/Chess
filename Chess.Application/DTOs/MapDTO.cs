using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Chess.Application.DTOs
{
    public class MapDTO : BaseDTO
    {
        public string Name { get; set; }
        public int Cols { get; set; }
        public int Rows { get; set; }

        // Navigations
        public ICollection<BoxDTO> Boxes { get; set; } = new List<BoxDTO>();
    }
}
