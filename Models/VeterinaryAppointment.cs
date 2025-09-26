using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinariaSanMiguel.Models;


public class VeterinaryAppointment
{
    //Esto es la cita veterinaria
    [Key]
    public int IdVetAppointment { get; set; }
    
    public DateTime Date { get; set; }
    public string Diagnosis { get; set; }
    
    public int IdPet { get; set; }
    public int IdVet { get; set; }
    
    [ForeignKey("IdPet")]
    public Pet Pet { get; set; }
    
    [ForeignKey("IdVet")]
    public Veterinary Vet { get; set; }
}