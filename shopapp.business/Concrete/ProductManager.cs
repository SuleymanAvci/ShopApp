using System.Collections.Generic;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.business.Concrete
{    
public class ProductManager : IProductService
    {

    private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
        public void Create(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new System.NotImplementedException();
        }
 
        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product GetProductDetails(string url)
        {
            return _productRepository.GetProductDetails(url);
        }

        public List<Product> GetProductsByCategory(string name,int page=1,int pageSize)
        {
            return _productRepository.GetProductsByCategory(name,page,pageSize);
        }

        public void Update(Product entity)
        {
            throw new System.NotImplementedException();
        }
    }
}