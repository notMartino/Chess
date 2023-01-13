using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Domain.Entities
{
    public class Box : BaseEntity
    {
        public int ColId { get; set; }
        public int RowId { get; set; }
        public bool Color { get; set; }
        [ForeignKey(nameof(Map))]
        public long MapId { get; set; }

        // Navigations
        public Map Map { get; set; }

    }
}
