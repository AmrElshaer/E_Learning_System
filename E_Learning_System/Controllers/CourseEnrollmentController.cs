using System;
using E_Learning_System.Attributes;
using ELearning.Application.Common.Commond;
using ELearning.Application.Common.Query;
using ELearning.Application.CourseEnrollment.Commonds.CreatEditCoursEnrollment;
using ELearning.Application.CourseEnrollment.Commonds.DeletCoursEnrollment;
using ELearning.Application.CourseEnrollment.Queries;
using ELearning.Application.CourseEnrollment.Queries.GetCoursesEnrollment;
using ELearning.Application.CourseEnrollment.Queries.GetStudentEnrollMentReport;
using MvcRazorToPdf;
using Syncfusion.EJ2.Base;
using Syncfusion.EJ2.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ELearning.Application.CourseEnrollment.Queries.GetStudentEnrollmentReportBerYear;
using Microsoft.Reporting.WebForms;

namespace E_Learning_System.Controllers
{

    public class CourseEnrollmentController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> CourseEnrollForYear(GetStudentEnrollmentReportBerYearQuery queries)
        {
            try
            {
                LocalReport lr = new LocalReport();
                string path = Path.Combine(Server.MapPath("~/Reports"), "CourseEnrollPerYearReport.rdlc");
                if (System.IO.File.Exists(path))
                {
                    lr.ReportPath = path;
                }
               // var report = await Mediator.RequestAsync<GetStudentEnrollmentReportBerYearQuery, QueryResult<CountCourseStudentsEnrollModel>>(queries);
               List<CountCourseStudentsEnrollModel> data = new List<CountCourseStudentsEnrollModel>()
               {
                   new CountCourseStudentsEnrollModel(){CourseTitle = "DotNet",NumOfStudentEnroll = 25},
                   new CountCourseStudentsEnrollModel(){CourseTitle = "Js",NumOfStudentEnroll = 100}
               };
                ReportDataSource rd = new ReportDataSource("CoursEnrollPerYearDataSet", data);
                lr.DataSources.Add(rd);
                var renderedBytes = lr.Render("PDF");
                return File(renderedBytes, "application/pdf", "Course_ENrolllMentPerYear.pdf");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async  Task<ActionResult> RDLCReport(GetStudentEnrollmentReportQuery queries)
        {
            try
            {
                LocalReport lr = new LocalReport();
                lr.DataSources.Clear();
                string path = Path.Combine(Server.MapPath("~/Reports"), "CoursEnrollReport.rdlc");
                if (System.IO.File.Exists(path))
                {
                    lr.ReportPath = path;
                }
                var report = await Mediator.RequestAsync<GetStudentEnrollmentReportQuery, QueryResult<StudentEnrollmentReportModel>>(queries);
                ReportDataSource rd = new ReportDataSource("CoursEnrollDataSet", report.result.ToList());
                lr.DataSources.Add(rd);
                var renderedBytes = lr.Render("PDF");
                return File(renderedBytes,"application/pdf","Course_ENrolllMent.pdf");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpGet]
        public async Task<ActionResult> EnrollmentReport(GetStudentEnrollmentReportQuery queries)
        {
            var report = await Mediator.RequestAsync<GetStudentEnrollmentReportQuery, QueryResult<StudentEnrollmentReportModel>>(queries);
            var model = new PdfExample<StudentEnrollmentReportModel>
            {
                Heading = "Courses Enrollment",
                Items = report.result.ToList()
            };
            return new PdfActionResult(model);
        }
        public async Task<ActionResult> UrlDatasource(DataManagerRequest dm)
        {
            var result = await Mediator.RequestAsync<GetCoursesEnrollQueries, QueryResult<CourseEnrollmentDto>>(new GetCoursesEnrollQueries(dm));
            return Json(new
            {
                result = result.result,
                count = result.count
            });

        }

        [HttpPost]
        public ActionResult CreatEditPartial(CourseEnrollmentDto value)
        {

            return PartialView("_CreatEditPartial", value);
        }
        [HttpPost]
        [ValidationActionFilter]
        public async Task<ActionResult> Save(CreatEditCoursEnrollmentCommond value)
        {

            value.CourseOfferingId = (await Mediator.RequestAsync<CreatEditCoursEnrollmentCommond, BaseEntity<int>>(value)).Id;
            return Json(value);

        }
        public async Task<ActionResult> Delete(CRUDModel<CreatEditCoursEnrollmentCommond> value)
        {
            await Mediator.SendAsync(new DeletCoursEnrollCommond() { CourseEnrollId = (int)value.Key });
            return Json(value);
        }
    }

  

    public class PdfExample<T>
    {
        public string Heading { get; set; }
        public List<T> Items { get; set; }
    }
}
