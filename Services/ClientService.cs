using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Models;
namespace VeterinariaSanMiguel.Services;
public class ClientService : PersonService<Client>
{ 
    public ClientService(AppDbContext context) : base(context) {}
    // Menu de opciones
    public void RegisterMenu()
    { 
        Console.WriteLine("------Registrar Clientes------");
        
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
        
        var client = new Client
        {
            Name = nombre,
            Age = edad,
            PhoneNumber = celular,
            Email = correo,
            Insurance = insurance
        };
        base.Register(client);
        Console.WriteLine($"El cliente {nombre} se ha registrado exitosamente.");
        
    } public void ListarMenu() { Console.WriteLine("-----Lista de clientes-----");
        Console.WriteLine("ID\tNombre\tEdad\tTeléfono\tCorreo\t\t\tSeguro");
        foreach (var c in base.ListAll())
        {
            Console.WriteLine($"{c.Id}\t{c.Name}\t{c.Age}\t{c.PhoneNumber}\t{c.Email}\t{(c.Insurance ? "Sí" : "No")}");
        }
        
    }
    public void EliminarMenu()
    {
        Console.WriteLine("-----Lista de clientes------");
        foreach (var c in base.ListAll())
        {
            Console.WriteLine($"{c.Id} - {c.Name} ({c.Age} años) - {c.Email}");
        }
        Console.Write("\nIngrese el ID del cliente que desea eliminar: ");

        if (int.TryParse(Console.ReadLine(), out int idEliminar))
        {
            base.Delete(idEliminar);
            Console.WriteLine($"Cliente con ID {idEliminar} ha sido eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Ingresa un ID válido.");
        }
    }
    public void EditarMenu()
    {
        Console.WriteLine("\n----- Editar Cliente -----");
        Console.Write("Ingrese el ID del cliente que desea editar: ");
        int idEditar = int.Parse(Console.ReadLine());
        var cliente = base.GetById(idEditar);
        if (cliente != null)
        {
            Console.WriteLine($"Editando cliente: {cliente.Name}");
            Console.Write("Nuevo nombre: \n"); string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoNombre))
                cliente.Name = nuevoNombre; Console.Write("Nueva edad: \n");
            string nuevaEdad = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevaEdad))
                cliente.Age = int.Parse(nuevaEdad);
            Console.Write("Nuevo teléfono: \n");
            string nuevoTelefono = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoTelefono))
                cliente.PhoneNumber = nuevoTelefono;
            Console.Write("Nuevo correo: \n");
            string nuevoCorreo = Console.ReadLine();
            if (!string.IsNullOrEmpty( nuevoCorreo)) //Esto lo que hace es veridficar si lo que ingreso el usuario esta null o esta vacio y me tira un true y me retorna un false si esta lleno y eso se debe por el !
                cliente.Email = nuevoCorreo; //Si la variable esta llena o con datos se ejecuta esta linea
            Console.Write("¿Tiene seguro? (si/no): \n");
            string nuevoSeguro = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoSeguro))
                cliente.Insurance = (nuevoSeguro.ToLower() == "si");
            base.Edit(cliente);
            Console.WriteLine("Cliente actualizado correctamente.");
            
        }
        else
        {
            Console.WriteLine("No se encontró el cliente con ese ID.");
        }
    }
}