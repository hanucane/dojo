using System.ComponentModel.DataAnnotations;

namespace Form.Models
{
    public class Register
    {
        [Required]
        [MinLength(4)]
        public string first_name { get; set; }
        [Required]
        [MinLength(4)]
        public string last_name { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Range(1, 100, ErrorMessage = "Age must be a positive number")]
        public int age { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}