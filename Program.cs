using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Interfaces;
using VeterinariaSanMiguel.Models;
using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel;

public class Program
{
    static async Task Main(string[] args)
    {
        var context = new AppDbContext();
        var clientService = new ClientService(context);
        var appointmentService = new VetAppointmentService(context);
        var petService = new PetService(context);
        var veterinaryService = new VeterinaryService(); // futuro uso

        while (true)
        {
            Console.WriteLine("\n===== Menú Principal =====");
            Console.WriteLine("1. Clientes");
            Console.WriteLine("2. Citas (Appointments)");
            Console.WriteLine("3. Mascotas (Pets)");
            Console.WriteLine("4. Veterinarios");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    clientService.ClientMenu();
                    break;
                case "2":
                    await appointmentService.AppointmentMenu();
                    break;
                case "3":
                    await petService.PetMenu();
                    break;
                case "4":
                    Console.WriteLine("Menú de Veterinarios próximamente...");
                    // veterinaryService.VeterinaryMenu(); //implementar menú de veterinarios
                    break;
                case "0":
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}