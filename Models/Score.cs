using System.ComponentModel.DataAnnotations;
using System;
namespace Cardle.Models;

public class Score
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }  

    public string GameMode { get; set; }  

    public int Value { get; set; }        
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
}