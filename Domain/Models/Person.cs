using System.ComponentModel.DataAnnotations;

namespace VeterinariaSanMiguel.Models;

public abstract class Person
{
    [Key]
    public int Id { get; set; }
    protected string Dni { get; set; }
    public string Name { get; set; }
    
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}