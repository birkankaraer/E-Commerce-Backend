using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }


        //[CacheRemoveAspect("IProductImageService.Get")]
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Add(IFormFile image, ProductImage productImage)
        {
            //var ruleResult = BusinessRules.Run(CheckImageLimitExceeded(productImage.ProductId));
            //if (!ruleResult.Success)
            //{
            //    return new ErrorResult(ruleResult.Message);
            //}

            var imageResult = FileHelper.Add(image);
            productImage.Date = DateTime.Now;
            productImage.ImagePath = imageResult.Message;
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.ProductImageAdded);
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Delete(ProductImage productImage)
        {
            var productToBeDeleted = _productImageDal.Get(p => p.ProductId == productImage.ProductId);
            if (productToBeDeleted == null)
            {
                return new ErrorResult(Messages.ProductImageDoesNotFound);
            }
            FileHelper.Delete(productToBeDeleted.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult(Messages.ProductImageDeleted);
        }


        //[CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }


        [CacheAspect]
        public IDataResult<ProductImage> GetById(int productImageId)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(pI => pI.ProductId == productImageId));
        }


        [CacheAspect]
        public IDataResult<List<ProductImage>> GetProductImagesByProductId(int productId)
        {
            var data = _productImageDal.GetAll(pI => pI.ProductId == productId);
            if (data.Count == 0)
            {
                data.Add(new ProductImage
                {
                    ProductId = productId,
                    ImagePath = "/Images/default.jpg"
                });
            }
            return new SuccessDataResult<List<ProductImage>>(data);
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Update(IFormFile image, ProductImage productImage)
        {
            var productToBeUpdated = _productImageDal.Get(p => p.ProductId == productImage.ProductId);
            if (productToBeUpdated == null)
            {
                return new ErrorResult(Messages.ProductImageDoesNotFound);
            }
            var imageResult = FileHelper.Update(image, productToBeUpdated.ImagePath);
            productImage.ImagePath = imageResult.Message;
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            _productImageDal.Update(productImage);
            return new SuccessResult(Messages.ProductImageUpdated);
        }


        private IResult CheckImageLimitExceeded(int productId)
        {
            var productImagesOfTheProduct = _productImageDal.GetAll(p => p.ProductId == productId);
            if (productImagesOfTheProduct.Count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}

