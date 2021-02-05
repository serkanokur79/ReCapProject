using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car(){Id=1, BrandId=1, ColorId=1, ModelYear=new DateTime(2014), DailyPrice=380000, Description= "Audi A6 Sedan 2.0 TDI" },
                new Car(){Id=2, BrandId=2, ColorId=1, ModelYear=new DateTime(2012), DailyPrice=315000, Description= "BMW 3 320d Luxury\t" },
                new Car(){Id=3, BrandId=2, ColorId=1, ModelYear=new DateTime(2015), DailyPrice=419000, Description= "BMW 5 520i Executive" },
                new Car(){Id=4, BrandId=3, ColorId=2, ModelYear=new DateTime(2013), DailyPrice=1145000, Description= "Mercedes-Benz GL 350 CDI" },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);

        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
    }
}
