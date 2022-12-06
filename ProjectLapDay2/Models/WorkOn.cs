using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectLapDay2.Models
{
    public class WorkOn
    {

        [Key, Column(Order = 1)]
        [ForeignKey("Emp")]
        public int Eid { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("Proj")]
        public int Pid { get; set; }
        public int hours { get; set; }

        public virtual Employee Emp { get; set; }
        public virtual Project Proj { get; set; }

    }
}
