namespace VeterinariaSanMiguel.Interfaces;

public interface IGenericService<T> where T: class
{
    //crear una carpeta Domain >> Interfaces, Models
    Task<IEnumerable<T>> ListAll();
    Task<T> Register(T entity);
    Task<T> Edit(int id, T entity);
    Task<bool> Delete(int id);
}