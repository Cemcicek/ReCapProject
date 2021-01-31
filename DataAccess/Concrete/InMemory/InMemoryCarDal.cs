using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    
    public class InMemoryCarDal: ICarDal
    {
        List<Car> _car;
        List<Brand> _brand;
        List<Color> _color;
        public InMemoryCarDal()
        {
            _brand = new List<Brand> { 
                new Brand{BrandId=1, BrandName="BMW"},
                new Brand{BrandId=2, BrandName="Audi"},
                new Brand{BrandId=3, BrandName="Volvo"},
                new Brand{BrandId=4, BrandName="Ford"}
            };

            _color = new List<Color> { 
                new Color{ColorId=1, ColorName="Siyah"},
                new Color{ColorId=2, ColorName="Beyaz"},
                new Color{ColorId=3, ColorName="Kırmızı"}
            };

            _car = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ColorId=1, ModelYear=2018, DailyPrice=500, Description="Sport"},
                new Car{CarId=2, BrandId=2, ColorId=1, ModelYear=2016, DailyPrice=450, Description="Hatchback"},
                new Car{CarId=1, BrandId=4, ColorId=3, ModelYear=2017, DailyPrice=350, Description="Sedan"},
                new Car{CarId=1, BrandId=3, ColorId=2, ModelYear=2020, DailyPrice=700, Description="SUV"}
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }
        public List<Car> GetById(int carId)
        {
            return _car.Where(p => p.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

           
        }
    }
}
