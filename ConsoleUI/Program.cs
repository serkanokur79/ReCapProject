using Business.Abstract;
using Business.Concrete;
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
            ICarService carManager = new CarManager(new InMemoryCarDal());

            // Add a new car to carManager
            Car carToAdd = new Car() { Id = 5, BrandId = 4, ColorId = 1, DailyPrice = 250000, ModelYear = 2018, Description = "Toyota Auris Hybrid" };
            carManager.Add(carToAdd);
            Console.WriteLine("Car has been added: " + carToAdd.Description + "\n");

            //List all cars in carManager
            ListAllVehicles(carManager);

            //Update Car 3
            Car carToUpdate = new Car() { Id = 3, BrandId = 2, ColorId = 1, ModelYear = 2015, DailyPrice = 450000, Description = "BMW 5 520i Executive" };
            carManager.Update(carToUpdate);
            Console.WriteLine("\nCar has been updated: " + carToUpdate.Id + " -" + carToUpdate.Description + "(" + carToUpdate.ModelYear + ")\n");


            //Delete Car 2
            Console.WriteLine("Select a car to delete (Car Id)");
            int v = Convert.ToInt32(Console.ReadLine());
            int delNo = v;
            Car carToDelete = carManager.GetById(delNo);
            carManager.Delete(carToDelete);
            Console.WriteLine("Car has been deleted: Car" + carToDelete.Id + ":" + carToDelete.Description + "\n");


            //List all cars in carManager
            ListAllVehicles(carManager);


        }

        private static void ListAllVehicles(ICarService carService)
        {
            Console.WriteLine("=========== All cars in Car Manager ===========");
            Console.WriteLine("\n \t Car \t\t\t Year \t Price(TL)");

            foreach (Car car in carService.GetAll())
            {
                Console.WriteLine("{0} - {1} \t {2} \t {3}", car.Id, car.Description, car.ModelYear, car.DailyPrice);
            }
        }
    }
}
