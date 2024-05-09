using final_proj;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace glowing_palm_tree.Pages;

public class IndexModel : PageModel
{
    private readonly CropDbContext _context;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(CropDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
