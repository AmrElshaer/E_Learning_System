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
    
    public partial class Applicant
    {
        public int ApplicantId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public System.DateTime ApplicationReceivedDate { get; set; }
        public string EntryTerm { get; set; }
        public string ApplicationType { get; set; }
        public Nullable<decimal> Gpa { get; set; }
        public Nullable<int> SatMathScore { get; set; }
        public Nullable<int> SatReadingScore { get; set; }
        public Nullable<int> SatWritingScore { get; set; }
        public Nullable<int> EssayScore { get; set; }
        public string ApplicationStatus { get; set; }
        public Nullable<double> AdmissionPoints { get; set; }
    
        public virtual Term Term { get; set; }
    }
}
