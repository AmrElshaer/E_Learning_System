using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ELearning.Application.Common.Mapping;
using ELearning.Domain;

namespace ELearning.Application.CourseEnrollment.Queries.GetStudentEnrollmentReportBerYear
{
    public class CountCourseStudentsEnrollModel:IMapFrom
    {
        public string CourseTitle { get; set; }
        public int? NumOfStudentEnroll { get; set; }
        public void Mapping(Profile profile)
        {
    
        profile.CreateMap<CountCourse_StudentsEnroll_Result, CountCourseStudentsEnrollModel>();
        }
    }
}
