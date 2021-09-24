using System.ComponentModel.DataAnnotations;

namespace api_livraria_dio.Services
{
    public class Livro
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [StringLength(150)]
        [Required]
        public string Titulo { get; set; }
        
        [StringLength(150)]
        [Required]
        public string Autor { get; set; }
        
        [Range(1,150)]
        [Required]
        public double Preço { get; set; }
        
        [Range(1,1000)]
        [Required]
        public int Quantidade { get; set; }

    }
}