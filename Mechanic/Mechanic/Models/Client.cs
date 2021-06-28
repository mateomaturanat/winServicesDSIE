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
    
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.Service = new HashSet<Service>();
        }
    
        public int IdClient { get; set; }
        public string NameClient { get; set; }
        public string SurnameClient { get; set; }
        public string IdentificationNumberClient { get; set; }
        public string GenderClient { get; set; }
        public string PhoneClient { get; set; }
        public string VehicleClient { get; set; }
        public byte[] ProfilePictureClient { get; set; }
        public System.Data.Entity.Spatial.DbGeography Latitude { get; set; }
        public System.Data.Entity.Spatial.DbGeography Longitude { get; set; }
        public int IdCity { get; set; }
        public int IdTypeDocument { get; set; }
    
        public virtual City City { get; set; }
        public virtual TypeDocument TypeDocument { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service> Service { get; set; }
    }
}
