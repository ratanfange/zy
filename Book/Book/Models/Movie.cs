using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.Models
{
    [Table("Movie")]
    public partial class Movie
    {
        public int MovieID { get; set; }

        [StringLength(100)]
        public string BookName { get; set; }

        public byte BookType { get; set; }

        public int? BookPrice { get; set; }

        public byte IsEable { get; set; }

        public DateTimeOffset? Created { get; set; }
    }
}
