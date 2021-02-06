using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a CarManager
            ICarService carManager = new CarManager(new EfCarDal());

            //List all cars in carManager
            ListAllVehicles(carManager);

            // Add a new car to carManager
            Car carToAdd = new Car() { Id=10 ,BrandId = 4, ColorId = 2, DailyPrice = 290000, ModelYear = 2019, Description = "Toyota Auris Hybrid" };
            carManager.Add(carToAdd);
            Console.WriteLine("\nCar has been added: " + carToAdd.Description + "\n");

            // Try to add invalid car data to carManager
            Car inValidCarToAdd = new Car() { Id=11, BrandId = 4, ColorId = 3, DailyPrice = 0, ModelYear = 2019, Description = "T" };
            carManager.Add(inValidCarToAdd);
           


            //List all cars in carManager
            ListAllVehicles(carManager);

            //Update Car 3
            Car carToUpdate = new Car() { Id = 3, BrandId = 2, ColorId = 1, ModelYear = 2015, DailyPrice = 450000, Description = "BMW 5 520i Executive" };
            carManager.Update(carToUpdate);
            Console.WriteLine("\nCar has been updated: " + carToUpdate.Id + " -" + carToUpdate.Description + "(" + carToUpdate.ModelYear + ")\n");

            //List all cars in carManager
            ListAllVehicles(carManager);

            ////Delete a Car 
            //Console.WriteLine("Select a car to delete (Car Id)");
            //int v = Convert.ToInt32(Console.ReadLine());
            //Car carToDelete = carManager.GetCarById(v);
            //carManager.Delete(carToDelete);
            //Console.WriteLine("\nCar has been deleted: Car" + carToDelete.Id + ":" + carToDelete.Description + "\n");

            ////List all cars in carManager
            //ListAllVehicles(carManager);

            //Get Cars by BrandId
            Console.WriteLine("\nSelect a BrandId to list the cars (1-4)");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("=========== All cars in Car Manager with BrandId {0}) ===========", b);
            Console.WriteLine("\n \t Car \t\t\t Year \t Price(TL)");
            foreach (Car car in carManager.GetCarsByBrandId(b))
            {
                Console.WriteLine("{0} - {1} \t {2} \t {3}", car.Id, car.Description, car.ModelYear, car.DailyPrice);
            }

            //Get Cars by ColorId
            Console.WriteLine("\nSelect a ColorId to list the cars (1-6)");
            int c = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("=========== All cars in Car Manager with ColorId {0}) ===========", c);
            Console.WriteLine("\n \t Car \t\t\t Year \t Price(TL)");
            foreach (Car car in carManager.GetCarsByColorId(c))
            {
                Console.WriteLine("{0} - {1} \t {2} \t {3}", car.Id, car.Description, car.ModelYear, car.DailyPrice);
            }

        }

        private static void ListAllVehicles(ICarService carService)
        {
            Console.WriteLine("\n=========== All cars in Car Manager ===========");
            Console.WriteLine("\n \t Car \t\t\t Year \t Price(TL) \t BrandId \t ColorId");

            foreach (Car car in carService.GetAllCars())
            {
                Console.WriteLine("{0} - {1} \t {2} \t {3} \t {4} \t\t {5}", car.Id, car.Description, car.ModelYear, car.DailyPrice, car.BrandId, car.ColorId);
            }
        }
    }
}
