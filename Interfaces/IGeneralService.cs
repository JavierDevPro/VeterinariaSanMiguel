namespace VeterinariaSanMiguel.Interfaces;

public interface IGeneralService<T> where T : class  // crea una interface generica. Where  T -> sea una clase cualquiera 
{
    // metodos crud --> generico => mascota y citas 

    void Printe(); 
}