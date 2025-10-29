using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL
    {

        private readonly ScreenSoundContext context;

        public ArtistaDAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        //IEnumerable<Artista> = vários artistas
        //Ele indica que o método vai devolver vários objetos do tipo Artista,
        //um por um, como se fosse uma lista.
        public IEnumerable<Artista> Listar()
        {

            return context.Artistas.ToList();
        }


        public void Adicionar(Artista artista)
        {
            context.Artistas.Add(artista);
            context.SaveChanges();
        }

        public void Atualizar(Artista artista)
        {

            context.Artistas.Update(artista);
            context.SaveChanges();
        }

        public void Deletar(Artista artista)
        {

            context.Artistas.Remove(artista);
            context.SaveChanges();
        }

        //O método retorna um obejto do tipo Artista o ? informa que pode retornar Null se não encontrar nenhum artista com o nome informado
        //RecuperarPeloNome, nome do método, ele recebe um parâmetro nome
        //FirstOrDefault(a => a.Nome.Equals(nome) -> Essa expressão faz uma busca dentro da tabela de artistas, o =>  indica uma expressão lambda
        // "a" representa cada artista da lista , a.Nome.Equals(nome) -> compara o nome do artista no banco com o nome passado como parâmetro
        //FirstOrDefault retorna o primeiro artista que satisfaz a condição, se não encontrar ninguem retorna null
        public Artista? RecuperarPeloNome(string nome)
        {
            return context.Artistas.FirstOrDefault(a => a.Nome.Equals(nome));
        }
    }
}
