using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TiendaMusica.Web.Helpers
{

    class Ubigeo
    {
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
    }

    public class UbigeoHelper
    {
        readonly IList<Ubigeo> ubigeos;

        public UbigeoHelper(string archivo)
        {
            ubigeos = new List<Ubigeo>();
            LeerUbigeosDesdeArchivo(archivo);
        }

        public IEnumerable<string> TraerDepartamentos()
        {
            return ubigeos.Select(u => u.Departamento).Distinct();
        }

        public IEnumerable<string> TraerProvincias(string departamento)
        {
            return ubigeos.Where(u => u.Departamento.Equals(departamento, StringComparison.InvariantCultureIgnoreCase))
                   .Select(u => u.Provincia)
                   .Distinct();
        }

        public IEnumerable<string> TraerDistritos(string departamento, string provincia)
        {
            return ubigeos.Where(u =>
               u.Departamento.Equals(departamento, StringComparison.InvariantCultureIgnoreCase) &&
               u.Provincia.Equals(provincia, StringComparison.InvariantCultureIgnoreCase)
                )
                .Select(u => u.Distrito)
                .Distinct();
        }
        private void LeerUbigeosDesdeArchivo(string archivo)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(archivo);
            var nodos = xml.SelectNodes("/ubigeo/location");
            if (nodos == null) return;

            foreach(XmlNode nodo in nodos)
            {
                Ubigeo ubigeo = new Ubigeo
                {
                    Departamento = nodo["Departamento"] == null ? string.Empty : nodo["Departamento"].InnerText,
                    Provincia = nodo["Provincia"] == null ? string.Empty : nodo["Provincia"].InnerText,
                    Distrito = nodo["Distrito"] == null ? string.Empty : nodo["Distrito"].InnerText
                };
                ubigeos.Add(ubigeo);
            }

        }
    }


}
