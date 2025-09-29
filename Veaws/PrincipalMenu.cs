using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel.Veaws;

public class PrincipalMenu
{
    private readonly AppDbContext _context;

    public PrincipalMenu(AppDbContext context)
    {
        _context = context;
    }

    public void MostrarMenu()
    {
        var clientService = new ClientService(_context);
        var veterinaryService = new VeterinaryService(_context);

        var clientMenu = new ClientMenu(clientService);
        var veterinaryMenu = new VeterinaryMenu(veterinaryService);

        string opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("===== Menú Principal =====");
            Console.WriteLine("1. Gestión de Clientes");
            Console.WriteLine("2. Gestión de Veterinarios");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    clientMenu.MostrarMenu();
                    break;
                case "2":
                    veterinaryMenu.MostrarMenu();
                    break;
                case "0":
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente de nuevo.");
                    Console.ReadKey();
                    break;
            }
        } while (opcion != "0");
    }
}