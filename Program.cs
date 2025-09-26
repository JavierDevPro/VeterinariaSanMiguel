using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Interfaces;
using VeterinariaSanMiguel.Models;
using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel;

public class Program
{
    static void Main(string[] args)
    {
        var context = new AppDbContext();
        var clienteUI = new ClientService(context);
        
        Console.WriteLine("-----Menu de opciones de cliente-----");
        Console.WriteLine("1. Registrar Clientes");
        Console.WriteLine("2. Listar Clientes");
        Console.WriteLine("3. Eliminar Clientes");
        Console.WriteLine("4. Editar Clientes");

        Console.WriteLine("¿Que deseas hacer?");
        string opcion =  Console.ReadLine();
        
        switch (opcion)
        {
            case "1":
                clienteUI.RegisterMenu();
                break;
            case "2":
                clienteUI.ListarMenu();
                break;
            case "3":
                clienteUI.EliminarMenu();
                break;
            case "4":
                clienteUI.EditarMenu();
                break;
            default:
                Console.WriteLine("Ingrese una opcion valida");
                return;
        }
    }
    
   

   
}