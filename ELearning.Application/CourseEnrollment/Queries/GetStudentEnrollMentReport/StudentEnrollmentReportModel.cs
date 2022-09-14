using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ELearning.Application.Common.Mapping;
using ELearning.Domain;

namespace ELearning.Application.CourseEnrollment.Queries.GetStudentEnrollMentReport
{
    public class StudentEnrollmentReportModel:IMapFrom
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseTitle { get; set; }
        public string Grade { get; set; }
        public string TermCode { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetEnrollMentStudentReport_Result, StudentEnrollmentReportModel>();
        }
    }
}
