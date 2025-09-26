using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinariaSanMiguel.Models;

public class Pet : Animal
{
    public int IdPerson { get; set; }
    [ForeignKey("IdPerson")]
    public Client client { get; set; }
}