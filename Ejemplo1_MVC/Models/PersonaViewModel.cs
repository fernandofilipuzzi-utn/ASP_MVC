using System.ComponentModel.DataAnnotations;

namespace Ejemplo1_MVC.Models;

public class PersonaViewModel
{
    [Required(ErrorMessage = "El DNI es obligatorio.")]
    public int Dni { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get; set; }
}
