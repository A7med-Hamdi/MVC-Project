using Depenancy.Models;

namespace Depenancy.Repositsry
{
    public interface IEmployeerepo
    {
        int Add(Employee employee);
        int Delete(int id);
        int Edit(Employee employee);
        List<Employee> Getall();
        Employee? getbyid(int id);
    }
}