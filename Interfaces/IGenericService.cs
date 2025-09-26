namespace VeterinariaSanMiguel.Interfaces;

public interface IGenericService<T> where T: class
{
    Task<IEnumerable<T>> List();
    //crear una carpeta Domain >> Interfaces, Models
}