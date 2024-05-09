using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

using final_proj;

namespace glowing_palm_tree.Pages.Veg_Model
{
    public class IndexModel : PageModel
    {
        private readonly CropDbContext _context;

        public IndexModel(CropDbContext context)
        {
            _context = context;
        }

        public IList<final_proj.Crop> Crop { get;set; } = default!;

        [BindProperty (SupportsGet = true)]
        public int PageNum {get;set;} = 1;

        public int PageSize {get;set;} =10;

        [BindProperty(SupportsGet = true)]
        public string? CurrentSort{get;set;} //left empty since the sort and filter could not be used by user
        //public int cropCount {get;set;} 

        public SelectList CropSortList {get; set;} = default!;
 

        public async Task OnGetAsync()
        {   //first has this line last but as project progressed it seemed better to place first 
            Crop = await _context.Crops.Include(p=> p.productions!).ThenInclude(pr=> pr.Farmer).ToListAsync();

            //next to do the sorting set the linc query then a switch since were sorting in a few different ways
            var sortcrop = _context.Crops.Select(c=> c);

            List<SelectListItem> sortCrops = new List<SelectListItem> 
            {
	        new SelectListItem { Text = "Name Ascending", Value = "n_Asc" },
	        new SelectListItem { Text = "Name Descending", Value = "n_Desc"},
            new SelectListItem { Text = "Price", Value = "Price"},
            new SelectListItem { Text = "In Production", Value = "in_Production"}
            };
            CropSortList = new SelectList(sortCrops, "Value", "Text", CurrentSort);

            switch (CurrentSort )
            {
                case "n_Asc":
                    sortcrop = sortcrop.OrderBy(c=> c.cNAme);//almost done and i see that i mis-typed my property name but still works, got to love autofill 
                break;

                case "n_Desc":
                    sortcrop = sortcrop.OrderByDescending(c=>c.cNAme);
                break;

                case "Price":
                    sortcrop = sortcrop.OrderBy(c=>c.Price);
                break;

                case "in_Production":
                    sortcrop = sortcrop.Include(p=>p.productions).OrderBy(t=> t.cNAme);
                break;
            }

         

            //Crop = await _context.Crop.Count(); 
            Crop = await sortcrop.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
            
        }
    }
}
