using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilites.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetailsDto(int carId);
        IResult Add(Rental rental);
        IResult CheckReturnDate(int carId);
        IResult UpdateReturnDate(int carId);
    }
}
