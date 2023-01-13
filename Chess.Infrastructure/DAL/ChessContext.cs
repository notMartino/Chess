using Chess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Infrastructure.DAL
{
    public class ChessContext : DbContext
    {
        public ChessContext(DbContextOptions options) : base(options){ }

        public DbSet<Map> Maps { get; set; }
        public DbSet<Box> Boxes { get; set; }

    }
}
