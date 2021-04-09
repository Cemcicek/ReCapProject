using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilites.Business;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity)
        {
            var result = BusinessRules.Run(WillLeasedCarAvailable(entity.CarId));

            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Rental> Get(int id)
        {
            Rental rental = _rentalDal.Get(p => p.Id == id);
            if (rental == null)
            {
                return new ErrorDataResult<Rental>();
            }
            else
            {
                return new SuccessDataResult<Rental>(rental);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            List<Rental> rentals = _rentalDal.GetAll();
            if (rentals.Count == 0)
            {
                return new ErrorDataResult<List<Rental>>();
            }
            else
            {
                return new SuccessDataResult<List<Rental>>(rentals);
            }
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            List<RentalDetailDto> rentalDetailDtos = _rentalDal.GetAllRentalDetails();
            if (rentalDetailDtos.Count > 0)
                return new SuccessDataResult<List<RentalDetailDto>>(rentalDetailDtos);
            else
                return new ErrorDataResult<List<RentalDetailDto>>();
        }

        public IDataResult<List<RentalDetailDto>> GetAllUndeliveredRentalDetails()
        {
            List<RentalDetailDto> rentalDetailDtos = _rentalDal.GetAllRentalDetails(p => p.ReturnDate == null);
            if (rentalDetailDtos.Count > 0)
                return new SuccessDataResult<List<RentalDetailDto>>(rentalDetailDtos);
            else
                return new ErrorDataResult<List<RentalDetailDto>>();
        }

        public IDataResult<List<RentalDetailDto>> GetAllDeliveredRentalDetails()
        {
            List<RentalDetailDto> rentalDetailDtos = _rentalDal.GetAllRentalDetails(p => p.ReturnDate != null);
            if (rentalDetailDtos.Count > 0)
                return new SuccessDataResult<List<RentalDetailDto>>(rentalDetailDtos);
            else
                return new ErrorDataResult<List<RentalDetailDto>>();
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult();
        }

        public IResult DeliverTheCar(Rental entity)
        {
            var result = BusinessRules.Run(CanARentalCarBeReturned(entity.Id));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Update(entity);
            return new SuccessResult();
        }

        #region RentalManager Business Rules

        private IResult WillLeasedCarAvailable(int carId)
        {
            if (_rentalDal.Get(p => p.CarId == carId && p.ReturnDate == null) != null)
                return new ErrorResult();
            else
                return new SuccessResult();
        }

        private IResult CanARentalCarBeReturned(int carId)
        {
            if (_rentalDal.Get(p => p.CarId == carId && p.ReturnDate == null) == null)
                return new ErrorResult();
            else
                return new SuccessResult();
        }

        #endregion RentalManager Business Rules
    }
}
