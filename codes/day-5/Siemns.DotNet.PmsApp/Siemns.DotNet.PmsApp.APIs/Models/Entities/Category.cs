using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Siemns.DotNet.PmsApp.APIs.Models.Entities
{
    //[Table("categories")]
    public class Category
    {
        //[Column("category_id", TypeName = "Int")]
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        //[Column("category_name",TypeName ="varchar(50)")]
        public string CategoryName { get; set; } = string.Empty;

        //navigation property (one-to-many)
        public ICollection<Product>? Products { get; set; }
    }
}
