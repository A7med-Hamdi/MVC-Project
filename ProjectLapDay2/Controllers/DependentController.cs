using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectLapDay2.Models;

namespace ProjectLapDay2.Controllers
{
    public class DependentController : Controller
    {
        Day2DBContext context;
        public DependentController()
        {
            context = new Day2DBContext();

        }
        public IActionResult Index()
        {
            List<Dependant> dependants = context.Dependants.Include(e => e.Emp).ToList();

            return View(dependants);
        }
        [HttpGet]
        public IActionResult Addform()
        {
            List<Employee> employees = context.Employees.ToList();

            return View(employees);
        }
        [HttpPost]
        public IActionResult Add(Dependant dependant)
        {
            Dependant olddependant = new Dependant()
            {
                name = dependant.name,
                age = dependant.age,
                Emp_id = dependant.Emp_id,

            };
            context.Dependants.Add(olddependant);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editform(int id)
        {
            Dependant dependant = context.Dependants.SingleOrDefault(p => p.id == id);
            List<Employee> employees = context.Employees.ToList();
            ViewBag.employees = new SelectList(employees, "id", "name");
            return View(dependant);
        }
        [HttpPost]
        public IActionResult Edit(Dependant dependant)
        {
            Dependant Olddependent = context.Dependants.SingleOrDefault(p => p.id == dependant.id);
            Olddependent.name = dependant.name;

           Olddependent.age = dependant.age;
            Olddependent.Emp_id = dependant.Emp_id;

            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Delete(int id)
        {
            Dependant dependant = context.Dependants.SingleOrDefault(e => e.id == id);

            context.Dependants.Remove(dependant);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
