//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InmosystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inmobiliaria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inmobiliaria()
        {
            this.Proyecto = new HashSet<Proyecto>();
        }
    
        public int Inmo_id { get; set; }
        public string Inmo_Name { get; set; }
        public string Inmo_Rut { get; set; }
        public string Inmo_RL { get; set; }
        public string Inmo_Zona { get; set; }
        public string Inmo_Region { get; set; }
        public string Inmo_Ciudad { get; set; }
        public string Inmo_Calle { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}
