using System.ComponentModel.DataAnnotations;

namespace MVCApp.Models
{
    public class Student
    {
        public int c_studid { get; set; }
        [Required(ErrorMessage = "student name is required")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "only alphanumeric characters are allowed")]
        public string c_studname { get; set; }

        [Required(ErrorMessage = "DOB is required")]
        [DataType(DataType.Date)]

        public DateTime? c_dob { get; set; }

        [Required(ErrorMessage = "student Stream is required")]
        public string c_stream { get; set; }
    }
    
}