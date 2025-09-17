using System.ComponentModel.DataAnnotations;

namespace MVCApp.Models
{
    public class Student
    {
        public int c_studid { get; set; }
        

        [MinLength(2)]
        public string c_studname { get; set; }

        [Required(ErrorMessage = "DOB is required")]
        [DataType(DataType.Date)]
        public DateTime? c_dob { get; set; }

        [Required(ErrorMessage = "student Stream is required")]
        
        public string c_stream { get; set; }
    }
    
}