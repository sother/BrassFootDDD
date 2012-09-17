using System.Collections.Generic;
using NHibernate;

namespace DDD.Exemplopuro.Domain.DB.Repositorio
{
    public class Patrocinados : BaseRepository
    {
        public Patrocinados()
        {

        }

        public Patrocinados(ISession session)
            : base(session)
        {

        }

        public void Salvar(Patrocinado patrocinado)
        {
            base.Salvar(patrocinado);
        }

        public Patrocinado Obter(int id)
        {
            return base.Obter<Patrocinado>(id);
        }

        public IList<Patrocinado> ObterTimes()
        {
            return null;
        }

        public void Excluir(Patrocinado patrocinado)
        {
            base.Deletar(patrocinado);
        }
    }
}
