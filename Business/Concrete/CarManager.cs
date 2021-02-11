using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Car car)
        {

            if (car.Description.Length > 1 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult( Messages.CarAdded);
            } else
            {

                if (car.Description.Length < 2) { 
                    Console.WriteLine("Description must be at least 2 characters");
                    return new ErrorResult(Messages.CarNameInvalid);
                }
                if (car.DailyPrice < 1) { Console.WriteLine("Daily Price must be bigger than 0");
                    return new ErrorResult(Messages.CarPriceInvalid);
                }
                return new Result(false);
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public List<Car> GetAllCars()
        {
           return  _carDal.GetAll();
        }

        public Car GetCarById(int Id)
        {
            return _carDal.Get(c => c.Id == Id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int Id)
        {
            return _carDal.GetAll(c => c.BrandId == Id);
        }

        public List<Car> GetCarsByColorId(int Id)
        {
            return _carDal.GetAll(c => c.ColorId == Id);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

       
    }
}
