using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_livraria_dio.Services;

namespace api_livraria_dio.Repository
{
    public interface ILivrariaRepository
    {
        public Task<List<Livro>> Obter(int pagina, int quantidade);
        public Task<Livro> Obter(int id);
        public Task<List<Livro>> Obter(string nome, string autor);
        public Task Inserir(Livro livro);
        public Task Atualizar(Livro livro);
        public Task Remover(Livro livro);
    }
}