using Depenancy.Models;
using Depenancy.Repositsry;

namespace Depenancy.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeerepo employeerepo;
        public EmployeeService(IEmployeerepo employeerepo)
        {
            this.employeerepo = employeerepo;
        }
        public List<Employee> getall()
        {
            List<Employee> employees = employeerepo.Getall();

            return employees;

        }
    }
}
