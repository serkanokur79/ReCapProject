using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [CacheRemoveAspect("IBrandManager.Get")]
        [SecuredOperation("Manager,Admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            //ValidationTool.Validate(new BrandValidator(), brand);

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);

        }

        [CacheRemoveAspect("IBrandManager.Get")]
        [SecuredOperation("Manager,Admin")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);

        }

        [PerformanceAspect(5)]
        [CacheAspect]
        [SecuredOperation("Manager.getall,Manager,Admin")]
        public IDataResult<List<Brand>> GetAllBrands()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }

        [SecuredOperation("Manager,Admin")]
        public IDataResult<Brand> GetBrandById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId), Messages.BrandListedById);
        }

        [CacheRemoveAspect("IBrandManager.Get")]
        [SecuredOperation("Manager,Admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);

        }

        [TransactionScopeAspect]
        public IResult TransactionalTest(Brand brand)
        {
            _brandDal.Add(brand);
            _brandDal.Update(brand);
            return null;
        }
    }
}
