using System.ComponentModel.DataAnnotations;

namespace AgeRanger.Models
{
    public class PersonViewModel
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Age { get; set; }

        public string AgeRangeDescription { get; set; }
    }
}