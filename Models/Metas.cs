using System.ComponentModel.DataAnnotations;

namespace Parcial1_Ap1_IsaacCoste.Models
{
    public class Metas
    {
        [Key]
        public int MetaId { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la fecha.")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la Descripción")]
        public string? Descripción { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el Monto")]
        public decimal Monto { get; set; }
    }
}
