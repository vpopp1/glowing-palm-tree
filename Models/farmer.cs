using System.ComponentModel.DataAnnotations;

namespace final_proj
{
    public class Farmer
    {
        [Key]
        public int fID {get;set;}

        [Display(Name ="Farmer's Name")]
        [Required]
        public string fName {get;set;} = string.Empty;

        [Display(Name = "Farm Location")]
        [Required]
        public string address {get;set;} = string.Empty;
        public double avRain {get;set;}
        public double avTemp {get;set;}
        public double CostpUnit {get;set;}

        public List<Production> productions {get;set;} = default!;
    }
}