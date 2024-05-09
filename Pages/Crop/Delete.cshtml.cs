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
        private readonly final_proj.CropDbContext _context;

        public DeleteModel(final_proj.CropDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public final_proj.Crop Crop { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crop = await _context.Crops.FirstOrDefaultAsync(m => m.cID == id);

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

            var crop = await _context.Crops.FindAsync(id);
            if (crop != null)
            {
                Crop = crop;
                _context.Crops.Remove(Crop);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
