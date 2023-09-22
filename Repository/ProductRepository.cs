using Fiap.Web.Donation1.Data;
using Fiap.Web.Donation1.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation1.Repository;

public class ProductRepository
{
    private readonly DataContext dataContext;

    public ProductRepository(DataContext ctx)
    {
        dataContext = ctx;
    }
    public IList<ModelProduct> FindAll()
    {
        var products = dataContext.ModelProducts.ToList();

        return products == null ? new List<ModelProduct>() : products;
    }

    public IList<ModelProduct> FindAllWithType()
    {
        var products = dataContext.ModelProducts.Include(p => p.TypeProduct).Include(p => p.UserID).ToList();

        return products == null ? new List<ModelProduct>() : products;
    }

    public IList<ModelProduct> FindAllWithTypeOrderByName()
    {
        var products = dataContext.ModelProducts.Include(p => p.TypeProduct).OrderBy(p => p.ProductName).ToList();

        return products == null ? new List<ModelProduct>() : products;
    }
    public IList<ModelProduct> FindAllAvaliable(bool avaliable)
    {
        var products = dataContext.ModelProducts.Include(p => p.TypeProduct).Where(p => p.ProductAvailable == avaliable).ToList();

        return products == null ? new List<ModelProduct>() : products;
    }

    public IList<ModelProduct> FindAllAvaliableForChange(bool avaliable, int userID)
    {
        var products = dataContext.ModelProducts.Include(p => p.TypeProduct).Where(p => p.ProductAvailable == avaliable && p.UserID != userID).ToList();

        return products == null ? new List<ModelProduct>() : products;
    }

    public IList<ModelProduct> FindByName(string name)
    {
        var products = dataContext.ModelProducts.Include(p => p.TypeProduct).Where(p => p.ProductName.ToLower().Contains(name.ToLower())).ToList();

        return products == null ? new List<ModelProduct>() : products;
    }
    public IList<ModelProduct> FindAllWithTypeAndUser()
    {
        var products = dataContext.ModelProducts.Include(p => p.TypeProduct).ToList();

        return products == null ? new List<ModelProduct>() : products;
    }

    // Detalhe (Consulta por Id)
    public ModelProduct FindById(int id)
    {
        var product = dataContext.ModelProducts.FirstOrDefault(p => p.ProductID == id);

        return product;
    }

    // Inserir
    public int Insert(ModelProduct productModel)
    {
        productModel.RegisterDate = DateTime.Now;

        dataContext.ModelProducts.Add(productModel);
        dataContext.SaveChanges();
        return productModel.ProductID;
    }

    // Alterar
    public void Update(ModelProduct productModel)
    {
        dataContext.ModelProducts.Update(productModel);
        dataContext.SaveChanges();
    }

    // Excluir
    public void Delete(ModelProduct productModel)
    {
        dataContext.ModelProducts.Remove(productModel);
        dataContext.SaveChanges();
    }


    public void Delete(int id)
    {
        var produtoModel = new ModelProduct()
        {
            ProductID = id,
        };

        Delete(produtoModel);
    }


}

