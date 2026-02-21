using System.ComponentModel.DataAnnotations;

namespace Mission06_Higby.Models;

public class Category
{
    [Key]
    [Required]
    [Display( Name = "Category ID" )]
    public int CategoryID { get; set; }
    
    [Required]
    [Display( Name = "Category Name" )]
    public string CategoryName { get; set; }
}