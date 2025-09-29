using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Models;
using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel.Interfaces;

public interface IVeterinaryService<T> where T : Person
{
    void Register(string name, int age, string phoneNumber, string email, string speciality);
    List<T> ListAll();
    void Edit(T entity);
    void Delete(int id);
}

