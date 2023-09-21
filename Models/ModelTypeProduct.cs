using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation1.Models;

[Table("TypeProduct")]
public class ModelTypeProduct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TypeProductID { get; set; }

    //[Column("TypeProductName")]
    [StringLength(200)]
    public string TypeProductName { get; set; }

    //[Column("TypeProductName")]
    [StringLength(256)]
    public string TypeProductDescription { get; set; }

    //[Column("TypeProductToken")]
    [NotMapped]
    public string TypeProductToken { get; set; }
}
