using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace DDD.Exemplopuro.Domain.Mappings
{
    public class CreditoPatrocinadorMap : ClassMap<CreditoPatrocinador>
    {
        public CreditoPatrocinadorMap() 
        {
            Id(c => c.Id);
            Map(c => c.Valor);
            Map(c => c.Data);
        }

    }
}
