namespace VeterinariaSanMiguel.Models;

public class Client : Person
{
    public bool Insurance { get; set; }
    private string insuranceType { get; set; }
}