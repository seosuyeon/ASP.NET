using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using syStudy.Models;

namespace syStudy.DataContext
{
    public class BoardDbContext : DbContext //C# 상속
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Board> Boards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=syBoardDb;User Id=sa;Password=tjtndus2280;");
        }
    }
}
