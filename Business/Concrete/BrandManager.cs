using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if(brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Message.BrandAdded);

            }
            else
            {
                return new ErrorResult(Message.BrandNameInvalid);

            }
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Message.BrandDeleted);

        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(c => c.BrandId == id));
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Message.BrandUpdated);

            }
            else
            {
                return new ErrorResult(Message.BrandNameInvalid);

            }

        }
    }
}
