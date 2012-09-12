using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DDD.Exemplopuro.Domain
{
    public class Tipos<T> : BaseRepository
    {
        public T Obter(int id)
        {
           return Obter<T>(id);
        }

        public IList<T> Todos()
        {
            return Todos<T>();
        }
    }
}
