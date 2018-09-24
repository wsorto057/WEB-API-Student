using MVCStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace MVCStudent.Controllers
{
    public class studentsController : Controller
    {
        // GET: students
        public ActionResult Index()
        {
            IEnumerable<mvcStudentModel> stuList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("students").Result;
            stuList = response.Content.ReadAsAsync<IEnumerable<mvcStudentModel>>().Result;

            return View(stuList);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcStudentModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("students/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcStudentModel>().Result);
            }

        }

        [HttpPost]
        public ActionResult AddorEdit(mvcStudentModel stu)
        {
            if (stu.id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("students", stu).Result;
                TempData["SuccesMessage"] = "Save Successfully";

            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("students/" + stu.id, stu).Result;
                TempData["SuccesMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");

        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("students/" + id.ToString()).Result;
            TempData["SuccesMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}