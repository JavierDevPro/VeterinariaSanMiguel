using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Interfaces;
using VeterinariaSanMiguel.Models;

namespace VeterinariaSanMiguel.Services;

public class ClientService : IClient<Client>
{
    private readonly AppDbContext _context;
    
    public ClientService(AppDbContext context)
    {
        _context = context;
    }
    
    // Menú principal de clientes
    public void ClientMenu()
    {
        while (true)
        {
            Console.WriteLine("\n Menú Clientes ");
            Console.WriteLine("1. Registrar Clientes");
            Console.WriteLine("2. Listar Clientes");
            Console.WriteLine("3. Eliminar Clientes");
            Console.WriteLine("4. Editar Clientes");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    RegisterMenu();
                    break;
                case "2":
                    ListarMenu();
                    break;
                case "3":
                    EliminarMenu();
                    break;
                case "4":
                    EditarMenu();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
    
    public void RegisterMenu()
    {
        Console.WriteLine("-Registrar Clientes-");

        Console.Write("Ingrese el nombre del cliente: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la edad del cliente: ");
        int edad = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el número del celular del cliente: ");
        string celular = Console.ReadLine();

        Console.Write("Ingrese el correo del cliente: ");
        string correo = Console.ReadLine();

        Console.Write("¿Tiene seguro? (Si/No): ");
        string seguroInput = Console.ReadLine();
        bool insurance = seguroInput.ToLower() == "si";

        Register(nombre, edad, celular, correo, insurance);
        Console.WriteLine($"El cliente {nombre} se ha registrado exitosamente.");
    }
    
    public void ListarMenu()
    {
        Console.WriteLine("-Lista de clientes-");
        Console.WriteLine("ID\tNombre\tEdad\tTeléfono\tCorreo\t\t\tSeguro");

        foreach (var c in ListAll())
        {
            Console.WriteLine($"{c.IdPerson}\t{c.name}\t{c.age}\t{c.phoneNumber}\t{c.email}\t{(c.insurance ? "Sí" : "No")}");
        }
    }

    public void EliminarMenu()
    {
        Console.WriteLine("-Lista de clientes-");
        foreach (var c in ListAll())
        {
            Console.WriteLine($"{c.IdPerson} - {c.name} ({c.age} años) - {c.email}");
        }

        Console.Write("\nIngrese el ID del cliente que desea eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int idEliminar))
        {
            Delete(idEliminar);
            Console.WriteLine($"Cliente con ID {idEliminar} ha sido eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Ingresa un ID válido.");
        }
    }

    public void EditarMenu()
    {
        Console.WriteLine("\n-Editar Cliente-");
        Console.Write("Ingrese el ID del cliente que desea editar: ");
        int idEditar = int.Parse(Console.ReadLine());

        var cliente = GetClientById(idEditar);

        if (cliente != null)
        {
            Console.WriteLine($"Editando cliente: {cliente.name}");

            Console.Write("Nuevo nombre: \n");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoNombre))
                cliente.name = nuevoNombre;

            Console.Write("Nueva edad: \n");
            string nuevaEdad = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevaEdad))
                cliente.age = int.Parse(nuevaEdad);

            Console.Write("Nuevo teléfono: \n");
            string nuevoTelefono = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoTelefono))
                cliente.phoneNumber = nuevoTelefono;

            Console.Write("Nuevo correo: \n");
            string nuevoCorreo = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoCorreo))//Esto lo que hace es veridficar si lo que ingreso el usuario esta null o esta vacio y me tira un true y me retorna un false si esta lleno y eso se debe por el ! 
                cliente.email = nuevoCorreo;//Si la variable esta llena o con datos se ejecuta esta linea

            Console.Write("¿Tiene seguro? (si/no): \n");
            string nuevoSeguro = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoSeguro))
                cliente.insurance = (nuevoSeguro.ToLower() == "si");

            Edit(cliente);
            Console.WriteLine("Cliente actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró el cliente con ese ID.");
        }
    }
    
    
    //Aqui esta toda la logica del crud lo que es registrar,listar,editar y eliminar
    public void Register(string name, int age, string phoneNumber, string email, bool insurance)
    {
        var client = new Client
        {
            name = name,
            age = age,
            phoneNumber = phoneNumber,
            email = email,
            insurance = insurance
        };
        _context.Clients.Add(client);
        _context.SaveChanges();
    }

    public List<Client> ListAll()
    {
        return _context.Clients.ToList();
    }

    public void Delete(int id)
    {
        var client = _context.Clients.Find(id);
        if (client != null)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }
    }
    
    public Client GetClientById(int id)
    {
        return _context.Clients.Find(id);
    }

    public void Edit(Client client)
    {
        _context.Clients.Update(client);
        _context.SaveChanges();
    }
}
