using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Exemplopuro.Domain
{
    public class Patrocinados : BaseRepository
    {
        public void Salvar(Patrocinado patrocinado)
        {
            base.Salvar(patrocinado);
        }

        public Patrocinado Obter(int id)
        {
            return base.Obter<Patrocinado>(id);
        }

        public  IList<Patrocinado> ObterTimes()
        {
            return null;
        }

        public void Excluir(Patrocinado patrocinado)
        {
            base.Deletar(patrocinado);
        }
    }
}
