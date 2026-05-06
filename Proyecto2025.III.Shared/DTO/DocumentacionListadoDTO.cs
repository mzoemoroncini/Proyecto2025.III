using Proyecto2025.III.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.III.Shared.DTO
{
    public class DocumentacionListadoDTO : BaseEntityDTO
    {

       
        public required string ArchivoUrl { get; set; }
        
        public string DatosDocumento { get; set; } =  "";
       

    }
}
