using VeterinariaSanMiguel.Models;

namespace VeterinariaSanMiguel.Interfaces;

public interface IPersonService<T> where T : Person
{
    void Register(T entity);
    List<T> ListAll();
    void Delete(int id);
    T GetById(int id);
    void Edit(T entity);
}