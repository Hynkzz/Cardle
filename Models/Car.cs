using System.ComponentModel.DataAnnotations;

namespace Cardle.Models;

public class Car
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Brand { get; set; } = ""; 

    [Required]
    public string Model { get; set; } = ""; 

    public string ParentCompany { get; set; } = ""; 

    public string Body { get; set; } = ""; 

    public string Country { get; set; } = ""; 
    
    public string Continent { get; set; } = ""; 

    public string Power { get; set; } = ""; 


    public string DisplayName => $"{Brand} {Model}";
    
    public string ImageUrl { get; set; } = ""; 
}