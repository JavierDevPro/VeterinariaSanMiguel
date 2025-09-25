namespace VeterinariaSanMiguel.Models;

public abstract class Animal
{
    protected int id;
    public string name;
    public string kind;
    protected string breed;

    public Animal(int id, string name, string kind, string breed)
    {
        this.id = id;
        this.name = name;
        this.kind = kind;
        this.breed = breed;
    }
}