using System.ComponentModel.DataAnnotations;

namespace Survey.Models
{
    public class SurveyData
    {
        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string _name { get; set; }
        public string _email { get; set; }
        [Required]
        public string _dojo { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string _language { get; set; }
        
        [MinLength(8)]
        [MaxLength(30)]
        public string _comments { get; set; }

    }
}