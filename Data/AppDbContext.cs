using Microsoft.EntityFrameworkCore;
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
    //>>> dotnet tool install --global dotnet-ef ---> siempre para las migraciones. 
    //>>> dotnet ef migrations add InitialCreate --> siempre para las migraciones. 
    //>>> dotnet ef database update
    // si te salto algun problema investiga como hacer las primary keys.
    
    
    // public DbSet<Profesor> Profesores { get; set; }
    // public DbSet<Estudiante> Estudiantes { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(
                "server=localhost;" +
                "database=riwi_db;" +
                "user=root;" + // su root
                "password=123456;",//este le ponen su contra del root de su pc o de el sql
                new MySqlServerVersion(new Version(8, 0, 36))
            );
        }
    }
}