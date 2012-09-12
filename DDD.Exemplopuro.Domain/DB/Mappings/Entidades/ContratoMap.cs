using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace DDD.Exemplopuro.Domain.Mappings
{
    public class ContratoMap : ClassMap<Contrato>
    {
        public ContratoMap() 
        {
            Id(c => c.Id);
            Map(c => c.DataFinal);
            Map(c => c.DataInicio).Not.Nullable();
            Map(c => c.Vigente);
            References(c => c.Time);
            References(c => c.Jogador);
        }
    }
}
