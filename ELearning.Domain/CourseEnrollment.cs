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
    
    public partial class CourseEnrollment
    {
        public int CourseEnrollmentId { get; set; }
        public int CourseOfferingId { get; set; }
        public int StudentId { get; set; }
        public string Grade { get; set; }
    
        public virtual CourseOffering CourseOffering { get; set; }
        public virtual Grade Grade1 { get; set; }
        public virtual Student Student { get; set; }
    }
}
