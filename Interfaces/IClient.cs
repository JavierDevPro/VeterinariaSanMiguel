using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Models;
using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel.Interfaces;

public interface IClient<T> where T : Person
{
    void Register(string name, int age,string phoneNumber,string email, bool insurance);
    List<T> ListAll();
    void Edit(T entity);
    void Delete(int id);
}

