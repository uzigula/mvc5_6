using System;
using System.Collections.Generic;
using System.Linq;
using VirtualOffice.Repositorios.Dominio;

namespace VirtualOffice.Repositorios.ADO
{
    public class SalaDbRepository : IDbRepository<Sala>
    {
        private IDatabaseContext databaseContext;
        public SalaDbRepository(IDatabaseContext context)
        {
            databaseContext = context;
        }

        public IQueryable<Sala> Get()
        {
            var lista = new List<Sala>();
            var reader = databaseContext.ExecuteQuery("la consulta", new Parameter[] { });
            //recorrer el datareader y crear una lista<PlayList>
            while (reader.Read())
            {
                lista.Add(new Sala()
                {
                    Id = reader.GetInt32(0)
                    //se hace el mapeo campo por campo

                }
                    );
            }

            return lista.AsQueryable<Sala>();
        }

        public void Create(Sala entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Sala entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Sala entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
