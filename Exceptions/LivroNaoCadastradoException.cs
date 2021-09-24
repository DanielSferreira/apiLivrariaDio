using System;

namespace api_livraria_dio.Exceptions
{
    public class LivroNaoCadastradoException: Exception
    {
        public LivroNaoCadastradoException() :base("Livro não encontrado") {}
    }
}
