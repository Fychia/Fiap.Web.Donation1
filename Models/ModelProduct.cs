namespace Fiap.Web.Donation1.Models;

public class ModelProduct
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public bool ProductAvailable { get; set; }
    public int ProductType { get; set; }
    public string Sugestion { get; set; }
    public double Value { get; set; }

    public DateTime RegisterDate { get; set; }
    public DateTime ExpirationDate { get; set; }


    public ModelUser Usuario { get; set; }

}
