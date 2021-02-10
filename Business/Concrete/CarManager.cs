using Business.Abstract;
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

        public void Add(Car car)
        {

            if (car.Description.Length > 1 && car.DailyPrice > 0)
            {
                _carDal.Add(car); 
            } else
            {
                if (car.Description.Length < 2) { Console.WriteLine("Description must be at least 2 characters"); }
                if (car.DailyPrice < 1) { Console.WriteLine("Daily Price must be bigger than 0"); }            
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
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

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

       
    }
}
