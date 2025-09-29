using Microsoft.EntityFrameworkCore;

namespace VeterinariaSanMiguel.Services;

using VeterinariaSanMiguel.Interfaces;
using VeterinariaSanMiguel.Models;
using VeterinariaSanMiguel.Data;
public class VetAppointmentService : IGenericService<VeterinaryAppointment>
{
    //aqui los cruds
    private readonly AppDbContext _context;

    public VetAppointmentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<VeterinaryAppointment> Register(VeterinaryAppointment entity)
    {
        _context.VeterinaryAppointments.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<VeterinaryAppointment>> ListAll()
    {
        var query = from v in _context.VeterinaryAppointments
            select v;
        return await query.ToListAsync();
    }

    public async Task<bool> Delete(int id)
    {
        var finded = await _context.VeterinaryAppointments.FindAsync(id);
        if (finded == null)
        {
            //it means that there is no date with this specific id
            return false;
        }
        _context.VeterinaryAppointments.Remove(finded);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<VeterinaryAppointment> Edit(int id, VeterinaryAppointment update)
    {
        var finded = await _context.VeterinaryAppointments.FindAsync(id);
        if (finded == null) return null;
        
        _context.VeterinaryAppointments.Update(update);
        await _context.SaveChangesAsync();
        return update;
    }
    
    //aqui el menu de consola
    public async Task AppointmentMenu()
    {
        while (true)
        {
            Console.WriteLine("\n==== Menú Citas Veterinarias ====");
            Console.WriteLine("1. Listar todas las citas");
            Console.WriteLine("2. Crear nueva cita");
            Console.WriteLine("3. Editar cita existente");
            Console.WriteLine("4. Eliminar cita");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ListAllAppointments();
                    break;
                case "2":
                    await RegisterAppointment();
                    break;
                case "3":
                    await EditAppointment();
                    break;
                case "4":
                    await DeleteAppointment();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    private async Task ListAllAppointments()
    {
        var all = await ListAll();
        foreach (var a in all)
            Console.WriteLine($"ID:{a.IdVetAppointment} | Fecha:{a.Date} | Diagnóstico:{a.Diagnosis} | IdPet:{a.IdPet} | IdVet:{a.IdVet}");
        if (!all.Any()) Console.WriteLine("No hay citas registradas.");
    }

    private async Task RegisterAppointment()
    {
        Console.Write("Fecha y hora (yyyy-MM-dd HH:mm): ");
        var date = DateTime.Parse(Console.ReadLine()!);

        Console.Write("Diagnóstico: ");
        var diagnosis = Console.ReadLine()!;

        Console.Write("IdPet: ");
        var idPet = int.Parse(Console.ReadLine()!);

        Console.Write("IdVet: ");
        var idVet = int.Parse(Console.ReadLine()!);

        var entity = new VeterinaryAppointment
        {
            Date = date,
            Diagnosis = diagnosis,
            IdPet = idPet,
            IdVet = idVet
        };

        await Register(entity);
        Console.WriteLine("Cita creada correctamente.");
    }

    private async Task EditAppointment()
    {
        Console.Write("Ingrese el ID de la cita a editar: ");
        var id = int.Parse(Console.ReadLine()!);

        var current = await _context.VeterinaryAppointments.FindAsync(id);
        if (current == null)
        {
            Console.WriteLine("Cita no encontrada.");
            return;
        }

        Console.Write("Nueva fecha y hora (yyyy-MM-dd HH:mm): ");
        current.Date = DateTime.Parse(Console.ReadLine()!);

        Console.Write("Nuevo diagnóstico: ");
        current.Diagnosis = Console.ReadLine()!;

        Console.Write("Nuevo IdPet: ");
        current.IdPet = int.Parse(Console.ReadLine()!);

        Console.Write("Nuevo IdVet: ");
        current.IdVet = int.Parse(Console.ReadLine()!);

        await Edit(id, current);
        Console.WriteLine("Cita editada correctamente.");
    }

    private async Task DeleteAppointment()
    {
        Console.Write("Ingrese el ID de la cita a eliminar: ");
        var id = int.Parse(Console.ReadLine()!);

        var ok = await Delete(id);
        Console.WriteLine(ok ? "Cita eliminada." : "No se encontró la cita.");
    }

}