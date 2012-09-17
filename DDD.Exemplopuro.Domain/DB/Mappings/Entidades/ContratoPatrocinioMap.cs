using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Exemplopuro.Domain.Patrocinio;
using FluentNHibernate.Mapping;
using DDD.Exemplopuro.Domain.Comercial;

namespace DDD.Exemplopuro.Domain.Mappings
{
    public class ContratoPatrocinioMap : ClassMap<ContratoPatrocinio>
    {
        public ContratoPatrocinioMap() 
        {
            Id(c => c.Id);
            Map(c => c.MesesDeContrato);
            References(c => c.Patrocinado).Not.Nullable();
            Map(c => c.ValorBaseBonus);
            Map(c => c.ValorBaseDireitoDeImagem);
            Map(c => c.ValorBaseSalario);
            Map(c => c.DataFinal);
            Map(c => c.DataInicio).Not.Nullable();
            Map(c => c.Vigente);
        }
    }
}
