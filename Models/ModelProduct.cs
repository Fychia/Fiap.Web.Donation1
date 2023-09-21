using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation1.Models;

[Table("Product")]
public class ModelProduct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductID { get; set; }

    [StringLength(50)]
    public string? ProductName { get; set; }
    
    [StringLength(150)]
    public string? ProductDescription { get; set; }
    public bool ProductAvailable { get; set; }
    
    [StringLength(220)] 
    public string? Sugestion { get; set; }
    public double Value { get; set; }

    //[DefaultValue(typeof)]
    public DateTime RegisterDate { get; set; }
    public DateTime ExpirationDate { get; set; }


    public int UserID { get; set; }

    [ForeignKey(nameof(UserID))]
    public ModelUser? User { get; set; }


    public int ProductTypeID { get; set; }

    [ForeignKey(nameof(ProductTypeID))]
    public ModelTypeProduct? TypeProduct { get; set; }
}
