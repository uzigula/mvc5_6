using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace VirtualOffice.Web.XmlHelpers
{
    class Location
    {
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
    }

    public class UbigeoHelper
    {
        readonly IList<Location> _ubigeo;

        public UbigeoHelper(string fileName)
        {
            _ubigeo = new List<Location>();
            LoadUbigeoFromFile(fileName);
        }

        public IEnumerable<string> GetDepartamentos()
        {
            return _ubigeo.Select(u => u.Departamento).Distinct();
        }

        public IEnumerable<string> GetProvincias(string departamento)
        {
            return
                _ubigeo.Where(u => u.Departamento.Equals(departamento, StringComparison.InvariantCultureIgnoreCase))
                    .Select(u => u.Provincia)
                    .Distinct();
        }

        public IEnumerable<string> GetDistritos(string departamento, string provincia)
        {
            return
                _ubigeo.Where(
                    u =>
                        u.Departamento.Equals(departamento, StringComparison.InvariantCultureIgnoreCase) &&
                        u.Provincia.Equals(provincia, StringComparison.InvariantCultureIgnoreCase))
                    .Select(u => u.Distrito)
                    .Distinct();
        }

        void LoadUbigeoFromFile(string fileName)
        {
            var xml = new XmlDocument();
            xml.Load(fileName);
            var nodes = xml.SelectNodes("/ubigeo/location");
            if (nodes != null)
                foreach (XmlNode node in nodes)
                {
                    var location = new Location
                    {
                        Departamento = node["Departamento"] == null ? string.Empty : node["Departamento"].InnerText,
                        Provincia = node["Provincia"] == null ? string.Empty : node["Provincia"].InnerText,
                        Distrito = node["Distrito"] == null ? string.Empty : node["Distrito"].InnerText
                    };
                    _ubigeo.Add(location);
                }
        }
    }
}