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

        IDataResult<Rental> Get(int id);

        IResult Add(Rental entity);

        IResult Update(Rental entity);

        IResult Delete(Rental entity);

       
        IResult DeliverTheCar(Rental rental);

        
        IDataResult<List<RentalDetailDto>> GetAllRentalDetails();

        
        IDataResult<List<RentalDetailDto>> GetAllUndeliveredRentalDetails();

       
        IDataResult<List<RentalDetailDto>> GetAllDeliveredRentalDetails();
    }
}

