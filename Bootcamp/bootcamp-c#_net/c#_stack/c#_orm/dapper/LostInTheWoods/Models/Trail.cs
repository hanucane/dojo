using System.ComponentModel.DataAnnotations;

namespace LostInTheWoods.Models
{
    public abstract class BaseEntity {}
    public class Trail : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Display(Name = "Trail Name")]
        public string Name { get; set; }
        [MinLength(10)]
        public string Description { get; set; }
        public int Length { get; set; }
        public int Elevation { get; set; }
        
        [Range(-180, 180)]
        public float Longitude { get; set; }

        [Range(-90, 90)]
        public float Latitude { get; set; }
    }
}