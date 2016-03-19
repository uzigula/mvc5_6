using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;


namespace VirtualOffice.Web.Areas.Administrativa.Models
{
    public class ReservaGrabarViewModel
    {
        public int ClienteId { get; set; }
        public int LocalId { get; set; }
        public int SalaId { get; set; }
        public int HoraInicio { get; set; }
        public int HoraFin { get; set; }
        public int Participantes { get; set; }
        [AllowHtml]
        public string Indicaciones { get; set; }
        public DateTime FechaFinal { get; set; }
        public DateTime FechaInicio { get; set; }

        public void ArreglarHoras()
        {
            var horario = new Horario().ObtenerHorario();
            FechaInicio = FechaInicio + horario
                .FirstOrDefault(x => x.Index == HoraInicio).Inicio;
            
            FechaFinal = FechaFinal + horario
                .FirstOrDefault(x => x.Index == HoraFin).Inicio;

        }


    }

    public class ReservaViewModel
    {
        private Horario horario;
        private SelectList horasInicio;
        private SelectList horasFin;
        
        public ReservaViewModel()
        {
            horario = new Horario();
            FechaFinal = DateTime.Now;
            FechaInicio = DateTime.Now;
        }


        public int ClienteId { get; set; }
        [Display(Name = "Nombre Cliente")]
        public string Cliente { get; set; }
        public int LocalId { get; set; }
        public int SalaId { get; set; }
        
        [Required(ErrorMessage = "Ingrese una fecha de inicio de reserva")]
        [Display(Name = "Inicio Reserva")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }
        
        public int HoraInicio { get; set; }
        public int HoraFin { get; set; }
        
        [Required(ErrorMessage = "Ingrese una fecha de termino de reserva")]
        [Display(Name = "Termino de reserva")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]        
        public DateTime FechaFinal { get; set; }

        public int Participantes { get; set; }
        [AllowHtml]
        public string Indicaciones { get; set; }

        // para mostrar en la vista 
        public SelectList Salas { get; set; }
        public SelectList HorasInicio
        {
            get
            {
                if (horasInicio == null)
                {
                    var timeSchedule = horario.ObtenerHorario().ToList();
                    horasInicio = new SelectList(timeSchedule, "Index", "InicioFormateado", HoraInicio);
                }
                return horasInicio;
            }
        }
        public SelectList HorasFin
        {
            get
            {
                if (horasFin == null)
                {
                    var timeSchedule = horario.ObtenerHorario().ToList();
                    horasFin = new SelectList(timeSchedule, "Index", "FinFormateado", HoraFin);
                }
                return horasInicio;
            }
        }
 
        public SelectList Locales { get; set; }

    }   



}