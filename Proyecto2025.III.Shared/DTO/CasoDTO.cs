using Proyecto2025.III.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto2025.III.Shared.DTO
{
    public class CasoDTO : BaseEntityDTO
    {
        [Required(ErrorMessage = "El numero de expediente es obligatorio")]
        public int NumeroExpediente { get; set; }
        public DateOnly FechaInicio { get; set; }
        public EstadoCaso Estado { get; set; }
        public string? Descripcion { get; set; }
        public TipoCaso Tipo { get; set; }
        public int ClienteId { get; set; }


    }
    //public enum EstadoCaso
    //{
    //    Abierto,
    //    Cerrado,
    //    EnProgreso,
    //    EnEspera
    //}
    //public enum TipoCaso
    //{
    //    Civil,
    //    Penal,
    //    Laboral,
    //    Familiar,
    //    Comercial
    //}
}
