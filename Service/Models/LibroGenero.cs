using System.ComponentModel.DataAnnotations;

namespace Service.Models
{
    public class LibroGenero
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public Libro? Libro { get; set; }
        public int GeneroId { get; set; }
        public Genero? Genero { get; set; }
        public bool IsDeleted { get; set; } = false;

        //public override string ToString()
        //{
        //    return $"{Libro?.Titulo} - {Genero?.Nombre}";
        //}
    }

}
