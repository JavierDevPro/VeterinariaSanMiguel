using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Interfaces;
using VeterinariaSanMiguel.Models;

namespace VeterinariaSanMiguel.Services;

public class VeterinaryService : IVeterinaryService<Veterinary>
{
    private readonly AppDbContext _context;

    public VeterinaryService(AppDbContext context)
    {
        _context = context;
    }

    // ===== Menú de Opciones =====
    public void RegisterMenu()
    {
        Console.WriteLine("------Registrar Veterinario------");

        Console.Write("Ingrese el nombre del veterinario: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la edad del veterinario: ");
        int edad = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el número de teléfono del veterinario: ");
        string telefono = Console.ReadLine();

        Console.Write("Ingrese el correo electrónico del veterinario: ");
        string correo = Console.ReadLine();

        Console.Write("Ingrese la especialidad del veterinario: ");
        string especialidad = Console.ReadLine();

        Register(nombre, edad, telefono, correo, especialidad);
        Console.WriteLine($"El veterinario {nombre} se ha registrado exitosamente.");
    }

    public void ListarMenu()
    {
        Console.WriteLine("-----Lista de veterinarios-----");
        Console.WriteLine("ID\tNombre\tEdad\tTeléfono\tCorreo\t\t\tEspecialidad");

        foreach (var v in ListAll())
        {
            Console.WriteLine($"{v.IdPerson}\t{v.name}\t{v.age}\t{v.phoneNumber}\t{v.email}\t{v.Speciality}");
        }
    }

    public void EliminarMenu()
    {
        Console.WriteLine("-----Lista de veterinarios------");
        foreach (var v in ListAll())
        {
            Console.WriteLine($"{v.IdPerson} - {v.name} ({v.age} años) - {v.email}");
        }

        Console.Write("\nIngrese el ID del veterinario que desea eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int idEliminar))
        {
            Delete(idEliminar);
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

        var vet = GetVeterinaryById(idEditar);

        if (vet != null)
        {
            Console.WriteLine($"Editando veterinario: {vet.name}");

            Console.Write("Nuevo nombre: \n");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoNombre))
                vet.name = nuevoNombre;

            Console.Write("Nueva edad: \n");
            string nuevaEdad = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevaEdad))
                vet.age = int.Parse(nuevaEdad);

            Console.Write("Nuevo teléfono: \n");
            string nuevoTelefono = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoTelefono))
                vet.phoneNumber = nuevoTelefono;

            Console.Write("Nuevo correo: \n");
            string nuevoCorreo = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoCorreo))
                vet.email = nuevoCorreo;

            Console.Write("Nueva especialidad: \n");
            string nuevaEspecialidad = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevaEspecialidad))
                vet.Speciality = nuevaEspecialidad;

            Edit(vet);
            Console.WriteLine("Veterinario actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró el veterinario con ese ID.");
        }
    }

    // Registrar
    public void Register(string name, int age, string phoneNumber, string email, string speciality)
    {
        var vet = new Veterinary
        {
            name = name,
            age = age,
            phoneNumber = phoneNumber,
            email = email,
            Speciality = speciality
        };

        _context.Set<Veterinary>().Add(vet);
        _context.SaveChanges();
    }

    // Listar
    public List<Veterinary> ListAll()
    {
        return _context.Set<Veterinary>().ToList();
    }

    // Eliminar
    public void Delete(int id)
    {
        var vet = _context.Set<Veterinary>().Find(id);
        if (vet != null)
        {
            _context.Set<Veterinary>().Remove(vet);
            _context.SaveChanges();
        }
    }

    // Obtener por ID
    public Veterinary GetVeterinaryById(int id)
    {
        return _context.Set<Veterinary>().Find(id);
    }

    // Editar
    public void Edit(Veterinary vet)
    {
        _context.Set<Veterinary>().Update(vet);
        _context.SaveChanges();
    }
}
