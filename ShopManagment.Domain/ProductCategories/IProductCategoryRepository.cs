using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Domain.ProductCategories
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory entity);
        ProductCategory GetById(long id);
        List<ProductCategory> GetAll();
        bool Exists(Expression<Func<ProductCategory,bool>> expression);
        void SaveChange();
        //EditProductCategory GetDetails(long id);
        //List<ProductCategory> Searchs(ProductCategorySearchModel searchModel);
    }
}
