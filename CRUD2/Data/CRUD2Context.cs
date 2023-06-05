using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD2.Models;

namespace CRUD2.Data
{
    public class CRUD2Context : DbContext
    {
        public CRUD2Context (DbContextOptions<CRUD2Context> options)
            : base(options)
        {
        }

        public DbSet<CRUD2.Models.Child> Child { get; set; } = default!;
    }
}
