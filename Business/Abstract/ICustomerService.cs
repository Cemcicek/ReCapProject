using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilites.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();

        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();

        IDataResult<Customer> Get(int id);

        IResult Add(Customer entity);

        IResult Update(Customer entity);

        IResult Delete(Customer entity);
    }
}
