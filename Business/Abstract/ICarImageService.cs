using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilites.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();

        IDataResult<CarImage> Get(int id);

        IResult Add(CarImagesOperationDto carImagesOperationDto);

        IResult Update(CarImagesOperationDto carImagesOperationDto);

        IResult Delete(CarImage entity);

        IDataResult<List<CarImage>> GetAllByCarId(int carId);
    }
}
