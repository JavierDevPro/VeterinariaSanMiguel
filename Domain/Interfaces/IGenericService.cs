using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Interfaces;
using VeterinariaSanMiguel.Models;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaSanMiguel.Services
{
    public class PersonService<T> : IPersonService<T> where T : Person
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet; // Este es el DbSet específico para T

        public PersonService(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); // EF Core selecciona automáticamente Client o Veterinary
        }

        // Crear un nuevo registro
        public void Register(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        // Listar todos los registros
        public List<T> ListAll()
        {
            return _dbSet.ToList();
        }

        // Obtener por Id
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        // Editar registro existente
        public void Edit(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        // Eliminar por Id
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}