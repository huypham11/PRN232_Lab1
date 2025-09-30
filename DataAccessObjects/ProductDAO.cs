using BusinessObjects;
using BusinessObjects.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects;

public class ProductDAO
{
    public static List<Product> GetProducts()
    {
        var listProducts = new List<Product>();
        try
        {
            using var context = new MyStoreDbContext();
            listProducts = context.Products.Include(p => p.Category).ToList();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return listProducts;
    }

    public static void SaveProduct(Product p)
    {
        try
        {
            using var context = new MyStoreDbContext();
            var product = new Product
            {
                ProductName = p.ProductName,
                CategoryId = p.CategoryId,
                UnitsInStock = p.UnitsInStock,
                UnitPrice = p.UnitPrice
            };
            context.Products.Add(product);
            context.SaveChanges();
        }catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public static void UpdateProduct(Product p)
    {
        try
        {
            using var context = new MyStoreDbContext();
            context.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public static void DeleteProduct(Product p)
    {
        try
        {
            using var context = new MyStoreDbContext();
            var pro = context.Products.SingleOrDefault(x => x.ProductId == p.ProductId);
            if (pro != null)
            {
                context.Products.Remove(pro);
                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public static Product GetProductById(int id)
    {
        using var context = new MyStoreDbContext();
        return context.Products.FirstOrDefault(x => x.ProductId == id);
    }
}