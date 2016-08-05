using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InmosystemWeb.Models
{
    public class CuentaViewModel
    {

        public int Cuenta_id { get; set; }
        public DateTime Cuenta_FechaProceso { get; set; }
        public int Cuenta_Valor { get; set; }
       
       
        
        public int Etapa_id { get; set; }
        public int Plan_Id { get; set; }

        public virtual Etapa Etapa { get; set; }
        public virtual PlandeCuentas PlandeCuentas { get; set; }
    }
}