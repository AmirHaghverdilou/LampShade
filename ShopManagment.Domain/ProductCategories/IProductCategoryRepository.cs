using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Domain.ProductCategories
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory entity);
        ProductCategory GetById(long id);
        List<ProductCategory> GetAll();
    }
}
