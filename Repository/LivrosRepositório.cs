using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_livraria_dio.Services;

namespace api_livraria_dio.Repository
{
    public class LivrosRepositório : ILivrariaRepository
    {
        private LivrariaContext context;
        public LivrosRepositório(LivrariaContext ctx)
        {
            context = ctx;
        }
        public Task<Livro> Obter(int id)
        {
            var obj = context.Livros.Where(x => x.Id == id).FirstOrDefault();
            if (obj == null)
                return Task.FromResult<Livro>(null);
            return Task.FromResult<Livro>(obj);
        }

        public Task<List<Livro>> Obter(string nome, string autor)
        {
            var livros = context.Livros.Where(x => x.Titulo == nome && x.Autor == autor).ToList();
            return Task.FromResult(livros);
        }
        public Task<List<Livro>> Obter(int pagina, int quantidade)
        {
            var livros = context.Livros.ToList();
            return Task.FromResult(livros.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }
        public Task Atualizar(Livro livro)
        {
            context.Livros.Update(livro);
            context.SaveChanges();
            return Task.CompletedTask;
        }


        public Task Inserir(Livro livro)
        {
            context.Livros.Add(livro);
            context.SaveChanges();
            return Task.CompletedTask;
        }


        public Task Remover(Livro livro)
        {
            context.Livros.Remove(livro);
            context.SaveChanges();
            return Task.CompletedTask;
        }

    }
}