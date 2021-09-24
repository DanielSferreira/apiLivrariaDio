using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_livraria_dio.Models;
using api_livraria_dio.Repository;
using api_livraria_dio.Exceptions;

namespace api_livraria_dio.Services
{
    public class LivroService : ILivroService
    {
        private readonly LivrosRepositório rp;

        public LivroService(LivrosRepositório _rp)
        {
            rp = _rp;
        }

        public async Task Atualizar(int id, LivroModel livro)
        {
            var entity = await rp.Obter(id);

            if (entity == null)
                throw new LivroNaoCadastradoException();

            entity.Titulo = livro.Titulo;
            entity.Autor = livro.Autor;
            entity.Preço = livro.Preço;
            entity.Quantidade = livro.Quantidade;

            await rp.Atualizar(entity);
        }

        public async Task Atualizar(int id, double preco)
        {
            var entity = await rp.Obter(id);

            if (entity == null)
                throw new LivroNaoCadastradoException();

            entity.Preço = preco;

            await rp.Atualizar(entity);
        }

        public async Task Atualizar(int id, int quantidade)
        {
            var entity = await rp.Obter(id);

            if (entity == null)
                throw new LivroNaoCadastradoException();

            entity.Quantidade = quantidade;

            await rp.Atualizar(entity);
        }

        public void Dispose()
        {
        }

        public async Task<LivroView> Inserir(LivroModel livro)
        {
            var entity = await rp.Obter(livro.Titulo, livro.Autor);

            if (entity.Count > 0)
                throw new LivroJaCadastradoException();

            var newLivro = new Livro
            {
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                Preço = livro.Preço,
                Quantidade = livro.Quantidade
            };

            await rp.Inserir(newLivro);

            return new LivroView
            {
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                Preço = livro.Preço,
                Quantidade = livro.Quantidade
            };
        }

        public async Task<List<LivroView>> Obter(int pagina, int quantidade)
        {
            var l = await rp.Obter(pagina, quantidade);
            return l.Select(x => new LivroView()
            {
                Autor = x.Autor,
                Preço = x.Preço,
                Titulo = x.Titulo,
                Quantidade = x.Quantidade
            }).ToList();
        }

        public async Task<LivroView> Obter(int id)
        {
            var livro = await rp.Obter(id);
            if (livro == null)
                throw new LivroNaoCadastradoException();
            return new LivroView()
            {
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                Preço = livro.Preço,
                Quantidade = livro.Quantidade
            };
        }

        public async Task Remover(int id)
        {
            var obj = await rp.Obter(id);

            if (obj == null) 
                throw new LivroNaoCadastradoException();

            await rp.Remover(obj);
        }
    }
}