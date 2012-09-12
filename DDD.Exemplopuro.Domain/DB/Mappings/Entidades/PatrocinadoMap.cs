using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Exemplopuro.Domain;
using FluentNHibernate.Mapping;

namespace DDD.Exemplopuro.Domain
{
    public class PatrocinadoMap : ClassMap<Patrocinado> 
    {
        public PatrocinadoMap()
        {
            Id(c => c.Id);
            Map(p => p.Nome);
            HasMany(j => j.Contratos).Inverse().Cascade.All();
            HasMany(x => x.Creditos).Inverse().Cascade.All();
            DiscriminateSubClassesOnColumn("TipoPatrocinado");
        }
    }

}
