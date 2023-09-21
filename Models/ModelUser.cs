using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation1.Models;

[Table("User")]
public class ModelUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }
    
    [StringLength(50)]
    public string? Email { get; set; }

}

