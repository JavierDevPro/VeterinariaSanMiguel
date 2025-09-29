namespace VeterinariaSanMiguel.Models;

public abstract class Animal
{
    public int id { get; set; }
    public string name { get; set; }
    public string kind { get; set; }
    protected string breed { get; set; }

}