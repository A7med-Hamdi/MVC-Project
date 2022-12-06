using Microsoft.AspNetCore.Mvc;
using ProjectLapDay2.Models;

namespace ProjectLapDay2.Controllers
{
    public class DepartmentController : Controller
    {
        Day2DBContext context = new Day2DBContext();

        public IActionResult getAll()
        {
            List<Department> departments = context.Departments.ToList();
            return View(departments);
        }

        public IActionResult Details(int id)
        {
            Department department = context.Departments.FirstOrDefault(d => d.id == id);
            return View(department);
        }

        public IActionResult AddForm()
        {
            return View();
        }
        public IActionResult Add(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("getAll");
        }

        public IActionResult EditForm(int id)
        {
            Department department = context.Departments.FirstOrDefault(d => d.id == id);
            return View(department);
        }
        public IActionResult Edit(Department department)
        {
            Department Old = context.Departments.SingleOrDefault(o => o.id == department.id);
            Old.name = department.name;
            Old.location = department.location;
            context.SaveChanges();
            return RedirectToAction("getAll");
        }

        public IActionResult Delete(int id)
        {
            Department department = context.Departments.SingleOrDefault(d => d.id == id);
            context.Departments.Remove(department);
            context.SaveChanges();
            return RedirectToAction("getAll");
        }
    }
}
