using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id  { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
