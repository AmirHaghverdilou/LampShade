using ShopManagment.Application.Contracts.ProductCategories;
using ShopManagment.Domain.ProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace ShopManagment.Application.ProductCategories
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد. لطفا مجدد تلاش نمایید.");

            var slug = command.Slug.Slugify();
            ProductCategory category = new ProductCategory(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            //_productCategoryRepository.


            _productCategoryRepository.Create(category);
            _productCategoryRepository.SaveChange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            ProductCategory product = _productCategoryRepository.GetById(command.Id);
            if (product == null)
                return operation.Failed("رکورد با اطلاعات درخواست شده یافت نشد. لطفا مجدد تلاش نمایید");

            if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد. لطفا مجدد تلاش نمایید.");

            var slug = command.Slug.Slugify();
            product.Edit(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug);

            _productCategoryRepository.SaveChange();
            return operation.Succedded();
        }

        public EditProductCategory GetDetails(long id)
        {
            EditProductCategory product =_productCategoryRepository.GetDetails(id);
            return product;
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            List<ProductCategory> products = _productCategoryRepository.Searchs(searchModel);
            return products;
        }
    }
}
