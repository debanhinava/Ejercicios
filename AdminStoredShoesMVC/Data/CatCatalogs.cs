//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CatCatalogs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CatCatalogs()
        {
            this.Products = new HashSet<Products>();
        }
    
        public int IdCatalog { get; set; }
        public int IdProvider { get; set; }
        public string Season { get; set; }
        public string StarActiveDate { get; set; }
        public string EndActiveDate { get; set; }
        public string DateUpdate { get; set; }
        public string IsEnabled { get; set; }
    
        public virtual CatProviders CatProviders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Products> Products { get; set; }
    }
}
