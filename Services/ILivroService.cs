
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_livraria_dio.Models;

namespace api_livraria_dio.Services
{
    public interface ILivroService : IDisposable
    {
        public Task<List<LivroView>> Obter(int pagina, int quantidade);
        public Task<LivroView> Obter(int id);
        public Task<LivroView> Inserir(LivroModel livro);
        public Task Atualizar(int id, LivroModel livro);
        public Task Atualizar(int id, double preco);
        public Task Remover(int id);
    }
}