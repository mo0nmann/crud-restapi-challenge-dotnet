using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud_restapi_challenge.Entities
{
    [Table("item")]
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }
    }
}
