using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgeRanger.Entities
{
    [Table("AgeGroup")]
    public class AgeGroup
    {
        [Key]
        public long Id { get; set; }
        
        public int? MinAge { get; set; }

        public int? MaxAge { get; set; }

        public string Description { get; set; }
    }
}