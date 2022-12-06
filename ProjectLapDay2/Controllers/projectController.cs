using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectLapDay2.Models;

namespace ProjectLapDay2.Controllers
{
    public class projectController : Controller
    {
        Day2DBContext context;
        public projectController()
        {
            context = new Day2DBContext();

        }
        public IActionResult Index()
        {
            List<Project> projects = context.Projects.Include(d => d.department).ToList();

            return View(projects);
        }
        [HttpGet]
        public IActionResult Addform()
        {
            List<Department> departments = context.Departments.ToList();

            return View(departments);
        }
        [HttpPost]
        public IActionResult Add(Project projectvm)
        {
            Project project = new Project()
            {
                name = projectvm.name,
                location = projectvm.location,
                departmentid = projectvm.departmentid,

            };
            context.Projects.Add(project);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editform(int id)
        {
            Project project = context.Projects.SingleOrDefault(p => p.id == id);
            List<Department> departments = context.Departments.ToList();
            ViewBag.departments = new SelectList(departments, "id", "name");
            return View(project);
        }
        [HttpPost]
        public IActionResult Edit(Project project)
        {
            Project Oldproject = context.Projects.SingleOrDefault(p => p.id == project.id);
            Oldproject.name = project.name;
            Oldproject.location = project.location;
            Oldproject.departmentid = project.departmentid;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Delete(int id)
        {
            Project project = context.Projects.SingleOrDefault(e => e.id == id);

            context.Projects.Remove(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
