namespace api_livraria_dio.Models
{
    public class LivroView : Model
    {
        public string Titulo {get; set;}
        public string Autor {get; set;}
        public double Preço {get; set;}
        public int Quantidade {get; set;}

    }
}