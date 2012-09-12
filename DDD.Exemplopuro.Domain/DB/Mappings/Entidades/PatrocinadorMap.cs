using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Exemplopuro.Domain.Comercial;
using FluentNHibernate.Mapping;

namespace DDD.Exemplopuro.Domain.Mappings
{
    public class PatrocinadorMap : ClassMap<Patrocinador>
    {
        public PatrocinadorMap()
        {
            Id(p => p.Id);
            Map(p => p.Nome);
            HasMany(p => p.Patrocinados).Inverse().Cascade.All().Not.LazyLoad();
        }
    }
}
