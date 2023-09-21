using Fiap.Web.Donation1.Data;
using Fiap.Web.Donation1.Models;


namespace Fiap.Web.Donation1.Repository;

public class ProductRepository
{
    public ProductRepository(DataContext dataContext) { }

    public class ProdutoRepository
    {
        //DataContext
        private readonly DataContext dataContext;
        public ProdutoRepository(DataContext ctx) 
        {    
            dataContext = ctx;
        }



        //Métodos que simulam as operacoes do banco

        // Listar Todos
        public IList<ModelProduct> FindAll()
        {
            var products = dataContext.ModelProducts.ToList();

            return products == null? new List<ModelProduct>() : products;
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
}
