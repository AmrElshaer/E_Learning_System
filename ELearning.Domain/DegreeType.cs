//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ELearning.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class DegreeType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DegreeType()
        {
            this.Degrees = new HashSet<Degree>();
        }
    
        public string DegreeTypeCode { get; set; }
        public string DegreeTypeName { get; set; }
        public string DegreeLevelCode { get; set; }
    
        public virtual DegreeLevel DegreeLevel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Degree> Degrees { get; set; }
    }
}
