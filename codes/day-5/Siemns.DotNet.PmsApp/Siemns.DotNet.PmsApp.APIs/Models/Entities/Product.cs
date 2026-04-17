using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siemns.DotNet.PmsApp.APIs.Models.Entities
{
    //[Table("products")]
    public class Product
    {
        //[Key]
        //[Column("product_id", TypeName ="Int")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        //[Column("product_name", TypeName ="varchar(50)")]        
        public string ProductName { get; set; } = string.Empty;

        //[Column("price", TypeName ="decimal(18,2)")]
        public decimal? Price { get; set; }

        //[Column("product_desc", TypeName = "varchar(max)")]
        public string? Description { get; set; }

        //[Column("category_id", TypeName ="Int")]
        public int? CategoryId { get; set; }

        //navigation property (one-to-one)
        //[ForeignKey("category_id")]       
        public Category? Category { get; set; }
    }
}
