using Business.Abstract;
using Business.Concrete;
using Business.Constants;
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
            DisplayMenuTest();
            // CarManagerOldTest();
            //ColorManagerTest();
            // BrandManagerTest();
            //CarManagerTest();

            static int DisplayMenu()
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("So Car Gallery");
                Console.WriteLine();
                Console.WriteLine("1. Test BrandManager");
                Console.WriteLine("2. Test ColorManager");
                Console.WriteLine("3. Test CarManager");
                Console.WriteLine("4. Test RentalManager");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Please write the id of the test to perform");
                var result = Console.ReadLine();
                return Convert.ToInt32(result);
            }
               
            static void DisplayMenuTest()
            {
                int userInput = 0;
                do
                {
                    userInput = DisplayMenu();
                    Console.WriteLine();
                    switch (userInput)
                    {
                        case 1:
                            BrandManagerTest();
                            break;
                        case 2:
                            ColorManagerTest();
                            break;
                        case 3:
                            CarManagerTest();
                            break;
                        case 4:
                            RentalManagerTest();
                            break;
                    }

                } while (userInput != 5);
            }
        }

        private static void RentalManagerTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            ListAllRentals(rentalManager);
            ListAllRentalsWithDetails(rentalManager);

            Console.WriteLine("\n * Try to rent CarId=1 to CustomerId=3");
            Console.WriteLine(rentalManager.AddRental(new Rental() { CarId = 1, CustomerId = 3, RentDate = DateTime.Now }).Message);

            Console.WriteLine("\n ** Try to rent CarId=2 to CustomerId=3");
            Console.WriteLine(rentalManager.AddRental(new Rental() { CarId = 2, CustomerId = 3, RentDate = DateTime.Now }).Message);
            rentalManager.AddRental(new Rental() { CarId = 2, CustomerId = 3, RentDate = DateTime.Now });
           
            ListAllRentalsWithDetails(rentalManager);

            Console.WriteLine("\n*** Try to rent CarId=3 to CustomerId=4");
            Console.WriteLine(rentalManager.AddRental(new Rental() { CarId = 3, CustomerId = 4, RentDate = DateTime.Now }).Message);
            ListAllRentalsWithDetails(rentalManager);
            


            static void ListAllRentals(RentalManager rentalManager)
            {
                Console.WriteLine("\n=========== All cars in Rental ===========");
                Console.WriteLine("\nID\tCarId\tCustomerId\tRentalDate\tReturnDate");

                var rentals = rentalManager.GetAllRentals();

                if (rentals.Success)
                {
                    foreach (var rental in rentalManager.GetAllRentals().Data)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", rental.Id, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
                    }
                }
                else
                {
                    Console.WriteLine(Messages.NoRentals);
                }

                
            }

            static void ListAllRentalsWithDetails(RentalManager rentalManager)
            {
                Console.WriteLine("\n=========== All cars in Rental with Details ===========");
                Console.WriteLine("\nID\tCarId\tCarName\t\t\tCustomer\tCompany\t\tRentalDate\t\tReturnDate");

                var rentals = rentalManager.GetAllRentalsWithDetails();

                if (rentals.Success)
                {
                    foreach (var rentalDetailDto in rentalManager.GetAllRentalsWithDetails().Data)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", rentalDetailDto.Id, rentalDetailDto.CarId, rentalDetailDto.CarName, rentalDetailDto.UserName, rentalDetailDto.CompanyName, rentalDetailDto.RentDate, rentalDetailDto.ReturnDate);
                    }
                }
                else
                {
                    Console.WriteLine(Messages.NoRentals);
                }


            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            ListAllCars(carManager);

            Console.WriteLine("\nThe car with id 5 is ");
            var carToShowRes = carManager.GetCarById(5);
            Car carToShow = carToShowRes.Data;
            Console.WriteLine("\nID\tCar\t\t\tYear\tPrice(TL)\tColorID\tBrandID");
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t\t{4}\t{5}", carToShow.Id, carToShow.Description, carToShow.ModelYear, carToShow.DailyPrice, carToShow.ColorId, carToShow.BrandId);
            Console.WriteLine(carToShowRes.Message);

            ListCarsWithDetails(carManager);
            carManager.Add(new Car() { BrandId = 2, ColorId = 4, Description = "BMW X5 XDrive30d", DailyPrice = 275000, ModelYear = 2017 });
            Console.WriteLine("\n** New car added to db =>");

            ListCarsWithDetails(carManager);

            carManager.Update(new Car() { Id = 11, BrandId = 2, ColorId = 4, Description = "BMW X5 XDrive30d", DailyPrice = 275000, ModelYear = 2018 });
            Console.WriteLine("\n** Car 11 is updated on db =>");

            ListCarsWithDetails(carManager);

            carManager.Delete(new Car() { Id = 11, BrandId = 2, ColorId = 4, Description = "BMW X5 XDrive30d", DailyPrice = 275000, ModelYear = 2018 });
            Console.WriteLine("\n**Car 11 is deleted from db =>");

            ListCarsWithDetails(carManager);

            static void ListAllCars(ICarService carService)
            {
                Console.WriteLine("\n=========== All cars in Car Manager ===========");
                Console.WriteLine("\n \t Car \t\t\t Year \t Price(TL) \t BrandId \t ColorId");

                foreach (Car car in carService.GetAllCars().Data)
                {
                    Console.WriteLine("{0} - {1} \t {2} \t {3} \t {4} \t\t {5}", car.Id, car.Description, car.ModelYear, car.DailyPrice, car.BrandId, car.ColorId);
                }
            }

            static void ListCarsWithDetails(CarManager carManager)
            {
                Console.WriteLine("\n=========== All cars in Car Manager with Details ===========");
                Console.WriteLine("\nID\tCar\t\t\tYear\tPrice(TL)\tColor\tBrand");

                foreach (var carDto in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t\t{4}\t{5}", carDto.Id, carDto.Description, carDto.ModelYear, carDto.DailyPrice, carDto.ColorName, carDto.BrandName);
                }
            }
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            ListBrands(brandManager);

            brandManager.Add(new Brand() { BrandName = "Suzaki" });
            Console.WriteLine("\n** Suzuki added to db =>");

            ListBrands(brandManager);

            brandManager.Update(new Brand() { BrandId = 5, BrandName = "Suzuki" });
            Console.WriteLine("\n** Suzuki is corrected at db =>");

            ListBrands(brandManager);

            brandManager.Delete(new Brand() { BrandId = 5, BrandName = "Suzuki" });
            Console.WriteLine("\n** Suzuki deleted from db =>");

            ListBrands(brandManager);

            static void ListBrands(BrandManager brandManager)
            {
                Console.WriteLine("==== Brands in BrandManager ====");
                Console.WriteLine("Id \t Brand");
                foreach (var brand in brandManager.GetAllBrands().Data)
                {
                    Console.WriteLine("{0} \t {1}", brand.BrandId, brand.BrandName);
                }
            }
        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            ListAllColors(colorManager);

            colorManager.Add(new Color() { ColorName = "Selver" });
            Console.WriteLine("\n** Selver added to db =>");

            ListAllColors(colorManager);

            colorManager.Update(new Color() { ColorId = 7, ColorName = "Silver" });
            Console.WriteLine("\n** Silver is corrected at db=>");

            ListAllColors(colorManager);

            colorManager.Delete(new Color() { ColorId = 7, ColorName = "Silver" });
            Console.WriteLine("\n** Silver is deleted from db=>");

            ListAllColors(colorManager);

            static void ListAllColors(ColorManager colorManager)
            {
                Console.WriteLine("==== Colors in ColorManager ====");
                Console.WriteLine("Id \t Color");
                var AllColorsRes = colorManager.GetAllColors();
                foreach (var color in AllColorsRes.Data)
                {
                    Console.WriteLine("{0} \t {1}", color.ColorId, color.ColorName);
                }
                Console.WriteLine(AllColorsRes.Message);
            }
        }
    }

    

}
