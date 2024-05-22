using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class Employee
    {
       
        public int EmployeeId {  get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ProfileImage {  get; set; }
        [Required]
        public string Gender {  get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public long Salary {  get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public string Notes {  get; set; }
    }
}
