using System;

namespace api_livraria_dio.Exceptions
{
    public class LivroJaCadastradoException : Exception
    {
        public LivroJaCadastradoException()
            : base("Livro Cadastrado")
        { }
    }
}
