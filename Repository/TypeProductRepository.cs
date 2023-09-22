using Fiap.Web.Donation1.Data;
using Fiap.Web.Donation1.Models;
using System;

namespace Fiap.Web.Donation1.Repository;

public class TypeProductRepository
{
    private readonly DataContext dataContext;

    public TypeProductRepository(DataContext ctx)
    {
        dataContext = ctx;
    }
    public IList<ModelTypeProduct> FindAll()
    {
        var type = dataContext.TypeProducts.ToList();

        return type == null ? new List<ModelTypeProduct>() : type;
    }

    public ModelTypeProduct FindById(int id)
    {
        var type = dataContext.TypeProducts.FirstOrDefault(t => t.TypeProductID == id);

        return type;
    }

    public int Insert(ModelTypeProduct typeModel)
    {
        dataContext.TypeProducts.Add(typeModel);
        dataContext.SaveChanges();

        return typeModel.TypeProductID;
    }

    // Alterar
    public void Update(ModelTypeProduct typeModel)
    {
        dataContext.TypeProducts.Update(typeModel);
        dataContext.SaveChanges();
    }

    // Excluir
    public void Delete(ModelTypeProduct typeModel)
    {
        dataContext.TypeProducts.Remove(typeModel);
        dataContext.SaveChanges();
    }


    public void Delete(int id)
    {
        var typeModel = new ModelTypeProduct()
        {
            TypeProductID = id,
        };

        Delete(typeModel);
    }

}