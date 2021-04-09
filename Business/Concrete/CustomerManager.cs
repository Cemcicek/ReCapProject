using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
           
            _customerDal.Add(customer);
            return new SuccessResult(Message.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Message.CustomerDeleted);
        }

        public IDataResult<Customer> Get(int id)
        {
            Customer customer = _customerDal.Get(p => p.Id == id);
            if (customer == null)
            {
                return new ErrorDataResult<Customer>(Message.CustomerNameInvalid);
            }
            else
            {
                return new SuccessDataResult<Customer>(customer, Message.CutomerListed);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Message.CarListed);
        }


        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetailDto(), Message.CutomerListed);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Message.CustomerUpdated);
        }
    }
}
