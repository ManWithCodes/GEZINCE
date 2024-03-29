//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GEZINCE.WebServices.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Place
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Place()
        {
            this.PlaceImages = new HashSet<PlaceImage>();
        }
    
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string AdressText { get; set; }
        public string Text { get; set; }
        public int Priority { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAdress { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual City City { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaceImage> PlaceImages { get; set; }
    }
}
