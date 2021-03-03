using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("Manager,Admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            //var context = new ValidationContext<Car>(car);
            //CarValidator carValidator = new CarValidator();
            //var result = carValidator.Validate(context);

            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}

           // ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
               
        }

        [SecuredOperation("Manager,Admin")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [SecuredOperation("Manager,Admin")]
        public IDataResult<List<Car>> GetAllCars()
        {
            if(DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<Car>>(_carDal.GetAll(), Messages.Maintenance);
            }
           return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        [SecuredOperation("Manager,Admin")]
        public IDataResult<Car> GetCarById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == Id),Messages.CarListedById);
        }

        [SecuredOperation("Manager,Admin")]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListedWithDetails);
        }

        [SecuredOperation("Manager,Admin")]
        public IDataResult<List<Car>> GetCarsByBrandId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == Id),Messages.CarsListedByBrandId);
        }

        [SecuredOperation("Manager,Admin")]
        public IDataResult<List<Car>> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == Id),Messages.CarsListedByColorId);
        }

        [SecuredOperation("Manager,Admin")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

       
    }
}
