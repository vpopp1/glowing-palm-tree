using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using final_proj;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace glowing_palm_tree.Pages.Veg_Model
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly RazorPagesCropDbContext _context;

        public DetailsModel(RazorPagesCropDbContext context, ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public final_proj.Crop Crop {get;set;} = default!;

        [BindProperty]
        public int Farmidtodelete {get;set;}

        [BindProperty]
        [Display(Name = "Farmer")]
        public int AtNewFarm {get;set;}
        public List<Farmer> AllFarmers {get; set;} = default!;
        public SelectList FarmerList {get; set;} = default!;
        


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            var crop = await _context.Crop.Include(m=> m.Production).ThenInclude(pr=> pr.Farmer).FirstOrDefaultAsync(m => m.cID == id);
            if (crop == null)
            {
                return NotFound();
            }
            else
            {
                Crop = crop;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteCropAsync(int? id)
        {
            _logger.LogWarning($"OnPost: Crop {id} no longer at farm {Farmidtodelete}");
            if (id == null)
            {
                return NotFound();
            }

            var crop = await _context.Crop.Include(p => p.Production).ThenInclude(f => f.Farmer).FirstOrDefaultAsync(m => m.cID == id);
            
            if (crop == null)
            {
                return NotFound();
            }
            else
            {
                Crop= crop;
            }

            Production Cropdelete = _context.Production.Find(Farmidtodelete, id.Value);

            if (Cropdelete != null)
            {
                _context.Remove(Cropdelete);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Crops not in production.");
            }

            return RedirectToPage(new {id = id});
        }

         public async Task<IActionResult> OnPostAsync(int? id)
        {
            _logger.LogWarning($"OnPost: Crop {id}, now at {AtNewFarm}");
            if (AtNewFarm == 0)
            {
                ModelState.AddModelError("NewFarm", "This field is a required field.");
                return Page();
            }
            if (id == null)
            {
                return NotFound();
            }

            var crop = await _context.Crop.Include(p=>p.Production!).ThenInclude(f => f.Farmer).FirstOrDefaultAsync(m => m.cID == id);            
            AllFarmers = await _context.Farmer.ToListAsync(p=> p.address);
            FarmerList = new SelectList(AllFarmers, "fID", "address");

            if (crop == null)
            {
                return NotFound();
            }
            else
            {
                Crop = crop;
            }

            if (!_context.Production.Any(f => f.fID == AtNewFarm && f.cID == id.Value))
            {
                Production NewFarm = new Production { cID = id.Value, fID = AtNewFarm};
                _context.Add(NewFarm);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Crops already in production at that location.");
            }

            return RedirectToPage(new {id = id});
        }
    }
}
