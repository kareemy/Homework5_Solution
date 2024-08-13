using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Homework5_Solution.Models;

namespace Homework5_Solution.Pages;

public class AddProductModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<AddProductModel> _logger;

    [BindProperty]
    public Product Product {get; set;} = default!;

    public AddProductModel(AppDbContext context, ILogger<AddProductModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Products.Add(Product);
        _context.SaveChanges();

        return RedirectToPage("./Index");
    }
}