using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilites.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult ReceivePayment(Payment payment);
    }
}
