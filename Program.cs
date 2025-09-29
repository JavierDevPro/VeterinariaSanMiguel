using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Veaws;

namespace VeterinariaSanMiguel;

public class Program
{
    static void Main(string[] args)
    {
        var context = new AppDbContext();
        var principalMenu = new PrincipalMenu(context);
        principalMenu.MostrarMenu();
    }
}