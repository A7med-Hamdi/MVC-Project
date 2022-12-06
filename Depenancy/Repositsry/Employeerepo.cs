using Depenancy.Models;

namespace Depenancy.Repositsry
{
    public class Employeerepo : IEmployeerepo
    {
        Day2DBContext db;
        public Employeerepo(Day2DBContext context)
        {
            db = context;
        }
        public List<Employee> Getall()
        {
            return db.Employees.ToList();
        }
        public Employee? getbyid(int id)
        {
            return db.Employees.SingleOrDefault(s => s.id == id);
        }
        public int Add(Employee employee)
        {
            db.Employees.Add(employee);
            return db.SaveChanges();
        }
        public int Edit(Employee employee)
        {
            Employee? OldEmployee = db.Employees.SingleOrDefault(e => e.id == employee.id);
            if (OldEmployee != null)
            {
                OldEmployee.name = employee.name;
                OldEmployee.age = employee.age;
                OldEmployee.address = employee.address;
                OldEmployee.salary = employee.salary;
                OldEmployee.dept_id = employee.dept_id;
                return db.SaveChanges();

            }
            return -1;
        }
        public int Delete(int id)
        {
            Employee? employee = getbyid(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                return db.SaveChanges();

            }
            return -1;
        }
    }
}
