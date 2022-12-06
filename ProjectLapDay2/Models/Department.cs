namespace ProjectLapDay2.Models
{
    public class Department
    {
        public Department()
        {
            emp = new List<Employee>();
            proj = new List<Project>();
        }
        public int id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public virtual List<Employee> emp { get; set; }
        public virtual  List<Project> proj { get; set; }

    }
}
