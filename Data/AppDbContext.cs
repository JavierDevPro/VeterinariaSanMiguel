using Microsoft.EntityFrameworkCore;
using VeterinariaSanMiguel.Models; 
namespace VeterinariaSanMiguel.Data;

public class AppDbContext : DbContext
{
    //para que se le quite el rojo le ponen lo siguiente:
    //aqui en data o infrastructure
    //es donde esta la interaccion con la DB
    //para ello se tiene que heredar : DbContext pero antes se instala
    //la dependencia en terminal
    //>>> dotnet add package Microsoft.EntityFrameworkCore
    //>>> dotnet add package Microsoft.EntityFrameworkCore.Design
    //>>> dotnet add package Pomelo.EntityFrameworkCore.MySql
    // ahora en los 3 puntos le das y buscas NuGet
    // busca que la extencion de Pomelo este ahi
    //luego el ultimo comando:
    //>>> dotnet tool install --global dotnet-ef
    //>>> dotnet ef migrations add InitialCreate
    //>>> dotnet ef database update
    // si te salto algun problema investiga como hacer las primary keys.

    
    // DbSet principal para la herencia
    public DbSet<Person> Persons { get; set; }

    // Estos DbSet son opcionales, pero permiten acceder directamente a cada entidad hija
    public DbSet<Client> Clients { get; set; }
    public DbSet<Veterinary> Veterinaries { get; set; }

    // Otras tablas independientes
    public DbSet<VeterinaryAppointment> VetsAppointments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(
                "server=localhost;" +
                "database=riwi;" +
                "user=root;" +
                "password=Qwe.123*",
                new MySqlServerVersion(new Version(8, 0, 36))
            );
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de herencia: Table Per Hierarchy (TPH)
        modelBuilder.Entity<Person>()
            .HasDiscriminator<string>("PersonType")  // Columna que indica el tipo
            .HasValue<Person>("Person")
            .HasValue<Client>("Client")
            .HasValue<Veterinary>("Veterinary");

        // Configuración opcional: limitar longitudes o requerimientos
        modelBuilder.Entity<Veterinary>()
            .Property(v => v.Speciality)
            .HasMaxLength(100);

        // Ejemplo: podrías definir reglas específicas para Client
        modelBuilder.Entity<Client>()
            .Property(c => c.Email)
            .IsRequired();
    }
}