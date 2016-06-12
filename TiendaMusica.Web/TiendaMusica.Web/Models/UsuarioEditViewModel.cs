using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TiendaMusica.Web.Models
{
    public class UsuarioEditViewModel
    {
        public string Nombre { get; set; }

        public SelectList Departamentos { get; set; }

        public SelectList Provincias { get; set; }

        public SelectList Distritos { get; set; }

        [Required]
        public string Departamento { get; set; }
        [Required]
        public string Provincia { get; set; }
        [Required]
        public string Distrito { get; set; }

        public UsuarioEditViewModel()
        {
            var listaVacia = new List<string>() { "Seleccione..." };
            Departamentos = new SelectList(listaVacia);
            Provincias = new SelectList(listaVacia);
            Distritos = new SelectList(listaVacia);
        }

    }
}
