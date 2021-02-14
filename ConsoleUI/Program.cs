using Business.Concrete;
using Business.Constants;
using Core.Utilites.Results.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Repository;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            //BrandId1(carManager, brandManager, colorManager);
            //ColorId2(carManager, brandManager, colorManager);
            //Id2(carManager, brandManager, colorManager);
            //gunlukfiyat(carManager, brandManager, colorManager);
            //liste(carManager, brandManager);
            //RentalTest(rentalManager);
            //AddColor(colorManager);

            /*
            var result = carManager.GetCarDetailDtos();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarId + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice + " " + car.Descriptions + " " + car.ModelYear);
            }

            Console.ReadLine();*/
            //var allCustomer = customerManager.GetAll();
            //Console.ReadLine();

            userManager.Add(new User { FirstName="Emir", LastName="Çiçek", Email="emir@gmail.com", Password="123"});
            
            Console.ReadLine();


        }

        private static void AddColor(ColorManager colorManager)
        {
            
            colorManager.Add(new Color { ColorName = "Yeşil" });
            Console.ReadLine();
        }

        private static void RentalTest(RentalManager rentalManager)
        {
            rentalManager.Add(new Rental { CustomerId=1, RentDate=DateTime.Today, ReturnDate = new DateTime(2021, 03, 13) });
            Console.ReadLine();



            //rentalManager.(new Rental { Id = 1 });
        }

        private static void liste(CarManager carManager, BrandManager brandManager)
        {
            Console.WriteLine("\n");

            carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = -300, ModelYear = "2021", Descriptions = "Otomatik Dizel" });
            brandManager.Add(new Brand { BrandName = "a" });
        }
        /*
        private static void gunlukfiyat(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {

            Console.WriteLine("\n\nGünlük fiyat aralığı 100 ile 165 olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetByDailyPrice(100, 165))
            {
                Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");

            }
        }

        private static void Id2(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("\n\nId'si 2 olan araba: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            Car carById = carManager.GetById(2);
            Console.WriteLine($"{carById.CarId}\t{colorManager.GetById(carById.ColorId).ColorName}\t\t{brandManager.GetById(carById.BrandId).BrandName}\t\t{carById.ModelYear}\t\t{carById.DailyPrice}\t\t{carById.Descriptions}");
        }

        private static void ColorId2(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("\n\nColor Id'si 2 olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetAllByColorId(2))
            {
                Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void BrandId1(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Brand Id'si 1 olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }
        */
    }
}
