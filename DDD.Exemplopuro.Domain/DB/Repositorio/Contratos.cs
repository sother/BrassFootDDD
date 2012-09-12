using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Exemplopuro.Domain.DB.Repositorio
{
    public class Contratos : BaseRepository
    {
        public void salvar(Contrato contrato) 
        {
            base.Salvar(contrato);
        }
    }
}
