using System.ComponentModel.DataAnnotations.Schema;

namespace Depenancy.Models

{
    public class Dependant
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        [ForeignKey("Emp")]
        public int Emp_id { get; set; }
        public virtual Employee Emp { get; set; }

    }
}
