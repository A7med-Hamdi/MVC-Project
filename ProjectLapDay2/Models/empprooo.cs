namespace ProjectLapDay2.Models
{
    public class empprooo
    {
        public int EmpId { get; set; }
        public int PId { get; set; }
        public int hours { get; set; }
        public virtual List<int> multi_projs { get; set; }
        public virtual List<Employee> Employees { get; set; }
        public virtual List<Project> projects { get; set; }
    }
}
