using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualOffice.Repositorios.Dominio.Componentes
{
    [ComplexType]
    public class Direccion
    {
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Calle { get; set; }
    }
}