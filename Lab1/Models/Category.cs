using System.ComponentModel.DataAnnotations;

namespace Lab1.Models;

public class Category
{
    [Key]
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }

    public List<Product> Products { get; set; }

}