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
    
    public partial class CourseOffering
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseOffering()
        {
            this.CourseEnrollments = new HashSet<CourseEnrollment>();
        }
    
        public int CourseOfferingId { get; set; }
        public int Section { get; set; }
        public int Capacity { get; set; }
        public int CourseNumber { get; set; }
        public Nullable<int> TermId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; }
        public virtual Cours Cours { get; set; }
        public virtual Term Term { get; set; }
    }
}
