using System.ComponentModel.DataAnnotations;

namespace api_livraria_dio.Models
{
    public class LivroModel : Model
    {
        public int Id {get; set;}
        [Required]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Titutlo deve ter no mínimo 5 caracteres")]
        public string Titulo {get; set;}

        [Required]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Autor deve ter no mínimo 5 caracteres")]
        public string Autor {get; set;}

        [Required]
        [Range(1,100,ErrorMessage = "Preço deve estar entre 1 e 100")]
        public double Preço {get; set;}

        [Required]
        [Range(0,100,ErrorMessage = "Quantidade deve estar entre 0 e 1000")]
        public int Quantidade {get; set;}

    }
}