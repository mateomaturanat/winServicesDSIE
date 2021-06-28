//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mechanic.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mechanic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mechanic()
        {
            this.ServiceList = new HashSet<ServiceList>();
        }
    
        public int IdMechanic { get; set; }
        public string NameMechanic { get; set; }
        public string SurnameMechanic { get; set; }
        public string DocumentNumberMechanic { get; set; }
        public string GenderMechanic { get; set; }
        public string PhoneMechanic { get; set; }
        public string EmailMechanic { get; set; }
        public byte[] ProfilePictureMechanic { get; set; }
        public string LatitudeMechanic { get; set; }
        public string LongitudeMechanic { get; set; }
        public int IdCity { get; set; }
        public int IdTypeDocument { get; set; }
    
        public virtual City City { get; set; }
        public virtual TypeDocument TypeDocument { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceList> ServiceList { get; set; }
    }
}
