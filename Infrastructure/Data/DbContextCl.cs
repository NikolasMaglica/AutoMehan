using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DbContextCl : DbContext
    {
        public DbContextCl(DbContextOptions<DbContextCl> dbContextOptions): base(dbContextOptions) { }
            public DbSet<Blog> Blogs { get; set; }
    }
}
