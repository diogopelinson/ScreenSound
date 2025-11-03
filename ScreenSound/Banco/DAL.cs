using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenSound.Modelos;


namespace ScreenSound.Banco 
{
    internal class DAL<T> where T : class //Tipo generico
    {
        protected readonly ScreenSoundContext context;

        public DAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Listar()
        {
            return context.Set<T>().ToList();
        }

        public void Adicionar(T objeto)
        {
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }

        public void Atualizar(T objeto)
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }

        public void Deletar(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }

        //Func traz um retorno
        //O método retorna um obejto do tipo Artista o ? informa que pode retornar Null se não encontrar nenhum artista com o nome informado
        //RecuperarPeloNome, nome do método, ele recebe um parâmetro nome
        //FirstOrDefault(a => a.Nome.Equals(nome) -> Essa expressão faz uma busca dentro da tabela de artistas, o =>  indica uma expressão lambda
        // "a" representa cada artista da lista , a.Nome.Equals(nome) -> compara o nome do artista no banco com o nome passado como parâmetro
        //FirstOrDefault retorna o primeiro artista que satisfaz a condição, se não encontrar ninguem retorna null
        public T? RecuperarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().FirstOrDefault(condicao);
        }

    }
}
