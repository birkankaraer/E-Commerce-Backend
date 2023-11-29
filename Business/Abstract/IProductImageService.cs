using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IResult Add(IFormFile formFile, ProductImage productImage);
        IResult Update(IFormFile formFile, ProductImage productImage);
        IResult Delete(ProductImage productImage);

        IDataResult<List<ProductImage>> GetAll();
        IDataResult<List<ProductImage>> GetProductImagesByProductId(int productId);
        IDataResult<ProductImage> GetById(int productImageId);
    }
}
