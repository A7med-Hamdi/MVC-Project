using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectLapDay2.Models;
using ProjectLapDay2.ViewModel;

namespace ProjectLapDay2.Controllers
{
    public class PartialviewController : Controller
    {
        Day2DBContext context = new Day2DBContext();
        public IActionResult GetAllempproj()
        {
            List<WorkOn> project = context.WorkOn.Include(p => p.Proj).Include(e => e.Emp).ToList();
            return View(project);
        }

        [HttpGet]
        public IActionResult Editprojecthoure()
        {
            EditprojecthoursVm hourVM = new();
            List<Employee> employees = context.Employees.ToList();
            hourVM.employee = new SelectList(employees, "id", "name");
            List<Project> projects = context.WorkOn.Include(sc => sc.Proj).Where(sc => sc.Eid == employees[0].id).Select(sc => sc.Proj).ToList();
            hourVM.project = new SelectList(projects, "id", "name");
            return View(hourVM);
        }
        [HttpPost]
        public IActionResult Editprojecthoure(EditprojecthoursVm vM)
        {
            WorkOn workOn = context.WorkOn.SingleOrDefault(sc => sc.Eid == vM.empId && sc.Pid == vM.proId);
            workOn.hours = vM.houre;
            context.SaveChanges();
            return RedirectToAction(nameof(GetAllempproj));
        }

        public IActionResult EditSelectProject(int id)
        {
            EditprojecthoursVm houreVM = new();
            List<Project> projects = context.WorkOn.Include(sc => sc.Proj).Where(sc => sc.Eid == id).Select(sc => sc.Proj).ToList();
            houreVM.project = new SelectList(projects, "id", "name");
            return PartialView("_projectlist", houreVM);
        }
    }
}
