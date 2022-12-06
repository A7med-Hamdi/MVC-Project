using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectLapDay2.Models
{
    public class Employee
    {

        public Employee()
        {
            depend = new List<Dependant>();
        }
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int age { get; set; }
        public double salary { get; set; }
        [ForeignKey("dept")]
        public int dept_id { get; set; }
        public virtual  Department dept { get; set; }
        public virtual List<Dependant> depend { get; set; }
        public virtual List<WorkOn> WorkOns { get; set; }
    }
}
