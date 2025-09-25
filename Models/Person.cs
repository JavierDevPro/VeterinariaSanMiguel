namespace VeterinariaSanMiguel.Models;

public abstract class Person
{
    protected int id;
    protected string dni;
    public string name { get; set; }
    public int age { get; set; }
    public string phoneNumber { get; set; }
    public string email { get; set; }

    public Person(int id, string dni, string name, int age, string phoneNumber, string email)
    {
        this.id = id;
        this.dni = dni;
        this.name = name;
        this.age = age;
        this.phoneNumber = phoneNumber;
        this.email = email;
    }
}