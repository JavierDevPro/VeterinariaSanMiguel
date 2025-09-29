namespace VeterinariaSanMiguel.Models;

public class Client : Person
{
    public bool insurance { get; set; }
    private string insuranceType { get; set; }
}