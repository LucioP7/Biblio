using Service.Enums;
using System.ComponentModel.DataAnnotations;

namespace Service.Models
{
    public class Ejemplar
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public Libro? Libro { get; set; }
        public bool Disponible { get; set; } = true; 
        [Required]
        public EstadoEnum Estado { get; set; } = EstadoEnum.Excelente; // "Exelente", "Muy Bueno".
        public bool IsDeleted { get; set; } = false;
        public override string ToString()
        {
            return $"{Libro?.Titulo} ";
        }
    }
}
