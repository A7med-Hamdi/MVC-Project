using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ProjectLapDay2.ViewModel
{
    public class EditprojecthoursVm
    {
        public SelectList project { get; set; }
        public SelectList employee { get; set; }

        [Display(Name = "Employee")]
        public int empId { get; set; }
        [Display(Name = "Project")]

        public int proId { get; set; }
        [Display(Name = "Hours")]

        public int houre { get; set; }
    }
}

