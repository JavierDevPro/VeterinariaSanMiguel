using System.ComponentModel.DataAnnotations;

namespace VeterinariaSanMiguel.Models;

public abstract class Person
{
<<<<<<< HEAD
    [Key]
    public int id { get; set; } 
    
    protected string dni;
    
=======
    public int Id { get; set; }
    protected string dni { get; set; }
>>>>>>> 36a71f717f619e328b08a3fb9071f9aa944c6cbe
    public string name { get; set; }
    
    public int age { get; set; }
    public string phoneNumber { get; set; }
    public string email { get; set; }
}