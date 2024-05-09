using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using final_proj;

    public class RazorPagesCropDbContext : DbContext
    {
   

    public RazorPagesCropDbContext (DbContextOptions<RazorPagesCropDbContext> options)
            : base(options)
        {
        }

        public DbSet<final_proj.Crop> Crop { get; set; } = default!;

}
