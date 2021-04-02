using System.Linq;
using System.Collections.Generic;
using shopapp.data.Abstract;
using shopapp.entity;
using Microsoft.EntityFrameworkCore;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public List<Product> GetPopularProducts()
        {
            using(var context =new ShopContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProductDetails(string url)
        {
           using(var context =new ShopContext())
            {
                return context.Products
                                .Where(i=>i.Url==url)
                                .Include(i=>i.ProductCategories)
                                .ThenInclude(i=>i.Category)
                                .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string name,int page,int pageSize)
        {
            using(var context =new ShopContext())
            {
                var products = context.Products.AsQueryable();

                if(!string.IsNullOrEmpty(name))
                {
                    products=products
                                .Include(i=>i.ProductCategories)
                                .ThenInclude(i=>i.Category)
                                .Where(i=>i.ProductCategories.Any(a=>a.Category.Url == name));
                }

                return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
            }
        }

        public List<Product> GetTop5Products()
        {
            throw new System.NotImplementedException();
        }

        ProductCategory IProductRepository.GetProductDetails(string url)
        {
            throw new System.NotImplementedException();
        }
    }
}