using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Homework5_Solution.Models;

namespace Homework5_Solution.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context; 
    private readonly ILogger<IndexModel> _logger;
    public List<Product> Products {get; set;} = default!;

    public IndexModel(AppDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
        Products = _context.Products.ToList();
    }
}
