using System.ComponentModel.DataAnnotations;

namespace VeterinariaSanMiguel.Models;

public abstract class Person
{
    [Key]
    public int IdPerson { get; set; }
    
    protected string dni { get; set; }
    public string name { get; set; }
    public int age { get; set; }
    public string phoneNumber { get; set; }
    public string email { get; set; }
}