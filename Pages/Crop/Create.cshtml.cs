using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using final_proj;

namespace glowing_palm_tree.Pages.Veg_Model
{
    public class CreateModel : PageModel
    {
        private readonly final_proj.CropDbContext _context;

        public CreateModel(final_proj.CropDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public final_proj.Crop Crop { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Crops.Add(Crop);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
