using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using DDD.Exemplopuro.Domain;

namespace DDD.Exemplopuro.Domain.Mappings
{
    public class JogadorMap : SubclassMap<Jogador>
    {
        public JogadorMap()
        {
            DiscriminatorValue(1);
        }
    }
    
}
