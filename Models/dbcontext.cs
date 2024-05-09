using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace final_proj
    {
	    public class CropDbContext : DbContext
	    {
		    public CropDbContext (DbContextOptions<CropDbContext> options)
			    : base(options)
		    {
		    }
			

			//error solutions by trial and error this is an option to get the sccaffolding to process and build
 			//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    		//{
      			//optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["CropDbContextDatabase"].ConnectionString);
    		//}

			
//when building migrations it wouldn't build completely without declaring keys 
			protected override void OnModelCreating(ModelBuilder builder)
			{
				builder.Entity<Crop>().HasKey(c => new {c.cID});
				builder.Entity<Farmer>().HasKey(f=> new {f.fID});
				builder.Entity<Production>().HasKey(p=> new {p.fID, p.cID});
			}

		public DbSet<Crop> Crops {get; set;} = default!;
        public DbSet<Farmer> Farmers {get; set;} = default!;
		public DbSet<Production> productions{get;set;} = default!;


		
	}
}
