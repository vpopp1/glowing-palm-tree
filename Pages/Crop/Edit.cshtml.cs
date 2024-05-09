using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using final_proj;

namespace glowing_palm_tree.Pages.Veg_Model
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesCropDbContext _context;

        public EditModel(RazorPagesCropDbContext context)
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

            var crop =  await _context.Crop.FirstOrDefaultAsync(m => m.cID == id);
            if (crop == null)
            {
                return NotFound();
            }
            Crop = crop;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Crop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CropExists(Crop.cID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CropExists(int id)
        {
            return _context.Crop.Any(e => e.cID == id);
        }
    }
}
