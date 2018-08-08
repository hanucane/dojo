using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
    public class MyDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            DateTime d = Convert.ToDateTime(value);
            return d < DateTime.Now; //Dates less than to today are valid (true)
        }
    }
    public class Reviews
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string restaurant { get; set; }
        [Required]
        [MinLength(10, ErrorMessage="Review must be at least 10 characters")]
        public string review { get; set; }
        [Required]
        [MyDate(ErrorMessage="Date must be in the past")]
        public DateTime review_date { get; set; }
        [Required]
        public int rating { get; set; }

    }
}