using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Models;
namespace VeterinariaSanMiguel.Services;

public class VeterinaryService : PersonService<Veterinary>
{
    public VeterinaryService(AppDbContext context) : base(context) {}

    // Menu de opciones 
    public void RegisterMenu()
    {
        Console.WriteLine("------Registrar Veterinario------");

        Console.Write("Ingrese el nombre del veterinario: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la edad del veterinario: ");
        int edad = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el número del celular del veterinario: ");
        string celular = Console.ReadLine();

        Console.Write("Ingrese el correo del veterinario: ");
        string correo = Console.ReadLine();

        Console.Write("Ingrese la especialidad del veterinario: ");
        string especialidad = Console.ReadLine();

        var vet = new Veterinary
        {
            Name = nombre,
            Age = edad,
            PhoneNumber = celular,
            Email = correo,
            Speciality = especialidad
        };

        base.Register(vet);
        Console.WriteLine($"El veterinario {nombre} se ha registrado exitosamente.");
    }

    public void ListarMenu()
    {
        Console.WriteLine("-----Lista de veterinarios-----");
        Console.WriteLine("ID\tNombre\tEdad\tTeléfono\tCorreo\t\t\tEspecialidad");

        foreach (var v in base.ListAll())
        {
            Console.WriteLine($"{v.Id}\t{v.Name}\t{v.Age}\t{v.PhoneNumber}\t{v.Email}\t{v.Speciality}");
        }
    }

    public void EliminarMenu()
    {
        Console.WriteLine("-----Lista de veterinarios------");
        foreach (var v in base.ListAll())
        {
            Console.WriteLine($"{v.Id} - {v.Name} ({v.Age} años) - {v.Email}");
        }

        Console.Write("\nIngrese el ID del veterinario que desea eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int idEliminar))
        {
            base.Delete(idEliminar);
            Console.WriteLine($"Veterinario con ID {idEliminar} ha sido eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Ingresa un ID válido.");
        }
    }

    public void EditarMenu()
    {
        Console.WriteLine("\n----- Editar Veterinario -----");
        Console.Write("Ingrese el ID del veterinario que desea editar: ");
        int idEditar = int.Parse(Console.ReadLine());

        var vet = base.GetById(idEditar);

        if (vet != null)
        {
            Console.WriteLine($"Editando veterinario: {vet.Name}");

            Console.Write("Nuevo nombre: \n");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoNombre))
                vet.Name = nuevoNombre;

            Console.Write("Nueva edad: \n");
            string nuevaEdad = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevaEdad))
                vet.Age = int.Parse(nuevaEdad);

            Console.Write("Nuevo teléfono: \n");
            string nuevoTelefono = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoTelefono))
                vet.PhoneNumber = nuevoTelefono;

            Console.Write("Nuevo correo: \n");
            string nuevoCorreo = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoCorreo))
                vet.Email = nuevoCorreo;

            Console.Write("Nueva especialidad: \n");
            string nuevaEspecialidad = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevaEspecialidad))
                vet.Speciality = nuevaEspecialidad;

            base.Edit(vet);
            Console.WriteLine("Veterinario actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró el veterinario con ese ID.");
        }
    }
}
