using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using final_proj;

namespace glowing_palm_tree.Pages.Veg_Model
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesCropDbContext _context;

        public DeleteModel(RazorPagesCropDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public final_proj.Crop Crop {get;set;} = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crop = await _context.Crop.FirstOrDefaultAsync(m => m.cID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crop = await _context.Crop.FindAsync(id);
            if (crop != null)
            {
                Crop = crop;
                _context.Crop.Remove(Crop);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
