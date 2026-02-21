using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Higby.Models;

public class Movie
{
    [Key]
    [Required]
    [Display(Name = "Movie ID")]
    public int MovieID { get; set; }

    [Required]
    [ForeignKey( "CategoryID" )]
    [Display(Name = "Category ID")]
    public int CategoryID { get; set; } 
    public Category Category { get; set; }

    [Required]
    [Display(Name = "Title")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Year")]
    public int Year { get; set; }

    [Required]
    [Display(Name = "Director")]
    public string Director { get; set; } = string.Empty;

    [Required]
    [RegularExpression("^(G|PG|PG-13|R)$", ErrorMessage = "Rating must be G, PG, PG-13, or R.")]
    [Display(Name = "Rating")]
    public string Rating { get; set; } = string.Empty;

    [Display(Name = "Edited")]
    public bool? Edited { get; set; }

    [Display(Name = "Lent To")]
    public string? LentTo { get; set; }
    
    [Display(Name = "Copied To Plex")]
    public bool? CopiedToPlex { get; set; }

    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    [Display(Name = "Notes")]
    public string? Notes { get; set; }
}