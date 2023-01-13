using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Application.DTOs
{
    public class BoxDTO : BaseDTO
    {
        public string ColId { get; set; }
        public int RowId { get; set; }
        public bool Color { get; set; }
        //[ForeignKey(nameof(Map))]
        public long MapId { get; set; }

        // Navigations
        public MapDTO Map { get; set; }
    }
}
