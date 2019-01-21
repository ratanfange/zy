using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.Models
{
    [Table("Author")]
    public partial class Author
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Column(Order = 1)]
        [StringLength(256)]
        public string Name { get; set; }
    }
}
