using System.ComponentModel.DataAnnotations;
namespace Homework5_Solution.Models;

public class Product
{
    public int ProductID {get; set;}
    public string Name {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;
    
    [DataType(DataType.Currency)]
    public decimal Price {get; set;}
    public string ImageURL {get; set;} = "img/placeholder.jpg";
}