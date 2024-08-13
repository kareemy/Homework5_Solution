using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Homework5_Solution.Models;
using System.ComponentModel.DataAnnotations;

namespace Homework5_Solution.Pages;

public class BuyNowModel : PageModel
{
    private readonly AppDbContext _context; 
    private readonly ILogger<BuyNowModel> _logger;
    public Product Product {get; set;} = default!;
    
    [DataType(DataType.Currency)]
    public decimal Shipping {get; set;} = 19.99M;

    [DataType(DataType.Currency)]
    public decimal Tax {get; set;}
    
    [DataType(DataType.Currency)]
    public decimal Total {get; set;}

    [DataType(DataType.Date)]
    public DateTime StartDeliveryDate {get; set;}

    [DataType(DataType.Date)]
    public DateTime EndDeliveryDate {get; set;}

    public BuyNowModel(AppDbContext context, ILogger<BuyNowModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult OnGet(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = _context.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }
        Product = product;
        Tax = Product.Price * 0.0825M;
        Total = Product.Price + Shipping + Tax;
        StartDeliveryDate = DateTime.Now.AddDays(7);
        EndDeliveryDate = StartDeliveryDate.AddDays(7);

        return Page();
    }
}
