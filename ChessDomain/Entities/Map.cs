using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Domain.Entities
{
    public class Map : BaseEntity
    {
        public string Name { get; set; }
        public int Cols { get; set; }
        public int Rows { get; set; }

        // Navigations
        public ICollection<Box> Boxes { get; set; }
    }
}
