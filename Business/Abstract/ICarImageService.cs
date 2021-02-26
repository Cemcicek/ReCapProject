using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilites.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage);
        IResult Update(CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        //IDataResult<CarImage> GetPhotosByCarId(int id);
    }
}
