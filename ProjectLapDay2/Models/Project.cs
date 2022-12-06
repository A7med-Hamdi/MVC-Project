using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectLapDay2.Models
{
    public class Project
    {

        public int id { get; set; }
        public string name { get; set; }
        public string location { get; set; }


        [ForeignKey("Department")]
        public int departmentid { get; set; }
        public virtual Department department { get; set; }

        public virtual List<WorkOn> worksfor { get; set; }

    }
}
