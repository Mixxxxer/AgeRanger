using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgeRanger.Entities
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Age { get; set; }
    }
}
