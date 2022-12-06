using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectLapDay2.Models;

namespace ProjectLapDay2.Controllers
{
    public class EmployeeController : Controller
    {
        Day2DBContext context = new Day2DBContext();
        public IActionResult getAll()
        {
            List<Employee> employees = context.Employees.Include(a => a.dept).ToList();
            return View(employees);
        }
        public IActionResult getAllWorksOn()
        {  List<WorkOn> workOns = context.WorkOn.ToList();
          
               
            return View(workOns);
        }
        public IActionResult Details(int id)
        {
            Employee employee = context.Employees.Include(e => e.dept).FirstOrDefault(e => e.id == id);
            return View(employee);
        }
        public IActionResult AddForm()
        {
            List<Department> departments = context.Departments.ToList();
            return View(departments);
        }
        public IActionResult Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            TempData["name"] = "data saved";
            return RedirectToAction("getAll");
        }
        public IActionResult EditForm(int id)
        {
            Employee employee = context.Employees.Include(c => c.dept).SingleOrDefault(c => c.id == id);
            List<Department> departments = context.Departments.ToList();
            ViewData["dept"] = departments;
            return View(employee);

        }
        public IActionResult Edit(Employee employee)
        {
            Console.WriteLine(employee);

            Employee OldEmployee = context.Employees.SingleOrDefault(e => e.id == employee.id);
            OldEmployee.name = employee.name;
            OldEmployee.age = employee.age;
            OldEmployee.address = employee.address;
            OldEmployee.salary = employee.salary;
            OldEmployee.dept_id = employee.dept_id;
            context.SaveChanges();
            return RedirectToAction("getAll");
        }

   
        public IActionResult Delete(int id)
        {
            Employee employee = context.Employees.SingleOrDefault(e => e.id == id);

            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("getAll");
        }

        public IActionResult AssignProject()
        {
            List<Employee> employees = context.Employees.ToList();
            List<Project> projects = context.Projects.ToList();
            empprooo empProjectVM = new empprooo() { Employees = employees, projects = projects };
            return View(empProjectVM);

        }
        public IActionResult AssignProjectDb(empprooo empProjectVM)
        {
            foreach(int item in empProjectVM.multi_projs)
            {
                WorkOn worksOn = new WorkOn()
                {
                    Eid = empProjectVM.EmpId,
                    Pid = item,
                    hours = empProjectVM.hours
                };
                WorkOn empPj = context.WorkOn.FirstOrDefault(a => a.Eid == empProjectVM.EmpId
                && a.Pid == item);
                if (empPj == null)
                {
                     context.WorkOn.Add(worksOn);
                    context.SaveChanges();
                

                }else
                {
                   
                    return RedirectToAction("AssignProject");

                }
            }
            return RedirectToAction("getAllWorksOn");


        }
    }
}
