using System.ComponentModel.DataAnnotations;

namespace final_proj 
{
    public class Crop
    {
        [Key] //sometimes i hate coding, 3 hrs later and this [key] was what I needed becasue the 
        //key declaration in the dbcontext with the OnModelCreating wouldn't work 
        public int cID {get;set;}

        [Display(Name = "Crop Name")]
        [StringLength (60)]
        [Required]
        public string cNAme {get;set;} = string.Empty;

        //originally water intake but majority say plenty of water or do not over water but do not give a measure
        //sun is in hours
        [Display(Name = "Direct Hours of Sunlight")]
        [Required]
        public int sun {get;set;}

        //temp range
        [Display(Name = "Ideal Temperature Range")]
        [Required]
        public int temp {get;set;}

        //going to use the higher end price 
        [Display(Name = "Highest Price per lb.")]
        [Required]
        public double Price {get;set;}

        [Display(Name = "Average Yield (lb/acre)")]
        [Required]
        public double avYeild {get;set;}

        public List<Production> Production {get;set;} = default!;
        
    }
        //association table with the composite keys and navigations properties
        public class Production 
        {
            [Key]
            public int fID {get;set;}
            [Key]
            public int cID {get;set;}
            public Farmer? Farmer {get;set;} 
            public Crop? Crop {get;set;}
        }

    
}