using Microsoft.EntityFrameworkCore;
using VeterinariaSanMiguel.Interfaces;
using VeterinariaSanMiguel.Models;
using VeterinariaSanMiguel.Data;

namespace VeterinariaSanMiguel.Services;

public class PetService : IGenericService<Pet>
{
    private readonly AppDbContext _context;

    public PetService(AppDbContext context)
    {
        _context = context;
    }

    // CRUD
    public async Task<Pet> Register(Pet entity)
    {
        _context.Pets.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<Pet>> ListAll()
    {
        var query = from p in _context.Pets
                    select p;
        return await query.ToListAsync();
    }

    public async Task<bool> Delete(int id)
    {
        var pet = await _context.Pets.FindAsync(id);
        if (pet == null) return false;
        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Pet> Edit(int id, Pet entity)
    {
        var current = await _context.Pets.FindAsync(id);
        if (current == null) return null;

        // actualización básica de campos editables
        current.name = entity.name;
        current.kind = entity.kind;
        current.IdPerson = entity.IdPerson;

        _context.Pets.Update(current);
        await _context.SaveChangesAsync();
        return current;
    }

    // Menú de consola para mascotas
    public async Task PetMenu()
    {
        while (true)
        {
            Console.WriteLine("\n==== Menú Mascotas ====");
            Console.WriteLine("1. Listar mascotas");
            Console.WriteLine("2. Registrar mascota");
            Console.WriteLine("3. Editar mascota");
            Console.WriteLine("4. Eliminar mascota");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ListAllPets();
                    break;
                case "2":
                    await RegisterPet();
                    break;
                case "3":
                    await EditPet();
                    break;
                case "4":
                    await DeletePet();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    private async Task ListAllPets()
    {
        var all = await ListAll();
        foreach (var p in all)
            Console.WriteLine($"ID:{p.id} | Nombre:{p.name} | Tipo:{p.kind} | IdDueño:{p.IdPerson}");
        if (!all.Any()) Console.WriteLine("No hay mascotas registradas.");
    }

    private async Task RegisterPet()
    {
        Console.Write("Nombre: ");
        var name = Console.ReadLine();

        Console.Write("Tipo (perro, gato, etc.): ");
        var kind = Console.ReadLine();

        Console.Write("ID del dueño (Client): ");
        var idPerson = int.Parse(Console.ReadLine()!);

        var entity = new Pet
        {
            name = name!,
            kind = kind!,
            IdPerson = idPerson
        };

        await Register(entity);
        Console.WriteLine("Mascota registrada correctamente.");
    }

    private async Task EditPet()
    {
        Console.Write("Ingrese el ID de la mascota a editar: ");
        var id = int.Parse(Console.ReadLine()!);

        var current = await _context.Pets.FindAsync(id);
        if (current == null)
        {
            Console.WriteLine("Mascota no encontrada.");
            return;
        }

        Console.Write("Nuevo nombre: ");
        var newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName)) current.name = newName!;

        Console.Write("Nuevo tipo: ");
        var newKind = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newKind)) current.kind = newKind!;

        Console.Write("Nuevo ID de dueño (Client): ");
        var idOwnerText = Console.ReadLine();
        if (int.TryParse(idOwnerText, out var newOwner)) current.IdPerson = newOwner;

        await Edit(id, current);
        Console.WriteLine("Mascota editada correctamente.");
    }

    private async Task DeletePet()
    {
        Console.Write("Ingrese el ID de la mascota a eliminar: ");
        var id = int.Parse(Console.ReadLine()!);

        var ok = await Delete(id);
        Console.WriteLine(ok ? "Mascota eliminada." : "No se encontró la mascota.");
    }
}