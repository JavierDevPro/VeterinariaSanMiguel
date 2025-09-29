using VeterinariaSanMiguel.Models;
using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel.Veaws;

public class ClientMenu
{
    private readonly ClientService _clientService;

    public ClientMenu(ClientService clientService)
    {
        _clientService = clientService;
    }

    public void MostrarMenu()
    {
        string opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("----- Menú de Clientes -----");
            Console.WriteLine("1. Registrar Cliente");
            Console.WriteLine("2. Listar Clientes");
            Console.WriteLine("3. Eliminar Cliente");
            Console.WriteLine("4. Editar Cliente");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    _clientService.RegisterMenu();
                    break;
                case "2":
                    _clientService.ListarMenu();
                    break;
                case "3":
                    _clientService.EliminarMenu();
                    break;
                case "4":
                    _clientService.EditarMenu();
                    break;
                case "0":
                    Console.WriteLine("Regresando al menú principal...");
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente de nuevo.");
                    break;
            }

            if (opcion != "0")
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != "0");
    }
}