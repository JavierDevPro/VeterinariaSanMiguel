using VeterinariaSanMiguel.Models;
using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel.Veaws;

public class VeterinaryMenu
{
    private readonly VeterinaryService _veterinaryService;

    public VeterinaryMenu(VeterinaryService veterinaryService)
    {
        _veterinaryService = veterinaryService;
    }

    public void MostrarMenu()
    {
        string opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("----- Menú de Veterinarios -----");
            Console.WriteLine("1. Registrar Veterinario");
            Console.WriteLine("2. Listar Veterinarios");
            Console.WriteLine("3. Eliminar Veterinario");
            Console.WriteLine("4. Editar Veterinario");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    _veterinaryService.RegisterMenu();
                    break;
                case "2":
                    _veterinaryService.ListarMenu();
                    break;
                case "3":
                    _veterinaryService.EliminarMenu();
                    break;
                case "4":
                    _veterinaryService.EditarMenu();
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