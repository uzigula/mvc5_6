using System;
using System.Collections.Generic;
using System.Linq;
using YoVoy.Repositorio.Entidades;

namespace YoVoy.Repositorio.ADO
{
    public class SalaDbRepository : IDbRepository<Evento>
    {
        private IDatabaseContext databaseContext;
        public SalaDbRepository(IDatabaseContext context)
        {
            databaseContext = context;
        }

        public IQueryable<Evento> Get()
        {
            var lista = new List<Evento>();
            var reader = databaseContext.ExecuteQuery("la consulta", new Parameter[] { });
            //recorrer el datareader y crear una lista<PlayList>
            while (reader.Read())
            {
                lista.Add(new Evento()
                {
                    Id = reader.GetInt32(0)
                    //se hace el mapeo campo por campo

                }
                    );
            }

            return lista.AsQueryable<Evento>();
        }

        public void Create(Evento entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Evento entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Evento entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
