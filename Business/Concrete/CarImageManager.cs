using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilites.Business;
using Core.Utilites.Helpers;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarImageManager :ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImagesOperationDto carImagesOperationDto)
        {
            var result = BusinessRules.Run(
                CheckCarImageCount(carImagesOperationDto.CarId));
            if (result != null)
            {
                return result;
            }

            foreach (var file in carImagesOperationDto.Images)
            {
                _carImageDal.Add(new CarImage
                {
                    CarId = carImagesOperationDto.CarId,
                    ImagePath = FileProcessHelper.Upload(DefaultNameOrPath.ImageDirectory, file).Data
                });
            }

            return new SuccessResult();
        }

        public IResult Delete(CarImage entity)
        {
            var imageData = _carImageDal.Get(p => p.Id == entity.Id);
            FileProcessHelper.Delete(imageData.ImagePath);
            _carImageDal.Delete(imageData);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
               return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId));
            //var getAllbyCarIdResult = _carImageDal.GetAll(p => p.CarId == carId);
            //if (getAllbyCarIdResult.Count == 0)
            //{
            //    return new SuccessDataResult<List<CarImage>>(new List<CarImage>
            //    {
            //        new CarImage
            //        {
            //            Id = -1,
            //            CarId = carId,
            //            Date = DateTime.MinValue,
            //            ImagePath = DefaultNameOrPath.NoImagePath
            //        }
            //    });
            //}
        }

        public IResult Update(CarImagesOperationDto carImagesOperationDto)
        {
            foreach (var file in carImagesOperationDto.Images)
            {
                var result = BusinessRules.Run(
                    CheckIfCarImagesId(carImagesOperationDto.Id),
                    CheckCarImageCount(carImagesOperationDto.CarId)
                );
                if (result != null)
                {
                    return result;
                }

                FileProcessHelper.Delete(_carImageDal.Get(p => p.Id == carImagesOperationDto.Id).ImagePath);
                _carImageDal.Update(new CarImage
                {
                    Id = carImagesOperationDto.Id,
                    CarId = carImagesOperationDto.CarId,
                    ImagePath = FileProcessHelper.Upload(DefaultNameOrPath.ImageDirectory, file).Data
                });
            }

            return new SuccessResult();
        }

        private IResult CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(p => p.CarId == carId).Count > 4)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarImagesId(int Id)
        {
            if (_carImageDal.Get(p => p.Id == Id) == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }



    }
}
