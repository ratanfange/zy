using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.Models
{
    [Table("Book")]
    public partial class BookModel
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string BookName { get; set; }

        public byte BookType { get; set; }

        public int? BookPrice { get; set; }

        public byte IsEable { get; set; }

        public string Test { get; set; }

        public DateTimeOffset? Created { get; set; }

        public DateTimeOffset? Updated { get; set; }
    }
}
