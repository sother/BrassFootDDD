using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Exemplopuro.Domain;
using FluentNHibernate.Mapping;

namespace DDD.Exemplopuro.Domain.Mappings
{
    public class TimeMap : SubclassMap<Time>
    {
        public TimeMap()
        {
            DiscriminatorValue(2);
        }
    }
}
