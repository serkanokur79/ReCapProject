﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAllCars();
        List<Car> GetCarsByBrandId(int Id);
        List<Car> GetCarsByColorId(int Id);
        Car GetCarById(int Id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        
    }
}
